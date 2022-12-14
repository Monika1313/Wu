using System;
using System.Globalization;
using System.Windows;

namespace Wu.Wpf.Converters
{
    /// <summary>
    /// string.IsNullOrWhiteSpace   null或空=true
    /// </summary>
    public class StringIsNullOrWhiteSpace2True : ValueConverterBase<StringIsNullOrWhiteSpace2Visibility>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(value?.ToString()))
                return true;
            return false;
        }
    }
}
