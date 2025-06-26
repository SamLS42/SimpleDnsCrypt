using SimpleDnsCrypt.Models;
using System;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Windows.Data;

namespace SimpleDnsCrypt.Converters;

/// <summary>
///     Interface to icon converter.
/// </summary>
public class InterfaceTypeToIconConverter : IValueConverter
{
	public object EthernetIconOffline { get; set; }
	public object EthernetIcon { get; set; }
	public object WifiIcon { get; set; }
	public object WifiIconOffline { get; set; }


	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		try
		{
			LocalNetworkInterface localNetworkInterface = (LocalNetworkInterface)value;
			bool isCable = localNetworkInterface.Type switch
			{
				NetworkInterfaceType.Ethernet or NetworkInterfaceType.Ethernet3Megabit or NetworkInterfaceType.FastEthernetFx or NetworkInterfaceType.FastEthernetT or NetworkInterfaceType.GigabitEthernet => true,
				NetworkInterfaceType.Wireless80211 => false,
				_ => true,
			};
			return isCable
				? localNetworkInterface.OperationalStatus != OperationalStatus.Up ? EthernetIconOffline : EthernetIcon
				: localNetworkInterface.OperationalStatus != OperationalStatus.Up ? WifiIconOffline : WifiIcon;
		}
		catch (Exception)
		{
			return EthernetIcon;
		}
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
