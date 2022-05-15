using System;
using System.ComponentModel;
using System.Globalization;

namespace Wu.MathPro
{
    /// <summary>
    /// Range类型转换器
    /// </summary>
    public class RangeConverter:TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            //去除字符串中的空格
            string spaceRemoved = value.ToString().Replace(" ", string.Empty);
            //分割成数组
            string[] splited = spaceRemoved.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (splited.Length == 2)
            {
                return new Range(double.Parse(splited[0]), double.Parse(splited[1]));
            }
            //if (splited.Length == 2 && double.TryParse(splited[0], out double d0) && double.TryParse(splited[1], out double d1))
            //{
            //    return new Range(d0, d1);
            //    //return new Range(double.Parse(splited[0]), double.Parse(splited[1]));
            //}
            return base.ConvertFrom(context, culture, value);

            ///* 剔除空格 */
            //string spaceRemoved = value.ToString().Replace(" ", string.Empty);

            ///* 逗号分隔 */
            //string[] splited = spaceRemoved.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            //var strs = splited;

            //double d0, d1;
            //if (strs.Length == 2
            //    && double.TryParse(strs[0], out d0)
            //    && double.TryParse(strs[1], out d1))
            //{
            //    return new Range { From = d0, To = d1 };
            //}
            //return base.ConvertFrom(context, culture, value);
        }
    }
}
