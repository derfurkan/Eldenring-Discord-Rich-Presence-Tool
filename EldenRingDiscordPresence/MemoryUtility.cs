using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EldenRingDiscordPresence
{
    internal class MemoryUtility
    {
        private const int PROCESS_VM_READ = 0x0010;
        private const int PROCESS_QUERY_INFORMATION = 0x0400;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        private const string MainPattern = "48 8B 05 ?? ?? ?? ?? 80 B8 ?? ?? ?? ?? 0D 0F 94 C0 C3";
        private const string DataPattern = "48 8B 05 ?? ?? ?? ?? 48 85 C0 74 05 48 8B 40 58 C3 C3";

        private static readonly byte[] MainPatternBytes = ParsePattern(MainPattern);
        private static readonly string MainMask = CreateMask(MainPattern);

        private static readonly byte[] DataPatternBytes = ParsePattern(DataPattern);
        private static readonly string DataMask = CreateMask(DataPattern);

        private const int PatternOffset = 3;
        private const int AddressAdjustment = 7;

        private const long GraceOffset = 0xB6C;
        private const long ProfileAdjOffset = 0x08;
        private const long ProfileNameOffset = 0x9C;
        private const long ProfileLevelOffset = 0x68;
        private const long DeathCountOffset = 0x94;
        private const long PlayTimeOffset = 0xA0;

        private IntPtr _processHandle = IntPtr.Zero;
        private Process _process;
        private ProcessModule _processModule;
        private long _mainAddress = 0;
        private long _dataAddress = 0;

        public void OpenMemoryProcess()
        {
            _process = Process.GetProcessesByName(Program.CurrentGameExecutable).FirstOrDefault()
                       ?? throw new Exception("Process not found.");
            _processModule = _process.MainModule ?? throw new Exception("Could not find MainModule.");

            _processHandle = OpenProcess(PROCESS_VM_READ | PROCESS_QUERY_INFORMATION, false, _process.Id);
            if (_processHandle == IntPtr.Zero)
                throw new Exception("Could not open process.");

            _mainAddress = CalculateAddress(MainPatternBytes, MainMask);
            _dataAddress = CalculateAddress(DataPatternBytes, DataMask);
        }

        public long ReadDeathCount() => _dataAddress == 0 ? 0 : ReadInt32(ReadInt64(_dataAddress) + DeathCountOffset);

        public long ReadPlayTimeMin() => ReadPlayTimeHrs() * 60;

        public long ReadPlayTimeHrs() => _dataAddress == 0 ? 0 : ReadInt64(ReadInt64(_dataAddress) + PlayTimeOffset) / (1000 * 3600);

        public long ReadProfileLevel()
        {
            if (_dataAddress == 0) return 0;
            long dataAddressValue = ReadInt64(_dataAddress);
            long adjAddressValue = ReadInt64(dataAddressValue + ProfileAdjOffset);
            return ReadInt32(adjAddressValue + ProfileLevelOffset);
        }

        public string ReadProfileName()
        {
            if (_dataAddress == 0) return "";

            long dataAddressValue = ReadInt64(_dataAddress);
            long adjAddressValue = ReadInt64(dataAddressValue + ProfileAdjOffset);
            return ReadString(adjAddressValue + ProfileNameOffset);

        }

        public long ReadLastGraceLocationId() => _mainAddress == 0 ? 0 : ReadInt32(ReadInt64(_mainAddress) + GraceOffset);

        public void CloseMemoryProcess()
        {
            if (_processHandle != IntPtr.Zero)
            {
                CloseHandle(_processHandle);
                _processHandle = IntPtr.Zero;
            }
            _mainAddress = 0;
            _dataAddress = 0;
        }

        private string ReadString(long address)
        {
            byte[] buffer = ReadBytes(address, 32);
            return Encoding.UTF8.GetString(buffer).TrimEnd('\0');
        }

        private int ReadInt32(long address) => ReadMemory<int>(address, 4, BitConverter.ToInt32);

        private long ReadInt64(long address) => ReadMemory<long>(address, 8, BitConverter.ToInt64);

        private byte[] ReadBytes(long address, int size)
        {
            byte[] buffer = new byte[size];
            if (!ReadProcessMemory(_processHandle, (IntPtr)address, buffer, size, out int bytesRead) || bytesRead != size)
            {
                return new byte[0];
            }
            return buffer;
        }

        private T ReadMemory<T>(long address, int size, Func<byte[], int, T> converter)
        {
            byte[] buffer = new byte[size];
            if (!ReadProcessMemory(_processHandle, (IntPtr)address, buffer, size, out int bytesRead) || bytesRead != size)
            {
                return default(T);
            }
            return converter(buffer, 0);
        }

        private long CalculateAddress(byte[] patternBytes, string mask)
        {
            IntPtr moduleBase = _processModule.BaseAddress;
            byte[] moduleMemory = ReadBytes(moduleBase.ToInt64(), _processModule.ModuleMemorySize);
            IntPtr patternAddress = FindPattern(moduleMemory, patternBytes, mask);

            if (patternAddress == IntPtr.Zero)
                throw new Exception("Pattern not found");

            int offset = BitConverter.ToInt32(moduleMemory, patternAddress.ToInt32() + PatternOffset);
            return (moduleBase + patternAddress.ToInt32() + offset + AddressAdjustment).ToInt64();
        }

        private static IntPtr FindPattern(byte[] moduleMemory, byte[] pattern, string mask)
        {
            for (int i = 0; i <= moduleMemory.Length - pattern.Length; i++)
            {
                bool found = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (mask[j] != '?' && moduleMemory[i + j] != pattern[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return new IntPtr(i);
                }
            }
            return IntPtr.Zero;
        }

        private static byte[] ParsePattern(string pattern)
        {
            return pattern.Split(' ')
                          .Select(x => x == "??" ? (byte)0x00 : Convert.ToByte(x, 16))
                          .ToArray();
        }

        private static string CreateMask(string pattern)
        {
            return new string(pattern.Split(' ')
                                     .Select(x => x == "??" ? '?' : 'x')
                                     .ToArray());
        }
    }
}
