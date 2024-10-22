namespace AudioWallpaper.Entity {
    public class CurrencyConfigObject {
        public bool AutoStopWallpaper = true;

        private String ConfigName = "CurrencyConfig";

        public bool SaveConfig(String configFilePath) {
            try {
                //创建配置工具对象
                ConfigurationTools configurationTools = new ConfigurationTools(configFilePath);
                configurationTools.AddSetting(ConfigName, "AutoStopWallpaper", AutoStopWallpaper.ToString());
                configurationTools.SaveSettings();
                return true;
            } catch (Exception) {
                return false;
            }
        }
        public CurrencyConfigObject LoadConfig(string configFilePath) {
            try {
                ConfigurationTools configurationTools = new ConfigurationTools(configFilePath);
                AutoStopWallpaper = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "AutoStopWallpaper"));
                return this;

            } catch (Exception) {
                return this;
            }
        }
    }
}
