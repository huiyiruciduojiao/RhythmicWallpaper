
using AudioWallpaper.Entity;
using LibVLCSharp.Shared;

namespace AudioWallpaper {
    public partial class VideoWallpaperWindow : Form {
        private IntPtr programIntPtr = IntPtr.Zero;

        private LibVLC? libVLC = new LibVLC();
        private MediaPlayer? mediaPlayer;
        private Media? media;
        private VideoWallpaperConfigObject videoWallpaperConfig;
        private AppBarManager appBarManager;
        public delegate void FullScreenDetected(bool status);
        public event FullScreenDetected FullScreenDetectedEvent;

        public VideoWallpaperWindow(VideoWallpaperConfigObject videoWallpaperConfigObject) {
            videoWallpaperConfig = videoWallpaperConfigObject;
            appBarManager = new AppBarManager(Handle);
            InitializeComponent();
            Init();
            Win32.SetParent(Handle, programIntPtr);
            PlayerWallPaper();
        }
        protected override void WndProc(ref Message m) {
            if (appBarManager != null && m.Msg == appBarManager.uCallbackMessage) {
                switch ((int)m.WParam) {
                    case AppBarManager.ABN_FULLSCREENAPP:
                        bool isFullScreen = m.LParam != IntPtr.Zero;
                        if (isFullScreen) {
                            SetFrom.FullScreenWindowCount++;
                        } else {
                            SetFrom.FullScreenWindowCount--;
                        }

                        ChangeVideoPlayerStatus(SetFrom.FullScreenWindowCount <= 0);

                        //通知其它窗体停止渲染
                        FullScreenDetectedEvent(SetFrom.FullScreenWindowCount <= 0);
                        break;

                }
            }
            base.WndProc(ref m);
        }
        public void DisposeAppBarManager() {
            appBarManager.Dispose();
        }
        public void PlayerWallPaper() {
            if (mediaPlayer == null && libVLC != null) {
                mediaPlayer = new MediaPlayer(libVLC);
                videoView1.MediaPlayer = mediaPlayer;
                mediaPlayer.EndReached += MediaPlayer_EndReached;
            }

            try {
                mediaPlayer.SetRate((float)videoWallpaperConfig.Rate / 10f);
                mediaPlayer.Volume = videoWallpaperConfig.Volume;
                media = new Media(libVLC, new Uri(videoWallpaperConfig.Url));

                mediaPlayer.Play(media);
            } catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }
            GC.Collect();
        }

        /// <summary>
        /// 监听视频播放结束事件，重复播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediaPlayer_EndReached(object? sender, EventArgs e) {
            if (media != null && mediaPlayer != null) {
                ThreadPool.QueueUserWorkItem((p) => { mediaPlayer.Play(media); GC.Collect(); });
            }
        }
        public void ReShow(int x, int y, int width, int height) {
            SetBounds(x, y, width, height);
        }
        public void ReShow(VideoWallpaperConfigObject videoWallpaperConfigObject) {
            if (videoWallpaperConfig.Url != null && videoWallpaperConfig.Url.Equals(videoWallpaperConfigObject.Url) && media != null && mediaPlayer != null) {

                mediaPlayer.SetRate((float)videoWallpaperConfigObject.Rate / 10f);
                mediaPlayer.Volume = videoWallpaperConfigObject.Volume;
                videoWallpaperConfig = videoWallpaperConfigObject;
                return;
            }
            videoWallpaperConfig = videoWallpaperConfigObject;
            PlayerWallPaper();

        }

        /// <summary>
        /// 窗体被关闭时，关闭视频播放相关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoWallpaperWindow_FormClosing(object sender, FormClosingEventArgs e) {
            VideoDispose();
        }
        public void VideoDispose() {
            if (mediaPlayer != null) {
                mediaPlayer.EndReached -= MediaPlayer_EndReached;
                mediaPlayer.Stop();
                mediaPlayer.Dispose();
                mediaPlayer = null;
            }
            if (media != null) {
                media.Dispose();
                media = null;
            }
            if (libVLC != null) {
                libVLC.Dispose();
                libVLC = null;
            }
        }
        public void ChangeVideoPlayerStatus(bool status) {
            if (!videoWallpaperConfig.AutoStopWallPaper) {
                if (mediaPlayer != null) {
                    mediaPlayer.SetPause(false);

                }
                return;
            }
            if (mediaPlayer != null) {
                mediaPlayer.SetPause(!status);
            }
        }
        public void Init() {
            // 通过类名查找一个窗口，返回窗口句柄。
            programIntPtr = Win32.FindWindow("Progman", null);

            // 窗口句柄有效
            if (programIntPtr != IntPtr.Zero) {

                IntPtr result = IntPtr.Zero;

                // 向 Program Manager 窗口发送 0x52c 的一个消息，超时设置为0x3e8（1秒）。
                Win32.SendMessageTimeout(programIntPtr, 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 0x3e8, result);

                // 遍历顶级窗口
                Win32.EnumWindows((hwnd, lParam) => {
                    // 找到包含 SHELLDLL_DefView 这个窗口句柄的 WorkerW
                    if (Win32.FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null) != IntPtr.Zero) {
                        // 找到当前 WorkerW 窗口的，后一个 WorkerW 窗口。
                        IntPtr tempHwnd = Win32.FindWindowEx(IntPtr.Zero, hwnd, "WorkerW", null);
                        Win32.ShowWindow(tempHwnd, 0);
                    }
                    return true;
                }, IntPtr.Zero);
            }
        }


    }
}
