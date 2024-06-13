namespace Wu.Wpf.Converters;

/// <summary>
/// 中文 是/否 转换为 true false
/// </summary>
public class CnYesNo2Bool : ValueConverterBase<CnYesNo2Bool>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || string.IsNullOrWhiteSpace(value?.ToString()))
            return null;
        if (value is string)
        {
            if (value.Equals("是"))
                return true;
        }
        return false;
    }

    public override object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool val && val == true)
        {
            return "是";
        }
        return "否";
    }
}
