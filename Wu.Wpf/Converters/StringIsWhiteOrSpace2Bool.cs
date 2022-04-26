using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wu.Wpf.Converters
{
    /// <summary>
    /// string.IsNullOrWhiteSpace   null或空 不可见
    /// </summary>
    public class StringIsNullOrWhiteSpace2Visibility : ValueConverterBase<StringIsNullOrWhiteSpace2Visibility>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(value?.ToString()))
                return Visibility.Collapsed;
            return Visibility.Visible;
        }
    }
}
