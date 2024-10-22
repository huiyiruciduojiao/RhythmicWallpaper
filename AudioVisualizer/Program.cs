using System.Runtime.InteropServices;

namespace AudioWallpaper {
    internal static class Program {
        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(int pfwi);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();//释放关联的控制台窗口

        [STAThread]
        static void Main(String[] args) {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            bool createdNew;
            bool DoesTheGuardianExist = false;
            // 创建一个唯一的互斥体名称，确保它是唯一的
            using (Mutex mutex = new Mutex(true, "{C8F8E5D9-6F05-4F92-BE10-DF7A4F5F97FB}", out createdNew)) {
                if (createdNew) {
                    //判断启动参数是否满足条件
                    //if (args.Length < 1) {
                    //    mutex.ReleaseMutex();
                    //    return;
                    //}
                    //if (!args[0].Equals("ManagerStart")) {
                    //    mutex.ReleaseMutex();
                    //    return;
                    //}
                    //if (!args[1].Equals("1")) {
                    //    mutex.ReleaseMutex();
                    //    return;
                    //}
#if !DEBUG
                   
                    Mutex Dmutex = new Mutex(true, "{C9F9E5D9-6F05-4F92-BE10-DF7A4F5F97FB}", out DoesTheGuardianExist);
                    if (DoesTheGuardianExist) {
                        Dmutex.ReleaseMutex();
                        Dmutex.Dispose();
                        mutex.ReleaseMutex();
                        return;
                    }
                    Dmutex.Dispose();
#endif
                    // 开启控制台
                    AllocConsole();
                    // 如果互斥体创建成功，说明当前没有其他实例在运行
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    ApplicationConfiguration.Initialize();

                    //创建窗体管理器
                    FormManager formManager = new FormManager();
                    Application.Run();
                    //释放控制台
                    FreeConsole();
                    mutex.ReleaseMutex(); // 释放互斥体
                }
            }
        }

    }
}