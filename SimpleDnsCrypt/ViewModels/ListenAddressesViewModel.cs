﻿using Caliburn.Micro;
using SimpleDnsCrypt.Config;
using SimpleDnsCrypt.Helper;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

namespace SimpleDnsCrypt.ViewModels;

[Export(typeof(ListenAddressesViewModel))]
[method: ImportingConstructor]
public class ListenAddressesViewModel() : Screen
{
	private string _windowTitle;
	private ObservableCollection<string> _listenAddresses = [];
	private string _selectedListenAddress;
	private string _addressInput;

	/// <summary>
	///     The title of the window.
	/// </summary>
	public string WindowTitle
	{
		get => _windowTitle;
		set
		{
			_windowTitle = value;
			NotifyOfPropertyChange(() => WindowTitle);
		}
	}

	public ObservableCollection<string> ListenAddresses
	{
		get => _listenAddresses;
		set
		{
			_listenAddresses = value;
			NotifyOfPropertyChange(() => ListenAddresses);
		}
	}

	public string SelectedListenAddress
	{
		get => _selectedListenAddress;
		set
		{
			_selectedListenAddress = value;
			NotifyOfPropertyChange(() => SelectedListenAddress);
		}
	}

	public string AddressInput
	{
		get => _addressInput;
		set
		{
			_addressInput = value;
			NotifyOfPropertyChange(() => AddressInput);
		}
	}

	public void AddAddress()
	{
		if (string.IsNullOrEmpty(_addressInput))
		{
			return;
		}

		string validatedAddress = ValidationHelper.ValidateIpEndpoint(_addressInput);
		if (string.IsNullOrEmpty(validatedAddress))
		{
			return;
		}

		if (ListenAddresses.Contains(validatedAddress))
		{
			return;
		}

		ListenAddresses.Add(validatedAddress);
		AddressInput = string.Empty;
	}

	public void RemoveAddress()
	{
		if (string.IsNullOrEmpty(_selectedListenAddress))
		{
			return;
		}

		if (_listenAddresses.Count == 1)
		{
			return;
		}

		_listenAddresses.Remove(_selectedListenAddress);
	}

	public void RestoreDefault()
	{
		ListenAddresses.Clear();
		ListenAddresses.Add(Global.DefaultResolverIpv4);
		ListenAddresses.Add(Global.DefaultResolverIpv6);
	}
}
