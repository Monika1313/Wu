using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Wu.Wpf.Converters
{
    /// <summary>
    /// bool转换Visibility false为Collapsed
    /// </summary>
    public class Bool2VisibilityCollapsed : ValueConverterBase<Bool2VisibilityCollapsed>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = System.Convert.ToBoolean(value);
            if (b)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }
    }
}
