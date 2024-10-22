using AudioWallpaper.Entity;
using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.Serialization.Formatters.Binary;

namespace AudioWallpaperManager {
    public class WallpaperProcessOperation {
        /// <summary>
        /// 壁纸进程通信管道
        /// </summary>
        NamedPipeClientStream wallpaperPice = new NamedPipeClientStream(".", "WallpaperReloadConfigPipe", PipeDirection.InOut, PipeOptions.Asynchronous);
        /// <summary>
        /// 管道是否连接成功
        /// </summary>
        private bool IsConnected = false;
        private ProcessStartInfo ProcessStartInfo;
        private Process? Process;
        //private Process? Process;
        private bool IsKeppProcessAlive = false;

        public WallpaperProcessOperation(ProcessStartInfo ProcessStartInfo) {
            this.ProcessStartInfo = ProcessStartInfo;
            InitializeProcessObject();
        }
        private void InitializeProcessObject() {
            Process = new Process();
            Process.StartInfo = ProcessStartInfo;
            Process.EnableRaisingEvents = true;
            //Process.StartInfo.RedirectStandardOutput = true;
            Process.Exited += exitedEvent;
            Process.Start();

        }
        public void KeepProcessAlive() {
            if (Process == null) {
                InitializeProcessObject();
            }
            IsKeppProcessAlive = true;
        }
        public void UnKeepProcessAlive() {
            IsKeppProcessAlive = false;
            Process?.Kill();
            Process?.Dispose();
            Process = null;
        }
        private void exitedEvent(object? sender, EventArgs e) {
            if (IsKeppProcessAlive) {
                Process?.Kill();
                Process?.Dispose();
                wallpaperPice.Close();
                wallpaperPice.Dispose();
                wallpaperPice = new NamedPipeClientStream(".", "WallpaperReloadConfigPipe", PipeDirection.InOut, PipeOptions.Asynchronous);
                Process = new Process();
                Process.StartInfo = ProcessStartInfo;
                Process.EnableRaisingEvents = true;
                Process.Exited += exitedEvent;
                Process.Start();
                LoadWallpeperNamePices();
            }
        }

        /// <summary>
        /// 初始化壁纸通信管道
        /// </summary>
        public void LoadWallpeperNamePices() {
            if (wallpaperPice.IsConnected) {
                return;
            }
            wallpaperPice.Connect();
        }
        public void DeviceStateChange() {
            ConfigurationObject configuration = new ConfigurationObject();
            configuration.DeviceStateChange = true;
            ReloadWallpeperConfig(configuration);
        }
        public void ReloadWallpeperConfig(ConfigurationObject configurationObject) {
            BinaryFormatter formatter = new BinaryFormatter();
            using MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, configurationObject);
            SendWallpeperData(memoryStream.ToArray());
            memoryStream.Close();
        }
        private void SendWallpeperData(byte[] bytes) {
            LoadWallpeperNamePices();
            wallpaperPice.WriteAsync(bytes, 0, bytes.Length);
        }

    }
}
