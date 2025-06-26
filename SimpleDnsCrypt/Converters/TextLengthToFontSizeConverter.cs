using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleDnsCrypt.Converters;

/// <summary>
///     Text length to font size converter.
/// </summary>
public class TextLengthToFontSizeConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		string text = (string)value;
		return text.Length is > 10 and < 15 ? 14 : text.Length >= 15 ? 10 : 14;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
