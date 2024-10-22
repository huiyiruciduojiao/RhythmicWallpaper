namespace AudioWallpaper.Entity {
    [Serializable]
    public class VideoWallpaperConfigObject {
        /// <summary>
        /// 视频资源播放地址
        /// </summary>
        public string? Url = null;
        /// <summary>
        /// 视频播放音量
        /// </summary>
        public int Volume = 100;
        /// <summary>
        /// 视频播放速度
        /// </summary>
        public int Rate = 10;
        /// <summary>
        /// 是否显示第三方壁纸
        /// </summary>
        public bool IsShow = false;
        /// <summary>
        /// 当有其它程序全屏时是否停止壁纸
        /// </summary>
        public bool AutoStopWallPaper = false;

        /// <summary>
        /// 多显示器配置保存
        /// </summary>
        public string SettingForScreenName = "";
        
        /// <summary>
        /// 该配置名
        /// </summary>
        public string SettingName = "VideoWallpaperConfig";



        public void SaveConfig(string configFilePath) {
            ConfigurationTools configurationTools = new ConfigurationTools(configFilePath);
            string ConfigName = SettingForScreenName + "_" + SettingName;
            //视频播放地址
            configurationTools.AddSetting(ConfigName, "VideoUrl", Url);
            //视频播放音量
            configurationTools.AddSetting(ConfigName, "VideoVolume", Volume.ToString());
            //视频播放速度
            configurationTools.AddSetting(ConfigName, "VideoRate", Rate.ToString());
            
            //是否显示第三方壁纸
            configurationTools.AddSetting(ConfigName, "IsShow", IsShow.ToString());
            //当有其它程序全屏时是否停止壁纸
            configurationTools.AddSetting(ConfigName, "AutoStopWallPaper", AutoStopWallPaper.ToString());

            configurationTools.SaveSettings();

        }
        public VideoWallpaperConfigObject LoadConfig(string configFilePath, string name) {
            ConfigurationTools configurationTools = new ConfigurationTools(configFilePath);
            string ConfigName = name + "_" + SettingName;
            try {
                //视频播放地址
                Url = configurationTools.GetSetting(ConfigName, "VideoUrl");
                //视频播放音量
                Volume = int.Parse(configurationTools.GetSetting(ConfigName, "VideoVolume"));
                //视频播放速度
                Rate = int.Parse(configurationTools.GetSetting(ConfigName, "VideoRate"));
                
                //是否显示第三方壁纸
                IsShow = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "IsShow"));
                //当有其它程序全屏时是否停止壁纸
                AutoStopWallPaper = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "AutoStopWallPaper"));

                return this;
            } catch (Exception) {
                return this;
            }
        }

    }
}
