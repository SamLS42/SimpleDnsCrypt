﻿using SimpleDnsCrypt.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using WPFLocalizeExtension.Engine;

namespace SimpleDnsCrypt.Helper;

/// <summary>
///     Class for translation management.
/// </summary>
public static class LocalizationEx
{
	/// <summary>
	///     Get a translated string by key and culture.
	/// </summary>
	/// <param name="key">The key to retrieve.</param>
	/// <param name="culture">The culture to retrieve the key from.</param>
	/// <returns>Translated string.</returns>
	public static string GetUiString(string key, CultureInfo culture)
	{
		return (string)LocalizeDictionary.Instance.GetLocalizedObject("simplednscrypt", "Translation", key, culture);
	}

	/// <summary>
	///		Get the supported languages.
	/// </summary>
	/// <returns></returns>
	public static ObservableCollection<Language> GetSupportedLanguages()
	{
		ObservableCollection<Language> supportedLanguages =
		[
			new Language {Name = "Arabic", ShortCode = "ar", CultureCode = "ar-AR"},
			new Language {Name = "Bulgarian", ShortCode = "bg", CultureCode = "bg-BG"},
			new Language {Name = "Chinese Simp.", ShortCode = "zh-Hans", CultureCode = "zh-Hans"},
			new Language {Name = "Chinese Trad.", ShortCode = "zh-Hant", CultureCode = "zh-Hant"},
			new Language {Name = "Czech", ShortCode = "cs", CultureCode = "cs-CZ"},
			new Language {Name = "Danish", ShortCode = "da", CultureCode = "da-DK"},
			new Language {Name = "Dutch", ShortCode = "nl", CultureCode = "nl-NL"},
			new Language {Name = "English", ShortCode = "en", CultureCode = "en-US"},
			new Language {Name = "Filipino", ShortCode = "fil", CultureCode = "fil-PH"},
			new Language {Name = "Finish", ShortCode = "fi", CultureCode = "fi-FI"},
			new Language {Name = "French", ShortCode = "fr", CultureCode = "fr-FR"},
			new Language {Name = "German", ShortCode = "de", CultureCode = "de-DE"},
			new Language {Name = "Greek", ShortCode = "el", CultureCode = "el-EL"},
			new Language {Name = "Hebrew", ShortCode = "he", CultureCode = "he-HE"},
			new Language {Name = "Hungarian", ShortCode = "hu", CultureCode = "hu-HU"},
			new Language {Name = "Indonesian", ShortCode = "id", CultureCode = "id-ID"},
			new Language {Name = "Italian", ShortCode = "it", CultureCode = "it-IT"},
			new Language {Name = "Japanese", ShortCode = "ja", CultureCode = "ja-JP"},
			new Language {Name = "Korean", ShortCode = "ko", CultureCode = "ko-KR"},
			new Language {Name = "Malay", ShortCode = "ms", CultureCode = "ms-MY"},
			//new Language {Name = "Norwegian", ShortCode = "no", CultureCode = "no-NO"},
			new Language {Name = "Persian", ShortCode = "fa", CultureCode = "fa-FA"},
			new Language {Name = "Polish", ShortCode = "pl", CultureCode = "pl-PL"},
			new Language {Name = "Portuguese", ShortCode = "pt", CultureCode = "pt-PT"},
			new Language {Name = "Portuguese (Brasil)", ShortCode = "pt-br", CultureCode = "pt-BR"},
			new Language {Name = "Romanian", ShortCode = "ro", CultureCode = "ro-RO"},
			new Language {Name = "Russian", ShortCode = "ru", CultureCode = "ru-RU"},
			new Language {Name = "Slovenian", ShortCode = "sl", CultureCode = "sl-SI"},
			new Language {Name = "Spanish", ShortCode = "es", CultureCode = "es-ES"},
			new Language {Name = "Swedish", ShortCode = "sv", CultureCode = "sv-SV"},
			new Language {Name = "Thai", ShortCode = "th", CultureCode = "th-TH"},
			new Language {Name = "Turkish", ShortCode = "tr", CultureCode = "tr-TR"},
			new Language {Name = "Ukrainian", ShortCode = "uk", CultureCode = "uk-UA"},
			new Language {Name = "Vietnamese", ShortCode = "vi", CultureCode = "vi-VN"},
		];
		supportedLanguages.OrderBy(l => l.Name);
		return supportedLanguages;
	}

	/// <summary>
	///     Sets the localization culture.
	/// </summary>
	/// <param name="culture">ISO code of the new culture.</param>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="InvalidOperationException"></exception>
	/// <exception cref="ArgumentException"></exception>
	public static CultureInfo SetCulture(string culture)
	{
		CultureInfo ci = CultureInfo.InvariantCulture;
		try
		{
			ci = new CultureInfo(culture);
		}
		catch (CultureNotFoundException)
		{
			try
			{
				// Try language without region
				ci = new CultureInfo(culture.Substring(0, 2));
			}
			catch (Exception)
			{
				ci = CultureInfo.InvariantCulture;
			}
		}
		finally
		{
			LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
			LocalizeDictionary.Instance.Culture = ci;
			// fixes the culture in threads
			CultureInfo.DefaultThreadCurrentCulture = ci;
			CultureInfo.DefaultThreadCurrentUICulture = ci;
			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;
		}
		return ci;
	}
}
