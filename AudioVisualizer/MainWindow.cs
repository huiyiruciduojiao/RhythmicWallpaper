using AudioWallpaper.Entity;
using LibAudioVisualizer;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Drawing.Drawing2D;
using System.Numerics;

namespace AudioWallpaper {
    public partial class MainWindow : Form {
        private IntPtr programIntPtr = IntPtr.Zero;

        public WasapiCapture capture;             // ��Ƶ����
        public Visualizer visualizer;             // ���ӻ�
        double[]? spectrumData;            // Ƶ������

        public Color[] allColors;                 // ������ɫ

        public GeneralConfigurationObjects generalConfigurationObjects;
        public Bitmap backgroundImage;
        //��ǰ����ƫ��ֵ�������������ʾ��
        public int offsetx = 0, offsety = 0;
        public int width = 1920;
        public int height = 1080;

        private AppBarManager appBarManager;
        public delegate void FullScreenDetected(bool status);
        public event FullScreenDetected FullScreenDetectedEvent;

        public MainWindow(GeneralConfigurationObjects configuration) {
            appBarManager = new AppBarManager(Handle);
            generalConfigurationObjects = configuration;
            capture = new WasapiLoopbackCapture();          // ������Է���������
            visualizer = new Visualizer(generalConfigurationObjects.DefaultFourierVariation);               // �½�һ�����ӻ���, ��ʹ�� 256 ���������и���Ҷ�任

            allColors = GetAllHsvColors(generalConfigurationObjects.NumberOfColors);                  // ��ȡ���еĽ�����ɫ (HSV ��ɫ)

            capture.WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(8192, 2);      // ָ������ĸ�ʽ, ������, 32λ���, IeeeFloat ����, 8192������
            capture.DataAvailable += Capture_DataAvailable;                          // �����¼�



            InitializeComponent();
            Init();
            Win32.SetParent(this.Handle, programIntPtr);//����ᴥ��DisplayChange�¼����е���ѧ
        }
        /// <summary>
        /// ��ȡ������ɫ
        /// </summary>
        /// <returns>��ɫ��Ϣ</returns>
        public Color[] GetAllHsvColors(int NumberOfColors) {
            if (generalConfigurationObjects.MonochromeOrNot) {
                return new Color[] { generalConfigurationObjects.DefaultColor };
            } else if (generalConfigurationObjects.UseDefaultColorOrNOt) {
                return SystemDefaultColors();
            } else {
                Color[] colors1 = GenerateColorsBetween(generalConfigurationObjects.DefaultColor, generalConfigurationObjects.DefaultStopColor, NumberOfColors / 2);
                Color[] colors2 = GenerateColorsBetween(generalConfigurationObjects.DefaultStopColor, generalConfigurationObjects.DefaultColor, NumberOfColors / 2);
                Color[] colors = new Color[colors1.Length + colors2.Length];
                Array.Copy(colors1, 0, colors, 0, colors1.Length);
                Array.Copy(colors2, 0, colors, colors1.Length, colors2.Length);
                return colors;
            }
        }
        /// <summary>
        /// ����Ĭ����ɫ��HSV �����еĻ�����ɫ (���ͶȺ����Ⱦ�Ϊ���ֵ)
        /// </summary>
        /// <returns>���е� HSV ������ɫ(�� 256 * 6 ��, ����������������, ��ɫҲ�ὥ��)</returns>
        public static Color[] SystemDefaultColors() {
            Color[] result = new Color[256 * 6];

            for (int i = 0; i < 256; i++) {
                result[i] = Color.FromArgb(255, i, 0);
            }

            for (int i = 0; i < 256; i++) {
                result[256 + i] = Color.FromArgb(255 - i, 255, 0);
            }

            for (int i = 0; i < 256; i++) {
                result[512 + i] = Color.FromArgb(0, 255, i);
            }

            for (int i = 0; i < 256; i++) {
                result[768 + i] = Color.FromArgb(0, 255 - i, 255);
            }

            for (int i = 0; i < 256; i++) {
                result[1024 + i] = Color.FromArgb(i, 0, 255);
            }

            for (int i = 0; i < 256; i++) {
                result[1280 + i] = Color.FromArgb(255, 0, 255 - i);
            }
            return result;
        }
        /// <summary>
        /// ��ȡ������ɫ������������ɫ
        /// </summary>
        /// <param name="color1">��ʼ��ɫ</param>
        /// <param name="color2">������ɫ</param>
        /// <param name="steps">��Ҫ��ȡ����ɫ����</param>
        /// <returns></returns>
        public Color[] GenerateColorsBetween(Color color1, Color color2, int steps) {
            Color[] colors = new Color[steps];

            for (int i = 0; i < steps; i++) {
                double t = (double)i / (steps - 1); // �����ֵ�İٷֱ�
                int red = (int)(color1.R + t * (color2.R - color1.R));
                int green = (int)(color1.G + t * (color2.G - color1.G));
                int blue = (int)(color1.B + t * (color2.B - color1.B));

                colors[i] = Color.FromArgb(red, green, blue);
            }

            return colors;
        }
        /// <summary>
        /// �����������ݵ�ʱ��, ���������ӻ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Capture_DataAvailable(object? sender, WaveInEventArgs e) {
            int length = e.BytesRecorded / 4;           // ���������� (ÿһ�������� 4 �ֽ�)
            double[] result = new double[length];       // �������
            
            for (int i = 0; i < length; i++) {

                result[i] = BitConverter.ToSingle(e.Buffer, i * 4)*generalConfigurationObjects.DefaultRadical;      // ȡ������ֵ
                
                //result[i] = db;

            }
            visualizer.PushSampleData(result);          // ���µĲ����洢�� ���ӻ��� ��

        }
        double CalculateDB(double sample) {
            return 20 * Math.Log10(Math.Abs(sample) + 1e-10); // ��С�����Ա������ȡ����
        }

        /// <summary>
        /// ����ˢ��Ƶ�������Լ�ʵ��Ƶ�����ݻ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataTimer_Tick(object? sender, EventArgs e) {

            double[] newSpectrumData = visualizer.GetSpectrumData(generalConfigurationObjects.ApplyWindowFunc);         // �ӿ��ӻ����л�ȡƵ������
            newSpectrumData = Visualizer.MakeSmooth(newSpectrumData, 2);                // ƽ��Ƶ������

            if (spectrumData == null)                                        // ����Ѿ��洢��Ƶ������Ϊ��, ����µ�Ƶ������ֱ�Ӹ�ֵ��ȥ
            {
                spectrumData = newSpectrumData;
                return;
            }

            for (int i = 0; i < newSpectrumData.Length; i++)                 // �����Ƶ�����ݺ���Ƶ������֮��� "�м�ֵ"
            {
                double oldData = spectrumData[i];
                double newData = newSpectrumData[i];
                double lerpData = oldData + (newData - oldData) * generalConfigurationObjects.DefaultOffset;            // ÿһ��ִ��, Ƶ��ֵ����Ŀ��ֵ�ƶ� 20% (���̫��, ����Ч��������, ���̫С, Ƶ�׻����ӳٵĸо�)
                spectrumData[i] = lerpData;
            }
        }

        /// <summary>
        /// ����һ������� ����
        /// </summary>
        /// <param name="g">��ͼĿ��</param>
        /// <param name="down">�·���ɫ</param>
        /// <param name="up">�Ϸ���ɫ</param>
        /// <param name="spectrumData">Ƶ������</param>
        /// <param name="pointCount">������, �������</param>
        /// <param name="drawingWidth">���˵Ŀ���</param>
        /// <param name="xOffset">���˵���ʼX����</param>
        /// <param name="yOffset">���˵���ʵY����</param>
        /// <param name="scale">Ƶ�׵�����(ʹ�ø�ֵ���Է�ת����)</param>
        private void DrawGradient(Graphics g, Color down, Color up, double[] spectrumData, int pointCount, int drawingWidth, float xOffset, float yOffset, double scale) {
            GraphicsPath path = new GraphicsPath();

            PointF[] points = new PointF[pointCount + 2];
            for (int i = 0; i < pointCount; i++) {
                double x = i * drawingWidth / pointCount + xOffset;
                double y = spectrumData[i * spectrumData.Length / pointCount] * scale + yOffset;
                points[i + 1] = new PointF((float)x, (float)y);
            }

            points[0] = new PointF(xOffset, yOffset);
            points[points.Length - 1] = new PointF(xOffset + drawingWidth, yOffset);

            path.AddCurve(points);

            float upP = (float)points.Min(v => v.Y);

            if (Math.Abs(upP - yOffset) < 1)
                return;

            using Brush brush = new LinearGradientBrush(new PointF(0, yOffset), new PointF(0, upP), down, up);
            g.FillPath(brush, path);
        }

        /// <summary>
        /// ���ƽ��������
        /// </summary>
        /// <param name="g">��ͼĿ��</param>
        /// <param name="down">�·���ɫ</param>
        /// <param name="up">�Ϸ���ɫ</param>
        /// <param name="spectrumData">Ƶ������</param>
        /// <param name="stripCount">���ε�����</param>
        /// <param name="drawingWidth">��ͼ�Ŀ���</param>
        /// <param name="xOffset">��ͼ����ʼ X ����</param>
        /// <param name="yOffset">��ͼ����ʼ Y ����</param>
        /// <param name="spacing">����������֮��ļ��(����)</param>
        /// <param name="scale"></param>
        private void DrawGradientStrips(Graphics g, Color down, Color up, double[] spectrumData, int stripCount, int drawingWidth, float xOffset, float yOffset, float spacing, double scale) {
            float stripWidth = (drawingWidth - spacing * stripCount) / stripCount;
            PointF[] points = new PointF[stripCount];

            for (int i = 0; i < stripCount; i++) {
                double x = stripWidth * i + spacing * i + xOffset;
                double y = spectrumData[i * spectrumData.Length / stripCount] * scale;   // height
                points[i] = new PointF((float)x, (float)y);
            }

            float upP = (float)points.Min(v => v.Y < 0 ? yOffset + v.Y : yOffset);
            float downP = (float)points.Max(v => v.Y < 0 ? yOffset : yOffset + v.Y);

            if (downP < yOffset)
                downP = yOffset;

            if (Math.Abs(upP - downP) < 1)
                return;

            using Brush brush = new LinearGradientBrush(new PointF(0, downP), new PointF(0, upP), down, up);

            for (int i = 0; i < stripCount; i++) {
                PointF p = points[i];
                float y = yOffset;
                float height = p.Y;

                if (height < 0) {
                    y += height;
                    height = -height;
                }
                g.FillRectangle(brush, new RectangleF(p.X, generalConfigurationObjects.SmoothStripe ? y + stripWidth / 2 : y, stripWidth, height));

                //�Ƿ��Եƽ��
                if (generalConfigurationObjects.SmoothStripe) {
                    //���ƶ��˵İ�Բ��ʹ��������ƽ��
                    float radius = stripWidth / 2; // ��Բ�İ뾶
                    if (height > 0) {
                        g.FillEllipse(brush, new RectangleF(p.X, y, stripWidth, radius * 2));
                    } else {
                        g.FillEllipse(brush, new RectangleF(p.X, y + height, stripWidth, radius * 2));
                    }
                }
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="spectrumData"></param>
        /// <param name="pointCount"></param>
        /// <param name="drawingWidth"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <param name="scale"></param>
        private void DrawCurve(Graphics g, Pen pen, double[] spectrumData, int pointCount, int drawingWidth, double xOffset, double yOffset, double scale) {
            PointF[] points = new PointF[pointCount];
            for (int i = 0; i < pointCount; i++) {
                //MessageBox.Show(spectrumData[0].ToString());
                if (spectrumData[i] == 0.0) {
                    continue;
                }
                double x = i * drawingWidth / pointCount + xOffset;
                double y = spectrumData[i * spectrumData.Length / pointCount] * scale + yOffset;

                points[i] = new PointF((float)x, (float)y);
            }

            g.DrawCurve(pen, points);
        }

        /// <summary>
        /// ���򵥵�Բ������
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        /// <param name="spectrumData"></param>
        /// <param name="stripCount"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <param name="radius"></param>
        /// <param name="spacing"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        private void DrawCircleStrips(Graphics g, Brush brush, double[] spectrumData, int stripCount, double xOffset, double yOffset, double radius, double spacing, double rotation, double scale) {
            double rotationAngle = Math.PI / 180 * rotation;
            double blockWidth = MathF.PI * 2 / stripCount;           // angle
            double stripWidth = blockWidth - MathF.PI / 180 * spacing;                // angle
            PointF[] points = new PointF[stripCount];

            for (int i = 0; i < stripCount; i++) {
                double x = blockWidth * i + rotationAngle;      // angle
                double y = spectrumData[i * spectrumData.Length / stripCount] * scale;   // height
                points[i] = new PointF((float)x, (float)y);
            }

            for (int i = 0; i < stripCount; i++) {
                PointF p = points[i];
                double sinStart = Math.Sin(p.X);
                double sinEnd = Math.Sin(p.X + stripWidth);
                double cosStart = Math.Cos(p.X);
                double cosEnd = Math.Cos(p.X + stripWidth);

                PointF[] polygon = new PointF[]
                {
                    new PointF((float)(cosStart * radius + xOffset), (float)(sinStart * radius + yOffset)),
                    new PointF((float)(cosEnd * radius + xOffset), (float)(sinEnd * radius + yOffset)),
                    new PointF((float)(cosEnd * (radius + p.Y) + xOffset), (float)(sinEnd * (radius + p.Y) + yOffset)),
                    new PointF((float)(cosStart * (radius + p.Y) + xOffset), (float)(sinStart * (radius + p.Y) + yOffset)),
                };

                g.FillPolygon(brush, polygon);
            }
        }

        /// <summary>
        /// ��Բ��������
        /// </summary>
        /// <param name="g"></param>
        /// <param name="inner"></param>
        /// <param name="outer"></param>
        /// <param name="spectrumData"></param>
        /// <param name="stripCount"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <param name="radius"></param>
        /// <param name="spacing"></param>
        /// <param name="scale"></param>
        private void DrawCircleGradientStrips(Graphics g, Color inner, Color outer, double[] spectrumData, int stripCount, double xOffset, double yOffset, double radius, double spacing, double rotation, double scale) {
            double rotationAngle = Math.PI / 180 * rotation;
            double blockWidth = Math.PI * 2 / stripCount;           // angle
            double stripWidth = blockWidth - MathF.PI / 180 * spacing;                // angle
            PointF[] points = new PointF[stripCount];

            for (int i = 0; i < stripCount; i++) {
                double x = blockWidth * i + rotationAngle;      // angle
                double y = spectrumData[i * spectrumData.Length / stripCount] * scale;   // height
                points[i] = new PointF((float)x, (float)y);
            }

            double maxHeight = points.Max(v => v.Y);
            double outerRadius = radius + maxHeight;

            PointF[] polygon = new PointF[4];
            GraphicsPath path = new GraphicsPath();
            for (int i = 0; i < stripCount; i++) {
                PointF p = points[i];
                double sinStart = Math.Sin(p.X);
                double sinEnd = Math.Sin(p.X + stripWidth);
                double cosStart = Math.Cos(p.X);
                double cosEnd = Math.Cos(p.X + stripWidth);

                PointF
                    p1 = new PointF((float)(cosStart * radius + xOffset), (float)(sinStart * radius + yOffset)),
                    p2 = new PointF((float)(cosEnd * radius + xOffset), (float)(sinEnd * radius + yOffset)),
                    p3 = new PointF((float)(cosEnd * (radius + p.Y) + xOffset), (float)(sinEnd * (radius + p.Y) + yOffset)),
                    p4 = new PointF((float)(cosStart * (radius + p.Y) + xOffset), (float)(sinStart * (radius + p.Y) + yOffset));

                polygon[0] = p1;
                polygon[1] = p2;
                polygon[2] = p3;
                polygon[3] = p4;



                PointF innerP = new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                PointF outerP = new PointF((p3.X + p4.X) / 2, (p3.Y + p4.Y) / 2);

                Vector2 offset = new Vector2(outerP.X - innerP.X, outerP.Y - innerP.Y);
                if (MathF.Sqrt(offset.X * offset.X + offset.Y * offset.Y) < 1)                                // �����ˢ����֮����벻��̫С
                    continue;

                try {
                    using LinearGradientBrush brush = new LinearGradientBrush(innerP, outerP, inner, outer);        // ��������ѧ bug, ��� ���Ա�ˢ�� OutMemoryException
                    g.FillPolygon(brush, polygon);                                                            // ����ʵ���ϲ�Ӧ��������쳣...
                } catch { }
            }
        }

        /// <summary>
        /// ���򵥵�����
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        /// <param name="spectrumData"></param>
        /// <param name="stripCount"></param>
        /// <param name="drawingWidth"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <param name="spacing"></param>
        /// <param name="scale"></param>
        private void DrawStrips(Graphics g, Brush brush, double[] spectrumData, int stripCount, int drawingWidth, float xOffset, float yOffset, float spacing, double scale) {
            float stripWidth = (drawingWidth - spacing * stripCount) / stripCount;
            PointF[] points = new PointF[stripCount];

            for (int i = 0; i < stripCount; i++) {
                double x = stripWidth * i + spacing * i + xOffset;
                double y = spectrumData[i * spectrumData.Length / stripCount] * scale;   // height
                points[i] = new PointF((float)x, (float)y);
            }

            for (int i = 0; i < stripCount; i++) {
                PointF p = points[i];
                float y = yOffset;
                float height = p.Y;

                if (height < 0) {
                    y += height;
                    height = -height;
                }

                g.FillRectangle(brush, new RectangleF(p.X, y, stripWidth, height));
            }
        }

        /// <summary>
        /// ������ı߿�
        /// </summary>
        /// <param name="g"></param>
        /// <param name="inner"></param>
        /// <param name="outer"></param>
        /// <param name="area"></param>
        /// <param name="scale"></param>
        /// <param name="width"></param>
        private void DrawGradientBorder(Graphics g, Color inner, Color outer, Rectangle area, double scale, float width) {
            int thickness = (int)(width * scale);
            if (thickness < 1)
                return;

            Rectangle rect = new Rectangle(area.X, area.Y, area.Width, area.Height);

            Rectangle up = new Rectangle(rect.Location, new Size(rect.Width, thickness));
            Rectangle down = new Rectangle(new Point(rect.X, (int)(rect.X + rect.Height - scale * width)), new Size(rect.Width, thickness));
            Rectangle left = new Rectangle(rect.Location, new Size(thickness, rect.Height));
            Rectangle right = new Rectangle(new Point((int)(rect.X + rect.Width - scale * width), rect.Y), new Size(thickness, rect.Height));

            LinearGradientBrush upB = new LinearGradientBrush(up, outer, inner, LinearGradientMode.Vertical);
            LinearGradientBrush downB = new LinearGradientBrush(down, inner, outer, LinearGradientMode.Vertical);
            LinearGradientBrush leftB = new LinearGradientBrush(left, outer, inner, LinearGradientMode.Horizontal);
            LinearGradientBrush rightB = new LinearGradientBrush(right, inner, outer, LinearGradientMode.Horizontal);

            upB.WrapMode = downB.WrapMode = leftB.WrapMode = rightB.WrapMode = WrapMode.TileFlipXY;

            g.FillRectangle(upB, up);
            g.FillRectangle(downB, down);
            g.FillRectangle(leftB, left);
            g.FillRectangle(rightB, right);
        }

        int colorIndex = 0;
        double rotation = 0;
        BufferedGraphics? oldBuffer;

        private void DrawingTimer_Tick(object? sender, EventArgs e) {
            if (spectrumData == null)
                return;

            rotation += .1;
            colorIndex++;

            Color color1 = allColors[colorIndex % allColors.Length];
            Color color2 = allColors[(colorIndex + 200) % allColors.Length];

            double[] bassArea = Visualizer.TakeSpectrumOfFrequency(spectrumData, capture.WaveFormat.SampleRate, 250);       // ��Ƶ����
            double bassScale = bassArea.Average() * 100;                                                                    // �������µ����� (������)
            double extraScale = Math.Min(drawingPanel.Width, drawingPanel.Height) / 6;                                      // �������µ����� (���ϴ��ڴ�С)

            Rectangle border = new Rectangle(Point.Empty, drawingPanel.Size);

            BufferedGraphics buffer = BufferedGraphicsManager.Current.Allocate(drawingPanel.CreateGraphics(), drawingPanel.ClientRectangle);
            Graphics g = buffer.Graphics;

            if (oldBuffer != null) {
                //oldBuffer.Render(buffer.Graphics);      // �������Ҫʵ�� "��Ӱ" Ч��, ��ȡ��ע����δ���, ���ҽ� g.Clear ��Ϊ g.FillRectange(xxx, ��͸���ĺ�ɫ)
                oldBuffer.Dispose();
            }

            using Pen pen = new Pen(Color.Pink);                  // ����Ƶ���������õı�

            g.SmoothingMode = SmoothingMode.HighQuality;          // ���˺�, �Ǳ�����Ǹ�������ͼ
            g.Clear(drawingPanel.BackColor);
            if (backgroundImage != null && generalConfigurationObjects.BackImgOrNot) {
                g.DrawImage(backgroundImage, 0, 0);
            }
            if (generalConfigurationObjects.Frame) {
                DrawGradientBorder(g, Color.FromArgb(0, color1), color2, border, bassScale, drawingPanel.Width / 10);
            }
            if (generalConfigurationObjects.Stripe) {
                DrawGradientStrips(g, color1, color2, spectrumData, spectrumData.Length, drawingPanel.Width, 0, drawingPanel.Height, generalConfigurationObjects.StripeSpacing, -drawingPanel.Height * 10);
            }
            if (generalConfigurationObjects.Rotundity) {
                DrawCircleGradientStrips(g, color1, color2, spectrumData, spectrumData.Length, drawingPanel.Width / 2, drawingPanel.Height / 2, MathF.Min(drawingPanel.Width, drawingPanel.Height) / 4 + extraScale * bassScale, 1, rotation, drawingPanel.Width / 6 * 10);
            }
            if (generalConfigurationObjects.WavyLine) {
                DrawCurve(g, pen, visualizer.SampleData, visualizer.SampleData.Length, drawingPanel.Width, 0, drawingPanel.Height / 2, MathF.Min(drawingPanel.Height / 10, 100));
            }
            buffer.Render();
            oldBuffer = buffer;                                   // ����һ�� buffer (֮���Բ�ȫ��ֻʹ��һ�� Buffer ����Ϊ,,, �û����ܵ������ڴ�С, ����ÿһ֡��������Ӧ)
        }

        private void MainWindow_Load(object sender, EventArgs e) {

            SetBounds(offsetx, offsety, width, height);

            capture.StartRecording();
            dataTimer.Start();
            drawingTimer.Start();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) {
            Environment.Exit(0);
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
                        ChangeStatus(SetFrom.FullScreenWindowCount <= 0);
                        FullScreenDetectedEvent(SetFrom.FullScreenWindowCount <= 0);
                        break;

                }
            }
            base.WndProc(ref m);

        }
        public void DisposeAppBarManager() {
            appBarManager.Dispose();
        }
        public void ReShow(int x, int y, int width, int height) {
            this.width = width;
            this.height = height;
            SetBounds(x, y, width, height);
            LoadBack();
            //Win32.SetParent(this.Handle, IntPtr.Zero);
            //Win32.SetParent(this.Handle, programIntPtr);
            Refresh();
        }
        public void ReShow(GeneralConfigurationObjects generalConfigurationObjects) {
            this.generalConfigurationObjects = generalConfigurationObjects;
            LoadBack();
            allColors = GetAllHsvColors(generalConfigurationObjects.NumberOfColors);
        }
        public void ChangeStatus(bool status) {
            if (!status && generalConfigurationObjects.AutoStopWallPaper) {
                dataTimer.Stop();
                drawingTimer.Stop();
                return;
            }
            Invoke(new Action(() => {
                dataTimer.Start();
                drawingTimer.Start();
            }));

        }
        //���ر���
        public void LoadBack() {
            if (generalConfigurationObjects.BackImgOrNot && generalConfigurationObjects.BackgroundImagePath != null) {
                //BackgroundImage = Image.FromFile(generalConfigurationObjects.BackgroundImagePath);
                using (var originalImage = Image.FromFile(generalConfigurationObjects.BackgroundImagePath)) {
                    double widthScale = (double)width / originalImage.Width;
                    double heightScale = (double)height / originalImage.Height;
                    double scale = Math.Min(widthScale, heightScale);
                    int newWidth = (int)(originalImage.Width * scale);
                    int newHeight = (int)(originalImage.Height * scale);
                    int bgioffsetX = (width - newWidth) / 2;
                    int bgioffsetY = (height - newHeight) / 2;
                    backgroundImage = new Bitmap(width, height);
                    using (var graphics = Graphics.FromImage(backgroundImage)) {
                        graphics.DrawImage(originalImage, bgioffsetX, bgioffsetY, newWidth, newHeight);
                    }
                }
            } else {
                BackColor = generalConfigurationObjects.BackgroundColor;
            }
        }
        public void Init() {
            // ͨ����������һ�����ڣ����ش��ھ����
            programIntPtr = Win32.FindWindow("Progman", null);

            // ���ھ����Ч
            if (programIntPtr != IntPtr.Zero) {

                IntPtr result = IntPtr.Zero;

                // �� Program Manager ���ڷ��� 0x52c ��һ����Ϣ����ʱ����Ϊ0x3e8��1�룩��
                Win32.SendMessageTimeout(programIntPtr, 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 0x3e8, result);

                // ������������
                Win32.EnumWindows((hwnd, lParam) => {
                    // �ҵ����� SHELLDLL_DefView ������ھ���� WorkerW
                    if (Win32.FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null) != IntPtr.Zero) {
                        // �ҵ���ǰ WorkerW ���ڵģ���һ�� WorkerW ���ڡ�
                        IntPtr tempHwnd = Win32.FindWindowEx(IntPtr.Zero, hwnd, "WorkerW", null);
                        // �����������
                        Win32.ShowWindow(tempHwnd, 0);
                    }
                    return true;
                }, IntPtr.Zero);
            }
        }
    }

}