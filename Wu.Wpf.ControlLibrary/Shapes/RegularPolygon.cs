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
        public RegularPolygon()
        {
            SetCurrentValue(FillProperty, Brushes.MediumPurple);
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
                double ctrlLength = Math.Min(ActualHeight, ActualWidth) / 2; //控件宽高的一半
                double len = ctrlLength * SizeRatio;                         //多边形中心到顶点的距离
                //Point pCenter = new(0, 0);  //相对定位前的中心
                #endregion

                var side = Sides > 2 ? Sides : 3;//多边形边数 至少3条边

                //无导角的情况
                var pStart = new Point(len + AbsOrigin.X, AbsOrigin.Y);//相对定位前的绘图起点
                //pStart.Offset(AbsOrigin.X, AbsOrigin.Y);
                var peakAng = 360.0 / side;      //多边形两顶点与原点的角度 

                double ratio = Math.Abs(CornerRatio) % side;
                double angle = peakAng * ratio / 2;//导角角度的一半


                #region 点位生成
                List<Point> points = new()
                {
                    PointRotate(AbsOrigin, pStart, -angle), //第一点 第一个顶点的导角左边
                    PointRotate(AbsOrigin, pStart, angle)  //第二点 第一个顶点的导角右边
                };

                //从第三点开始补点位
                for (int i = 3; i <= side * 2; i++)
                {
                    points.Add(PointRotate(AbsOrigin, points[points.Count - 2], peakAng));
                }
                #endregion

                double cR = (points[0].Y - points[1].Y) / 2 / Math.Sin(peakAng/ 2 * Math.PI / 180);//计算圆角的半径
                //double cR = 2 *(points[0].Y - points[1].Y) / gh3;//计算圆角的半径
                Size size = new(cR, cR);

                #region 绘图
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




                //#region 点位生成
                //List<Point> points = new()
                //{
                //    pStart
                //};

                //for (int i = 2; i <= side; i++)
                //{
                //    points.Add(PointRotate(AbsOrigin, points.Last(), peakAng));
                //}
                //#endregion


                //#region 绘图
                //geo.BeginFigure(points[0], true, true);

                //for (int i = 1; i < points.Count; i++)
                //{
                //    geo.LineTo(points[i], true, false);
                //} 
                //#endregion

                #region MyRegion



                //#region 坐标点位
                //var p1 = PointRotate(pCenter, pStart, -angle);
                //var p3 = PointRotate(pCenter, p1, 60);
                //var p5 = PointRotate(pCenter, p3, 60);
                //var p7 = PointRotate(pCenter, p5, 60);
                //var p9 = PointRotate(pCenter, p7, 60);
                //var p11 = PointRotate(pCenter, p9, 60);
                //var p2 = PointRotate(pCenter, pStart, angle);
                //var p4 = PointRotate(pCenter, p2, 60);
                //var p6 = PointRotate(pCenter, p4, 60);
                //var p8 = PointRotate(pCenter, p6, 60);
                //var p10 = PointRotate(pCenter, p8, 60);
                //var p12 = PointRotate(pCenter, p10, 60);
                //#endregion

                ////相对中心点偏移
                //p1.Offset(AbsOrigin.X, AbsOrigin.Y);
                //p3.Offset(AbsOrigin.X, AbsOrigin.Y);
                //p5.Offset(AbsOrigin.X, AbsOrigin.Y);
                //p7.Offset(AbsOrigin.X, AbsOrigin.Y);
                //p9.Offset(AbsOrigin.X, AbsOrigin.Y);
                //p11.Offset(AbsOrigin.X, AbsOrigin.Y);
                //p2.Offset(AbsOrigin.X, AbsOrigin.Y);
                //p4.Offset(AbsOrigin.X, AbsOrigin.Y);
                //p6.Offset(AbsOrigin.X, AbsOrigin.Y);
                //p8.Offset(AbsOrigin.X, AbsOrigin.Y);
                //p10.Offset(AbsOrigin.X, AbsOrigin.Y);
                //p12.Offset(AbsOrigin.X, AbsOrigin.Y);

                //double cR = 2 * (p1.Y - p2.Y) / Math.Sqrt(3);//计算圆角的半径
                //Size size = new(cR, cR);                    //圆角的圆弧尺寸

                ////绘图
                //geo.BeginFigure(p1, true, true);
                //geo.ArcTo(p2, size, 0, false, SweepDirection.Counterclockwise, true, true);
                //geo.LineTo(p3, true, false);
                //geo.ArcTo(p4, size, 0, false, SweepDirection.Counterclockwise, true, true);
                //geo.LineTo(p5, true, false);
                //geo.ArcTo(p6, size, 0, false, SweepDirection.Counterclockwise, true, true);
                //geo.LineTo(p7, true, false);
                //geo.ArcTo(p8, size, 0, false, SweepDirection.Counterclockwise, true, true);
                //geo.LineTo(p9, true, false);
                //geo.ArcTo(p10, size, 0, false, SweepDirection.Counterclockwise, true, true);
                //geo.LineTo(p11, true, false);
                //geo.ArcTo(p12, size, 0, false, SweepDirection.Counterclockwise, true, true);
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
        private Point PointRotate(Point center, Point p1, double angle)
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

