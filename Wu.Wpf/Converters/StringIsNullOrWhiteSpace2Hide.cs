using System;
using System.Globalization;
using Wu.Wpf.Converters;

namespace Wu.Wpf.Converters
{
    /// <summary>
    /// string.IsNullOrWhiteSpace
    /// </summary>
    public class StringIsNullOrWhiteSpace2Hide : ValueConverterBase<StringIsNullOrWhiteSpace2Hide>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(value?.ToString()))
                return true;
            return false;
        }
    }
}
