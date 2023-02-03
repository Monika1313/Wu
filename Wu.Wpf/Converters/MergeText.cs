using System;
using System.Globalization;

namespace Wu.Wpf.Converters
{
    /// <summary>
    /// 合并文本
    /// </summary>
    public class MergeText : MultiValueConverterBase<MergeText>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0)
            {
                return string.Empty;
            }

            string re = string.Empty;
            foreach (var item in values)
            {
                string str = System.Convert.ToString(item, CultureInfo.InvariantCulture) ?? string.Empty;
                if (!string.IsNullOrEmpty(str))
                    re += str;
            }
            return re;
        }
    }
}
