using System.Runtime.InteropServices;

namespace AudioWallpaperManager {
    internal static class Program {
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();//释放关联的控制台窗口
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            bool createdNew;
            // 创建一个唯一的互斥体名称，确保它是唯一的
            using (Mutex mutex = new Mutex(true, "{C9F9E5D9-6F05-4F92-BE10-DF7A4F5F97FB}", out createdNew)) {
                if (createdNew) {
                    // To customize application configuration such as set high DPI settings or default font,
                    // see https://aka.ms/applicationconfiguration.
                    ApplicationConfiguration.Initialize();
#if DEBUG
                    AllocConsole();
#endif
                    //创建窗体管理器对象
                    new Manager();
                    Application.Run();
#if DEBUG
                    FreeConsole();
#endif
                    mutex.ReleaseMutex(); // 释放互斥体
                }
            }
        }
    }
}