using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Wu.Wpf.Converters
{
    /// <summary>
    /// ValueConverter继承该基类
    /// 用法示例:  xaml引入该命名空间cvt   Converter={cvt:转换器名称}
    /// </summary>
    /// <typeparam name="T">要实现转换的类型本身</typeparam>
    public abstract class ValueConverterBase<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();

        private static T _Instance = new();

        /// <summary>
        /// 在xmal中使用时,将自动获取到该方法
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider) => _Instance ??= new();
    }

    public abstract class MultiValueConverterBase<T> : MarkupExtension, IMultiValueConverter where T : class, new()
    {

        private static T _Instance = new();

        /// <summary>
        /// 在xmal中使用时,将自动获取到该方法
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider) => _Instance ??= new();

        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
