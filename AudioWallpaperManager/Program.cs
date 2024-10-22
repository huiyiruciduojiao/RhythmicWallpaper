using System.Runtime.InteropServices;

namespace AudioWallpaperManager {
    internal static class Program {
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();//�ͷŹ����Ŀ���̨����
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            bool createdNew;
            // ����һ��Ψһ�Ļ��������ƣ�ȷ������Ψһ��
            using (Mutex mutex = new Mutex(true, "{C9F9E5D9-6F05-4F92-BE10-DF7A4F5F97FB}", out createdNew)) {
                if (createdNew) {
                    // To customize application configuration such as set high DPI settings or default font,
                    // see https://aka.ms/applicationconfiguration.
                    ApplicationConfiguration.Initialize();
#if DEBUG
                    AllocConsole();
#endif
                    //�����������������
                    new Manager();
                    Application.Run();
#if DEBUG
                    FreeConsole();
#endif
                    mutex.ReleaseMutex(); // �ͷŻ�����
                }
            }
        }
    }
}