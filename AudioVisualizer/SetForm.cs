using AudioWallpaper.Entity;
using LibVLCSharp.Shared;
using System.Runtime.CompilerServices;

namespace AudioWallpaper {
    public partial class SetFrom : Form {
        public static String ConfigFilePath = Application.StartupPath + "\\config.ini";
        public String? BackImagePath = null;
        public String? OtherVideoPath = null;
        private static SetFrom? setFrom = null;
        private Screen NowWindowOnScrenn;
        private System.Timers.Timer debounceTimer;
        private const double DEBOUNCE_TIME = 150;
        public static int FullScreenWindowCount = 0;
        private LibVLC? libVLC = new LibVLC();
        private MediaPlayer? mediaPlayer;
        private Media? media;
        private String[] windowFunc = new String[] { "RECTANGULAR", "HANNING", "HAMMING", "BLACKMAN", "BARTLETT" };

        private SetFrom() {
            debounceTimer = new System.Timers.Timer(DEBOUNCE_TIME);
            debounceTimer.Elapsed += DebounceTimer_Tick;
            debounceTimer.AutoReset = false;

        }
        public delegate void ReLoadConfig(ConfigurationObject configurationObject);
        public event ReLoadConfig ReloadConfig;



        public static SetFrom ShowSetFrom() {
            if (setFrom == null) {
                setFrom = new SetFrom();
                setFrom.InitializeComponent();
                setFrom.selectWindowFunc.Items.Clear();
                foreach (string item in setFrom.windowFunc) {
                    setFrom.selectWindowFunc.Items.Add(item);
                }
            }
            return setFrom;
        }
        private void buttonSave_Click(object sender, EventArgs e) {
            SavaConfig();
        }
        private void SavaConfig() {
            //创建配置对象
            GeneralConfigurationObjects generalConfigurationObjects = new GeneralConfigurationObjects {
                //为配置对象添加内容
                DefaultRadical = (float)numericUpDownRhythmicMagnification.Value,
                DefaultOffset = (float)numericUpDownSpectralShift.Value,
                DefaultFourierVariation = (int)numericUpDownFourierVariation.Value,
                ApplyWindowFunc = selectWindowFunc.SelectedItem != null ? selectWindowFunc.SelectedItem.ToString() : "",
                DefaultColor = StartColor.BackColor,
                DefaultStopColor = StopColor.BackColor,
                UseDefaultColorOrNOt = checkBoxUseDefault.Checked,
                NumberOfColors = (int)numericUpDownNumberOfColors.Value,
                MonochromeOrNot = checkBoxMonochrome.Checked,
                BackgroundColor = BackgroundColor.BackColor,
                BackImgOrNot = checkBoxImgOrColor.Checked,
                BackgroundImagePath = BackImagePath,
                WavyLine = checkBoxWavyLine.Checked,
                Frame = checkBoxFrame.Checked,
                Rotundity = checkBoxRotundity.Checked,
                Stripe = checkBoxBottomEdge.Checked,
                SmoothStripe = checkBoxSmoothStripe.Checked,
                StripeSpacing = (uint)numericUpDownStripeSpacing.Value,
                SettingForScreenName = DisplayName.Text,
                IsShow = checkBoxIsShow.Checked,
                IsUsingUnifiedConfiguration = checkBoxUsingUnifiedConfiguration.Checked,
                AutoStopWallPaper = RoutineCheckBoxAutoStop.Checked
            };
            //保存设置
            generalConfigurationObjects.SaveConfig(ConfigFilePath);
            //创建其他配置对象 
            VideoWallpaperConfigObject videoWallpaperConfigObject = new VideoWallpaperConfigObject {
                Rate = trackBarVideoRate.Value,
                Volume = trackBarVideoVolume.Value,
                Url = OtherVideoPath,
                SettingForScreenName = OtherDisplayName.Text,
                IsShow = UseOtherWallpaper.Checked,
                AutoStopWallPaper = CheckBoxAutoStop.Checked
            };
            videoWallpaperConfigObject.SaveConfig(ConfigFilePath);


            ConfigurationObject configurationObject = new ConfigurationObject() {
                GeneralConfigurationObjects = generalConfigurationObjects,
                VideoWallpaperConfigObject = videoWallpaperConfigObject
            };

            if (ReloadConfig != null) {
                ReloadConfig(configurationObject);
            }
        }
        /// <summary>
        /// 设置窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetForm_Load(object sender, EventArgs e) {
            //appBarManager.RegisterCallbackMessage();
            //appBarManage
            ShowSetData();
            ControlStatusUpdates();
        }

        public void ShowSetData() {
            //获取当前显示器
            NowWindowOnScrenn = GetThisWindowOnScreen();
            DisplayName.Text = NowWindowOnScrenn.DeviceName;
            OtherDisplayName.Text = NowWindowOnScrenn.DeviceName;
            //创建配置对象
            ConfigurationObject configurationObject = new ConfigurationObject();
            GeneralConfigurationObjects generalConfigurationObjects = configurationObject.GeneralConfigurationObjects.LoadConfiguration(ConfigFilePath, NowWindowOnScrenn.DeviceName);
            VideoWallpaperConfigObject videoWallpaperConfig = configurationObject.VideoWallpaperConfigObject.LoadConfig(ConfigFilePath, NowWindowOnScrenn.DeviceName);

            numericUpDownRhythmicMagnification.Value = (decimal)generalConfigurationObjects.DefaultRadical;
            numericUpDownSpectralShift.Value = (decimal)generalConfigurationObjects.DefaultOffset;
            numericUpDownFourierVariation.Value = generalConfigurationObjects.DefaultFourierVariation;
            selectWindowFunc.SelectedIndex = Array.IndexOf(windowFunc, generalConfigurationObjects.ApplyWindowFunc) >= 0 ? Array.IndexOf(windowFunc, generalConfigurationObjects.ApplyWindowFunc) : 0;
            StartColor.BackColor = generalConfigurationObjects.DefaultColor;
            StopColor.BackColor = generalConfigurationObjects.DefaultStopColor;
            checkBoxUseDefault.Checked = generalConfigurationObjects.UseDefaultColorOrNOt;
            numericUpDownNumberOfColors.Value = generalConfigurationObjects.NumberOfColors;
            checkBoxMonochrome.Checked = generalConfigurationObjects.MonochromeOrNot;
            BackgroundColor.BackColor = generalConfigurationObjects.BackgroundColor;
            checkBoxImgOrColor.Checked = generalConfigurationObjects.BackImgOrNot;
            BackImagePath = generalConfigurationObjects.BackgroundImagePath;
            if (generalConfigurationObjects.BackgroundImagePath != null) {
                BackgroundImage.Image = Image.FromFile(generalConfigurationObjects.BackgroundImagePath);
            } else {
                BackgroundImage.Image = null;
            }
            checkBoxWavyLine.Checked = generalConfigurationObjects.WavyLine;
            checkBoxFrame.Checked = generalConfigurationObjects.Frame;
            checkBoxRotundity.Checked = generalConfigurationObjects.Rotundity;
            checkBoxBottomEdge.Checked = generalConfigurationObjects.Stripe;
            checkBoxSmoothStripe.Checked = generalConfigurationObjects.SmoothStripe;
            numericUpDownStripeSpacing.Value = generalConfigurationObjects.StripeSpacing;
            checkBoxIsShow.Checked = generalConfigurationObjects.IsShow;
            checkBoxUsingUnifiedConfiguration.Checked = generalConfigurationObjects.IsUsingUnifiedConfiguration;
            RoutineCheckBoxAutoStop.Checked = generalConfigurationObjects.AutoStopWallPaper;

            UseOtherWallpaper.Checked = videoWallpaperConfig.IsShow;
            OtherVideoPath = videoWallpaperConfig.Url;
            trackBarVideoRate.Value = videoWallpaperConfig.Rate;
            trackBarVideoVolume.Value = videoWallpaperConfig.Volume;
            VideoRateLabel.Text = ((float)videoWallpaperConfig.Rate / 10f).ToString();
            VideoVolumeLabel.Text = videoWallpaperConfig.Volume.ToString();
            CheckBoxAutoStop.Checked = videoWallpaperConfig.AutoStopWallPaper;
            videoViewPlayer(OtherVideoPath);


        }
        private void ButtonReset_Click(object sender, EventArgs e) {
            GeneralConfigurationObjects generalConfigurationObjects = new GeneralConfigurationObjects();
            generalConfigurationObjects.SettingForScreenName = NowWindowOnScrenn.DeviceName;
            generalConfigurationObjects.SaveConfig(ConfigFilePath);

            ShowSetData();
        }
        private void checkBoxMonochrome_CheckedChanged(object sender, EventArgs e) {
            ControlStatusUpdates();
        }

        private void StartColor_Click(object sender, EventArgs e) {
            //创建颜色选择器
            ColorDialog startColorDialog = new ColorDialog();
            if (startColorDialog.ShowDialog() == DialogResult.OK) {
                StartColor.BackColor = startColorDialog.Color;
            }
        }

        private void StopColor_Click(object sender, EventArgs e) {
            ColorDialog stopColorDialog = new ColorDialog();
            if (stopColorDialog.ShowDialog() == DialogResult.OK) {
                StopColor.BackColor = stopColorDialog.Color;
            }
        }
        private void BackgroundColor_Click(object sender, EventArgs e) {
            ColorDialog backgroundColorDialog = new ColorDialog();
            if (backgroundColorDialog.ShowDialog() == DialogResult.OK) {
                BackgroundColor.BackColor = backgroundColorDialog.Color;
            }
        }
        /// <summary>
        /// 是否使用系统默认颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxUseDefault_CheckedChanged(object sender, EventArgs e) {
            StartColor.Enabled = !checkBoxUseDefault.Checked;
            StopColor.Enabled = !checkBoxUseDefault.Checked;
            if (checkBoxUseDefault.Checked && checkBoxMonochrome.Checked) {
                checkBoxMonochrome.Checked = false;
            }
            numericUpDownNumberOfColors.Enabled = !checkBoxUseDefault.Checked;
        }
        private void ImgOrColor_CheckedChanged(object sender, EventArgs e) {
            //选中时，背景颜色选项将不能被点击
            BackgroundColor.Enabled = !checkBoxImgOrColor.Checked;
            BackgroundImage.Enabled = checkBoxImgOrColor.Checked;
        }

        private void BackgroundImage_Click(object sender, EventArgs e) {
            //创建文件选择框，并显示，选择文件
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "图片文件(*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
            dialog.Title = "请选择一张图片作为背景";
            if (dialog.ShowDialog() == DialogResult.OK) {
                BackImagePath = dialog.FileName;
                BackgroundImage.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void SetFrom_FormClosed(object sender, FormClosedEventArgs e) {
            DisposeVideo();
            Visible = false;

        }
        /// <summary>
        /// 获取当期窗体所在屏幕
        /// </summary>
        private Screen GetThisWindowOnScreen() {
            return Screen.FromControl(this);
        }

        private void SetFrom_LocationChanged(object sender, EventArgs e) {
            //防抖，调用showsetdata函数
            debounceTimer.Stop();
            debounceTimer.Start();

        }
        /// <summary>
        /// 防抖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebounceTimer_Tick(object sender, EventArgs e) {
            this.Invoke(new Action(() => {
                if (GetThisWindowOnScreen().GetHashCode() != NowWindowOnScrenn.GetHashCode()) {
                    ShowSetData();
                }
                ControlStatusUpdates();
            }));
        }

        private void checkBoxUsingUnifiedConfiguration_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxUsingUnifiedConfiguration.Checked) {

            }
        }

        private void checkBoxIsShow_CheckedChanged(object sender, EventArgs e) {
            ControlStatusUpdates();
            if (checkBoxIsShow.Checked && UseOtherWallpaper.Checked) {
                UseOtherWallpaper.Checked = false;
            }
        }
        /// <summary>
        /// 统一更新控件状态
        /// </summary>
        private void ControlStatusUpdates() {
            bool IsShow = checkBoxIsShow.Checked;
            Display.Enabled = IsShow;
            groupBoxColor.Enabled = IsShow;
            Effect.Enabled = IsShow;
            checkBoxUsingUnifiedConfiguration.Enabled = IsShow;

            //是否单色 如果选中，禁用停止颜色选项卡
            StopColor.Cursor = checkBoxMonochrome.Checked ? Cursors.No : Cursors.Hand;
            StopColor.Enabled = !checkBoxMonochrome.Checked;
            if (checkBoxMonochrome.Checked && checkBoxUseDefault.Checked) {
                checkBoxUseDefault.Checked = false;
            }
            numericUpDownNumberOfColors.Enabled = !checkBoxMonochrome.Checked;
        }
        /// <summary>
        /// 是否使用第三方壁纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UseOtherWallpaper_CheckedChanged(object sender, EventArgs e) {
            if (UseOtherWallpaper.Checked && checkBoxIsShow.Checked) {
                checkBoxIsShow.Checked = false;
            }
        }
        /// <summary>
        /// 视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoView1_Click(object sender, EventArgs e) {
            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "视频(*.MP4;*.AVI;*.MKV;*.MOV;*.WMV)|*.MP4;*.AVI;*.MKV;*.MOV;*.WMV";
            dialog.Title = "请选择一个视频文件作为壁纸";
            if (dialog.ShowDialog() == DialogResult.OK) {
                OtherVideoPath = dialog.FileName;
                videoViewPlayer(OtherVideoPath);
            }
        }
        /// <summary>
        /// 音量滑动条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarVideoVolume_Scroll(object sender, EventArgs e) {
            VideoVolumeLabel.Text = trackBarVideoVolume.Value.ToString();
            if (mediaPlayer != null) {
                mediaPlayer.Volume = trackBarVideoVolume.Value;
            }
        }
        /// <summary>
        /// 速率滑动条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarVideoRate_Scroll(object sender, EventArgs e) {
            VideoRateLabel.Text = ((float)trackBarVideoRate.Value / 10f).ToString();
            if (mediaPlayer != null) {
                mediaPlayer.SetRate((float)trackBarVideoRate.Value / 10f);
            }
        }
        private void videoViewPlayer(String? url) {
            if (url == null) {
                return;
            }
            if (libVLC == null) {
                libVLC = new LibVLC();
            }
            Uri? uri = null;

            try {
                uri = new Uri(url);
            } catch (Exception) {
                return;
            };
            if (uri == null) {
                return;
            }

            media = new Media(libVLC, uri);

            if (mediaPlayer == null) {
                mediaPlayer = new MediaPlayer(libVLC);
                mediaPlayer.TimeChanged += MediaPlayer_TimeChanged;
                mediaPlayer.EndReached += MediaPlayer_EndReached;
            }
            videoView1.MediaPlayer = mediaPlayer;
            System.GC.Collect();
            mediaPlayer.SetRate((float)trackBarVideoRate.Value / 10f);
            mediaPlayer.Mute = true;
            mediaPlayer.Play(media);
        }

        private void MediaPlayer_TimeChanged(object? sender, MediaPlayerTimeChangedEventArgs e) {
            if (e.Time >= 3000 && mediaPlayer != null && media != null) {
                mediaPlayer.Position = 0;
            }
        }
        private void MediaPlayer_EndReached(object? sender, EventArgs e) {
            if (media != null && mediaPlayer != null) {
                ThreadPool.QueueUserWorkItem((p) => mediaPlayer.Play(media));
            }
        }
        private void DisposeVideo() {
            if (mediaPlayer != null) {
                mediaPlayer.TimeChanged -= MediaPlayer_TimeChanged;
                mediaPlayer.EndReached -= MediaPlayer_EndReached;
                mediaPlayer.Stop();
                mediaPlayer.Dispose();
                mediaPlayer = null;
            }
            if (media != null) {
                media.Dispose();
                media = null;
            }
            GC.Collect();
        }
        /// <summary>
        /// 其他配置保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OtherSaveBtn_Click(object sender, EventArgs e) {
            SavaConfig();
        }

        private void OtherResetBtn_Click(object sender, EventArgs e) {
            VideoWallpaperConfigObject videoWallpaperConfigObject = new VideoWallpaperConfigObject();
            videoWallpaperConfigObject.SettingForScreenName = NowWindowOnScrenn.DeviceName;
            videoWallpaperConfigObject.SaveConfig(ConfigFilePath);
            ShowSetData();
        }
    }
}
