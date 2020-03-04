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


        public String ActualWebComicUrl { get; set; }

        public String WebComicUrlTpl { get; set; }

    }

}