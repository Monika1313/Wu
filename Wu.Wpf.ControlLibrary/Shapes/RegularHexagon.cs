using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Wu.Wpf.ControlLibrary.Shapes
{
    public class RegularHexagon : Shape
    {
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
                if (IsRelativeOrigin)
                    AbsoluteOrigin = new Point(Origin.X * ActualWidth, Origin.Y * ActualHeight);
                else
                    AbsoluteOrigin = new Point(Origin.X, Origin.Y);
                double ctrlLength = Math.Min(ActualHeight, ActualWidth) /2; //控件宽高的一半
                double len = ctrlLength * Length;                          //多边形两顶点最长值的一半
                Point pCenter = new(0, 0);                       //相对定位前的中心

                #region MyRegion
                var pStart = new Point(len, 0);
                double angle = 10;
                var p1 = PointRotate(pCenter, pStart, -angle / 2);
                var p3 = PointRotate(pCenter, p1, 60);
                var p5 = PointRotate(pCenter, p3, 60);
                var p7 = PointRotate(pCenter, p5, 60);
                var p9 = PointRotate(pCenter, p7, 60);
                var p11 = PointRotate(pCenter, p9, 60);

                var p2 = PointRotate(pCenter, pStart, angle / 2);
                var p4 = PointRotate(pCenter, p2, 60);
                var p6 = PointRotate(pCenter, p4, 60);
                var p8 = PointRotate(pCenter, p6, 60);
                var p10 = PointRotate(pCenter, p8, 60);
                var p12 = PointRotate(pCenter, p10, 60);

                //相对中心点偏移
                p1.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);
                p3.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);
                p5.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);
                p7.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);
                p9.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);
                p11.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);
                p2.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);
                p4.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);
                p6.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);
                p8.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);
                p10.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);
                p12.Offset(AbsoluteOrigin.X, AbsoluteOrigin.Y);

                double cR = 2*(p1.Y - p2.Y) / 1.732;
                Size size = new(cR, cR);
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
                #endregion



                //var pa = new Point(len, 0);
                //var pb = PointRotate(pCenter, pa, 60);
                //var pc = PointRotate(pCenter, pb, 60);
                //var pd = PointRotate(pCenter, pc, 60);
                //var pe = PointRotate(pCenter, pd, 60);
                //var pf = PointRotate(pCenter, pe, 60);



                #region MyRegion
                //var pStart = new Point(len, 0);
                //var p1 = new Point(len, 0);
                //var p3 = PointRotate(pCenter, p1, 60);
                //var p5 = PointRotate(pCenter, p3, 60);
                //var p7 = PointRotate(pCenter, p5, 60);
                //var p9 = PointRotate(pCenter, p7, 60);
                //var p11 = PointRotate(pCenter, p9, 60);

                ////相对中心点偏移
                //p1.Offset(AbsoluteOrigin.X,AbsoluteOrigin.Y);
                //p3.Offset(AbsoluteOrigin.X,AbsoluteOrigin.Y);
                //p5.Offset(AbsoluteOrigin.X,AbsoluteOrigin.Y);
                //p7.Offset(AbsoluteOrigin.X,AbsoluteOrigin.Y);
                //p9.Offset(AbsoluteOrigin.X,AbsoluteOrigin.Y);
                //p11.Offset(AbsoluteOrigin.X,AbsoluteOrigin.Y);

                ////绘图
                //geo.BeginFigure(p1, true, true);
                //geo.LineTo(p3, true, false);
                //geo.LineTo(p5, true, false);
                //geo.LineTo(p7, true, false);
                //geo.LineTo(p9, true, false);
                //geo.LineTo(p11, true, false); 
                #endregion


                //geo.ArcTo(p3, sizeTo, 0, isLargeArc, SweepDirection.Clockwise, true, true);
            }
            return stream;
        }


        ///// <summary>
        ///// 以中心点旋转Angle角度
        ///// </summary>
        ///// <param name="origin">中心点</param>
        ///// <param name="reRotate">待旋转的点</param>
        ///// <param name="angle">旋转角度, 逆时针</param>
        //private Point PointRotate(Point origin, Point rePoint, double angle)
        //{
        //    double x = (rePoint.X - origin.X) * Math.Cos(-angle) - (rePoint.Y - origin.Y) * Math.Sin(-angle) + origin.X;
        //    double y = (rePoint.X - origin.X) * Math.Sin(-angle) + (rePoint.Y - origin.Y) * Math.Cos(-angle) + origin.Y;

        //    return new Point(x, y);
        //}


        //public Point PointRotate(Point p2, Point p1, double ARotate)
        //{
        //    double Rad = 0;
        //    Rad = ARotate * Math.Acos(-1) / 180;
        //    Point p3 = new Point();
        //    p3.X = (p2.X - p1.X) * Math.Cos(Rad) - (p2.Y - p1.Y) * Math.Sin(Rad) + p1.X;
        //    p3.Y = (p2.Y - p1.Y) * Math.Cos(Rad) + (p2.X - p1.X) * Math.Sin(Rad) + p1.Y;
        //    return p3;
        //}


        /// <summary>  
        /// 相对中心顺时针旋转 
        /// </summary>  
        /// <param name="center">中心点</param>  
        /// <param name="p1">要旋转的点</param>  
        /// <param name="angle">旋转角度，笛卡尔直角坐标</param>  
        /// <returns></returns>  
        private Point PointRotate(Point center, Point p1, double angle)
        {
            Point tmp = new Point();
            double angleHude = angle * Math.PI / 180;/*角度变成弧度*/
            double x1 = (p1.X - center.X) * Math.Cos(angleHude) + (p1.Y - center.Y) * Math.Sin(angleHude) + center.X;
            double y1 = -(p1.X - center.X) * Math.Sin(angleHude) + (p1.Y - center.Y) * Math.Cos(angleHude) + center.Y;
            tmp.X = x1;
            tmp.Y = y1;
            return tmp;
        }




        #region 依赖属性

        [Category("Wu")]
        [Description("边长")]
        public double Length
        {
            get { return (double)GetValue(LengthProperty); }
            set { SetValue(LengthProperty, value); }
        }
        public static readonly DependencyProperty LengthProperty =
                    DependencyProperty.Register("Length", typeof(double), typeof(RegularHexagon),
                        new FrameworkPropertyMetadata(0.5,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));


        [Category("Wu")]
        [Description("圆角半径")]
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
                    DependencyProperty.Register("CornerRadius", typeof(double), typeof(RegularHexagon),
                        new FrameworkPropertyMetadata(default(double),
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));



        [Category("Wu")]
        [Description("旋转角度")]
        public double Rotation
        {
            get { return (double)GetValue(RotationProperty); }
            set { SetValue(RotationProperty, value); }
        }
        public static readonly DependencyProperty RotationProperty =
                    DependencyProperty.Register("Rotation", typeof(double), typeof(RegularHexagon),
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

        private static void OnOriginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RegularHexagon self)
            {
                if (self.IsRelativeOrigin)
                {
                    self.AbsoluteOrigin = new Point(self.Origin.X * self.ActualWidth, self.Origin.Y * self.ActualHeight);
                }
                else
                {
                    self.AbsoluteOrigin = new Point(self.Origin.X, self.Origin.Y);
                }
            }
        }

        //绝对定位的坐标
        public Point AbsoluteOrigin { get; set; } = new Point(0, 0);

        /// <summary>
        /// 是否为相对定位
        /// </summary>
        public bool IsRelativeOrigin => Math.Abs(Origin.X) <= 1 && Math.Abs(Origin.Y) <= 1;
        #endregion

    }
}
