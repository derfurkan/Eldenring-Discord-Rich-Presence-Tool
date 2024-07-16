using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace EldenRingDiscordPresence
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        public void SetStatus(string statusText, Color color)
        {
            Invoke(() =>
            {
                statusLabel.Text = statusText;
                statusLabel.ForeColor = color;
            });
        }

        public void SetGraceID(long id)
        {
            Invoke(() =>
            {
                if (id == 0)
                {
                    graceID.Text = "Unknown";
                    return;
                }
                graceID.Text = id.ToString();
            });
        }

        public void SetImageKey(string key)
        {
            Invoke((Delegate)(() =>
            {
                if (key.Equals(""))
                {
                    imageKey.Text = "Unknown";
                    return;
                }
                imageKey.Text = key;
            }));
        }
    }
}
