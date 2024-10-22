using LibAudioVisualizer;
using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Wave;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using System;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace AudioVisualizerDx {
    public partial class MainWindow : Form {
        WasapiCapture capture;             // ��Ƶ����
        Visualizer visualizer;             // ���ӻ�
        double[]? spectrumData;            // Ƶ������

        RawColor4[] allColors;                 // ������ɫ

        Factory fac;
        RenderTarget rt;

        public MainWindow() {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            

            capture = new WasapiLoopbackCapture();          // ������Է���������

            visualizer = new Visualizer(256);               // �½�һ�����ӻ���, ��ʹ�� 256 ���������и���Ҷ�任

            allColors = GetAllHsvColors();                  // ��ȡ���еĽ�����ɫ (HSV ��ɫ)

            capture.WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(8192, 2);      // ָ������ĸ�ʽ, ������, 32λ���, IeeeFloat ����, 8192������

            capture.DataAvailable += Capture_DataAvailable;                          // �����¼�

            InitializeComponent();

            fac = new Factory();

            rt = new WindowRenderTarget(fac,
                new RenderTargetProperties(
                    new PixelFormat(SharpDX.DXGI.Format.R8G8B8A8_UNorm, AlphaMode.Ignore)),
                new HwndRenderTargetProperties() {
                    Hwnd = drawingPanel.Handle,
                    PixelSize = new Size2(drawingPanel.Width, drawingPanel.Height),
                    PresentOptions = PresentOptions.None,
                });
        }

        /// <summary>
        /// ��ȡ HSV �����еĻ�����ɫ (���ͶȺ����Ⱦ�Ϊ���ֵ)
        /// </summary>
        /// <returns>���е� HSV ������ɫ(�� 256 * 6 ��, ����������������, ��ɫҲ�ὥ��)</returns>
        private RawColor4[] GetAllHsvColors() {
            RawColor4[] result = new RawColor4[256 * 6];

            for (int i = 0; i < 256; i++) {
                result[i] = new RawColor4(1, i / 255f, 0, 1);
            }

            for (int i = 0; i < 256; i++) {
                result[256 + i] = new RawColor4((255 - i) / 255f, 1, 0, 1);
            }

            for (int i = 0; i < 256; i++) {
                result[512 + i] = new RawColor4(0, 1, i / 255f, 1);
            }

            for (int i = 0; i < 256; i++) {
                result[768 + i] = new RawColor4(0, (255 - i) / 255f, 1, 1);
            }

            for (int i = 0; i < 256; i++) {
                result[1024 + i] = new RawColor4(i / 255f, 0, 1, 1);
            }

            for (int i = 0; i < 256; i++) {
                result[1280 + i] = new RawColor4(1, 0, (255 - i) / 255f, 1);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Capture_DataAvailable(object? sender, WaveInEventArgs e) {
            int length = e.BytesRecorded / 4;           // ���������� (ÿһ�������� 4 �ֽ�)
            double[] result = new double[length];       // �������

            for (int i = 0; i < length; i++)
                result[i] = BitConverter.ToSingle(e.Buffer, i * 4);      // ȡ������ֵ

            visualizer.PushSampleData(result);          // ���µĲ����洢�� ���ӻ��� ��
        }

        /// <summary>
        /// ����ˢ��Ƶ�������Լ�ʵ��Ƶ�����ݻ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataTimer_Tick(object? sender, EventArgs e) {
            double[] newSpectrumData = visualizer.GetSpectrumData("");         // �ӿ��ӻ����л�ȡƵ������
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
                double lerpData = oldData + (newData - oldData) * .2f;            // ÿһ��ִ��, Ƶ��ֵ����Ŀ��ֵ�ƶ� 20% (���̫��, ����Ч��������, ���̫С, Ƶ�׻����ӳٵĸо�)
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
        /// <param name="drawingWidth">���˵Ŀ��</param>
        /// <param name="xOffset">���˵���ʼX����</param>
        /// <param name="yOffset">���˵���ʵY����</param>
        /// <param name="scale">Ƶ�׵�����(ʹ�ø�ֵ���Է�ת����)</param>
        private void DrawGradient(RenderTarget g, RawColor4 down, RawColor4 up, double[] spectrumData, int pointCount, int drawingWidth, float xOffset, float yOffset, double scale) {
            RawVector2[] points = new RawVector2[pointCount + 2];
            for (int i = 0; i < pointCount; i++) {
                double x = i * drawingWidth / pointCount + xOffset;
                double y = spectrumData[i * spectrumData.Length / pointCount] * scale + yOffset;
                points[i + 1] = new RawVector2((float)x, (float)y);
            }

            points[0] = new RawVector2(xOffset, yOffset);
            points[points.Length - 1] = new RawVector2(xOffset + drawingWidth, yOffset);

            using PathGeometry geo = new PathGeometry(fac);
            using GeometrySink sink = geo.Open();
            sink.BeginFigure(points[0], FigureBegin.Filled);
            for (int i = 1; i < points.Length; i++)
                sink.AddLine(points[i]);
            sink.EndFigure(FigureEnd.Closed);

            float upP = (float)points.Min(v => v.Y);

            if (Math.Abs(upP - yOffset) < 1)
                return;

            LinearGradientBrushProperties linearGradientBrushProperties = new LinearGradientBrushProperties() { StartPoint = new RawVector2(0, yOffset), EndPoint = new RawVector2(0, upP) };
            using GradientStopCollection gradientStopCollection =
                new GradientStopCollection(rt, new GradientStop[] { new GradientStop() { Position = 0, Color = down }, new GradientStop() { Position = 1, Color = up } });
            using LinearGradientBrush brush = new LinearGradientBrush(rt, linearGradientBrushProperties, gradientStopCollection);

            g.FillGeometry(geo, brush);
        }

        /// <summary>
        /// ���ƽ��������
        /// </summary>
        /// <param name="g">��ͼĿ��</param>
        /// <param name="down">�·���ɫ</param>
        /// <param name="up">�Ϸ���ɫ</param>
        /// <param name="spectrumData">Ƶ������</param>
        /// <param name="stripCount">���ε�����</param>
        /// <param name="drawingWidth">��ͼ�Ŀ��</param>
        /// <param name="xOffset">��ͼ����ʼ X ����</param>
        /// <param name="yOffset">��ͼ����ʼ Y ����</param>
        /// <param name="spacing">����������֮��ļ��(����)</param>
        /// <param name="scale"></param>
        private void DrawGradientStrips(RenderTarget g, RawColor4 down, RawColor4 up, double[] spectrumData, int stripCount, int drawingWidth, float xOffset, float yOffset, float spacing, double scale) {
            float stripWidth = (drawingWidth - spacing * stripCount) / stripCount;
            RawVector2[] points = new RawVector2[stripCount];

            for (int i = 0; i < stripCount; i++) {
                double x = stripWidth * i + spacing * i + xOffset;
                double y = spectrumData[i * spectrumData.Length / stripCount] * scale;   // height
                points[i] = new RawVector2((float)x, (float)y);
            }

            float upP = (float)points.Min(v => v.Y < 0 ? yOffset + v.Y : yOffset);
            float downP = (float)points.Max(v => v.Y < 0 ? yOffset : yOffset + v.Y);

            if (downP < yOffset)
                downP = yOffset;

            if (Math.Abs(upP - downP) < 1)
                return;

            LinearGradientBrushProperties linearGradientBrushProperties = new LinearGradientBrushProperties() { StartPoint = new RawVector2(0, downP), EndPoint = new RawVector2(0, upP) };
            using GradientStopCollection gradientStopCollection =
                new GradientStopCollection(rt, new GradientStop[] { new GradientStop() { Position = 0, Color = down }, new GradientStop() { Position = 1, Color = up } });
            using Brush brush = new LinearGradientBrush(rt, linearGradientBrushProperties, gradientStopCollection);

            for (int i = 0; i < stripCount; i++) {
                RawVector2 p = points[i];
                float y = yOffset;
                float height = p.Y;

                if (height < 0) {
                    y += height;
                    height = -height;
                }

                g.FillRectangle(new RawRectangleF(p.X, y, p.X + stripWidth, y + height), brush);
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
        /// <param name="spectrumData"></param>
        /// <param name="pointCount"></param>
        /// <param name="drawingWidth"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <param name="scale"></param>
        private void DrawCurve(RenderTarget g, Brush brush, double[] spectrumData, int pointCount, int drawingWidth, double xOffset, double yOffset, double scale) {
            RawVector2[] points = new RawVector2[pointCount];
            for (int i = 0; i < pointCount; i++) {
                double x = i * drawingWidth / pointCount + xOffset;
                double y = spectrumData[i * spectrumData.Length / pointCount] * scale + yOffset;
                points[i] = new RawVector2((float)x, (float)y);
            }

            using PathGeometry geo = new PathGeometry(fac);
            using GeometrySink sink = geo.Open();
            sink.BeginFigure(points[0], FigureBegin.Filled);
            for (int i = 1; i < pointCount; i++)
                sink.AddLine(points[i]);
            sink.EndFigure(FigureEnd.Open);
            sink.Close();

            g.DrawGeometry(geo, brush);
        }

        private void DrawCircleStrips(RenderTarget g, Brush brush, double[] spectrumData, int stripCount, double xOffset, double yOffset, double radius, double spacing, double rotation, double scale) {
            double rotationAngle = Math.PI / 180 * rotation;
            double blockWidth = MathF.PI * 2 / stripCount;           // angle
            double stripWidth = blockWidth - MathF.PI / 180 * spacing;                // angle
            RawVector2[] points = new RawVector2[stripCount];

            for (int i = 0; i < stripCount; i++) {
                double x = blockWidth * i + rotationAngle;      // angle
                double y = spectrumData[i * spectrumData.Length / stripCount] * scale;   // height
                points[i] = new RawVector2((float)x, (float)y);
            }

            for (int i = 0; i < stripCount; i++) {
                RawVector2 p = points[i];
                double sinStart = Math.Sin(p.X);
                double sinEnd = Math.Sin(p.X + stripWidth);
                double cosStart = Math.Cos(p.X);
                double cosEnd = Math.Cos(p.X + stripWidth);

                RawVector2 p0 = new RawVector2((float)(cosStart * radius + xOffset), (float)(sinStart * radius + yOffset));
                RawVector2 p1 = new RawVector2((float)(cosEnd * radius + xOffset), (float)(sinEnd * radius + yOffset));
                RawVector2 p2 = new RawVector2((float)(cosEnd * (radius + p.Y) + xOffset), (float)(sinEnd * (radius + p.Y) + yOffset));
                RawVector2 p3 = new RawVector2((float)(cosStart * (radius + p.Y) + xOffset), (float)(sinStart * (radius + p.Y) + yOffset));

                using PathGeometry geo = new PathGeometry(fac);
                using GeometrySink sink = geo.Open();
                sink.BeginFigure(p0, FigureBegin.Filled);
                sink.AddLine(p1);
                sink.AddLine(p2);
                sink.AddLine(p3);
                sink.EndFigure(FigureEnd.Closed);
                sink.Close();

                g.FillGeometry(geo, brush);
            }
        }

        /// <summary>
        /// ��Բ����
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
        private void DrawCircleGradientStrips(RenderTarget g, RawColor4 inner, RawColor4 outer, double[] spectrumData, int stripCount, double xOffset, double yOffset, double radius, double spacing, double rotation, double scale) {
            double rotationAngle = Math.PI / 180 * rotation;
            double blockWidth = Math.PI * 2 / stripCount;           // angle
            double stripWidth = blockWidth - MathF.PI / 180 * spacing;                // angle
            RawVector2[] points = new RawVector2[stripCount];

            for (int i = 0; i < stripCount; i++) {
                double x = blockWidth * i + rotationAngle;      // angle
                double y = spectrumData[i * spectrumData.Length / stripCount] * scale;   // height
                points[i] = new RawVector2((float)x, (float)y);
            }

            double maxHeight = points.Max(v => v.Y);
            double outerRadius = radius + maxHeight;

            using GradientStopCollection gradientStopCollection = new GradientStopCollection(rt, new GradientStop[]
            {
                new GradientStop() { Position = 0, Color = inner },
                new GradientStop() { Position = 1, Color = outer }
            });

            RawVector2[] polygon = new RawVector2[4];
            for (int i = 0; i < stripCount; i++) {
                RawVector2 p = points[i];
                double sinStart = Math.Sin(p.X);
                double sinEnd = Math.Sin(p.X + stripWidth);
                double cosStart = Math.Cos(p.X);
                double cosEnd = Math.Cos(p.X + stripWidth);

                RawVector2
                    p0 = new RawVector2((float)(cosStart * radius + xOffset), (float)(sinStart * radius + yOffset)),
                    p1 = new RawVector2((float)(cosEnd * radius + xOffset), (float)(sinEnd * radius + yOffset)),
                    p2 = new RawVector2((float)(cosEnd * (radius + p.Y) + xOffset), (float)(sinEnd * (radius + p.Y) + yOffset)),
                    p3 = new RawVector2((float)(cosStart * (radius + p.Y) + xOffset), (float)(sinStart * (radius + p.Y) + yOffset));

                polygon[0] = p0;
                polygon[1] = p1;
                polygon[2] = p2;
                polygon[3] = p3;


                RawVector2 innerP = new RawVector2((p0.X + p1.X) / 2, (p0.Y + p1.Y) / 2);
                RawVector2 outerP = new RawVector2((p2.X + p3.X) / 2, (p2.Y + p3.Y) / 2);

                Vector2 offset = new Vector2(outerP.X - innerP.X, outerP.Y - innerP.Y);
                if (MathF.Sqrt(offset.X * offset.X + offset.Y * offset.Y) < 3)
                    continue;

                using PathGeometry geo = new PathGeometry(fac);
                using GeometrySink sink = geo.Open();
                sink.BeginFigure(p0, FigureBegin.Filled);
                sink.AddLine(p1);
                sink.AddLine(p2);
                sink.AddLine(p3);
                sink.EndFigure(FigureEnd.Closed);
                sink.Close();

                LinearGradientBrushProperties linearGradientBrushProperties =
                    new LinearGradientBrushProperties() { StartPoint = innerP, EndPoint = outerP };
                using LinearGradientBrush brush = new LinearGradientBrush(rt,
                    linearGradientBrushProperties, gradientStopCollection);

                g.FillGeometry(geo, brush);

                brush.Dispose();
            }
        }

        private void DrawStrips(RenderTarget g, Brush brush, double[] spectrumData, int stripCount, int drawingWidth, float xOffset, float yOffset, float spacing, double scale) {
            float stripWidth = (drawingWidth - spacing * stripCount) / stripCount;
            RawVector2[] points = new RawVector2[stripCount];

            for (int i = 0; i < stripCount; i++) {
                double x = stripWidth * i + spacing * i + xOffset;
                double y = spectrumData[i * spectrumData.Length / stripCount] * scale;   // height
                points[i] = new RawVector2((float)x, (float)y);
            }

            for (int i = 0; i < stripCount; i++) {
                RawVector2 p = points[i];
                float y = yOffset;
                float height = p.Y;

                if (height < 0) {
                    y += height;
                    height = -height;
                }

                g.FillRectangle(new RawRectangleF(p.X, y, p.X + stripWidth, y + height), brush);
            }
        }

        private void DrawGradientBorder(RenderTarget g, RawColor4 inner, RawColor4 outer, RawRectangleF area, double scale, float width) {
            int thickness = (int)(width * scale);

            RawRectangleF rect = new RawRectangleF(area.Left, area.Top, area.Right, area.Bottom);

            RawRectangleF up = new RawRectangleF(rect.Left, rect.Top, rect.Right, rect.Top + thickness);
            RawRectangleF down = new RawRectangleF(rect.Left, rect.Bottom - thickness, rect.Right, rect.Bottom);
            RawRectangleF left = new RawRectangleF(rect.Left, rect.Top, rect.Left + thickness, rect.Bottom);
            RawRectangleF right = new RawRectangleF(rect.Right - thickness, rect.Top, rect.Right, rect.Bottom);

            using GradientStopCollection gradientStopCollection = new GradientStopCollection(rt, new GradientStop[]
            {
                new GradientStop() { Position = 0, Color = inner },
                new GradientStop() { Position = 1, Color = outer }
            });

            using LinearGradientBrush upB = new LinearGradientBrush(rt,
                new LinearGradientBrushProperties() { StartPoint = new RawVector2(up.Left, up.Bottom), EndPoint = new RawVector2(up.Left, up.Top) }, gradientStopCollection);
            using LinearGradientBrush downB = new LinearGradientBrush(rt,
                new LinearGradientBrushProperties() { StartPoint = new RawVector2(down.Left, down.Top), EndPoint = new RawVector2(down.Left, down.Bottom) }, gradientStopCollection);
            using LinearGradientBrush leftB = new LinearGradientBrush(rt,
                new LinearGradientBrushProperties() { StartPoint = new RawVector2(left.Right, left.Top), EndPoint = new RawVector2(left.Left, left.Top) }, gradientStopCollection);
            using LinearGradientBrush rightB = new LinearGradientBrush(rt,
                new LinearGradientBrushProperties() { StartPoint = new RawVector2(right.Left, right.Top), EndPoint = new RawVector2(right.Right, right.Top) }, gradientStopCollection);

            g.FillRectangle(up, upB);
            g.FillRectangle(down, downB);
            g.FillRectangle(left, leftB);
            g.FillRectangle(right, rightB);
        }

        int colorIndex = 0;
        double rotation = 0;
        private void DrawingTimer_Tick(object? sender, EventArgs e) {
            if (spectrumData == null)
                return;

            rotation += .1;
            colorIndex++;

            RawColor4 color1 = allColors[colorIndex % allColors.Length];
            RawColor4 color2 = allColors[(colorIndex + 200) % allColors.Length];

            double[] bassArea = Visualizer.TakeSpectrumOfFrequency(spectrumData, capture.WaveFormat.SampleRate, 250);
            double bassScale = bassArea.Average() * 100;
            double extraScale = Math.Min(drawingPanel.Width, drawingPanel.Height) / 6;

            RawRectangleF border = new RawRectangleF(0, 0, drawingPanel.Width, drawingPanel.Height);
            using SolidColorBrush sampleBrush = new SolidColorBrush(rt, new RawColor4(238 / 255f, 130 / 255f, 238 / 255f, 1));

            rt.BeginDraw();
            rt.Clear(new RawColor4(0, 0, 0, 1));
            //rt.FillRectangle(border, new SolidColorBrush(rt, new RawColor4(0, 0, 0, 0.1f)));

            DrawGradientBorder(rt, new RawColor4(color1.R, color1.G, color1.B, 0), color2, border, bassScale, drawingPanel.Width / 10);

            DrawGradientStrips(rt, color1, color2, spectrumData, spectrumData.Length, drawingPanel.Width, 0, drawingPanel.Height, 3, -drawingPanel.Height * 10);
            DrawCircleGradientStrips(rt, color1, color2, spectrumData, spectrumData.Length, drawingPanel.Width / 2, drawingPanel.Height / 2, MathF.Min(drawingPanel.Width, drawingPanel.Height) / 4 + extraScale * bassScale, 1, rotation, drawingPanel.Width / 6 * 10);

            DrawCurve(rt, sampleBrush, visualizer.SampleData, visualizer.SampleData.Length, drawingPanel.Width, 0, drawingPanel.Height / 2, MathF.Min(drawingPanel.Height / 10, 100));

            rt.EndDraw();
        }

        private void MainWindow_Load(object sender, EventArgs e) {
            capture.StartRecording();
            
            dataTimer.Start();
            drawingTimer.Start();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) {
            Environment.Exit(0);
        }
    }
}