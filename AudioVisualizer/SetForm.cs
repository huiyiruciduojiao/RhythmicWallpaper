using LibAudioVisualizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioVisualizer {
    public partial class SetFrom : Form {
        String ConfigFilePath = Application.StartupPath + "\\config.ini";
        public MainWindow MainWindowData;
        public String? BackImagePath = null;
        private static SetFrom? setFrom = null;
        private SetFrom() {

        }
        public static SetFrom ShowSetFrom(MainWindow mainWindow) {
            if (setFrom == null) {
                setFrom = new SetFrom();
            }
            setFrom.InitializeComponent();
            setFrom.MainWindowData = mainWindow;
            return setFrom;
        }
        private void buttonSave_Click(object sender, EventArgs e) {
            //创建配置对象
            ConfigurationObject configuration = new ConfigurationObject {
                //为配置对象添加内容
                DefaultRadical = (float)numericUpDownRhythmicMagnification.Value,
                DefaultOffset = (float)numericUpDownSpectralShift.Value,
                DefaultFourierVariation = (int)numericUpDownFourierVariation.Value,
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
                Stripe = checkBoxBottomEdge.Checked
            };
            //保存设置
            configuration.SaveConfiguration(ConfigFilePath);
            ReloadSet(configuration);

        }
        public void ReloadSet(ConfigurationObject configuration) {
            MainWindow.configurationObject = configuration;
            //重新生成颜色数组
            MainWindow.allColors = MainWindow.GetAllHsvColors(configuration.NumberOfColors);

            //MainWindowData.BackColor = Color.Red;
            if (configuration.BackImgOrNot && configuration.BackgroundImagePath != null) {
                //MainWindowData.BackColor = Color.Transparent;
                //MainWindowData.BackgroundImage = Image.FromFile(configuration.BackgroundImagePath);
                int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;

                int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
                MainWindowData.backgroundImage = new Bitmap(iActulaWidth, iActulaHeight);
                using (var graphics = Graphics.FromImage(MainWindowData.backgroundImage)) {
                    graphics.DrawImage(Image.FromFile(configuration.BackgroundImagePath), 0, 0, iActulaWidth, iActulaHeight);
                }

            } else {
                MainWindowData.BackColor = configuration.BackgroundColor;
            }
            //修改傅里叶变化量


            GC.Collect();
        }
        /// <summary>
        /// 设置窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetForm_Load(object sender, EventArgs e) {
            ShowSetData();
        }

        public void ShowSetData() {
            //创建配置对象
            ConfigurationObject configuration = new ConfigurationObject().LoadConfiguration(ConfigFilePath);
            numericUpDownRhythmicMagnification.Value = (decimal)configuration.DefaultRadical;
            numericUpDownSpectralShift.Value = (decimal)configuration.DefaultOffset;
            numericUpDownFourierVariation.Value = configuration.DefaultFourierVariation;
            StartColor.BackColor = configuration.DefaultColor;
            StopColor.BackColor = configuration.DefaultStopColor;
            checkBoxUseDefault.Checked = configuration.UseDefaultColorOrNOt;
            numericUpDownNumberOfColors.Value = configuration.NumberOfColors;
            checkBoxMonochrome.Checked = configuration.MonochromeOrNot;
            BackgroundColor.BackColor = configuration.BackgroundColor;
            checkBoxImgOrColor.Checked = configuration.BackImgOrNot;
            if (configuration.BackgroundImagePath != null) {
                BackgroundImage.Image = Image.FromFile(configuration.BackgroundImagePath);
            }
            BackImagePath = configuration.BackgroundImagePath;
            checkBoxWavyLine.Checked = configuration.WavyLine;
            checkBoxFrame.Checked = configuration.Frame;
            checkBoxRotundity.Checked = configuration.Rotundity;
            checkBoxBottomEdge.Checked = configuration.Stripe;
            MainWindow.configurationObject = configuration;
        }

        private void buttonReset_Click(object sender, EventArgs e) {
            new ConfigurationObject().SaveConfiguration(ConfigFilePath);
            ShowSetData();
        }

        private void checkBoxMonochrome_CheckedChanged(object sender, EventArgs e) {
            //如果选中，禁用停止颜色选项卡
            StopColor.Cursor = checkBoxMonochrome.Checked ? Cursors.No : Cursors.Hand;
            StopColor.Enabled = !checkBoxMonochrome.Checked;
            if (checkBoxMonochrome.Checked && checkBoxUseDefault.Checked) {
                checkBoxUseDefault.Checked = false;
            }

            numericUpDownNumberOfColors.Enabled = !checkBoxMonochrome.Checked;
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
            if (setFrom != null) {
                setFrom.Dispose();
                setFrom = null;
            }
        }
    }
}
