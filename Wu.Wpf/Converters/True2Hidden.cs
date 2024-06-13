namespace Wu.Wpf.Converters;

/// <summary>
/// bool转换Visibility false为Hidden
/// </summary>
public class True2Hidden : ValueConverterBase<True2Hidden>
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
            return Visibility.Hidden;
        }
    }
}
