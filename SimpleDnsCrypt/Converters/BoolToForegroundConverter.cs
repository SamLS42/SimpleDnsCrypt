using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleDnsCrypt.Converters;

public class BoolToForegroundConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return (bool)value ? "#FF8ab329" : "#FFFF8C00";
	}

	public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
