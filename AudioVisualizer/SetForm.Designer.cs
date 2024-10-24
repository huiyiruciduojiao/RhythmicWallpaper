﻿namespace AudioWallpaper {
    partial class SetFrom {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetFrom));
            tabControl = new TabControl();
            Routine = new TabPage();
            MultiMonitorCompatibility = new GroupBox();
            RoutineCheckBoxAutoStop = new CheckBox();
            LableRoutineAutoStop = new Label();
            checkBoxUsingUnifiedConfiguration = new CheckBox();
            LabelUsingUnifiedConfiguration = new Label();
            DisplayName = new Label();
            checkBoxIsShow = new CheckBox();
            IsTheMonitorEnabled = new Label();
            DisplayRegistrationName = new Label();
            groupBoxColor = new GroupBox();
            labelBackgroundImg = new Label();
            BackgroundImage = new PictureBox();
            labelBackImgOrBackColor = new Label();
            checkBoxImgOrColor = new CheckBox();
            labelBackgroundCOlor = new Label();
            BackgroundColor = new PictureBox();
            checkBoxUseDefault = new CheckBox();
            labelUseSystemColor = new Label();
            labelNumberOfColors = new Label();
            numericUpDownNumberOfColors = new NumericUpDown();
            StartColor = new PictureBox();
            labelMonochrome = new Label();
            StopColor = new PictureBox();
            checkBoxMonochrome = new CheckBox();
            labelStartColor = new Label();
            labelStopColor = new Label();
            buttonReset = new Button();
            buttonSave = new Button();
            Display = new GroupBox();
            label2 = new Label();
            checkBoxSmoothStripe = new CheckBox();
            checkBoxBottomEdge = new CheckBox();
            checkBoxRotundity = new CheckBox();
            checkBoxFrame = new CheckBox();
            checkBoxWavyLine = new CheckBox();
            labelBottomEdge = new Label();
            labelRotundity = new Label();
            labelFrame = new Label();
            labelWaveLineDisplay = new Label();
            Effect = new GroupBox();
            labelWindowFuncText = new Label();
            selectWindowFunc = new ComboBox();
            numericUpDownFourierVariation = new NumericUpDown();
            labelFourierVariation = new Label();
            numericUpDownSpectralShift = new NumericUpDown();
            numericUpDownRhythmicMagnification = new NumericUpDown();
            labelSpectralShift = new Label();
            labelRhythmicMagnification = new Label();
            Other = new TabPage();
            ThirdParty = new GroupBox();
            CheckBoxAutoStop = new CheckBox();
            OtherDisplayName = new Label();
            LabelAutoStop = new Label();
            label3 = new Label();
            panelEx1 = new PanelEx();
            VideoRateLabel = new Label();
            trackBarVideoVolume = new TrackBar();
            VideoVolumeLabel = new Label();
            trackBarVideoRate = new TrackBar();
            videoView1 = new LibVLCSharp.WinForms.VideoView();
            UseOtherWallpaper = new CheckBox();
            label1 = new Label();
            OtherResetBtn = new Button();
            OtherSaveBtn = new Button();
            label4 = new Label();
            numericUpDownStripeSpacing = new NumericUpDown();
            tabControl.SuspendLayout();
            Routine.SuspendLayout();
            MultiMonitorCompatibility.SuspendLayout();
            groupBoxColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BackgroundImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BackgroundColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberOfColors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StopColor).BeginInit();
            Display.SuspendLayout();
            Effect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFourierVariation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSpectralShift).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRhythmicMagnification).BeginInit();
            Other.SuspendLayout();
            ThirdParty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVideoVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVideoRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)videoView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStripeSpacing).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(Routine);
            tabControl.Controls.Add(Other);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(313, 722);
            tabControl.TabIndex = 0;
            // 
            // Routine
            // 
            Routine.Controls.Add(MultiMonitorCompatibility);
            Routine.Controls.Add(groupBoxColor);
            Routine.Controls.Add(buttonReset);
            Routine.Controls.Add(buttonSave);
            Routine.Controls.Add(Display);
            Routine.Controls.Add(Effect);
            Routine.Location = new Point(4, 26);
            Routine.Name = "Routine";
            Routine.Padding = new Padding(3);
            Routine.Size = new Size(305, 692);
            Routine.TabIndex = 0;
            Routine.Text = "常规";
            Routine.UseVisualStyleBackColor = true;
            // 
            // MultiMonitorCompatibility
            // 
            MultiMonitorCompatibility.Controls.Add(RoutineCheckBoxAutoStop);
            MultiMonitorCompatibility.Controls.Add(LableRoutineAutoStop);
            MultiMonitorCompatibility.Controls.Add(checkBoxUsingUnifiedConfiguration);
            MultiMonitorCompatibility.Controls.Add(LabelUsingUnifiedConfiguration);
            MultiMonitorCompatibility.Controls.Add(DisplayName);
            MultiMonitorCompatibility.Controls.Add(checkBoxIsShow);
            MultiMonitorCompatibility.Controls.Add(IsTheMonitorEnabled);
            MultiMonitorCompatibility.Controls.Add(DisplayRegistrationName);
            MultiMonitorCompatibility.Location = new Point(8, 537);
            MultiMonitorCompatibility.Name = "MultiMonitorCompatibility";
            MultiMonitorCompatibility.Size = new Size(289, 122);
            MultiMonitorCompatibility.TabIndex = 5;
            MultiMonitorCompatibility.TabStop = false;
            MultiMonitorCompatibility.Text = "多显示器";
            // 
            // RoutineCheckBoxAutoStop
            // 
            RoutineCheckBoxAutoStop.AutoSize = true;
            RoutineCheckBoxAutoStop.Location = new Point(225, 97);
            RoutineCheckBoxAutoStop.Name = "RoutineCheckBoxAutoStop";
            RoutineCheckBoxAutoStop.Size = new Size(15, 14);
            RoutineCheckBoxAutoStop.TabIndex = 19;
            RoutineCheckBoxAutoStop.UseVisualStyleBackColor = true;
            // 
            // LableRoutineAutoStop
            // 
            LableRoutineAutoStop.AutoSize = true;
            LableRoutineAutoStop.Location = new Point(18, 96);
            LableRoutineAutoStop.Name = "LableRoutineAutoStop";
            LableRoutineAutoStop.Size = new Size(140, 17);
            LableRoutineAutoStop.TabIndex = 18;
            LableRoutineAutoStop.Text = "其它应用全屏时暂停壁纸";
            // 
            // checkBoxUsingUnifiedConfiguration
            // 
            checkBoxUsingUnifiedConfiguration.AutoSize = true;
            checkBoxUsingUnifiedConfiguration.Location = new Point(132, 73);
            checkBoxUsingUnifiedConfiguration.Name = "checkBoxUsingUnifiedConfiguration";
            checkBoxUsingUnifiedConfiguration.Size = new Size(15, 14);
            checkBoxUsingUnifiedConfiguration.TabIndex = 17;
            checkBoxUsingUnifiedConfiguration.UseVisualStyleBackColor = true;
            checkBoxUsingUnifiedConfiguration.CheckedChanged += checkBoxUsingUnifiedConfiguration_CheckedChanged;
            // 
            // LabelUsingUnifiedConfiguration
            // 
            LabelUsingUnifiedConfiguration.AutoSize = true;
            LabelUsingUnifiedConfiguration.Location = new Point(18, 71);
            LabelUsingUnifiedConfiguration.Name = "LabelUsingUnifiedConfiguration";
            LabelUsingUnifiedConfiguration.Size = new Size(80, 17);
            LabelUsingUnifiedConfiguration.TabIndex = 16;
            LabelUsingUnifiedConfiguration.Text = "使用统一配置";
            // 
            // DisplayName
            // 
            DisplayName.AutoSize = true;
            DisplayName.Location = new Point(104, 19);
            DisplayName.Name = "DisplayName";
            DisplayName.Size = new Size(68, 17);
            DisplayName.TabIndex = 15;
            DisplayName.Text = "没有初始化";
            // 
            // checkBoxIsShow
            // 
            checkBoxIsShow.AutoSize = true;
            checkBoxIsShow.Location = new Point(132, 47);
            checkBoxIsShow.Name = "checkBoxIsShow";
            checkBoxIsShow.Size = new Size(15, 14);
            checkBoxIsShow.TabIndex = 14;
            checkBoxIsShow.UseVisualStyleBackColor = true;
            checkBoxIsShow.CheckedChanged += checkBoxIsShow_CheckedChanged;
            // 
            // IsTheMonitorEnabled
            // 
            IsTheMonitorEnabled.AutoSize = true;
            IsTheMonitorEnabled.Location = new Point(18, 45);
            IsTheMonitorEnabled.Name = "IsTheMonitorEnabled";
            IsTheMonitorEnabled.Size = new Size(80, 17);
            IsTheMonitorEnabled.TabIndex = 1;
            IsTheMonitorEnabled.Text = "启用律动壁纸";
            // 
            // DisplayRegistrationName
            // 
            DisplayRegistrationName.AutoSize = true;
            DisplayRegistrationName.Location = new Point(18, 19);
            DisplayRegistrationName.Name = "DisplayRegistrationName";
            DisplayRegistrationName.Size = new Size(80, 17);
            DisplayRegistrationName.TabIndex = 0;
            DisplayRegistrationName.Text = "显示器注册名";
            // 
            // groupBoxColor
            // 
            groupBoxColor.Controls.Add(labelBackgroundImg);
            groupBoxColor.Controls.Add(BackgroundImage);
            groupBoxColor.Controls.Add(labelBackImgOrBackColor);
            groupBoxColor.Controls.Add(checkBoxImgOrColor);
            groupBoxColor.Controls.Add(labelBackgroundCOlor);
            groupBoxColor.Controls.Add(BackgroundColor);
            groupBoxColor.Controls.Add(checkBoxUseDefault);
            groupBoxColor.Controls.Add(labelUseSystemColor);
            groupBoxColor.Controls.Add(labelNumberOfColors);
            groupBoxColor.Controls.Add(numericUpDownNumberOfColors);
            groupBoxColor.Controls.Add(StartColor);
            groupBoxColor.Controls.Add(labelMonochrome);
            groupBoxColor.Controls.Add(StopColor);
            groupBoxColor.Controls.Add(checkBoxMonochrome);
            groupBoxColor.Controls.Add(labelStartColor);
            groupBoxColor.Controls.Add(labelStopColor);
            groupBoxColor.Location = new Point(8, 147);
            groupBoxColor.Name = "groupBoxColor";
            groupBoxColor.Size = new Size(289, 256);
            groupBoxColor.TabIndex = 4;
            groupBoxColor.TabStop = false;
            groupBoxColor.Text = "颜色信息";
            // 
            // labelBackgroundImg
            // 
            labelBackgroundImg.AutoSize = true;
            labelBackgroundImg.Location = new Point(16, 157);
            labelBackgroundImg.Name = "labelBackgroundImg";
            labelBackgroundImg.Size = new Size(56, 17);
            labelBackgroundImg.TabIndex = 22;
            labelBackgroundImg.Text = "背景图片";
            // 
            // BackgroundImage
            // 
            BackgroundImage.BackgroundImageLayout = ImageLayout.Zoom;
            BackgroundImage.BorderStyle = BorderStyle.FixedSingle;
            BackgroundImage.Cursor = Cursors.Hand;
            BackgroundImage.Enabled = false;
            BackgroundImage.Location = new Point(80, 157);
            BackgroundImage.Name = "BackgroundImage";
            BackgroundImage.Size = new Size(160, 90);
            BackgroundImage.SizeMode = PictureBoxSizeMode.Zoom;
            BackgroundImage.TabIndex = 21;
            BackgroundImage.TabStop = false;
            BackgroundImage.Click += BackgroundImage_Click;
            // 
            // labelBackImgOrBackColor
            // 
            labelBackImgOrBackColor.AutoSize = true;
            labelBackImgOrBackColor.Location = new Point(163, 125);
            labelBackImgOrBackColor.Name = "labelBackImgOrBackColor";
            labelBackImgOrBackColor.Size = new Size(56, 17);
            labelBackImgOrBackColor.TabIndex = 20;
            labelBackImgOrBackColor.Text = "是否图片";
            // 
            // checkBoxImgOrColor
            // 
            checkBoxImgOrColor.AutoSize = true;
            checkBoxImgOrColor.Location = new Point(225, 126);
            checkBoxImgOrColor.Name = "checkBoxImgOrColor";
            checkBoxImgOrColor.Size = new Size(15, 14);
            checkBoxImgOrColor.TabIndex = 19;
            checkBoxImgOrColor.UseVisualStyleBackColor = true;
            checkBoxImgOrColor.CheckedChanged += ImgOrColor_CheckedChanged;
            // 
            // labelBackgroundCOlor
            // 
            labelBackgroundCOlor.AutoSize = true;
            labelBackgroundCOlor.Location = new Point(16, 125);
            labelBackgroundCOlor.Name = "labelBackgroundCOlor";
            labelBackgroundCOlor.Size = new Size(56, 17);
            labelBackgroundCOlor.TabIndex = 18;
            labelBackgroundCOlor.Text = "背景颜色";
            // 
            // BackgroundColor
            // 
            BackgroundColor.BorderStyle = BorderStyle.FixedSingle;
            BackgroundColor.Cursor = Cursors.Hand;
            BackgroundColor.Location = new Point(99, 125);
            BackgroundColor.Name = "BackgroundColor";
            BackgroundColor.Size = new Size(45, 17);
            BackgroundColor.TabIndex = 17;
            BackgroundColor.TabStop = false;
            BackgroundColor.Click += BackgroundColor_Click;
            // 
            // checkBoxUseDefault
            // 
            checkBoxUseDefault.AutoSize = true;
            checkBoxUseDefault.Location = new Point(99, 30);
            checkBoxUseDefault.Name = "checkBoxUseDefault";
            checkBoxUseDefault.Size = new Size(15, 14);
            checkBoxUseDefault.TabIndex = 16;
            checkBoxUseDefault.UseVisualStyleBackColor = true;
            checkBoxUseDefault.CheckedChanged += checkBoxUseDefault_CheckedChanged;
            // 
            // labelUseSystemColor
            // 
            labelUseSystemColor.AutoSize = true;
            labelUseSystemColor.Location = new Point(16, 30);
            labelUseSystemColor.Name = "labelUseSystemColor";
            labelUseSystemColor.Size = new Size(56, 17);
            labelUseSystemColor.TabIndex = 15;
            labelUseSystemColor.Text = "使用默认";
            // 
            // labelNumberOfColors
            // 
            labelNumberOfColors.AutoSize = true;
            labelNumberOfColors.Location = new Point(16, 90);
            labelNumberOfColors.Name = "labelNumberOfColors";
            labelNumberOfColors.Size = new Size(56, 17);
            labelNumberOfColors.TabIndex = 14;
            labelNumberOfColors.Text = "颜色数量";
            // 
            // numericUpDownNumberOfColors
            // 
            numericUpDownNumberOfColors.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownNumberOfColors.Location = new Point(99, 89);
            numericUpDownNumberOfColors.Maximum = new decimal(new int[] { 51200, 0, 0, 0 });
            numericUpDownNumberOfColors.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownNumberOfColors.Name = "numericUpDownNumberOfColors";
            numericUpDownNumberOfColors.Size = new Size(120, 23);
            numericUpDownNumberOfColors.TabIndex = 13;
            numericUpDownNumberOfColors.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // StartColor
            // 
            StartColor.BorderStyle = BorderStyle.FixedSingle;
            StartColor.Cursor = Cursors.Hand;
            StartColor.Location = new Point(99, 59);
            StartColor.Name = "StartColor";
            StartColor.Size = new Size(45, 17);
            StartColor.TabIndex = 7;
            StartColor.TabStop = false;
            StartColor.Click += StartColor_Click;
            // 
            // labelMonochrome
            // 
            labelMonochrome.AutoSize = true;
            labelMonochrome.Location = new Point(163, 30);
            labelMonochrome.Name = "labelMonochrome";
            labelMonochrome.Size = new Size(56, 17);
            labelMonochrome.TabIndex = 12;
            labelMonochrome.Text = "是否单色";
            // 
            // StopColor
            // 
            StopColor.BorderStyle = BorderStyle.FixedSingle;
            StopColor.Cursor = Cursors.Hand;
            StopColor.Location = new Point(225, 59);
            StopColor.Name = "StopColor";
            StopColor.Size = new Size(45, 17);
            StopColor.TabIndex = 8;
            StopColor.TabStop = false;
            StopColor.Click += StopColor_Click;
            // 
            // checkBoxMonochrome
            // 
            checkBoxMonochrome.AutoSize = true;
            checkBoxMonochrome.Location = new Point(225, 32);
            checkBoxMonochrome.Name = "checkBoxMonochrome";
            checkBoxMonochrome.Size = new Size(15, 14);
            checkBoxMonochrome.TabIndex = 11;
            checkBoxMonochrome.UseVisualStyleBackColor = true;
            checkBoxMonochrome.CheckedChanged += checkBoxMonochrome_CheckedChanged;
            // 
            // labelStartColor
            // 
            labelStartColor.AutoSize = true;
            labelStartColor.Location = new Point(16, 59);
            labelStartColor.Name = "labelStartColor";
            labelStartColor.Size = new Size(56, 17);
            labelStartColor.TabIndex = 9;
            labelStartColor.Text = "起始颜色";
            // 
            // labelStopColor
            // 
            labelStopColor.AutoSize = true;
            labelStopColor.Location = new Point(163, 59);
            labelStopColor.Name = "labelStopColor";
            labelStopColor.Size = new Size(56, 17);
            labelStopColor.TabIndex = 10;
            labelStopColor.Text = "停止颜色";
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(8, 665);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(75, 23);
            buttonReset.TabIndex = 3;
            buttonReset.Text = "重置";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += ButtonReset_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(222, 665);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "保存";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // Display
            // 
            Display.Controls.Add(numericUpDownStripeSpacing);
            Display.Controls.Add(label4);
            Display.Controls.Add(label2);
            Display.Controls.Add(checkBoxSmoothStripe);
            Display.Controls.Add(checkBoxBottomEdge);
            Display.Controls.Add(checkBoxRotundity);
            Display.Controls.Add(checkBoxFrame);
            Display.Controls.Add(checkBoxWavyLine);
            Display.Controls.Add(labelBottomEdge);
            Display.Controls.Add(labelRotundity);
            Display.Controls.Add(labelFrame);
            Display.Controls.Add(labelWaveLineDisplay);
            Display.Location = new Point(8, 409);
            Display.Name = "Display";
            Display.Size = new Size(289, 122);
            Display.TabIndex = 1;
            Display.TabStop = false;
            Display.Text = "显示内容";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 97);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 15;
            label2.Text = "平滑圆角";
            // 
            // checkBoxSmoothStripe
            // 
            checkBoxSmoothStripe.AutoSize = true;
            checkBoxSmoothStripe.Location = new Point(255, 98);
            checkBoxSmoothStripe.Name = "checkBoxSmoothStripe";
            checkBoxSmoothStripe.Size = new Size(15, 14);
            checkBoxSmoothStripe.TabIndex = 14;
            checkBoxSmoothStripe.UseVisualStyleBackColor = true;
            // 
            // checkBoxBottomEdge
            // 
            checkBoxBottomEdge.AutoSize = true;
            checkBoxBottomEdge.Location = new Point(130, 98);
            checkBoxBottomEdge.Name = "checkBoxBottomEdge";
            checkBoxBottomEdge.Size = new Size(15, 14);
            checkBoxBottomEdge.TabIndex = 13;
            checkBoxBottomEdge.UseVisualStyleBackColor = true;
            // 
            // checkBoxRotundity
            // 
            checkBoxRotundity.AutoSize = true;
            checkBoxRotundity.Location = new Point(130, 72);
            checkBoxRotundity.Name = "checkBoxRotundity";
            checkBoxRotundity.Size = new Size(15, 14);
            checkBoxRotundity.TabIndex = 12;
            checkBoxRotundity.UseVisualStyleBackColor = true;
            // 
            // checkBoxFrame
            // 
            checkBoxFrame.AutoSize = true;
            checkBoxFrame.Location = new Point(130, 46);
            checkBoxFrame.Name = "checkBoxFrame";
            checkBoxFrame.Size = new Size(15, 14);
            checkBoxFrame.TabIndex = 11;
            checkBoxFrame.UseVisualStyleBackColor = true;
            // 
            // checkBoxWavyLine
            // 
            checkBoxWavyLine.AutoSize = true;
            checkBoxWavyLine.Location = new Point(130, 20);
            checkBoxWavyLine.Name = "checkBoxWavyLine";
            checkBoxWavyLine.Size = new Size(15, 14);
            checkBoxWavyLine.TabIndex = 10;
            checkBoxWavyLine.UseVisualStyleBackColor = true;
            // 
            // labelBottomEdge
            // 
            labelBottomEdge.AutoSize = true;
            labelBottomEdge.Location = new Point(16, 97);
            labelBottomEdge.Name = "labelBottomEdge";
            labelBottomEdge.Size = new Size(80, 17);
            labelBottomEdge.TabIndex = 5;
            labelBottomEdge.Text = "是否显示底边";
            // 
            // labelRotundity
            // 
            labelRotundity.AutoSize = true;
            labelRotundity.Location = new Point(16, 71);
            labelRotundity.Name = "labelRotundity";
            labelRotundity.Size = new Size(80, 17);
            labelRotundity.TabIndex = 4;
            labelRotundity.Text = "是否显示圆形";
            // 
            // labelFrame
            // 
            labelFrame.AutoSize = true;
            labelFrame.Location = new Point(16, 45);
            labelFrame.Name = "labelFrame";
            labelFrame.Size = new Size(80, 17);
            labelFrame.TabIndex = 3;
            labelFrame.Text = "是否显示边框";
            // 
            // labelWaveLineDisplay
            // 
            labelWaveLineDisplay.AutoSize = true;
            labelWaveLineDisplay.Location = new Point(16, 19);
            labelWaveLineDisplay.Name = "labelWaveLineDisplay";
            labelWaveLineDisplay.Size = new Size(80, 17);
            labelWaveLineDisplay.TabIndex = 2;
            labelWaveLineDisplay.Text = "是否显示频谱";
            // 
            // Effect
            // 
            Effect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Effect.Controls.Add(labelWindowFuncText);
            Effect.Controls.Add(selectWindowFunc);
            Effect.Controls.Add(numericUpDownFourierVariation);
            Effect.Controls.Add(labelFourierVariation);
            Effect.Controls.Add(numericUpDownSpectralShift);
            Effect.Controls.Add(numericUpDownRhythmicMagnification);
            Effect.Controls.Add(labelSpectralShift);
            Effect.Controls.Add(labelRhythmicMagnification);
            Effect.Location = new Point(8, 6);
            Effect.Name = "Effect";
            Effect.Size = new Size(289, 135);
            Effect.TabIndex = 0;
            Effect.TabStop = false;
            Effect.Text = "基础参数";
            // 
            // labelWindowFuncText
            // 
            labelWindowFuncText.AutoSize = true;
            labelWindowFuncText.Location = new Point(13, 106);
            labelWindowFuncText.Name = "labelWindowFuncText";
            labelWindowFuncText.Size = new Size(80, 17);
            labelWindowFuncText.TabIndex = 8;
            labelWindowFuncText.Text = "选择窗口函数";
            // 
            // selectWindowFunc
            // 
            selectWindowFunc.DisplayMember = "0";
            selectWindowFunc.FormattingEnabled = true;
            selectWindowFunc.Location = new Point(99, 103);
            selectWindowFunc.Name = "selectWindowFunc";
            selectWindowFunc.Size = new Size(120, 25);
            selectWindowFunc.TabIndex = 7;
            selectWindowFunc.ValueMember = "0";
            // 
            // numericUpDownFourierVariation
            // 
            numericUpDownFourierVariation.Location = new Point(99, 74);
            numericUpDownFourierVariation.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numericUpDownFourierVariation.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownFourierVariation.Name = "numericUpDownFourierVariation";
            numericUpDownFourierVariation.Size = new Size(120, 23);
            numericUpDownFourierVariation.TabIndex = 5;
            numericUpDownFourierVariation.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelFourierVariation
            // 
            labelFourierVariation.AutoSize = true;
            labelFourierVariation.Location = new Point(16, 75);
            labelFourierVariation.Name = "labelFourierVariation";
            labelFourierVariation.Size = new Size(80, 17);
            labelFourierVariation.TabIndex = 4;
            labelFourierVariation.Text = "傅里叶变化量";
            // 
            // numericUpDownSpectralShift
            // 
            numericUpDownSpectralShift.DecimalPlaces = 2;
            numericUpDownSpectralShift.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownSpectralShift.Location = new Point(99, 45);
            numericUpDownSpectralShift.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSpectralShift.Minimum = new decimal(new int[] { 2, 0, 0, -2147418112 });
            numericUpDownSpectralShift.Name = "numericUpDownSpectralShift";
            numericUpDownSpectralShift.Size = new Size(120, 23);
            numericUpDownSpectralShift.TabIndex = 3;
            // 
            // numericUpDownRhythmicMagnification
            // 
            numericUpDownRhythmicMagnification.DecimalPlaces = 1;
            numericUpDownRhythmicMagnification.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownRhythmicMagnification.Location = new Point(99, 16);
            numericUpDownRhythmicMagnification.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDownRhythmicMagnification.Minimum = new decimal(new int[] { 9999, 0, 0, int.MinValue });
            numericUpDownRhythmicMagnification.Name = "numericUpDownRhythmicMagnification";
            numericUpDownRhythmicMagnification.Size = new Size(120, 23);
            numericUpDownRhythmicMagnification.TabIndex = 2;
            // 
            // labelSpectralShift
            // 
            labelSpectralShift.AutoSize = true;
            labelSpectralShift.Location = new Point(16, 47);
            labelSpectralShift.Name = "labelSpectralShift";
            labelSpectralShift.Size = new Size(56, 17);
            labelSpectralShift.TabIndex = 1;
            labelSpectralShift.Text = "频谱偏移";
            // 
            // labelRhythmicMagnification
            // 
            labelRhythmicMagnification.AutoSize = true;
            labelRhythmicMagnification.Location = new Point(16, 19);
            labelRhythmicMagnification.Name = "labelRhythmicMagnification";
            labelRhythmicMagnification.Size = new Size(56, 17);
            labelRhythmicMagnification.TabIndex = 0;
            labelRhythmicMagnification.Text = "律动倍率";
            // 
            // Other
            // 
            Other.Controls.Add(ThirdParty);
            Other.Controls.Add(OtherResetBtn);
            Other.Controls.Add(OtherSaveBtn);
            Other.Location = new Point(4, 26);
            Other.Name = "Other";
            Other.Padding = new Padding(3);
            Other.Size = new Size(305, 692);
            Other.TabIndex = 1;
            Other.Text = "其他";
            Other.UseVisualStyleBackColor = true;
            // 
            // ThirdParty
            // 
            ThirdParty.Controls.Add(CheckBoxAutoStop);
            ThirdParty.Controls.Add(OtherDisplayName);
            ThirdParty.Controls.Add(LabelAutoStop);
            ThirdParty.Controls.Add(label3);
            ThirdParty.Controls.Add(panelEx1);
            ThirdParty.Controls.Add(VideoRateLabel);
            ThirdParty.Controls.Add(trackBarVideoVolume);
            ThirdParty.Controls.Add(VideoVolumeLabel);
            ThirdParty.Controls.Add(trackBarVideoRate);
            ThirdParty.Controls.Add(videoView1);
            ThirdParty.Controls.Add(UseOtherWallpaper);
            ThirdParty.Controls.Add(label1);
            ThirdParty.Location = new Point(8, 6);
            ThirdParty.Name = "ThirdParty";
            ThirdParty.Size = new Size(289, 289);
            ThirdParty.TabIndex = 6;
            ThirdParty.TabStop = false;
            ThirdParty.Text = "第三方壁纸";
            // 
            // CheckBoxAutoStop
            // 
            CheckBoxAutoStop.AutoSize = true;
            CheckBoxAutoStop.Location = new Point(193, 246);
            CheckBoxAutoStop.Name = "CheckBoxAutoStop";
            CheckBoxAutoStop.Size = new Size(15, 14);
            CheckBoxAutoStop.TabIndex = 18;
            CheckBoxAutoStop.UseVisualStyleBackColor = true;
            // 
            // OtherDisplayName
            // 
            OtherDisplayName.AutoSize = true;
            OtherDisplayName.Location = new Point(140, 219);
            OtherDisplayName.Name = "OtherDisplayName";
            OtherDisplayName.Size = new Size(68, 17);
            OtherDisplayName.TabIndex = 24;
            OtherDisplayName.Text = "没有初始化";
            // 
            // LabelAutoStop
            // 
            LabelAutoStop.AutoSize = true;
            LabelAutoStop.Location = new Point(16, 245);
            LabelAutoStop.Name = "LabelAutoStop";
            LabelAutoStop.Size = new Size(140, 17);
            LabelAutoStop.TabIndex = 0;
            LabelAutoStop.Text = "其它应用全屏时暂停壁纸";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 219);
            label3.Name = "label3";
            label3.Size = new Size(80, 17);
            label3.TabIndex = 23;
            label3.Text = "显示器注册名";
            // 
            // panelEx1
            // 
            panelEx1.BackColor = Color.Transparent;
            panelEx1.BorderThickness = 1F;
            panelEx1.Cursor = Cursors.Hand;
            panelEx1.Location = new Point(16, 40);
            panelEx1.Name = "panelEx1";
            panelEx1.Opacity = 0.5F;
            panelEx1.RotateAngle = 0F;
            panelEx1.Size = new Size(192, 108);
            panelEx1.TabIndex = 22;
            panelEx1.Click += videoView1_Click;
            // 
            // VideoRateLabel
            // 
            VideoRateLabel.AutoSize = true;
            VideoRateLabel.Location = new Point(229, 182);
            VideoRateLabel.Name = "VideoRateLabel";
            VideoRateLabel.Size = new Size(15, 17);
            VideoRateLabel.TabIndex = 21;
            VideoRateLabel.Text = "1";
            // 
            // trackBarVideoVolume
            // 
            trackBarVideoVolume.Location = new Point(223, 40);
            trackBarVideoVolume.Maximum = 100;
            trackBarVideoVolume.Name = "trackBarVideoVolume";
            trackBarVideoVolume.Orientation = Orientation.Vertical;
            trackBarVideoVolume.Size = new Size(45, 104);
            trackBarVideoVolume.TabIndex = 7;
            trackBarVideoVolume.Value = 100;
            trackBarVideoVolume.Scroll += trackBarVideoVolume_Scroll;
            // 
            // VideoVolumeLabel
            // 
            VideoVolumeLabel.AutoSize = true;
            VideoVolumeLabel.Location = new Point(229, 154);
            VideoVolumeLabel.Name = "VideoVolumeLabel";
            VideoVolumeLabel.Size = new Size(29, 17);
            VideoVolumeLabel.TabIndex = 20;
            VideoVolumeLabel.Text = "100";
            // 
            // trackBarVideoRate
            // 
            trackBarVideoRate.Location = new Point(16, 154);
            trackBarVideoRate.Maximum = 100;
            trackBarVideoRate.Minimum = 5;
            trackBarVideoRate.Name = "trackBarVideoRate";
            trackBarVideoRate.Size = new Size(192, 45);
            trackBarVideoRate.TabIndex = 19;
            trackBarVideoRate.TickStyle = TickStyle.TopLeft;
            trackBarVideoRate.Value = 10;
            trackBarVideoRate.Scroll += trackBarVideoRate_Scroll;
            // 
            // videoView1
            // 
            videoView1.BackColor = Color.Black;
            videoView1.Cursor = Cursors.Hand;
            videoView1.Location = new Point(16, 40);
            videoView1.MediaPlayer = null;
            videoView1.Name = "videoView1";
            videoView1.Size = new Size(192, 108);
            videoView1.TabIndex = 18;
            videoView1.Text = "videoView1";
            // 
            // UseOtherWallpaper
            // 
            UseOtherWallpaper.AutoSize = true;
            UseOtherWallpaper.Location = new Point(193, 21);
            UseOtherWallpaper.Name = "UseOtherWallpaper";
            UseOtherWallpaper.Size = new Size(15, 14);
            UseOtherWallpaper.TabIndex = 17;
            UseOtherWallpaper.UseVisualStyleBackColor = true;
            UseOtherWallpaper.CheckedChanged += UseOtherWallpaper_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 19);
            label1.Name = "label1";
            label1.Size = new Size(92, 17);
            label1.TabIndex = 5;
            label1.Text = "启用第三方壁纸";
            // 
            // OtherResetBtn
            // 
            OtherResetBtn.Location = new Point(8, 665);
            OtherResetBtn.Name = "OtherResetBtn";
            OtherResetBtn.Size = new Size(75, 23);
            OtherResetBtn.TabIndex = 5;
            OtherResetBtn.Text = "重置";
            OtherResetBtn.UseVisualStyleBackColor = true;
            OtherResetBtn.Click += OtherResetBtn_Click;
            // 
            // OtherSaveBtn
            // 
            OtherSaveBtn.Location = new Point(222, 665);
            OtherSaveBtn.Name = "OtherSaveBtn";
            OtherSaveBtn.Size = new Size(75, 23);
            OtherSaveBtn.TabIndex = 4;
            OtherSaveBtn.Text = "保存";
            OtherSaveBtn.UseVisualStyleBackColor = true;
            OtherSaveBtn.Click += OtherSaveBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(163, 71);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 16;
            label4.Text = "条纹间隔";
            // 
            // numericUpDownStripeSpacing
            // 
            numericUpDownStripeSpacing.Location = new Point(225, 68);
            numericUpDownStripeSpacing.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownStripeSpacing.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownStripeSpacing.Name = "numericUpDownStripeSpacing";
            numericUpDownStripeSpacing.Size = new Size(45, 23);
            numericUpDownStripeSpacing.TabIndex = 9;
            numericUpDownStripeSpacing.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SetFrom
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 722);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SetFrom";
            Text = "设置";
            FormClosed += SetFrom_FormClosed;
            Load += SetForm_Load;
            LocationChanged += SetFrom_LocationChanged;
            tabControl.ResumeLayout(false);
            Routine.ResumeLayout(false);
            MultiMonitorCompatibility.ResumeLayout(false);
            MultiMonitorCompatibility.PerformLayout();
            groupBoxColor.ResumeLayout(false);
            groupBoxColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BackgroundImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)BackgroundColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberOfColors).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)StopColor).EndInit();
            Display.ResumeLayout(false);
            Display.PerformLayout();
            Effect.ResumeLayout(false);
            Effect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFourierVariation).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSpectralShift).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRhythmicMagnification).EndInit();
            Other.ResumeLayout(false);
            ThirdParty.ResumeLayout(false);
            ThirdParty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVideoVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVideoRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)videoView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStripeSpacing).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage Routine;
        private TabPage Other;
        private GroupBox Effect;
        private Label labelRhythmicMagnification;
        private Label labelSpectralShift;
        private GroupBox Display;
        private Label labelBottomEdge;
        private Label labelRotundity;
        private Label labelFrame;
        private Label labelWaveLineDisplay;
        private NumericUpDown numericUpDownSpectralShift;
        private NumericUpDown numericUpDownRhythmicMagnification;
        private Button buttonReset;
        private Button buttonSave;
        private CheckBox checkBoxBottomEdge;
        private CheckBox checkBoxRotundity;
        private CheckBox checkBoxFrame;
        private CheckBox checkBoxWavyLine;
        private NumericUpDown numericUpDownFourierVariation;
        private Label labelFourierVariation;
        private PictureBox StartColor;
        private Label labelStopColor;
        private Label labelStartColor;
        private PictureBox StopColor;
        private Label labelMonochrome;
        private CheckBox checkBoxMonochrome;
        private Label labelNumberOfColors;
        private NumericUpDown numericUpDownNumberOfColors;
        private GroupBox groupBoxColor;
        private CheckBox checkBoxUseDefault;
        private Label labelUseSystemColor;
        private Label labelBackgroundCOlor;
        private PictureBox BackgroundColor;
        private Label labelBackgroundImg;
        private PictureBox BackgroundImage;
        private Label labelBackImgOrBackColor;
        private CheckBox checkBoxImgOrColor;
        private GroupBox MultiMonitorCompatibility;
        private Label DisplayRegistrationName;
        private Label DisplayName;
        private CheckBox checkBoxIsShow;
        private Label IsTheMonitorEnabled;
        private Label LabelUsingUnifiedConfiguration;
        private CheckBox checkBoxUsingUnifiedConfiguration;
        private CheckBox RoutineCheckBoxAutoStop;
        private Label LableRoutineAutoStop;
        private Button OtherResetBtn;
        private Button OtherSaveBtn;
        private GroupBox ThirdParty;
        private CheckBox UseOtherWallpaper;
        private Label label1;
        private LibVLCSharp.WinForms.VideoView videoView1;
        private Label VideoRateLabel;
        private TrackBar trackBarVideoVolume;
        private Label VideoVolumeLabel;
        private TrackBar trackBarVideoRate;
        private PanelEx panelEx1;
        private Label OtherDisplayName;
        private Label label3;
        private CheckBox CheckBoxAutoStop;
        private Label LabelAutoStop;
        private Label labelWindowFuncText;
        private ComboBox selectWindowFunc;
        private Label label2;
        private CheckBox checkBoxSmoothStripe;
        private NumericUpDown numericUpDownStripeSpacing;
        private Label label4;
    }
}