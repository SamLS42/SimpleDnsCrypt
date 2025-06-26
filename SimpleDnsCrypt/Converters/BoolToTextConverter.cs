using SimpleDnsCrypt.Helper;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Data;

namespace SimpleDnsCrypt.Converters;

public class BoolToTextConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return (bool)value
			? LocalizationEx.GetUiString("yes", Thread.CurrentThread.CurrentCulture)
			: LocalizationEx.GetUiString("no", Thread.CurrentThread.CurrentCulture);
	}

	public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
