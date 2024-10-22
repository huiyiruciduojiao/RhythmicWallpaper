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
        public static extern bool FreeConsole();//�ͷŹ����Ŀ���̨����

        [STAThread]
        static void Main(String[] args) {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            bool createdNew;
            bool DoesTheGuardianExist = false;
            // ����һ��Ψһ�Ļ��������ƣ�ȷ������Ψһ��
            using (Mutex mutex = new Mutex(true, "{C8F8E5D9-6F05-4F92-BE10-DF7A4F5F97FB}", out createdNew)) {
                if (createdNew) {
                    //�ж����������Ƿ���������
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
                    // ��������̨
                    AllocConsole();
                    // ��������崴���ɹ���˵����ǰû������ʵ��������
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    ApplicationConfiguration.Initialize();

                    //�������������
                    FormManager formManager = new FormManager();
                    Application.Run();
                    //�ͷſ���̨
                    FreeConsole();
                    mutex.ReleaseMutex(); // �ͷŻ�����
                }
            }
        }

    }
}