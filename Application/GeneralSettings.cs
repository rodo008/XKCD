using System;

namespace Application
{

    /// <summary>
    /// GeneralSettings Class store info from appsettings.json file and persist its data around App. Notice this class is singleton
    /// </summary>
    public class GeneralSettings 
    {

        private static GeneralSettings _instance = new GeneralSettings();

        public static GeneralSettings Instance
        {
            get => _instance;
        }

        private GeneralSettings() { }

        /// <summary>
        /// Today Comic resource Url 
        /// </summary>

        public String TodayComicUrl { get; set; }

        /// <summary>
        /// Web Comic Template resource Url for specific Comic Resource
        /// </summary>
        public String ComicUrlTpl { get; set; }

    }

}