using System.Runtime.InteropServices;
using static AudioWallpaper.Win32;

namespace AudioWallpaper {
    public class AppBarManager {
        private const int ABM_NEW = 0x00000000;
        private const int ABM_REMOVE = 0x00000001;
        private const int ABM_QUERYPOS = 0x00000002;
        private const int ABM_SETPOS = 0x00000003;
        private const int ABM_GETSTATE = 0x00000004;
        private const int ABM_GETTASKBARPOS = 0x00000005;
        private const int ABM_ACTIVATE = 0x00000006;
        private const int ABM_GETAUTOHIDEBAR = 0x00000007;
        private const int ABM_SETAUTOHIDEBAR = 0x00000008;
        private const int ABM_WINDOWPOSCHANGED = 0x00000009;
        private const int ABM_SETSTATE = 0x0000000A;

        private const int ABS_AUTOHIDE = 0x0000001;
        private const int ABS_ALWAYSONTOP = 0x0000002;

        private const int ABN_STATECHANGE = 0x0000000;
        private const int ABN_POSCHANGED = 0x0000001;
        public const int ABN_FULLSCREENAPP = 0x0000002;
        private const int ABN_WINDOWARRANGE = 0x0000003;



        private IntPtr hWnd;
        public uint uCallbackMessage;

        public AppBarManager(IntPtr hWnd) {
            this.hWnd = hWnd;
            uCallbackMessage = RegisterCallbackMessage();

            APPBARDATA abd = new APPBARDATA();
            abd.cbSize = Marshal.SizeOf(typeof(APPBARDATA));
            abd.hWnd = hWnd;
            abd.uCallbackMessage = uCallbackMessage;

            SHAppBarMessage(ABM_NEW, ref abd);
        }
        public void Dispose() {
            APPBARDATA abd = new APPBARDATA();
            abd.cbSize = Marshal.SizeOf(typeof(APPBARDATA));
            abd.hWnd = hWnd;

            SHAppBarMessage(ABM_REMOVE, ref abd);
        }

        public uint RegisterCallbackMessage() {
            // 注册一个自定义的消息编号，用于AppBar消息
            string uniqueMessageString = "AppBarMessage" + Guid.NewGuid().ToString();
            return RegisterWindowMessage(uniqueMessageString);
        }

    }
}
