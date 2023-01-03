using System;
using System.Globalization;
using System.Windows;

namespace Wu.Wpf.Converters
{
    /// <summary>
    /// bool转换Visibility false为Collapsed
    /// </summary>
    public class False2Collapsed : ValueConverterBase<False2Collapsed>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = System.Convert.ToBoolean(value);
            if (b)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }
    }
}
