using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu.Wpf.Converters
{
    /// <summary>
    /// Bool反转
    /// </summary>
    public class ReverseBool : ValueConverterBase<ReverseBool>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) 
                return true;
            bool b = System.Convert.ToBoolean(value);
            return !b;
        }
    }
}
