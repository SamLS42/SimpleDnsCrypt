using SimpleDnsCrypt.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleDnsCrypt.Converters;

/// <summary>
///     Enum to color converter.
/// </summary>
[ValueConversion(typeof(BoxType), typeof(string))]
public class MessageBoxTypeToColor : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return (BoxType)value switch
		{
			BoxType.Error => "#CCC1170F",//red
			BoxType.Warning => "#CCEA6A12",//orange
			BoxType.Default => "#CC60A917",//green
			_ => null,
		};
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
