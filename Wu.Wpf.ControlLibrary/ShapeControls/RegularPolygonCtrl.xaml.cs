using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace Wu.Wpf.ControlLibrary.ShapeControls
{
    /// <summary>
    /// RegularPolygonCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class RegularPolygonCtrl : UserControl
    {
        public RegularPolygonCtrl()
        {
            InitializeComponent();
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
                    DependencyProperty.Register("Sides", typeof(int), typeof(RegularPolygonCtrl),
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
                    DependencyProperty.Register("SizeRatio", typeof(double), typeof(RegularPolygonCtrl),
                        new FrameworkPropertyMetadata(0.8,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));


        [Category("Wu")]
        [Description("导角占图形的大小比例 [0,1] 超过范围显示将不再是正多边形")]
        public double CornerRatio
        {
            get { return (double)GetValue(CornerRatioProperty); }
            set { SetValue(CornerRatioProperty, value); }
        }
        public static readonly DependencyProperty CornerRatioProperty =
                    DependencyProperty.Register("CornerRatio", typeof(double), typeof(RegularPolygonCtrl),
                        new FrameworkPropertyMetadata(0.1,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        [Category("Wu")]
        [Description("填充色")]
        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }
        public static readonly DependencyProperty FillProperty =
                    DependencyProperty.Register("Fill", typeof(Brush), typeof(RegularPolygonCtrl),
                        new FrameworkPropertyMetadata(Brushes.MediumPurple,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        [Category("Wu")]
        [Description("旋转角度")]
        public double Rotation
        {
            get { return (double)GetValue(RotationProperty); }
            set { SetValue(RotationProperty, value); }
        }
        public static readonly DependencyProperty RotationProperty =
                    DependencyProperty.Register("Rotation", typeof(double), typeof(RegularPolygonCtrl),
                        new FrameworkPropertyMetadata(0.0,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

    }
}
