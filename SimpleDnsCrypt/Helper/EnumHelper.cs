using SimpleDnsCrypt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace SimpleDnsCrypt.Helper;

public static class EnumHelper
{
	public static string Description(this Enum eValue)
	{
		object[] nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
		if (nAttributes.Any())
		{
			return (nAttributes.First() as DescriptionAttribute).Description;
		}

		TextInfo oTi = CultureInfo.CurrentCulture.TextInfo;
		return oTi.ToTitleCase(oTi.ToLower(eValue.ToString()));
	}

	public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions(Type t)
	{
		return !t.IsEnum
			? throw new ArgumentException("t must be an enum type")
			: (IEnumerable<ValueDescription>)[.. Enum.GetValues(t).Cast<Enum>().Select((e) => new ValueDescription() { Value = e, Description = e.Description() })];
	}
}
