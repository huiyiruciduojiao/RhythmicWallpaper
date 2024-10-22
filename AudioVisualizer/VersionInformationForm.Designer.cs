namespace AudioWallpaper {
    partial class VersionInformationForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionInformationForm));
            linkLabelURLHome = new LinkLabel();
            labelAuthor = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            labelEdition = new Label();
            backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            labelCopyright = new Label();
            backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            pictureBoxCopyright = new PictureBox();
            pictureBoxIcon = new PictureBox();
            pictureBoxLogo = new PictureBox();
            linkLabelSponsor = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCopyright).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // linkLabelURLHome
            // 
            linkLabelURLHome.AutoSize = true;
            linkLabelURLHome.Font = new Font("宋体", 24F, FontStyle.Bold, GraphicsUnit.Point);
            linkLabelURLHome.Location = new Point(82, 125);
            linkLabelURLHome.Margin = new Padding(4, 0, 4, 0);
            linkLabelURLHome.Name = "linkLabelURLHome";
            linkLabelURLHome.Size = new Size(412, 33);
            linkLabelURLHome.TabIndex = 2;
            linkLabelURLHome.TabStop = true;
            linkLabelURLHome.Text = "律动壁纸——IT资源网产品";
            linkLabelURLHome.LinkClicked += linkLabelURLHome_LinkClicked;
            // 
            // labelAuthor
            // 
            labelAuthor.AutoSize = true;
            labelAuthor.Font = new Font("华文行楷", 18F, FontStyle.Regular, GraphicsUnit.Point);
            labelAuthor.Location = new Point(222, 176);
            labelAuthor.Margin = new Padding(4, 0, 4, 0);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new Size(132, 25);
            labelAuthor.TabIndex = 3;
            labelAuthor.Text = "李传玖开发";
            // 
            // labelEdition
            // 
            labelEdition.AutoSize = true;
            labelEdition.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelEdition.Location = new Point(186, 206);
            labelEdition.Margin = new Padding(4, 0, 4, 0);
            labelEdition.Name = "labelEdition";
            labelEdition.Size = new Size(77, 12);
            labelEdition.TabIndex = 4;
            labelEdition.Text = "版本号:1.2.3";
            // 
            // labelCopyright
            // 
            labelCopyright.AutoSize = true;
            labelCopyright.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelCopyright.Location = new Point(336, 206);
            labelCopyright.Margin = new Padding(4, 0, 4, 0);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(41, 12);
            labelCopyright.TabIndex = 5;
            labelCopyright.Text = "李传玖";
            // 
            // pictureBoxCopyright
            // 
            pictureBoxCopyright.Image = (Image)resources.GetObject("pictureBoxCopyright.Image");
            pictureBoxCopyright.Location = new Point(321, 206);
            pictureBoxCopyright.Name = "pictureBoxCopyright";
            pictureBoxCopyright.Size = new Size(12, 12);
            pictureBoxCopyright.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCopyright.TabIndex = 6;
            pictureBoxCopyright.TabStop = false;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Cursor = Cursors.Hand;
            pictureBoxIcon.Image = (Image)resources.GetObject("pictureBoxIcon.Image");
            pictureBoxIcon.Location = new Point(-1, 116);
            pictureBoxIcon.Margin = new Padding(4, 3, 4, 3);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(69, 50);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 1;
            pictureBoxIcon.TabStop = false;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Cursor = Cursors.Hand;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(-1, 1);
            pictureBoxLogo.Margin = new Padding(4, 3, 4, 3);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(519, 104);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            pictureBoxLogo.Click += pictureBoxLogo_Click;
            // 
            // linkLabelSponsor
            // 
            linkLabelSponsor.AutoSize = true;
            linkLabelSponsor.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabelSponsor.Location = new Point(247, 228);
            linkLabelSponsor.Name = "linkLabelSponsor";
            linkLabelSponsor.Size = new Size(53, 12);
            linkLabelSponsor.TabIndex = 7;
            linkLabelSponsor.TabStop = true;
            linkLabelSponsor.Text = "赞助开发";
            linkLabelSponsor.LinkClicked += linkLabelSponsor_LinkClicked;
            // 
            // VersionInformationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(518, 246);
            Controls.Add(linkLabelSponsor);
            Controls.Add(pictureBoxCopyright);
            Controls.Add(labelCopyright);
            Controls.Add(labelEdition);
            Controls.Add(labelAuthor);
            Controls.Add(linkLabelURLHome);
            Controls.Add(pictureBoxIcon);
            Controls.Add(pictureBoxLogo);
            Font = new Font("宋体", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VersionInformationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "关于我们";
            ((System.ComponentModel.ISupportInitialize)pictureBoxCopyright).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxLogo;
        private PictureBox pictureBoxIcon;
        private LinkLabel linkLabelURLHome;
        private Label labelAuthor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Label labelEdition;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private Label labelCopyright;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private PictureBox pictureBoxCopyright;
        private LinkLabel linkLabelSponsor;
    }
}