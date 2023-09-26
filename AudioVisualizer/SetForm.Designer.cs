namespace AudioVisualizer {
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
            checkBoxBottomEdge = new CheckBox();
            checkBoxRotundity = new CheckBox();
            checkBoxFrame = new CheckBox();
            checkBoxWavyLine = new CheckBox();
            labelBottomEdge = new Label();
            labelRotundity = new Label();
            labelFrame = new Label();
            labelWaveLineDisplay = new Label();
            Effect = new GroupBox();
            numericUpDownFourierVariation = new NumericUpDown();
            labelFourierVariation = new Label();
            numericUpDownSpectralShift = new NumericUpDown();
            numericUpDownRhythmicMagnification = new NumericUpDown();
            labelSpectralShift = new Label();
            labelRhythmicMagnification = new Label();
            Other = new TabPage();
            tabControl.SuspendLayout();
            Routine.SuspendLayout();
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
            tabControl.Size = new Size(313, 568);
            tabControl.TabIndex = 0;
            // 
            // Routine
            // 
            Routine.Controls.Add(groupBoxColor);
            Routine.Controls.Add(buttonReset);
            Routine.Controls.Add(buttonSave);
            Routine.Controls.Add(Display);
            Routine.Controls.Add(Effect);
            Routine.Location = new Point(4, 26);
            Routine.Name = "Routine";
            Routine.Padding = new Padding(3);
            Routine.Size = new Size(305, 538);
            Routine.TabIndex = 0;
            Routine.Text = "常规";
            Routine.UseVisualStyleBackColor = true;
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
            groupBoxColor.Location = new Point(8, 120);
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
            buttonReset.Location = new Point(8, 509);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(75, 23);
            buttonReset.TabIndex = 3;
            buttonReset.Text = "重置";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(222, 509);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "保存";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // Display
            // 
            Display.Controls.Add(checkBoxBottomEdge);
            Display.Controls.Add(checkBoxRotundity);
            Display.Controls.Add(checkBoxFrame);
            Display.Controls.Add(checkBoxWavyLine);
            Display.Controls.Add(labelBottomEdge);
            Display.Controls.Add(labelRotundity);
            Display.Controls.Add(labelFrame);
            Display.Controls.Add(labelWaveLineDisplay);
            Display.Location = new Point(8, 382);
            Display.Name = "Display";
            Display.Size = new Size(289, 122);
            Display.TabIndex = 1;
            Display.TabStop = false;
            Display.Text = "显示内容";
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
            Effect.Controls.Add(numericUpDownFourierVariation);
            Effect.Controls.Add(labelFourierVariation);
            Effect.Controls.Add(numericUpDownSpectralShift);
            Effect.Controls.Add(numericUpDownRhythmicMagnification);
            Effect.Controls.Add(labelSpectralShift);
            Effect.Controls.Add(labelRhythmicMagnification);
            Effect.Location = new Point(8, 6);
            Effect.Name = "Effect";
            Effect.Size = new Size(289, 108);
            Effect.TabIndex = 0;
            Effect.TabStop = false;
            Effect.Text = "基础参数";
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
            Other.Location = new Point(4, 26);
            Other.Name = "Other";
            Other.Padding = new Padding(3);
            Other.Size = new Size(305, 538);
            Other.TabIndex = 1;
            Other.Text = "其他";
            Other.UseVisualStyleBackColor = true;
            // 
            // SetFrom
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 568);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SetFrom";
            Text = "设置";
            FormClosed += SetFrom_FormClosed;
            Load += SetForm_Load;
            tabControl.ResumeLayout(false);
            Routine.ResumeLayout(false);
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
    }
}