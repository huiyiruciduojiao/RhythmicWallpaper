using System.Runtime.InteropServices;

namespace AudioWallpaper {
    public class GetScreenInfo {

        public GetScreenInfo() {

        }

        public string GetScreenName(Control obj) {
            string name = null;
            if (obj != null) {
                name = Screen.FromControl(obj).DeviceName;
            }
            return name;
        }
        public Screen GetScreen(Control obj) {
            Screen screen = null;
            if (obj != null) {
                screen = Screen.FromControl(obj);
            }
            return screen;
        }
        public Screen? GetScreenForName(String name) {
            foreach (Screen s in GetAllScreen()) {
                if (s.DeviceName.Equals(name)) {
                    return s;
                }
            }
            return null;
        }
        public int GetScreenCount() {

            return Screen.AllScreens.Count();

        }
        public Screen[] GetAllScreen() {
            return Screen.AllScreens;
        }
        /// <summary>
        /// 获取显示器X，Y值基于窗体显示的修正值
        /// </summary>
        /// <param name="screen">显示器</param>
        /// <returns>修正后窗体显示基准点</returns>
        public Point GetOffsetCorrection(Screen screen) {
            //返回的基准点
            Point point = new Point();
            //所有显示器对象
            Screen[] screens = GetAllScreen();
            //主显示器
            Screen MainScreen = Screen.PrimaryScreen;
            int offsetX = 0;
            int offsetY = 0;
            //位于主显示器左边最远的显示器距离
            int minX = 0;
            int minY = 0;

            foreach (Screen sc in screens) {
                if (sc.Bounds.Location.X < minX) {
                    minX = sc.Bounds.Location.X;
                }
                if (sc.Bounds.Location.Y < 0) {
                    minY = sc.Bounds.Location.Y;
                }
            }
            //计算传入的显示器距离主显示器位置
            if (screen.Bounds.Location.X < 0) {
                //该显示器在主显示器的左边
                offsetX = Math.Abs(screen.Bounds.Location.X);
                point.X = Math.Abs(minX) - offsetX;
            }
            if (screen.Bounds.Location.Y < 0) {
                //该显示器在主显示器的上边
                offsetY = Math.Abs(screen.Bounds.Location.Y);
                point.Y = Math.Abs(minY) - offsetY;
            }
            if (screen.Bounds.Location.X >= 0) {
                //在主显示器的右边或者，它就是主显示器
                //偏移主显示器缩放带来的误差
                point.X = Math.Abs(minX) + screen.Bounds.Location.X;
            }
            if (screen.Bounds.Location.Y >= 0) {
                //在主显示器的下边
                point.Y = Math.Abs(minY) + screen.Bounds.Location.Y;
            }

            //Console.WriteLine($"屏幕的位置{screen.Bounds.Location}");
            //Console.WriteLine($"Abs miX ：{Math.Abs(minX)}");
            //Console.WriteLine($"offsetx {offsetX}");
            //Console.WriteLine($"新算法结果：{point}");


            return point;

        }
        [DllImport("user32.dll")]
        private static extern uint GetDpiForWindow([In] IntPtr hmonitor);

        #region Win32 API

        [DllImport("gdi32.dll", EntryPoint = "GetDeviceCaps")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        [DllImport("gdi32.dll", EntryPoint = "CreateDC")]
        static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

        #endregion
        public Size GetScreenScale(Screen screen) {
            IntPtr hdc = CreateDC(screen.DeviceName, null, null, IntPtr.Zero);
            float yPixel = GetDeviceCaps(hdc, 117);
            float xPixel = GetDeviceCaps(hdc, 118);
            ReleaseDC(IntPtr.Zero, hdc);

            return new Size((int)xPixel, (int)yPixel);
        }


    }

}
