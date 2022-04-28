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
    /// bool转换Visibility false为Hidden
    /// </summary>
    public class Bool2VisibilityHidden : ValueConverterBase<Bool2VisibilityHidden>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = System.Convert.ToBoolean(value);
            if (b)
            {
                return Visibility.Hidden;
            }
            else
            {
                return Visibility.Visible;
            }
        }
    }
}
