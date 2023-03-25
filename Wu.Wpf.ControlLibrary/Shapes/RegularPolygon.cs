using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Wu.Wpf.ControlLibrary.Shapes
{
    /// <summary>
    /// 正多边形 基础图形
    /// </summary>
    public class RegularPolygon : Shape
    {

        static RegularPolygon()
        {
            FillProperty.OverrideMetadata(typeof(RegularPolygon),new FrameworkPropertyMetadata(Brushes.MediumPurple));
        }


        public RegularPolygon()
        {
            SetCurrentValue(StrokeThicknessProperty, 0d);
            SetCurrentValue(MinWidthProperty, 100d);
            SetCurrentValue(MinHeightProperty, 100d);
        }

        protected override Geometry DefiningGeometry => GeometryGenerator();

        private double gh3 = Math.Sqrt(3);//根号3

        /// <summary>
        /// 生成图形
        /// </summary>
        /// <returns></returns>
        private Geometry GeometryGenerator()
        {
            StreamGeometry stream = new();
            using (StreamGeometryContext geo = stream.Open())
            {
                #region 计算中心点的绝对坐标
                if (IsRelativeOrigin)
                    AbsOrigin = new Point(Origin.X * ActualWidth, Origin.Y * ActualHeight);
                else
                    AbsOrigin = new Point(Origin.X, Origin.Y);
                double ctrlLength = Math.Min(ActualHeight, ActualWidth) / 2;                  //控件宽高的一半
                double len = ctrlLength * (SizeRatio < 0 ? 0 : SizeRatio > 1 ? 1 : SizeRatio);//多边形中心到顶点的距离
                #endregion

                var side = Sides > 2 ? Sides : 3;                        //多边形边数 至少3条边
                var pStart = new Point(AbsOrigin.X,-len + AbsOrigin.Y);//绘图起点在Y轴上
                var peakAng = 360.0 / side;                            //多边形两顶点与原点的角度 
                double ratio = Math.Abs(CornerRatio) % side;                //导角的占比∈[0,边数]
                double angle = peakAng * ratio / 2;                         //导角角度的一半

                #region 点位生成
                //先定义第一个顶点导角后的两个点位
                List<Point> points = new()
                {
                    PointRotate(AbsOrigin, pStart, -angle), //第一点 第一个顶点的导角左边
                    PointRotate(AbsOrigin, pStart, angle)  //第二点 第一个顶点的导角右边
                };

                //从第三点开始补点位
                for (int i = 3; i <= side * 2; i++)
                {
                    points.Add(PointRotate(AbsOrigin, points[points.Count-2], peakAng));//下一个点相对前前个点旋转获得
                }
                #endregion

                double cR = (Math.Abs(points[1].X - points[0].X)) / 2 / Math.Sin(peakAng / 2 * Math.PI / 180);//导角圆的半径
                Size size = new(cR, cR);                                                                   //导角圆的尺寸

                #region 绘图
                //绘制起点
                geo.BeginFigure(points[0], true, true);

                for (int i = 1; i < points.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        geo.ArcTo(points[i], size, 0, false, SweepDirection.Counterclockwise, true, true);
                    }
                    else
                    {
                        geo.LineTo(points[i], true, false);
                    }
                }
                #endregion
            }
            return stream;
        }

        /// <summary>  
        /// 相对中心顺时针旋转 
        /// </summary>  
        /// <param name="center">中心点</param>  
        /// <param name="p1">要旋转的点</param>  
        /// <param name="angle">旋转角度，笛卡尔直角坐标</param>  
        /// <returns></returns>  
        private static Point PointRotate(Point center, Point p1, double angle)
        {
            double angleHude = angle * Math.PI / 180;/*角度变成弧度*/
            double x = (p1.X - center.X) * Math.Cos(angleHude) + (p1.Y - center.Y) * Math.Sin(angleHude) + center.X;
            double y = -(p1.X - center.X) * Math.Sin(angleHude) + (p1.Y - center.Y) * Math.Cos(angleHude) + center.Y;
            return new Point(x, y);
        }

        #region 依赖属性
        [Category("Wu")]
        [Description("多边形的边数量")]
        public int Sides
        {
            get { return (int)GetValue(SidesProperty); }
            set { SetValue(SidesProperty, value); }
        }
        public static readonly DependencyProperty SidesProperty =
                    DependencyProperty.Register("Sides", typeof(int), typeof(RegularPolygon),
                        new FrameworkPropertyMetadata(3,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        [Category("Wu")]
        [Description("正多边形长对角线的一半的比例 ∈(0,1]")]
        public double SizeRatio
        {
            get { return (double)GetValue(SizeRatioProperty); }
            set { SetValue(SizeRatioProperty, value); }
        }
        public static readonly DependencyProperty SizeRatioProperty =
                    DependencyProperty.Register("SizeRatio", typeof(double), typeof(RegularPolygon),
                        new FrameworkPropertyMetadata(0.8,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        [Category("Wu")]
        [Description("导角占图形的大小比例 [0,1]")]
        public double CornerRatio
        {
            get { return (double)GetValue(CornerRatioProperty); }
            set { SetValue(CornerRatioProperty, value); }
        }
        public static readonly DependencyProperty CornerRatioProperty =
                    DependencyProperty.Register("CornerRatio", typeof(double), typeof(RegularPolygon),
                        new FrameworkPropertyMetadata(default(double),
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        [Category("Wu")]
        [Description("中心")]
        public Point Origin
        {
            get { return (Point)GetValue(OriginProperty); }
            set { SetValue(OriginProperty, value); }
        }
        public static readonly DependencyProperty OriginProperty =
                    DependencyProperty.Register("Origin", typeof(Point), typeof(RegularPolygon),
                        new FrameworkPropertyMetadata(new Point(0.5, 0.5), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(OnOriginChanged)));

        /// <summary>
        /// 中心点修改事件, 修改中心点的绝对坐标
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnOriginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RegularPolygon self)
            {
                if (self.IsRelativeOrigin)
                    self.AbsOrigin = new Point(self.Origin.X * self.ActualWidth, self.Origin.Y * self.ActualHeight);
                else
                    self.AbsOrigin = new Point(self.Origin.X, self.Origin.Y);
            }
        }

        //绝对定位的坐标
        public Point AbsOrigin { get; set; } = new Point(0, 0);

        /// <summary>
        /// 是否为相对定位
        /// </summary>
        public bool IsRelativeOrigin => Math.Abs(Origin.X) <= 1 && Math.Abs(Origin.Y) <= 1;
        #endregion

    }
}

