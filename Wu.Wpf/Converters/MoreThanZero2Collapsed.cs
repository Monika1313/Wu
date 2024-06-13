namespace Wu.Wpf.Converters;

public class MoreThanZero2Collapsed : ValueConverterBase<MoreThanZero2Collapsed>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null && int.TryParse(value.ToString(), out int result))
        {
            if (result == 0)
            {
                return Visibility.Visible;
            }
        }
        return Visibility.Collapsed;
    }
}
