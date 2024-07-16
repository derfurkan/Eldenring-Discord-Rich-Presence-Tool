
using IWshRuntimeLibrary;
using System.Diagnostics;
using System.Windows.Forms;

namespace EldenRingDiscordPresence
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            gameStatusTitleLabel = new Label();
            toggleStartOnStartup = new CheckBox();
            notifyIcon = new NotifyIcon(components);
            statusLabel = new Label();
            graceIdTitle = new Label();
            graceID = new Label();
            showTimeElapsed = new CheckBox();
            presenceSettings = new Label();
            showImages = new CheckBox();
            showGraceName = new CheckBox();
            cloudLocationRegister = new CheckBox();
            title = new TextBox();
            subtitle = new TextBox();
            showAreaNameCheckbox = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            customClientID = new TextBox();
            customClientIDCheckbox = new CheckBox();
            imageKey = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            fallbackSubtitle = new TextBox();
            fallbackTitle = new TextBox();
            SuspendLayout();
            // 
            // gameStatusTitleLabel
            // 
            gameStatusTitleLabel.AutoSize = true;
            gameStatusTitleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gameStatusTitleLabel.Location = new Point(5, 7);
            gameStatusTitleLabel.Name = "gameStatusTitleLabel";
            gameStatusTitleLabel.Size = new Size(74, 30);
            gameStatusTitleLabel.TabIndex = 1;
            gameStatusTitleLabel.Text = "Status:";
            // 
            // toggleStartOnStartup
            // 
            toggleStartOnStartup.AutoSize = true;
            toggleStartOnStartup.Location = new Point(12, 414);
            toggleStartOnStartup.Name = "toggleStartOnStartup";
            toggleStartOnStartup.Size = new Size(187, 19);
            toggleStartOnStartup.TabIndex = 3;
            toggleStartOnStartup.Text = "Start minimized with Windows";
            toggleStartOnStartup.UseVisualStyleBackColor = true;
            toggleStartOnStartup.CheckedChanged += toggleStartOnStartupCheckedChange;
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "ELDEN RING Discord Presence (Click to show)";
            notifyIcon.MouseClick += notifyIconClick;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.BackColor = Color.Transparent;
            statusLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusLabel.ForeColor = Color.DarkGoldenrod;
            statusLabel.Location = new Point(70, 7);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(223, 30);
            statusLabel.TabIndex = 6;
            statusLabel.Text = "WAITING FOR GAME...";
            // 
            // graceIdTitle
            // 
            graceIdTitle.AutoSize = true;
            graceIdTitle.Location = new Point(299, 399);
            graceIdTitle.Name = "graceIdTitle";
            graceIdTitle.Size = new Size(97, 15);
            graceIdTitle.TabIndex = 7;
            graceIdTitle.Text = "Current Grace ID:";
            // 
            // graceID
            // 
            graceID.AutoSize = true;
            graceID.Location = new Point(299, 414);
            graceID.Name = "graceID";
            graceID.Size = new Size(58, 15);
            graceID.TabIndex = 8;
            graceID.Text = "Unknown";
            // 
            // showTimeElapsed
            // 
            showTimeElapsed.AutoSize = true;
            showTimeElapsed.Location = new Point(12, 74);
            showTimeElapsed.Name = "showTimeElapsed";
            showTimeElapsed.Size = new Size(127, 19);
            showTimeElapsed.TabIndex = 9;
            showTimeElapsed.Text = "Show elapsed Time";
            showTimeElapsed.UseVisualStyleBackColor = true;
            showTimeElapsed.CheckedChanged += timeElapsedChanged;
            // 
            // presenceSettings
            // 
            presenceSettings.AutoSize = true;
            presenceSettings.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            presenceSettings.Location = new Point(5, 46);
            presenceSettings.Name = "presenceSettings";
            presenceSettings.Size = new Size(186, 25);
            presenceSettings.TabIndex = 10;
            presenceSettings.Text = "- Presence Settings -";
            // 
            // showImages
            // 
            showImages.AutoSize = true;
            showImages.Location = new Point(12, 99);
            showImages.Name = "showImages";
            showImages.Size = new Size(118, 19);
            showImages.TabIndex = 11;
            showImages.Text = "Show Area Image";
            showImages.UseVisualStyleBackColor = true;
            showImages.CheckedChanged += imageCheckChanged;
            // 
            // showGraceName
            // 
            showGraceName.AutoSize = true;
            showGraceName.Location = new Point(12, 149);
            showGraceName.Name = "showGraceName";
            showGraceName.Size = new Size(98, 19);
            showGraceName.TabIndex = 12;
            showGraceName.Text = "Show Subtitle";
            showGraceName.UseVisualStyleBackColor = true;
            showGraceName.CheckedChanged += graceLocationChecked;
            // 
            // cloudLocationRegister
            // 
            cloudLocationRegister.AutoSize = true;
            cloudLocationRegister.Location = new Point(12, 174);
            cloudLocationRegister.Name = "cloudLocationRegister";
            cloudLocationRegister.Size = new Size(176, 19);
            cloudLocationRegister.TabIndex = 13;
            cloudLocationRegister.Text = "Use Cloud Location-Register";
            cloudLocationRegister.UseVisualStyleBackColor = true;
            cloudLocationRegister.CheckedChanged += cloudChecked;
            // 
            // title
            // 
            title.Location = new Point(116, 199);
            title.Name = "title";
            title.Size = new Size(190, 23);
            title.TabIndex = 14;
            title.Text = "Area -> %area_name%";
            title.TextChanged += titleChanged;
            // 
            // subtitle
            // 
            subtitle.Location = new Point(116, 228);
            subtitle.Name = "subtitle";
            subtitle.Size = new Size(190, 23);
            subtitle.TabIndex = 15;
            subtitle.Text = "Grace -> %grace_name%";
            subtitle.TextChanged += subTitleChanged;
            // 
            // showAreaNameCheckbox
            // 
            showAreaNameCheckbox.AutoSize = true;
            showAreaNameCheckbox.Location = new Point(12, 124);
            showAreaNameCheckbox.Name = "showAreaNameCheckbox";
            showAreaNameCheckbox.Size = new Size(80, 19);
            showAreaNameCheckbox.TabIndex = 16;
            showAreaNameCheckbox.Text = "Show Title";
            showAreaNameCheckbox.UseVisualStyleBackColor = true;
            showAreaNameCheckbox.CheckedChanged += areaNameChecked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 202);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 17;
            label1.Text = "Title:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 231);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 18;
            label2.Text = "Subtitle:";
            // 
            // customClientID
            // 
            customClientID.Location = new Point(152, 391);
            customClientID.Name = "customClientID";
            customClientID.Size = new Size(131, 23);
            customClientID.TabIndex = 19;
            customClientID.Text = "1243218524554530998";
            customClientID.TextChanged += customClientIDChanged;
            // 
            // customClientIDCheckbox
            // 
            customClientIDCheckbox.AutoSize = true;
            customClientIDCheckbox.Location = new Point(12, 395);
            customClientIDCheckbox.Name = "customClientIDCheckbox";
            customClientIDCheckbox.Size = new Size(141, 19);
            customClientIDCheckbox.TabIndex = 20;
            customClientIDCheckbox.Text = "Use custom Client-ID";
            customClientIDCheckbox.UseVisualStyleBackColor = true;
            customClientIDCheckbox.CheckedChanged += customClientIDChecked;
            // 
            // imageKey
            // 
            imageKey.AutoSize = true;
            imageKey.Location = new Point(299, 377);
            imageKey.Name = "imageKey";
            imageKey.Size = new Size(58, 15);
            imageKey.TabIndex = 23;
            imageKey.Text = "Unknown";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(299, 362);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 22;
            label4.Text = "Current Image Key:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 302);
            label5.Name = "label5";
            label5.Size = new Size(98, 15);
            label5.TabIndex = 27;
            label5.Text = "Fallback-Subtitle:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 273);
            label6.Name = "label6";
            label6.Size = new Size(80, 15);
            label6.TabIndex = 26;
            label6.Text = "Fallback-Title:";
            // 
            // fallbackSubtitle
            // 
            fallbackSubtitle.Location = new Point(116, 299);
            fallbackSubtitle.Name = "fallbackSubtitle";
            fallbackSubtitle.Size = new Size(190, 23);
            fallbackSubtitle.TabIndex = 25;
            fallbackSubtitle.TextChanged += fallbackSubTitleChanged;
            // 
            // fallbackTitle
            // 
            fallbackTitle.Location = new Point(116, 270);
            fallbackTitle.Name = "fallbackTitle";
            fallbackTitle.Size = new Size(190, 23);
            fallbackTitle.TabIndex = 24;
            fallbackTitle.Text = "The Lands Between";
            fallbackTitle.TextChanged += fallbackTitleChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 437);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(fallbackSubtitle);
            Controls.Add(fallbackTitle);
            Controls.Add(imageKey);
            Controls.Add(label4);
            Controls.Add(customClientIDCheckbox);
            Controls.Add(customClientID);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(showAreaNameCheckbox);
            Controls.Add(subtitle);
            Controls.Add(title);
            Controls.Add(cloudLocationRegister);
            Controls.Add(showGraceName);
            Controls.Add(showImages);
            Controls.Add(presenceSettings);
            Controls.Add(showTimeElapsed);
            Controls.Add(graceID);
            Controls.Add(graceIdTitle);
            Controls.Add(statusLabel);
            Controls.Add(toggleStartOnStartup);
            Controls.Add(gameStatusTitleLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "ELDEN RING - Discord Presence";
            Load += FromLoad;
            Resize += MainForm_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        private void fallbackSubTitleChanged(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.FallbackSubTitle = fallbackSubtitle.Text;
            Program.ConfigurationManager.updateConfigurationFile();
        }

        private void fallbackTitleChanged(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.FallbackTitle = fallbackTitle.Text;
            Program.ConfigurationManager.updateConfigurationFile();
        }

        private void subTitleChanged(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.SubTitle = subtitle.Text;
            Program.ConfigurationManager.updateConfigurationFile();
        }

        private void titleChanged(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.Title = title.Text;
            Program.ConfigurationManager.updateConfigurationFile();
        }

        private void customClientIDChanged(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.CustomClientID = customClientID.Text;
            Program.ConfigurationManager.updateConfigurationFile();
        }

        private void customClientIDChecked(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.UseCustomClientID = customClientIDCheckbox.Checked;
            Program.ConfigurationManager.updateConfigurationFile();

        

                Program.InitDiscord();


        }


        private void areaNameChecked(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.ShowAreaName = showAreaNameCheckbox.Checked;
            Program.ConfigurationManager.updateConfigurationFile();
        }

        private void cloudChecked(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.UseCloudLocationRegister = cloudLocationRegister.Checked;
            Program.ConfigurationManager.updateConfigurationFile();
        }

        private void graceLocationChecked(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.ShowGraceLocationName = showGraceName.Checked;
            Program.ConfigurationManager.updateConfigurationFile();
        }

        private void imageCheckChanged(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.ShowAreaImages = showImages.Checked;
            Program.ConfigurationManager.updateConfigurationFile();
        }

        private void timeElapsedChanged(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.ShowElapsedTime = showTimeElapsed.Checked;
            Program.ConfigurationManager.updateConfigurationFile();
        }

        private void FromLoad(object sender, EventArgs e)
        {

            showAreaNameCheckbox.Checked = Program.ConfigurationManager.CurrentConfiguration.ShowAreaName;

            customClientIDCheckbox.Checked = Program.ConfigurationManager.CurrentConfiguration.UseCustomClientID;

            title.Text = Program.ConfigurationManager.CurrentConfiguration.Title;
            subtitle.Text = Program.ConfigurationManager.CurrentConfiguration.SubTitle;
            fallbackTitle.Text = Program.ConfigurationManager.CurrentConfiguration.FallbackTitle;
            fallbackSubtitle.Text = Program.ConfigurationManager.CurrentConfiguration.FallbackSubTitle;
            customClientID.Text = Program.ConfigurationManager.CurrentConfiguration.CustomClientID;
           toggleStartOnStartup.Checked = Program.ConfigurationManager.CurrentConfiguration.StartWithWindows;
            showImages.Checked = Program.ConfigurationManager.CurrentConfiguration.ShowAreaImages;
            showTimeElapsed.Checked = Program.ConfigurationManager.CurrentConfiguration.ShowElapsedTime;
            showGraceName.Checked = Program.ConfigurationManager.CurrentConfiguration.ShowGraceLocationName;

            cloudLocationRegister.Checked = Program.ConfigurationManager.CurrentConfiguration.UseCloudLocationRegister;

        }

        private void delayChanged(object sender, EventArgs e)
        {
            Program.ConfigurationManager.updateConfigurationFile();
            Program.StopTimer();
            Program.StartTimer();

        }

        private void toggleStartOnStartupCheckedChange(object sender, EventArgs e)
        {
            Program.ConfigurationManager.CurrentConfiguration.StartWithWindows = toggleStartOnStartup.Checked;
            Program.ConfigurationManager.updateConfigurationFile();

            string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Start Menu\\Programs\\Startup\\EldenRingDiscordPresence.lnk");

            if (System.IO.File.Exists(shortcutPath) && !toggleStartOnStartup.Checked)
            {
                System.IO.File.Delete(shortcutPath);
            }
            else if(toggleStartOnStartup.Checked)
            {

                object shortCut = (object)"EldenRingDiscordPresence";
                WshShell shell = new WshShell();
                string shortcutAddress = (string)shell.SpecialFolders.Item(ref shortCut) + shortcutPath;
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                shortcut.TargetPath = Application.ExecutablePath;
                shortcut.WorkingDirectory = Application.StartupPath;
                shortcut.WindowStyle = 7;
                shortcut.Save();
            }
        }

        private void notifyIconClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;

            notifyIcon.Visible = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
         
                if (FormWindowState.Minimized == this.WindowState)
                {
                notifyIcon.Visible = true;
                this.Hide();
                }
            
        }

        #endregion
        private Label gameStatusTitleLabel;
        private CheckBox toggleStartOnStartup;
        private NotifyIcon notifyIcon;
        private Label statusLabel;
        private Label graceIdTitle;
        private Label graceID;
        private CheckBox showTimeElapsed;
        private Label presenceSettings;
        private CheckBox showImages;
        private CheckBox showGraceName;
        private CheckBox cloudLocationRegister;
        private TextBox title;
        private TextBox subtitle;
        private CheckBox showAreaNameCheckbox;
        private Label label1;
        private Label label2;
        private TextBox customClientID;
        private CheckBox customClientIDCheckbox;
        private Label imageKey;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox fallbackSubtitle;
        private TextBox fallbackTitle;
    }
}
