namespace Wu.Wpf.Converters;

/// <summary>
/// string.IsNullOrWhiteSpace
/// </summary>
public class StringIsNullOrWhiteSpace2Visibility : ValueConverterBase<StringIsNullOrWhiteSpace2Visibility>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (string.IsNullOrWhiteSpace(value?.ToString()))
            return true;
        return false;
    }
}
