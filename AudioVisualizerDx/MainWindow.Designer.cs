using System.Windows.Forms;

namespace AudioVisualizerDx {
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
            dataTimer = new Timer(components);
            drawingTimer = new Timer(components);
            SuspendLayout();
            // 
            // drawingPanel
            // 
            drawingPanel.Location = new System.Drawing.Point(207, 133);
            drawingPanel.Margin = new Padding(2);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new System.Drawing.Size(379, 231);
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
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.DimGray;
            ClientSize = new System.Drawing.Size(701, 452);
            Controls.Add(drawingPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "Music Visualizer (DX)";
            FormClosed += MainWindow_FormClosed;
            Load += MainWindow_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel drawingPanel;
        private Timer dataTimer;
        private Timer drawingTimer;
    }
}