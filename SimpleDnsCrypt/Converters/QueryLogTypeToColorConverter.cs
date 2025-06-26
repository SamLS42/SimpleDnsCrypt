using SimpleDnsCrypt.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleDnsCrypt.Converters;

public class QueryLogTypeToColorConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		QueryLogLineType logLineType = (QueryLogLineType)value;
		return logLineType switch
		{
			QueryLogLineType.A => "#FF8ab329",
			QueryLogLineType.Unknown => "#FF8ab329",
			QueryLogLineType.NS => "#FF8ab329",
			QueryLogLineType.CNAME => "#FF8ab329",
			QueryLogLineType.SOA => "#FF8ab329",
			QueryLogLineType.WKS => "#FF8ab329",
			QueryLogLineType.PTR => "#FF2a3b68",
			QueryLogLineType.MX => "#FF8ab329",
			QueryLogLineType.TXT => "#FF8ab329",
			QueryLogLineType.AAAA => "#FFB32929",
			QueryLogLineType.SRV => "#FF8ab329",
			QueryLogLineType.ANY => "#FF8ab329",
			_ => "#FFB32929",
		};
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
