using System.Runtime.InteropServices;

namespace AudioVisualizer {
    internal static class Program {
        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(int pfwi);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            bool createdNew;
            // 创建一个唯一的互斥体名称，确保它是唯一的
            using (Mutex mutex = new Mutex(true, "{C8F8E5D9-6F05-4F92-BE10-DF7A4F5F97FB}", out createdNew)) {
                if (createdNew) {
                    // 如果互斥体创建成功，说明当前没有其他实例在运行
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    ApplicationConfiguration.Initialize();
                    Application.Run(new MainWindow());
                    mutex.ReleaseMutex(); // 释放互斥体
                }
            }
        }
    }
}