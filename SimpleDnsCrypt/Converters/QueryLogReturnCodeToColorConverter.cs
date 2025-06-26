using SimpleDnsCrypt.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleDnsCrypt.Converters;

public class QueryLogReturnCodeToColorConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		QueryLogReturnCode logLineReturnCode = (QueryLogReturnCode)value;
		return logLineReturnCode switch
		{
			QueryLogReturnCode.PASS => "#FF8ab329",
			QueryLogReturnCode.FORWARD => "#FF8ab329",
			QueryLogReturnCode.DROP => "#FFB32929",
			QueryLogReturnCode.REJECT => "#FFB32929",
			QueryLogReturnCode.SYNTH => "#FF8ab329",
			QueryLogReturnCode.PARSE_ERROR => "#FFB32929",
			QueryLogReturnCode.NXDOMAIN => "#FFB36729",
			QueryLogReturnCode.RESPONSE_ERROR => "#FFB32929",
			QueryLogReturnCode.SERVER_ERROR => "#FFB32929",
			QueryLogReturnCode.CLOAK => "#FF2a3b68",
			_ => "#FFB32929",
		};
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
