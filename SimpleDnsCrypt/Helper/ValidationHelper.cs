﻿using System;
using System.Globalization;
using System.Net;

namespace SimpleDnsCrypt.Helper;

public static class ValidationHelper
{

	public static string ValidateIpEndpoint(string endpoint)
	{
		try
		{
			IPEndPoint ipEndPoint = CreateIpEndPoint(endpoint);
			return ipEndPoint.ToString();
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static IPEndPoint CreateIpEndPoint(string endPoint)
	{
		string[] ep = endPoint.Split(':');
		if (ep.Length < 2)
		{
			throw new FormatException("Invalid endpoint format");
		}

		IPAddress ip;
		if (ep.Length > 2)
		{
			if (!IPAddress.TryParse(string.Join(":", ep, 0, ep.Length - 1), out ip))
			{
				throw new FormatException("Invalid ip-adress");
			}
		}
		else
		{
			if (!IPAddress.TryParse(ep[0], out ip))
			{
				throw new FormatException("Invalid ip-adress");
			}
		}

		return !int.TryParse(ep[ep.Length - 1], NumberStyles.None, NumberFormatInfo.CurrentInfo, out int port)
			? throw new FormatException("Invalid port")
			: new IPEndPoint(ip, port);
	}
}
