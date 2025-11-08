using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleDnsCrypt.Controls;

/// <summary>
/// Interaction logic for AdvancedSettings.xaml
/// </summary>
public partial class AdvancedSettings : UserControl
{
	private static readonly Regex _nonNumericRegex = new("[^0-9]+", RegexOptions.Compiled);

	public AdvancedSettings()
	{
		InitializeComponent();
	}

	private void NetprobeTimeout_PreviewTextInput(object sender, TextCompositionEventArgs e)
	{
		e.Handled = _nonNumericRegex.IsMatch(e.Text);
	}

	private void NetprobeTimeout_Pasting(object sender, DataObjectPastingEventArgs e)
	{
		if (e.DataObject.GetDataPresent(typeof(string)))
		{
			var text = (string)e.DataObject.GetData(typeof(string));
			if (_nonNumericRegex.IsMatch(text))
			{
				e.CancelCommand();
			}
		}
		else
		{
			e.CancelCommand();
		}
	}

	private void NetprobeTimeout_PreviewKeyDown(object sender, KeyEventArgs e)
	{
		// Prevent space
		if (e.Key == Key.Space)
			e.Handled = true;
	}

	private void NetprobeTimeout_LostFocus(object sender, RoutedEventArgs e)
	{
		if (sender is TextBox tb)
		{
			if (string.IsNullOrWhiteSpace(tb.Text))
			{
				// set to 0 if empty
				tb.Text = "0";
			}
			else if (!long.TryParse(tb.Text, out var value) || value < 0)
			{
				// invalid -> revert to 0
				tb.Text = "0";
			}
			// update binding source explicitly
			var binding = tb.GetBindingExpression(TextBox.TextProperty);
			binding?.UpdateSource();
		}
	}
}
