using AudioWallpaper;
using AudioWallpaper.Entity;
using AudioWallpaperManager.Properties;
using NAudio.CoreAudioApi;
using System.Diagnostics;

namespace AudioWallpaperManager {

    public class Manager {
        private SetFrom setFrom = SetFrom.ShowSetFrom();
        private string WallpaperProcessName = "AudioWallpaper.exe";
        /// <summary>
        /// 壁纸进程启动参数
        /// </summary>
        private ProcessStartInfo processStartInfo = new ProcessStartInfo();
        /// <summary>
        /// 壁纸进程
        /// </summary>
        private Process process = new Process();
        /// <summary>
        /// 壁纸进程操作对象
        /// </summary>
        private WallpaperProcessOperation wallpaperProcessOperation;
        #region 系统托盘相关控件
        private ContextMenuStrip contextMenuStripSystemTray;
        private ToolStripMenuItem SettingSToolStripMenuItem;
        private ToolStripMenuItem ExitWallpaperToolStripMenuItem;
        private ToolStripMenuItem ReStartAPPRToolStripMenuItem;
        private ToolStripMenuItem AboutUsToolStripMenuItem;
        private NotifyIcon notifyIconSystemTray;
        #endregion
        public Manager() {
            //初始化
            InitializeWallpaperStartupParameters();
            //检测是否存在其他壁纸软件
            Task.Run(() => CheckOtherWallpaperSoftware());
            ChangeOutputDevices changeOutputDevices = new ChangeOutputDevices(this);
            MMDeviceEnumerator mMDevice = new MMDeviceEnumerator();
            mMDevice.RegisterEndpointNotificationCallback(changeOutputDevices);

            LoadWallpaper();
            LoadTary();
            //为设置窗体绑定保存回调事件
            setFrom.ReloadConfig += SetFrom_ReloadConfig;
          
        }
        /// <summary>
        /// 检测是否存在其他壁纸软件
        /// </summary>
        private void CheckOtherWallpaperSoftware() {
            while (true) {
                Process[] wallpaper32 = Process.GetProcessesByName("wallpaper32");
                Process[] wallpaper64 = Process.GetProcessesByName("wallpaper64");
                //HashSet<String> paths = new();
                if (wallpaper32.Length > 0) {
                    for (int i = 0; i < wallpaper32.Length; i++) {
                        Process p = wallpaper32[i];
                        p.Kill();
                    }
                }
                if (wallpaper64.Length > 0) {
                    for (int i = 0; i < wallpaper64.Length; i++) {
                        Process p = wallpaper64[i];
                        p.Kill();
                    }
                }
                Thread.Sleep(1000);

            }
        }
        public void DevicesStateChanged() {
            wallpaperProcessOperation.DeviceStateChange();
        }
        /// <summary>
        /// 设置保存回调事件
        /// </summary>
        /// <param name="configurationObject"></param>
        private void SetFrom_ReloadConfig(ConfigurationObject configurationObject) {
            //通知AudioWallpaper进程，传递config对象，让其重新加载配置
            //序列化config对象
            if (configurationObject == null) {
                return;
            }
            wallpaperProcessOperation.ReloadWallpeperConfig(configurationObject);

        }
        /// <summary>
        /// 初始化壁纸启动参数
        /// </summary>
        public void InitializeWallpaperStartupParameters() {
            //初始化启动
            processStartInfo.FileName = WallpaperProcessName;
            processStartInfo.Arguments = "ManagerStart 1";

            Process[] processes = Process.GetProcessesByName("AudioWallpaper");
            for (int i = 0; i < processes.Length; i++) {
                processes[i]?.Kill();
            }
        }
        /// <summary>
        /// 启动壁纸进程
        /// </summary>
        public void LoadWallpaper() {
            wallpaperProcessOperation = new WallpaperProcessOperation(processStartInfo);
            wallpaperProcessOperation.LoadWallpeperNamePices();
            wallpaperProcessOperation.KeepProcessAlive();
        }

        /// <summary>
        /// 加载系统托盘
        /// </summary>
        public void LoadTary() {
            System.ComponentModel.Container components = new System.ComponentModel.Container();
            contextMenuStripSystemTray = new ContextMenuStrip(components);
            SettingSToolStripMenuItem = new ToolStripMenuItem();
            ReStartAPPRToolStripMenuItem = new ToolStripMenuItem();
            ExitWallpaperToolStripMenuItem = new ToolStripMenuItem();
            AboutUsToolStripMenuItem = new ToolStripMenuItem();
            notifyIconSystemTray = new NotifyIcon(components);
            contextMenuStripSystemTray.SuspendLayout();

            // 
            // contextMenuStripSystemTray
            // 
            contextMenuStripSystemTray.ImageScalingSize = new Size(36, 36);
            contextMenuStripSystemTray.Items.AddRange(new ToolStripItem[] { SettingSToolStripMenuItem, ReStartAPPRToolStripMenuItem, ExitWallpaperToolStripMenuItem, AboutUsToolStripMenuItem });
            contextMenuStripSystemTray.Name = "contextMenuStripSystemTray";
            contextMenuStripSystemTray.Size = new Size(181, 114);
            // 
            // SettingSToolStripMenuItem
            // 
            SettingSToolStripMenuItem.Name = "SettingSToolStripMenuItem";
            SetToolStripMenuItemImage(SettingSToolStripMenuItem, Resources.setting, 16, 16);
            SettingSToolStripMenuItem.Size = new Size(180, 22);
            SettingSToolStripMenuItem.Text = "设置&(S)";
            SettingSToolStripMenuItem.Click += SettingSToolStripMenuItem_Click;
            // 
            // ReStartAPPRToolStripMenuItem
            // 
            ReStartAPPRToolStripMenuItem.Name = "ReStartAPPRToolStripMenuItem";
            SetToolStripMenuItemImage(ReStartAPPRToolStripMenuItem, Resources.reboot, 16, 16);
            ReStartAPPRToolStripMenuItem.Size = new Size(180, 22);
            ReStartAPPRToolStripMenuItem.Text = "重启APP&(R)";
            ReStartAPPRToolStripMenuItem.Click += ReStartAPPRToolStripMenuItem_Click;
            // 
            // ExitWallpaperToolStripMenuItem
            // 
            ExitWallpaperToolStripMenuItem.Name = "ExitWallpaperToolStripMenuItem";
            SetToolStripMenuItemImage(ExitWallpaperToolStripMenuItem, Resources.exit, 16, 16);
            ExitWallpaperToolStripMenuItem.Size = new Size(180, 22);
            ExitWallpaperToolStripMenuItem.Text = "退出壁纸&(E)";
            ExitWallpaperToolStripMenuItem.Click += ExitWallpaperToolStripMenuItem_Click;
            // 
            // AboutUsToolStripMenuItem
            // 
            AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem";
            SetToolStripMenuItemImage(AboutUsToolStripMenuItem, Resources.VersionInformation, 16, 16);
            AboutUsToolStripMenuItem.Size = new Size(180, 22);
            AboutUsToolStripMenuItem.Text = "关于我们&(A)";
            AboutUsToolStripMenuItem.Click += AboutUsToolStripMenuItem_Click;
            // 
            // notifyIconSystemTray
            // 
            notifyIconSystemTray.ContextMenuStrip = contextMenuStripSystemTray;
            notifyIconSystemTray.Icon = Resources.FM_channel;
            notifyIconSystemTray.Text = "律动壁纸";
            notifyIconSystemTray.Visible = true;
            contextMenuStripSystemTray.ResumeLayout(false);
        }
        #region 托盘事件处理
        private void ExitWallpaperToolStripMenuItem_Click(object sender, EventArgs e) {
            wallpaperProcessOperation.UnKeepProcessAlive();
            Environment.Exit(0);
        }

        private void SettingSToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!setFrom.Visible) {
                setFrom.ShowDialog();
            } else {
                setFrom.WindowState = FormWindowState.Normal;
                setFrom.Activate();
            }

        }

        private void ReStartAPPRToolStripMenuItem_Click(object sender, EventArgs e) {
            wallpaperProcessOperation.UnKeepProcessAlive();
            wallpaperProcessOperation.KeepProcessAlive();

        }

        private void AboutUsToolStripMenuItem_Click(object sender, EventArgs e) {
            new VersionInformationForm().ShowDialog();
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
    }
}
