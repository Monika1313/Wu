using System;
using System.Windows.Markup;

namespace Wu.Wpf.Converters
{
    /// <summary>
    /// 绑定枚举列表
    /// </summary>
    /// <remarks>
    ///  示例
    ///  ① xaml添加引用 xmlns:wucvt="clr-namespace:Wu.Wpf.Converters;assembly=Wu.Wpf"
    ///  ② 同时要添加枚举类的引用 xmlns:enums="该处根据实际设置"
    ///  ③ 在需要绑定的地方如此绑定 <ComboBox ItemsSource="{Binding Source={wucvt:EnumBindingSource {x:Type enums:枚举类型}}}" />
    /// </remarks>
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type _enumType;

        public Type EnumType
        {
            get { return _enumType; }
            set
            {
                if (value != _enumType)
                {
                    if (null != value)
                    {
                        var enumType = Nullable.GetUnderlyingType(value) ?? value;
                        if (!enumType.IsEnum)
                        {
                            throw new ArgumentException("Type must bu for an Enum");
                        }

                    }

                    _enumType = value;
                }
            }
        }

        public EnumBindingSourceExtension()
        {

        }

        public EnumBindingSourceExtension(Type enumType)
        {
            EnumType = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (null == _enumType)
            {
                throw new InvalidOperationException("The EnumTYpe must be specified.");
            }

            var actualEnumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;
            var enumValues = Enum.GetValues(actualEnumType);

            if (actualEnumType == _enumType)
            {
                return enumValues;
            }

            var tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
            enumValues.CopyTo(tempArray, 1);

            return tempArray;
        }
    }
}
