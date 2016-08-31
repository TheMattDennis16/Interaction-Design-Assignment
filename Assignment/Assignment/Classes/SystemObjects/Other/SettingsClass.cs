namespace Assignment.Classes
{
    class SettingsClass
    {
        public static string[] resolutions = { "1280x720", "800x600" };
        public static string getSetting(string setting)
        {
            string returnSetting = "";
            if (setting == "volume")
                returnSetting = Properties.Settings.Default.volume.ToString();
            else if (setting == "resolution")
                returnSetting = Properties.Settings.Default.resolution.ToString();
            return returnSetting;
        }

        public static void setSetting(string setting, string value)
        {
            if (setting == "volume")
            {
                Assignment.Properties.Settings.Default.volume = int.Parse(value);
                Classes.SystemObjects.Other.Audio.updateVolume();
            }
            else if(setting == "resolution")
                Assignment.Properties.Settings.Default.resolution = value;
            Assignment.Properties.Settings.Default.Save();
        }

        public static void upgradeSettings()
        {
            Assignment.Properties.Settings.Default.Upgrade();
            Assignment.Properties.Settings.Default.Save();
        }
    }
}
