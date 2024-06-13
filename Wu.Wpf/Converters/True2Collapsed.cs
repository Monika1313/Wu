namespace Wu.Wpf.Converters;

/// <summary>
/// bool转换Visibility false为Collapsed
/// </summary>
public class True2Collapsed : ValueConverterBase<True2Collapsed>
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
