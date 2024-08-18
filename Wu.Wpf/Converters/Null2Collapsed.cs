﻿namespace Wu.Wpf.Converters;

/// <summary>
/// 为Null则隐藏
/// </summary>
public class Null2Collapsed : ValueConverterBase<Null2Collapsed>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null )
        {
            return Visibility.Visible;
        }
        return Visibility.Collapsed;
    }
}
