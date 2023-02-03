using System;
using System.Globalization;
using System.Windows;

namespace Wu.Wpf.Converters
{
    /// <summary>
    /// 非零则隐藏
    /// </summary>
    public class NonZero2Collapsed : ValueConverterBase<NonZero2Collapsed>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int result))
            {
                if (result.Equals(0))
                {
                    return Visibility.Visible;
                }
            }
            return Visibility.Collapsed;
        }
    }
}
