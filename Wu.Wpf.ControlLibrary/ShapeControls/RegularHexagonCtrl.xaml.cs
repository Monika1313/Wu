using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// RegularHexagonCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class RegularHexagonCtrl : UserControl
    {
        public RegularHexagonCtrl()
        {
            InitializeComponent();
            SetCurrentValue(FillProperty, Brushes.MediumPurple);
        }


        [Category("Wu")]
        [Description("填充色")]
        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }
        public static readonly DependencyProperty FillProperty =
                    DependencyProperty.Register("Fill", typeof(Brush), typeof(RegularHexagonCtrl),
                        new FrameworkPropertyMetadata(Brushes.MediumPurple,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));


        [Category("Wu")]
        [Description("六边形大小尺寸相对控件大小的比例∈(0,1]")]
        public double SizeRatio
        {
            get { return (double)GetValue(SizeRatioProperty); }
            set { SetValue(SizeRatioProperty, value); }
        }
        public static readonly DependencyProperty SizeRatioProperty =
                    DependencyProperty.Register("SizeRatio", typeof(double), typeof(RegularHexagonCtrl),
                        new FrameworkPropertyMetadata(0.8,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));


        [Category("Wu")]
        [Description("导角占图形的大小比例∈[0,1]")]
        public double CornerRatio
        {
            get { return (double)GetValue(CornerRatioProperty); }
            set { SetValue(CornerRatioProperty, value); }
        }
        public static readonly DependencyProperty CornerRatioProperty =
                    DependencyProperty.Register("CornerRatio", typeof(double), typeof(RegularHexagonCtrl),
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
                    DependencyProperty.Register("Rotation", typeof(double), typeof(RegularHexagonCtrl),
                        new FrameworkPropertyMetadata(0.0,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));




    }
}
