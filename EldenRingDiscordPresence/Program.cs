using DiscordRPC;
using Newtonsoft.Json;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace EldenRingDiscordPresence
{
    internal static class Program
    {
        public static readonly MemoryUtility MemoryUtility = new();
        public static Dictionary<long, string>? LocationRegister;
        public static ConfigurationManager ConfigurationManager = new ConfigurationManager();
        public static MainForm MainForm;
        private static System.Timers.Timer MainTimer;
        private static DiscordRpcClient? RpcClient;
        private static Timestamps? startGameTimestamp;
        public static string CurrentGameExecutable;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            LoadLocationRegister();
            InitDiscord();
            StartTimer();

            Application.Run(MainForm = new MainForm());
        }

    
        private static void LoadLocationRegister()
        {
            try
            {
                if (ConfigurationManager.CurrentConfiguration.UseCloudLocationRegister)
                {
                    string webData = new System.Net.WebClient().DownloadString("https://raw.githubusercontent.com/derfurkan/Eldenring-Discord-Rich-Presence-Tool/master/LocationRegister.json");
                    LocationRegister = JsonConvert.DeserializeObject<Dictionary<long, string>>(webData);
                }
                else
                {
                    if (!File.Exists("LocationRegister.json"))
                    {
                        MessageBox.Show("Could not find LocationRegister.json\nPlease make sure to put the LocationRegister.json file in the same directory as this executable.\n\nOr toggle 'Use Cloud Location-Register' and Re-Launch.", "Failed to load LocationRegister", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        LocationRegister = JsonConvert.DeserializeObject<Dictionary<long, string>>(File.ReadAllText("LocationRegister.json"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load LocationRegister: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void InitDiscord()
        {
            RpcClient?.ClearPresence();
            RpcClient?.SetPresence(null);
            RpcClient?.Dispose();
            RpcClient = null;

            string clientId = ConfigurationManager.CurrentConfiguration.UseCustomClientID ? ConfigurationManager.CurrentConfiguration.CustomClientID : "1243218524554530998";
            RpcClient = new DiscordRpcClient(clientId);
            RpcClient.Initialize();
        }

    
        public static void StartTimer()
        {
            if (ConfigurationManager == null)
                return;

            MainTimer = new System.Timers.Timer
            {
                Interval = 10 * 1000, // 10 seconds
                AutoReset = true,
                Enabled = true
            };
            MainTimer.Elapsed += OnTimerElapsed;
            MainTimer.Start();
        }
        private static void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            if (!IsGameLoaded())
            {
                MainForm.SetStatus("WAITING FOR GAME...", Color.DarkOrange);
                RpcClient?.ClearPresence();
                MemoryUtility.CloseMemoryProcess();
                startGameTimestamp = null;
                return;
            }

            if (IsEacRunning())
            {
                MainForm.SetStatus("EAC RUNNING. DISABLE FIRST.", Color.DarkRed);
                MemoryUtility.CloseMemoryProcess();
                return;
            }

            if (startGameTimestamp == null)
                startGameTimestamp = Timestamps.Now;

            UpdateDiscordPresence();
        }

        private static void UpdateDiscordPresence()
        {
            MemoryUtility.OpenMemoryProcess();

            string title = ConfigurationManager.CurrentConfiguration.FallbackTitle;
            string subtitle = ConfigurationManager.CurrentConfiguration.FallbackSubTitle;
            string currentLocation = "";
            string imageKey = "none";

            long locationId = MemoryUtility.ReadLastGraceLocationId();
            MainForm.SetGraceID(locationId);

            if (LocationRegister != null && LocationRegister.TryGetValue(locationId, out currentLocation))
            {
                string[] locationParts = currentLocation.Split(" - ");
                string areaName = locationParts[0];
                string graceName = locationParts.Length > 1 ? locationParts[1] : "";

                title = ConfigurationManager.CurrentConfiguration.Title
                    .Replace("%area_name%", areaName)
                    .Replace("%grace_name%", graceName);

                subtitle = ConfigurationManager.CurrentConfiguration.SubTitle
                    .Replace("%area_name%", areaName)
                    .Replace("%grace_name%", graceName);

                imageKey = areaName.Replace(" ", "").ToLower();
            }

            string playerName = MemoryUtility.ReadProfileName();
            string playerLevel = MemoryUtility.ReadProfileLevel().ToString();
            string playtimeHrs = MemoryUtility.ReadPlayTimeHrs().ToString();
            string playtimeMin = MemoryUtility.ReadPlayTimeMin().ToString();
            string playerDeaths = MemoryUtility.ReadDeathCount().ToString();

            title = title.Replace("%player_name%", playerName)
                         .Replace("%player_level%", playerLevel)
                         .Replace("%playtime_hrs%", playtimeHrs)
                         .Replace("%playtime_min%", playtimeMin)
                         .Replace("%player_deaths%", playerDeaths);

            subtitle = subtitle.Replace("%player_name%", playerName)
                               .Replace("%player_level%", playerLevel)
                               .Replace("%playtime_hrs%", playtimeHrs)
                               .Replace("%playtime_min%", playtimeMin)
                               .Replace("%player_deaths%", playerDeaths);

            var richPresence = new RichPresence
            {
                Details = ConfigurationManager.CurrentConfiguration.ShowAreaName ? title : null,
                State = ConfigurationManager.CurrentConfiguration.ShowGraceLocationName ? subtitle : null,
                Assets = new Assets
                {
                    LargeImageKey = ConfigurationManager.CurrentConfiguration.ShowAreaImages ? imageKey : "none",
                    LargeImageText = title.Contains(" - ") ? title.Split(" - ")[0] : title
                }
            };

            if (ConfigurationManager.CurrentConfiguration.ShowElapsedTime)
            {
                richPresence.Timestamps = startGameTimestamp;
            }

            RpcClient?.SetPresence(richPresence);
            MainForm.SetStatus("RUNNING", Color.DarkGreen);
            MainForm.SetImageKey(imageKey);
            MemoryUtility.CloseMemoryProcess();
        }

        public static void StopTimer()
        {
            MainTimer.Stop();
            MainTimer.Close();
        }

        private static bool IsGameLoaded()
        {
            string[] procNames = { "start_protected_game", "eldenring" };

            foreach (var procName in procNames)
            {
                var procList = Process.GetProcessesByName(procName);

                if (procList.Any() && !procList[0].HasExited)
                {
                    int timeout = 0;
                    while (!procList[0].Responding)
                    {
                        if (timeout > 10000)
                            break;
                        procList[0].Refresh();
                        Task.Delay(500).Wait();
                        timeout += 500;
                    }

                    if (procList[0].Responding)
                    {
                        CurrentGameExecutable = procName;
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool IsEacRunning()
        {
            var eacServices = ServiceController.GetServices().Where(service => service.ServiceName.Contains("EasyAntiCheat")).ToArray();
            return eacServices.Any(eacService =>
            {
                using var sc = new ServiceController(eacService.ServiceName);
                return sc.Status == ServiceControllerStatus.Running ||
                       sc.Status == ServiceControllerStatus.ContinuePending ||
                       sc.Status == ServiceControllerStatus.StartPending;
            });
        }
    }
}
