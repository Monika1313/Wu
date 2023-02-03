using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Wu.Wpf.Extensions
{
    /// <summary>
    /// 当 TextBoxBase获得焦点的时候，自动全部选择文字。附加属性为SelectAllWhenGotFocus，类型为bool, true为生效 false不生效
    /// 用法 添加引用 xmlns:wuext="clr-namespace:Wu.Wpf.Extensions;assembly=Wu.Wpf"
    /// 在TextBox内添加属性 <TextBox wuext:TextBoxExtensions.SelectAllWhenGotFocus="True"/>
    /// </summary>
    public class TextBoxExtensions
    {
        public static readonly DependencyProperty SelectAllWhenGotFocusProperty = DependencyProperty.RegisterAttached("SelectAllWhenGotFocus",
                            typeof(bool), typeof(TextBoxExtensions),
                            new FrameworkPropertyMetadata((bool)false, new PropertyChangedCallback(OnSelectAllWhenGotFocusChanged)));

        public static bool GetSelectAllWhenGotFocus(TextBoxBase d)
        {
            return (bool)d.GetValue(SelectAllWhenGotFocusProperty);
        }
        public static void SetSelectAllWhenGotFocus(TextBoxBase d, bool value)
        {
            d.SetValue(SelectAllWhenGotFocusProperty, value);
        }

        private static void OnSelectAllWhenGotFocusChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            if (dependency is TextBoxBase tBox)
            {
                var isSelectedAllWhenGotFocus = (bool)e.NewValue;
                if (isSelectedAllWhenGotFocus)
                {
                    tBox.PreviewMouseDown += TextBoxPreviewMouseDown;
                    tBox.GotFocus += TextBoxOnGotFocus;
                    tBox.LostFocus += TextBoxOnLostFocus;
                }
                else
                {
                    tBox.PreviewMouseDown -= TextBoxPreviewMouseDown;
                    tBox.GotFocus -= TextBoxOnGotFocus;
                    tBox.LostFocus -= TextBoxOnLostFocus;
                }
            }
        }

        private static void TextBoxOnGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBoxBase tBox)
            {
                tBox.SelectAll();
                tBox.PreviewMouseDown -= TextBoxPreviewMouseDown;
            }

        }

        private static void TextBoxPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBoxBase tBox)
            {
                tBox.Focus();
                e.Handled = true;
            }
        }

        private static void TextBoxOnLostFocus(object sender, RoutedEventArgs e)
        {

            if (sender is TextBoxBase tBox)
            {
                tBox.PreviewMouseDown += TextBoxPreviewMouseDown;
            }

        }
    }
}