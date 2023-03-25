using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wu.Wpf.ControlLibrary
{
    /// <summary>
    /// 圆形环绕文本
    /// </summary>
    public partial class RingText : UserControl
    {
        public RingText()
        {
            InitializeComponent();
            this.SizeChanged += RingText_SizeChanged;               //尺寸改变时重绘
        }

        private void RingText_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RefreshLabels();
        }

        #region 依赖属性
        [Category("Wu")]
        [Description("文字颜色")]
        public new Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }
        public static new readonly DependencyProperty ForegroundProperty =
                    DependencyProperty.Register("Foreground", typeof(Brush), typeof(RingText),
                        new FrameworkPropertyMetadata(Brushes.MediumPurple, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(OnParamChanged)));

        [Category("Wu")]
        [Description("文字第一个字所在的角度 0°在X轴上")]
        public double CenterTo
        {
            get { return (double)GetValue(CenterToProperty); }
            set { SetValue(CenterToProperty, value); }
        }
        public static readonly DependencyProperty CenterToProperty =
                    DependencyProperty.Register("CenterTo", typeof(double), typeof(RingText),
                        new FrameworkPropertyMetadata(0.0,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnParamChanged)));

        [Category("Wu")]
        [Description("文本")]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
                    DependencyProperty.Register("Text", typeof(string), typeof(RingText),
                        new FrameworkPropertyMetadata("123中文abc123中文abc",
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnParamChanged)));

        [Category("Wu")]
        [Description("尺寸比例")]
        public double SizeRatio
        {
            get { return (double)GetValue(SizeRatioProperty); }
            set { SetValue(SizeRatioProperty, value); }
        }
        public static readonly DependencyProperty SizeRatioProperty =
                    DependencyProperty.Register("SizeRatio", typeof(double), typeof(RingText),
                        new FrameworkPropertyMetadata(0.9, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(OnParamChanged)));

        [Category("Wu")]
        [Description("字体大小")]
        public new double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        public static new readonly DependencyProperty FontSizeProperty =
                    DependencyProperty.Register("FontSize", typeof(double), typeof(RingText),
                        new FrameworkPropertyMetadata(18d, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(OnParamChanged)));

        [Category("Wu")]
        [Description("文字间隔的比例系数 默认1 小于0时文字反序显示")]
        public double IntervalRatio
        {
            get { return (double)GetValue(IntervalRatioProperty); }
            set { SetValue(IntervalRatioProperty, value); }
        }
        public static readonly DependencyProperty IntervalRatioProperty =
                    DependencyProperty.Register("IntervalRatio", typeof(double), typeof(RingText),
                        new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(OnParamChanged)));

        [Category("Wu")]
        [Description("是否在一个圆环上均匀放置文本")]
        public bool IsARing
        {
            get { return (bool)GetValue(IsARingProperty); }
            set { SetValue(IsARingProperty, value); }
        }
        public static readonly DependencyProperty IsARingProperty =
                    DependencyProperty.Register("IsARing", typeof(bool), typeof(RingText),
                        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(OnParamChanged)));

        /// <summary>
        /// 参数修改时重绘
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnParamChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RingText self)
            {
                self.RefreshLabels();
            }
        }
        #endregion


        /// <summary>
        /// 重绘标签
        /// </summary>
        private void RefreshLabels()
        {
            int count = Text.Length;//文字数量
            if (count.Equals(0))
            {
                return;
            }
            //控件宽高
            double width = ActualWidth;
            double height = ActualHeight;
            if (width <= 0 || height <= 0)
            {
                container.Children.Clear();//清空
                return;
            }

            Point ctrlCenter = new(width / 2.0, height / 2.0);//控件中心
            double angle = CenterTo;//文字指向圆环的角度
            double lastAngle = 0;//上一个文字的角度
            double value = 0;
            Point p;

            double radius = Math.Min(width, height) / 2.0 * SizeRatio;//圆环的半径
            container.Children.Clear();//清空
            //遍历Text
            for (int i = 0; i < Text.Length; i++)
            {
                char item = Text[i];
                var txt = new TextBlock
                {
                    Text = item.ToString(),
                    FontSize = FontSize,
                    Foreground = Foreground,
                    RenderTransformOrigin = new Point(0.5, 0.5), //以文字自身为旋转中心
                    //RenderTransform = new RotateTransform(angle + 90),//文字本身的旋转角度
                    //Background = Brushes.Black,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center
                };

                container.Children.Add(txt);//添加进容器
                txt.UpdateLayout();

                if (IsARing)
                {
                    angle = 360.0 / count * i;
                }
                else
                {
                    //该字占的角度
                    double currentAngle = Math.Atan(txt.ActualWidth / (radius - txt.ActualHeight / 2)) * R2A * 2;
                    //第一个字不需要旋转自身一般的角度
                    if (i == 0)
                    {
                        angle = CenterTo % 360;//文字指向的角度为起始角度
                    }
                    else
                    {
                        angle += lastAngle * IntervalRatio / 2 + currentAngle * IntervalRatio / 2;//文字指向的角度 计算当前文字指向的角度
                    }
                    lastAngle = currentAngle;//上一个字占的角度
                }

                txt.RenderTransform = new RotateTransform(angle + 90);//文字本身的旋转角度

                //设置文本在容器中的位置
                p = PolarToCartesian(angle, radius);
                Canvas.SetLeft(txt, ctrlCenter.X + p.X - txt.ActualWidth / 2.0);
                Canvas.SetTop(txt, ctrlCenter.Y + p.Y - txt.ActualHeight / 2.0);
            }
        }

        const double R2A = 180.0 / Math.PI;//弧度转角度系数
        const double A2R = Math.PI / 180.0;//角度转弧度系数

        /// <summary>
        /// 极坐标转笛卡尔坐标
        /// </summary>
        /// <param name="angle">角度</param>
        /// <param name="radius">半径</param>
        /// <returns></returns>
        public static Point PolarToCartesian(double angle, double radius)
        {
            var rad = angle * A2R;
            var x = radius * Math.Cos(rad);
            var y = radius * Math.Sin(rad);
            return new Point(x, y);
        }
    }
}
