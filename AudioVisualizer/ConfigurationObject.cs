﻿using AudioWallpaper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisualizer {
    public class ConfigurationObject {
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
        public String? BackgroundImagePath = null;

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
        /// 是否画出底边条形
        /// </summary>
        public bool Stripe = true;


        public String DefaultConfiguration = "DefaultConfiguration";

        public bool SaveConfiguration(String configFilePath) {
            //创建配置工具对象
            ConfigurationTools configurationTools = new ConfigurationTools(configFilePath);

            #region 将配置文件添加到配置工具对象中
            //默认律动激进倍率
            configurationTools.AddSetting(DefaultConfiguration, "DefaultRadical", DefaultRadical.ToString());
            //默认频谱偏移量
            configurationTools.AddSetting(DefaultConfiguration, "DefaultOffset", DefaultOffset.ToString());
            //默认傅里叶变化量
            configurationTools.AddSetting(DefaultConfiguration, "DefaultFourierVariation", DefaultFourierVariation.ToString());
            //默认开始颜色
            configurationTools.AddSetting(DefaultConfiguration, "DefaultColor", ColorTranslator.ToHtml(DefaultColor));
            //默认停止颜色
            configurationTools.AddSetting(DefaultConfiguration, "DefaultStopColor", ColorTranslator.ToHtml(DefaultStopColor));
            //是否使用默认颜色
            configurationTools.AddSetting(DefaultConfiguration, "UseDefaultColorOrNOt", UseDefaultColorOrNOt.ToString());
            //颜色数量
            configurationTools.AddSetting(DefaultConfiguration, "NumberOfColors", NumberOfColors.ToString());
            //是否单色显示
            configurationTools.AddSetting(DefaultConfiguration, "MonochromeOrNot", MonochromeOrNot.ToString());
            //默认背景颜色
            configurationTools.AddSetting(DefaultConfiguration, "BackgroundColor", ColorTranslator.ToHtml(BackgroundColor));
            //是否使用背景图
            configurationTools.AddSetting(DefaultConfiguration, "BackImgOrNot", BackImgOrNot.ToString());
            //背景图地址
            configurationTools.AddSetting(DefaultConfiguration, "BackgroundImagePath", BackgroundImagePath);
            //是否画出波浪线
            configurationTools.AddSetting(DefaultConfiguration, "WavyLine", WavyLine.ToString());
            //是否画出边框
            configurationTools.AddSetting(DefaultConfiguration, "Frame", Frame.ToString());
            //是否画出中间圆形
            configurationTools.AddSetting(DefaultConfiguration, "Rotundity", Rotundity.ToString());
            //是否画出底边条形
            configurationTools.AddSetting(DefaultConfiguration, "Stripe", Stripe.ToString());
            #endregion
            //保存配置
            configurationTools.SaveSettings();

            return true;
        }
        public ConfigurationObject LoadConfiguration(String configFilePath) {
            //创建配置工具对象
            ConfigurationTools configurationTools = new ConfigurationTools(configFilePath);
            #region 为配置对象添加配置
            try {
                //默认律动激进倍率
                DefaultRadical = float.Parse(configurationTools.GetSetting(DefaultConfiguration, "DefaultRadical"));
                //默认频谱偏移量
                DefaultOffset = float.Parse(configurationTools.GetSetting(DefaultConfiguration, "DefaultOffset"));
                //默认傅里叶变化量
                DefaultFourierVariation = int.Parse(configurationTools.GetSetting(DefaultConfiguration, "DefaultFourierVariation"));
                //默认颜色
                DefaultColor = ColorTranslator.FromHtml(configurationTools.GetSetting(DefaultConfiguration, "DefaultColor"));
                //默认停止颜色
                DefaultStopColor = ColorTranslator.FromHtml(configurationTools.GetSetting(DefaultConfiguration, "DefaultStopColor"));
                //是否使用默认颜色
                UseDefaultColorOrNOt = Convert.ToBoolean(configurationTools.GetSetting(DefaultConfiguration, "UseDefaultColorOrNOt"));
                //颜色数量
                NumberOfColors = int.Parse(configurationTools.GetSetting(DefaultConfiguration, "NumberOfColors"));
                //是否单色显示
                MonochromeOrNot = Convert.ToBoolean(configurationTools.GetSetting(DefaultConfiguration, "MonochromeOrNot"));
                //默认背景颜色
                BackgroundColor = ColorTranslator.FromHtml(configurationTools.GetSetting(DefaultConfiguration, "BackgroundColor"));
                //是否使用背景图
                BackImgOrNot = Convert.ToBoolean(configurationTools.GetSetting(DefaultConfiguration, "BackImgOrNot"));
                //背景图地址
                BackgroundImagePath = configurationTools.GetSetting(DefaultConfiguration, "BackgroundImagePath");
                //是否画出波浪线
                WavyLine = Convert.ToBoolean(configurationTools.GetSetting(DefaultConfiguration, "WavyLine"));
                //是否画出边框
                Frame = Convert.ToBoolean(configurationTools.GetSetting(DefaultConfiguration, "Frame"));
                //是否画出中间圆形
                Rotundity = Convert.ToBoolean(configurationTools.GetSetting(DefaultConfiguration, "Rotundity"));
                //是否画出底边条形
                Stripe = Convert.ToBoolean(configurationTools.GetSetting(DefaultConfiguration, "Stripe"));
                #endregion
            } catch (Exception) {

            }
            return this;
        }
    }
}
