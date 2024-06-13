namespace Wu.Wpf.Converters;

/// <summary>
/// 使枚举绑定值改为Description
/// 示例 
/// 在枚举类型添加该特性即可 [TypeConverter(typeof(EnumDescriptionTypeConverter))]  
/// 绑定参考EnumBindingSourceExtension.cs
/// </summary>
public class EnumDescriptionTypeConverter : EnumConverter
{
    public EnumDescriptionTypeConverter(Type type) : base(type)
    {
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string))
        {
            if (null != value)
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());

                if (null != fi)
                {
                    var attributes =
                        (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    return ((attributes.Length > 0) && (!string.IsNullOrEmpty(attributes[0].Description)))
                        ? attributes[0].Description
                        : value.ToString();
                }
            }

            return string.Empty;
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
}
