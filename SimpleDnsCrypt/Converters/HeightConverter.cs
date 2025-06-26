using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleDnsCrypt.Converters;

public class HeightConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		try
		{
			double actualHeight = (double)value;
			return actualHeight > 700
				? (string)parameter switch
				{
					"Resolvers" => actualHeight - 400,
					"QueryLog" => actualHeight - 200,
					"DomainBlockLog" => actualHeight - 200,
					_ => (object)(actualHeight - 200),
				}
				: actualHeight;
		}
		catch
		{
			return 0;
		}
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
