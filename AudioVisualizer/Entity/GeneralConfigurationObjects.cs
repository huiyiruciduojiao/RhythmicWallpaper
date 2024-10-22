namespace AudioWallpaper.Entity {
    [Serializable]
    public class GeneralConfigurationObjects {
        /// <summary>
        /// 律动默认激进倍率
        /// </summary>
        public float DefaultRadical = 2f;
        /// <summary>
        /// 默认频谱偏移量
        /// </summary>
        public float DefaultOffset = 0.4f;
        /// <summary>
        /// 默认傅里叶变化量
        /// </summary>
        public int DefaultFourierVariation = 512;
        /// <summary>
        /// 窗体函数
        /// </summary>
        public string ApplyWindowFunc = "BARTLETT";
        /// <summary>
        /// 默认颜色
        /// </summary>
        public Color DefaultColor = Color.Blue;
        /// <summary>
        /// 默认停止颜色
        /// </summary>
        public Color DefaultStopColor = Color.Red;
        /// <summary>
        /// 是否使用系统默认颜色
        /// </summary>
        public bool UseDefaultColorOrNOt = true;
        /// <summary>
        /// 默认颜色数量
        /// </summary>
        public int NumberOfColors = 256;
        /// <summary>
        /// 是否单色显示
        /// </summary>
        public bool MonochromeOrNot = false;
        /// <summary>
        /// 默认背景颜色
        /// </summary>
        public Color BackgroundColor = Color.Black;
        /// <summary>
        /// 是否使用背景图
        /// </summary>
        public bool BackImgOrNot = false;
        /// <summary>
        /// 背景图片地址
        /// </summary>
        public string? BackgroundImagePath = null;
        /// <summary>
        /// 是否画出波浪线
        /// </summary>
        public bool WavyLine = true;
        /// <summary>
        /// 是否画出边框
        /// </summary>
        public bool Frame = true;
        /// <summary>
        /// 是否画出中间圆形
        /// </summary>
        public bool Rotundity = true;
        /// <summary>
        /// 是否平滑过渡中间圆形边条
        /// </summary>
        public bool SmoothRotundity = true;
        /// <summary>
        /// 中间圆形边条间距
        /// </summary>
        public uint RotunditySpacing = 3;
        /// <summary>
        /// 是否画出底边条形
        /// </summary>
        public bool Stripe = true;
        /// <summary>
        /// 是否平滑过渡底边条形
        /// </summary>
        public bool SmoothStripe = true;
        /// <summary>
        /// 底边条形间距
        /// </summary>
        public uint StripeSpacing = 3;
        /// <summary>
        /// 显示器设备名
        /// </summary>
        public string SettingForScreenName = "";
        /// <summary>
        ///  当前显示器是否显示壁纸
        /// </summary>
        public bool IsShow = true;
        /// <summary>
        /// 是否使用统一配置
        /// </summary>
        public bool IsUsingUnifiedConfiguration = false;
        /// <summary>
        /// 当有其它程序全屏时是否停止壁纸
        /// </summary>
        public bool AutoStopWallPaper = false;
        /// <summary>
        /// 配置名
        /// </summary>
        public string DefaultConfiguration = "DefaultConfiguration";

        public bool SaveConfig(string configFilePath) {
            //创建配置工具对象
            ConfigurationTools configurationTools = new ConfigurationTools(configFilePath);

            string ConfigName = SettingForScreenName + "_" + DefaultConfiguration;

            #region 将配置文件添加到配置工具对象中
            //默认律动激进倍率
            configurationTools.AddSetting(ConfigName, "DefaultRadical", DefaultRadical.ToString());
            //默认频谱偏移量
            configurationTools.AddSetting(ConfigName, "DefaultOffset", DefaultOffset.ToString());
            //默认傅里叶变化量
            configurationTools.AddSetting(ConfigName, "DefaultFourierVariation", DefaultFourierVariation.ToString());
            //窗体函数
            configurationTools.AddSetting(ConfigName, "ApplyWindowFunc", ApplyWindowFunc);
            //默认开始颜色
            configurationTools.AddSetting(ConfigName, "DefaultColor", ColorTranslator.ToHtml(DefaultColor));
            //默认停止颜色
            configurationTools.AddSetting(ConfigName, "DefaultStopColor", ColorTranslator.ToHtml(DefaultStopColor));
            //是否使用默认颜色
            configurationTools.AddSetting(ConfigName, "UseDefaultColorOrNOt", UseDefaultColorOrNOt.ToString());
            //颜色数量
            configurationTools.AddSetting(ConfigName, "NumberOfColors", NumberOfColors.ToString());
            //是否单色显示
            configurationTools.AddSetting(ConfigName, "MonochromeOrNot", MonochromeOrNot.ToString());
            //默认背景颜色
            configurationTools.AddSetting(ConfigName, "BackgroundColor", ColorTranslator.ToHtml(BackgroundColor));
            //是否使用背景图
            configurationTools.AddSetting(ConfigName, "BackImgOrNot", BackImgOrNot.ToString());
            //背景图地址
            configurationTools.AddSetting(ConfigName, "BackgroundImagePath", BackgroundImagePath);
            //是否画出波浪线
            configurationTools.AddSetting(ConfigName, "WavyLine", WavyLine.ToString());
            //是否画出边框
            configurationTools.AddSetting(ConfigName, "Frame", Frame.ToString());
            //是否画出中间圆形
            configurationTools.AddSetting(ConfigName, "Rotundity", Rotundity.ToString());
            //是否平滑过渡中间圆形
            configurationTools.AddSetting(ConfigName, "SmoothRotundity", SmoothRotundity.ToString());
            //中间圆形条边距
            configurationTools.AddSetting(ConfigName, "RotunditySpacing", RotunditySpacing.ToString());
            //是否画出底边条形
            configurationTools.AddSetting(ConfigName, "Stripe", Stripe.ToString());
            //是否平滑过渡底边条形
            configurationTools.AddSetting(ConfigName, "SmoothStripe", SmoothStripe.ToString());
            //底边条形间距
            configurationTools.AddSetting(ConfigName, "StripeSpacing", StripeSpacing.ToString());
            //当前显示器名
            configurationTools.AddSetting(ConfigName, "SettingForScreenName", SettingForScreenName);
            //是否启用
            configurationTools.AddSetting(ConfigName, "IsShow", IsShow.ToString());
            //是否使用统一配置
            configurationTools.AddSetting(ConfigName, "IsUsingUnifiedConfiguration", IsUsingUnifiedConfiguration.ToString());
            //当有其它程序全屏时是否停止壁纸
            configurationTools.AddSetting(ConfigName, "AutoStopWallPaper", AutoStopWallPaper.ToString());
            #endregion
            //保存配置
            configurationTools.SaveSettings();

            return true;
        }
        public GeneralConfigurationObjects LoadConfiguration(string configFilePath, string name) {
            //创建配置工具对象
            ConfigurationTools configurationTools = new ConfigurationTools(configFilePath);
            string ConfigName = name + "_" + DefaultConfiguration;
            #region 为配置对象添加配置
            try {
                //默认律动激进倍率
                DefaultRadical = float.Parse(configurationTools.GetSetting(ConfigName, "DefaultRadical"));
                //默认频谱偏移量
                DefaultOffset = float.Parse(configurationTools.GetSetting(ConfigName, "DefaultOffset"));
                //默认傅里叶变化量
                DefaultFourierVariation = int.Parse(configurationTools.GetSetting(ConfigName, "DefaultFourierVariation"));
                //窗体函数
                ApplyWindowFunc = configurationTools.GetSetting(ConfigName, "ApplyWindowFunc");
                //默认颜色
                DefaultColor = ColorTranslator.FromHtml(configurationTools.GetSetting(ConfigName, "DefaultColor"));
                //默认停止颜色
                DefaultStopColor = ColorTranslator.FromHtml(configurationTools.GetSetting(ConfigName, "DefaultStopColor"));
                //是否使用默认颜色
                UseDefaultColorOrNOt = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "UseDefaultColorOrNOt"));
                //颜色数量
                NumberOfColors = int.Parse(configurationTools.GetSetting(ConfigName, "NumberOfColors"));
                //是否单色显示
                MonochromeOrNot = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "MonochromeOrNot"));
                //默认背景颜色
                BackgroundColor = ColorTranslator.FromHtml(configurationTools.GetSetting(ConfigName, "BackgroundColor"));
                //是否使用背景图
                BackImgOrNot = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "BackImgOrNot"));
                //背景图地址
                BackgroundImagePath = configurationTools.GetSetting(ConfigName, "BackgroundImagePath");
                //是否画出波浪线
                WavyLine = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "WavyLine"));
                //是否画出边框
                Frame = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "Frame"));
                //是否画出中间圆形
                Rotundity = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "Rotundity"));
                //是否平滑过渡中间圆形边条
                SmoothRotundity = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "SmoothRotundity"));
                //中间圆形边条间距
                RotunditySpacing = uint.Parse(configurationTools.GetSetting(ConfigName,"RotunditySpacing"));
                //是否画出底边条形
                Stripe = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "Stripe"));
                //是否平滑过渡底边条形
                SmoothStripe = Convert.ToBoolean(configurationTools.GetSetting(ConfigName,"SmoothStripe"));
                //底边条形间距
                StripeSpacing = uint.Parse(configurationTools.GetSetting(ConfigName, "StripeSpacing"));
                //显示器名
                SettingForScreenName = configurationTools.GetSetting(ConfigName, "SettingForScreenName");
                //是否显示
                IsShow = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "IsShow"));
                //是否使用统一配置
                IsUsingUnifiedConfiguration = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "IsUsingUnifiedConfiguration"));
                //当有其它程序全屏时是否停止壁纸
                AutoStopWallPaper = Convert.ToBoolean(configurationTools.GetSetting(ConfigName, "AutoStopWallPaper"));
                #endregion
            } catch (Exception) {
                return this;
            }
            return this;
        }
    }
}
