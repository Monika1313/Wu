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
    /// 正六边形 基础图形
    /// </summary>
    public class RegularHexagon : Shape
    {
        public RegularHexagon()
        {
            SetCurrentValue(FillProperty, Brushes.MediumPurple);
            SetCurrentValue(StrokeThicknessProperty, 0d);
            SetCurrentValue(MinWidthProperty, 100d);
            SetCurrentValue(MinHeightProperty, 100d);
        }

        protected override Geometry DefiningGeometry => GeometryGenerator();

        /// <summary>
        /// 生成图形
        /// </summary>
        /// <returns></returns>
        private Geometry GeometryGenerator()
        {
            StreamGeometry stream = new();
            using (StreamGeometryContext geo = stream.Open())
            {
                //计算中心点的绝对坐标
                if (IsRelativeOrigin)
                    AbsOrigin = new Point(Origin.X * ActualWidth, Origin.Y * ActualHeight);
                else
                    AbsOrigin = new Point(Origin.X, Origin.Y);
                double ctrlLength = Math.Min(ActualHeight, ActualWidth) / 2;    //控件宽高的一半
                double len = ctrlLength * SizeRatio;                           //多边形中心点到顶点的距离

                Point pCenter = new(0, 0);  //相对定位前的中心
               

                double gh3 = Math.Sqrt(3);

                //计算添加圆角时, 顶点需要的旋转角度
                //double angle = Math.Atan(gh3 * CornerRadius / (2 * gh3 * len - CornerRadius)) * (180 / Math.PI);
                //
                double ratio = Math.Abs(CornerRatio)%6.0;
                double angle = 30 * ratio;//导角的一半

                #region 内切
                //计算添加导角后的顶点到原点的距离
                //double length = Math.Sin(60 * Math.PI / 180.0) * len / Math.Sin((120 - angle) * Math.PI / 180.0);
                //var pStart = new Point(length, 0);//正六边形的绘图起点 
                #endregion

                var pStart = new Point(len, 0);//正六边形的绘图起点
                #region 坐标点位
                var p1 = PointRotate(pCenter, pStart, -angle);
                var p3 = PointRotate(pCenter, p1, 60);
                var p5 = PointRotate(pCenter, p3, 60);
                var p7 = PointRotate(pCenter, p5, 60);
                var p9 = PointRotate(pCenter, p7, 60);
                var p11 = PointRotate(pCenter, p9, 60);
                var p2 = PointRotate(pCenter, pStart, angle);
                var p4 = PointRotate(pCenter, p2, 60);
                var p6 = PointRotate(pCenter, p4, 60);
                var p8 = PointRotate(pCenter, p6, 60);
                var p10 = PointRotate(pCenter, p8, 60);
                var p12 = PointRotate(pCenter, p10, 60);
                #endregion

                //相对中心点偏移
                p1.Offset(AbsOrigin.X, AbsOrigin.Y);
                p3.Offset(AbsOrigin.X, AbsOrigin.Y);
                p5.Offset(AbsOrigin.X, AbsOrigin.Y);
                p7.Offset(AbsOrigin.X, AbsOrigin.Y);
                p9.Offset(AbsOrigin.X, AbsOrigin.Y);
                p11.Offset(AbsOrigin.X, AbsOrigin.Y);
                p2.Offset(AbsOrigin.X, AbsOrigin.Y);
                p4.Offset(AbsOrigin.X, AbsOrigin.Y);
                p6.Offset(AbsOrigin.X, AbsOrigin.Y);
                p8.Offset(AbsOrigin.X, AbsOrigin.Y);
                p10.Offset(AbsOrigin.X, AbsOrigin.Y);
                p12.Offset(AbsOrigin.X, AbsOrigin.Y);

                double cR = 2 * (p1.Y - p2.Y) / Math.Sqrt(3);//计算圆角的半径
                Size size = new(cR, cR);                    //圆角的圆弧尺寸

                //绘图
                geo.BeginFigure(p1, true, true);
                geo.ArcTo(p2, size, 0, false, SweepDirection.Counterclockwise, true, true);
                geo.LineTo(p3, true, false);
                geo.ArcTo(p4, size, 0, false, SweepDirection.Counterclockwise, true, true);
                geo.LineTo(p5, true, false);
                geo.ArcTo(p6, size, 0, false, SweepDirection.Counterclockwise, true, true);
                geo.LineTo(p7, true, false);
                geo.ArcTo(p8, size, 0, false, SweepDirection.Counterclockwise, true, true);
                geo.LineTo(p9, true, false);
                geo.ArcTo(p10, size, 0, false, SweepDirection.Counterclockwise, true, true);
                geo.LineTo(p11, true, false);
                geo.ArcTo(p12, size, 0, false, SweepDirection.Counterclockwise, true, true);
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
        private Point PointRotate(Point center, Point p1, double angle)
        {
            double angleHude = angle * Math.PI / 180;/*角度变成弧度*/
            double x = (p1.X - center.X) * Math.Cos(angleHude) + (p1.Y - center.Y) * Math.Sin(angleHude) + center.X;
            double y = -(p1.X - center.X) * Math.Sin(angleHude) + (p1.Y - center.Y) * Math.Cos(angleHude) + center.Y;
            return new Point(x, y);
        }


        #region 依赖属性
        [Category("Wu")]
        [Description("正六边形长对角线的一半的比例 ∈(0,1]")]
        public double SizeRatio
        {
            get { return (double)GetValue(SizeRatioProperty); }
            set { SetValue(SizeRatioProperty, value); }
        }
        public static readonly DependencyProperty SizeRatioProperty =
                    DependencyProperty.Register("SizeRatio", typeof(double), typeof(RegularHexagon),
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
                    DependencyProperty.Register("CornerRatio", typeof(double), typeof(RegularHexagon),
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
                    DependencyProperty.Register("Origin", typeof(Point), typeof(RegularHexagon),
                        new FrameworkPropertyMetadata(new Point(0.5, 0.5), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(OnOriginChanged)));

        /// <summary>
        /// 中心点修改事件, 修改中心点的绝对坐标
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnOriginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RegularHexagon self)
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
