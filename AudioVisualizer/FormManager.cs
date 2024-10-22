using AudioWallpaper.Entity;
using Microsoft.Win32;
using NAudio.Wave;
using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace AudioWallpaper {
    public class FormManager {
        public GetScreenInfo getScreenInfo = new GetScreenInfo();
        public Dictionary<string, MainWindow> mainWindowForms = new();
        public Dictionary<string, VideoWallpaperWindow> videoWallpaperForms = new();
        //public int ScreenCount = 0;
        public Screen[] OldScreens;
        public static int restart = 1;
        public static bool isCreateWindow = false;
        NamedPipeServerStream WallpaperReloadConfigPipe = new NamedPipeServerStream("WallpaperReloadConfigPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
        public FormManager() {
            //Console.WriteLine("窗体管理器被加载");
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            isCreateWindow = true;
            LoadWindowSet();
            LoadNamePipes();
            //Console.WriteLine($"线程ID{Thread.CurrentThread.ManagedThreadId}");

        }
        public void LoadNamePipes() {
            BinaryFormatter formatter = new BinaryFormatter();
            WallpaperReloadConfigPipe.WaitForConnectionAsync().ContinueWith(s => {
                new Task(() => {
                    while (true) {
                        byte[] bytes = new byte[2048];
                        int bytesRead = WallpaperReloadConfigPipe.Read(bytes, 0, bytes.Length);
                        using (MemoryStream memoryStream = new MemoryStream()) {
                            memoryStream.Write(bytes, 0, bytesRead);
                            memoryStream.Position = 0;
                            ConfigurationObject configurationObject = (ConfigurationObject)formatter.Deserialize(memoryStream);
                            if (configurationObject != null) {
                                SetFrom_ReloadConfig(configurationObject);
                            }

                        }
                    }
                }).Start();

            });

        }

        private void SetFrom_ReloadConfig(ConfigurationObject configurationObject) {
            if (configurationObject.DeviceStateChange) {
                foreach (var item in mainWindowForms) {
                    item.Value.capture.StopRecording();
                    item.Value.capture.DataAvailable += null;
                    item.Value.capture.Dispose();
                    item.Value.capture = new WasapiLoopbackCapture();
                    item.Value.capture.WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(8192, 1);
                    item.Value.capture.DataAvailable += item.Value.Capture_DataAvailable;
                    item.Value.capture.StartRecording();

                }
                return;
            }

            GeneralConfigurationObjects generalConfigurationObjects = configurationObject.GeneralConfigurationObjects;
            MainWindowReLoadConfig(generalConfigurationObjects);


            VideoWallpaperConfigObject videoWallpaperConfigObject = configurationObject.VideoWallpaperConfigObject;
            VideoWindowReLoadConfig(videoWallpaperConfigObject);

            WinStatusChangeEvent(SetFrom.FullScreenWindowCount <= 0);
        }
        private void WinStatusChangeEvent(bool status) {
            //循环所有窗体
            foreach (var item in mainWindowForms) {
                item.Value.ChangeStatus(status);
            }
            foreach (var item in videoWallpaperForms) {
                item.Value.ChangeVideoPlayerStatus(status);
            }
        }
        
        private void MainWindowReLoadConfig(GeneralConfigurationObjects generalConfigurationObjects) {
            String wsn = generalConfigurationObjects.SettingForScreenName;
            //获取对应的form
            MainWindow? w = mainWindowForms.GetValueOrDefault(wsn);
            if (w == null && generalConfigurationObjects.IsShow) {
                //return;
                Process.GetCurrentProcess()?.Kill();
                return;
            }
            if (w == null) {
                return;
            }
            if (!generalConfigurationObjects.IsShow) {
                w.Invoke(() => {
                    w.DisposeAppBarManager();
                    w.Dispose();
                    w.Close();
                    mainWindowForms.Remove(wsn);
                });
                return;
            }
            //使用统一配置
            if (generalConfigurationObjects.IsUsingUnifiedConfiguration) {
                foreach (var item in mainWindowForms) {
                    item.Value.generalConfigurationObjects.IsUsingUnifiedConfiguration = true;
                    item.Value.ReShow(generalConfigurationObjects);
                }
                return;
            }

            w.ReShow(generalConfigurationObjects);
        }
        private void VideoWindowReLoadConfig(VideoWallpaperConfigObject videoWallpaperConfigObject) {
            String vsn = videoWallpaperConfigObject.SettingForScreenName;
            VideoWallpaperWindow? v = videoWallpaperForms.GetValueOrDefault(vsn);

            if (v == null && videoWallpaperConfigObject.IsShow) {
                Process.GetCurrentProcess()?.Kill();
                return;
            }
            if (v == null) {
                return;
            }
            if (!videoWallpaperConfigObject.IsShow) {
                v.Invoke(() => {
                    v.DisposeAppBarManager();
                    v.VideoDispose();
                    v.Dispose();
                    v.Close();

                    videoWallpaperForms.Remove(vsn);
                });
                return;
            }
            v.ReShow(videoWallpaperConfigObject);

        }
        public void LoadWindowSet() {
            //加载窗体设置
            //Console.WriteLine("窗体管理器正在初始化");
            ReCreateWindow();

        }
        private void SystemEvents_DisplaySettingsChanged(object? sender, EventArgs e) {
            if (isCreateWindow) {

                isCreateWindow = false;
                //Console.WriteLine("????");
                return;
            }
            SystemEvents.DisplaySettingsChanging -= SystemEvents_DisplaySettingsChanged;
            Process.GetCurrentProcess()?.Kill();
        }
        private bool IsDisplayChange() {
            Screen[] screens = getScreenInfo.GetAllScreen();
            if (screens.Length != OldScreens.Length) {
                return true;
            }
            for (int i = 0; i < screens.Length; i++) {
                for (int j = 0; j < OldScreens.Length; j++) {
                    if (screens[i].DeviceName.Equals(OldScreens[j].DeviceName)) {
                        //这是同一个显示器
                        if (screens[i].Bounds != OldScreens[j].Bounds) {
                            return true;
                        }
                        if (screens[i].WorkingArea != OldScreens[j].WorkingArea) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public void CreateWindow() {
            //获取显示器数量决定是否继续创建窗体
            Screen[] screens = getScreenInfo.GetAllScreen();
            OldScreens = screens;
            for (int i = 0; i < screens.Length; i++) {
                Screen screen = screens[i];
                GeneralConfigurationObjects configurationObject = new GeneralConfigurationObjects().LoadConfiguration(SetFrom.ConfigFilePath, screen.DeviceName);
                if (configurationObject.IsShow) {
                    MainWindow mainWindow = new MainWindow(configurationObject);
                    mainWindow.FullScreenDetectedEvent += WinStatusChangeEvent;
                    mainWindowForms.Add(screen.DeviceName, mainWindow);
                    mainWindow.Show();
                    continue;
                }
                VideoWallpaperConfigObject videoWallpaperConfigObject = new VideoWallpaperConfigObject().LoadConfig(SetFrom.ConfigFilePath, screen.DeviceName);
                if (videoWallpaperConfigObject.IsShow) {
                    //Console.WriteLine("视频窗体被创建");
                    VideoWallpaperWindow videoWallpaperWindow = new VideoWallpaperWindow(videoWallpaperConfigObject);
                    videoWallpaperWindow.FullScreenDetectedEvent += WinStatusChangeEvent;
                    videoWallpaperForms.Add(screen.DeviceName, videoWallpaperWindow);
                    videoWallpaperWindow.Show();

                }
            }
        }
        public void CorrectFormSizeAndPosition() {
            foreach (var item in mainWindowForms) {
                String key = item.Key;
                Point point = new Point(0, 0);
                Screen? screen = getScreenInfo.GetScreenForName(key);
                if (screen != null) {
                    Size size = getScreenInfo.GetScreenScale(screen);
                    point = getScreenInfo.GetOffsetCorrection(screen);
                    //Console.WriteLine($"窗体{item.Key}该显示的位置{point}");
                    //Console.WriteLine($"窗体{item.Key}的大小{size}");
                    //Console.WriteLine($"窗体{item.Key}的实际位置和大小{item.Value.Location}");
                    item.Value.ReShow(point.X, point.Y, size.Width, size.Height);
                }
            }
            foreach (var item in videoWallpaperForms) {
                String key = item.Key;
                Point point = new Point(0, 0);
                Screen? screen = getScreenInfo.GetScreenForName(key);
                if (screen != null) {
                    Size size = getScreenInfo.GetScreenScale(screen);
                    point = getScreenInfo.GetOffsetCorrection(screen);
                    //Console.WriteLine($"窗体{item.Key}该显示的位置{point}");
                    //Console.WriteLine($"窗体{item.Key}的大小{size}");
                    //Console.WriteLine($"窗体{item.Key}的实际位置和大小{item.Value.Location}");
                    item.Value.ReShow(point.X, point.Y, size.Width, size.Height);
                }
            }
        }
        public void ReCreateWindow() {
            //关闭所有窗体
            foreach (var item in mainWindowForms) {
                item.Value.Invoke(() => {
                    item.Value.DisposeAppBarManager();
                    item.Value.Dispose();
                    item.Value.Close();
                });
            }
            foreach (var item in videoWallpaperForms) {
                item.Value.Invoke(() => {
                    item.Value.DisposeAppBarManager();
                    item.Value.VideoDispose();
                    item.Value.Dispose();
                    item.Value.Close();
                });
            }
            mainWindowForms.Clear();
            videoWallpaperForms.Clear();
            //加载窗体
            CreateWindow();
            CorrectFormSizeAndPosition();
        }
    }
}
