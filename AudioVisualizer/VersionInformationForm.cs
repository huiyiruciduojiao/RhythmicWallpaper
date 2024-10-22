namespace AudioWallpaper {
    public partial class VersionInformationForm : Form {
        public VersionInformationForm() {
            InitializeComponent();
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("explorer.exe", "https://www.itziyuanwang.top/");
        }

        private void linkLabelURLHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("explorer.exe", "https://www.itziyuanwang.top/");
        }

        private void linkLabelSponsor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("explorer.exe", "https://www.itziyuanwang.top/supportOur.php");
        }
    }
}
