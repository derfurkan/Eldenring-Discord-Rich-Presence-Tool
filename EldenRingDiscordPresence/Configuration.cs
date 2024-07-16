using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRingDiscordPresence
{
    public record Configuration
    {

        public bool StartWithWindows {  get; set; }

        public bool ShowGraceLocationName { get; set; }

        public bool ShowElapsedTime { get; set; }

        public bool UseCloudLocationRegister { get; set; }

        public bool ShowAreaImages { get; set; }

        public bool ShowAreaName { get; set; }

        public bool UseCustomClientID { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string FallbackTitle { get; set; }

        public string FallbackSubTitle { get; set; }

        public string CustomClientID { get; set; }


        public Configuration(bool startWithWindows, bool showElapsedTime, bool showAreaImages, bool showGraceLocationName, bool useCloudLocationRegister
            , bool showAreaName, bool useCustomClientID, string title, string subtitle, string fallbackTitle, string fallbackSubTitle, string customClientID)
       
        {
            this.StartWithWindows = startWithWindows;
            this.ShowElapsedTime = showElapsedTime;
            this.ShowAreaImages = showAreaImages;
            this.ShowGraceLocationName = showGraceLocationName;
            this.UseCloudLocationRegister = useCloudLocationRegister;
            this.ShowAreaName = showAreaName;
            this.FallbackTitle = fallbackTitle;
            this.FallbackSubTitle = fallbackSubTitle;
            this.CustomClientID = customClientID;
            this.Title = title;
            this.SubTitle = subtitle;
            this.UseCustomClientID = useCustomClientID;
        }

    }
}
