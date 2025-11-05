using SimpleDnsCrypt.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleDnsCrypt.Converters
{
	public class QueryLogTypeToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var logLineType = (QueryLogLineType) value;
			switch (logLineType)
			{
				case QueryLogLineType.A:
					return "{StaticResource MahApps.Brushes.AccentBase}";
				case QueryLogLineType.Unknown:
					return "{StaticResource MahApps.Brushes.AccentBase}";
				case QueryLogLineType.NS:
					return "{StaticResource MahApps.Brushes.AccentBase}";
				case QueryLogLineType.CNAME:
					return "{StaticResource MahApps.Brushes.AccentBase}";
				case QueryLogLineType.SOA:
					return "{StaticResource MahApps.Brushes.AccentBase}";
				case QueryLogLineType.WKS:
					return "{StaticResource MahApps.Brushes.AccentBase}";
				case QueryLogLineType.PTR:
					return "#FF2a3b68";
				case QueryLogLineType.MX:
					return "{StaticResource MahApps.Brushes.AccentBase}";
				case QueryLogLineType.TXT:
					return "{StaticResource MahApps.Brushes.AccentBase}";
				case QueryLogLineType.AAAA:
					return "#FFB32929";
				case QueryLogLineType.SRV:
					return "{StaticResource MahApps.Brushes.AccentBase}";
				case QueryLogLineType.ANY:
					return "{StaticResource MahApps.Brushes.AccentBase}";
				default:
					return "#FFB32929";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
