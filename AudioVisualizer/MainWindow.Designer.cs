using System.Net.NetworkInformation;

namespace AudioWallpaper {
    partial class MainWindow {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            drawingPanel = new Panel();
            dataTimer = new System.Windows.Forms.Timer(components);
            drawingTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // drawingPanel
            // 
            drawingPanel.AutoSize = true;
            drawingPanel.Dock = DockStyle.Fill;
            drawingPanel.Location = new Point(0, 0);
            drawingPanel.Margin = new Padding(2);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(560, 306);
            drawingPanel.TabIndex = 0;
            // 
            // dataTimer
            // 
            dataTimer.Interval = 30;
            dataTimer.Tick += DataTimer_Tick;
            // 
            // drawingTimer
            // 
            drawingTimer.Interval = 30;
            drawingTimer.Tick += DrawingTimer_Tick;
            // 
            // MainWindow
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(560, 306);
            Controls.Add(drawingPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "MainWindow";
            StartPosition = FormStartPosition.Manual;
            Text = "Music Visualizer";
            FormClosed += MainWindow_FormClosed;
            Load += MainWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        #region 自定义图标大小初始化方法
        /// <summary>
        /// 自定义图标大小初始化方法
        /// </summary>
        /// <param name="toolStripItem">需要设置的菜单项元素</param>
        /// <param name="image">图片</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        private void SetToolStripMenuItemImage(ToolStripItem toolStripItem, Image image, int width, int height) {
            //取消菜单项自动大小
            toolStripItem.AutoSize = false;
            //取消菜单项缩放
            toolStripItem.ImageScaling = ToolStripItemImageScaling.None;
            //设置菜单项图标大小
            toolStripItem.Image = new Bitmap(image, new Size(width, height));
        }
        #endregion
        private System.Windows.Forms.Timer dataTimer;
        private Panel drawingPanel;
        private System.Windows.Forms.Timer drawingTimer;
    }
}