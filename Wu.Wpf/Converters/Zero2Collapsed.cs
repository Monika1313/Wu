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
    /// 为0则隐藏
    /// </summary>
    public class Zero2Collapsed : ValueConverterBase<Zero2Collapsed>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && int.TryParse(value.ToString(), out int result))
            {
                if (result > 0)
                {
                    return Visibility.Visible;
                }
            }
            return Visibility.Collapsed;
        }
    }
}
