using SimpleDnsCrypt.Extensions;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;

namespace SimpleDnsCrypt.Converters;

public class ServerListBackgroundConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return (bool)value ? "#FF8AB329" : Color.DarkGray.ToHexString();
	}

	public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}