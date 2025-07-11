using Caliburn.Micro;
using SimpleDnsCrypt.Helper;
using SimpleDnsCrypt.Logger;
using SimpleDnsCrypt.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SimpleDnsCrypt;

public class AppBootstrapper : BootstrapperBase
{
	private CompositionContainer _container;
	private static readonly ILog Log = LogManagerHelper.Factory();
	private static Mutex _mutex = null;

	public AppBootstrapper()
	{
		LogManager.GetLog = type => new NLogLogger(type);
		Initialize();
	}

	protected override void Configure()
	{
		try
		{
			_container = new CompositionContainer(
				new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x))
					.OfType<ComposablePartCatalog>())
			);
			CompositionBatch batch = new();
			batch.AddExportedValue<IWindowManager>(new AppWindowManager());
			batch.AddExportedValue<IEventAggregator>(new EventAggregator());
			batch.AddExportedValue(_container);
			_container.Compose(batch);
		}
		catch (Exception exception)
		{
			Log.Error(exception);
		}
	}

	protected override object GetInstance(Type service, string key)
	{
		string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(service) : key;
		IEnumerable<object> exports = _container.GetExportedValues<object>(contract);

		return exports.Any() ? exports.First() : throw new Exception($"Could not locate any instances of contract {contract}.");
	}

	protected override IEnumerable<object> GetAllInstances(Type service)
	{
		return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(service));
	}

	protected override void BuildUp(object instance)
	{
		_container.SatisfyImportsOnce(instance);
	}

	protected override void OnStartup(object sender, StartupEventArgs e)
	{
		try
		{
			// set the working directory
			Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

			// prevent multiple instances
			const string appName = "SimpleDnsCrypt";
			_mutex = new Mutex(true, appName, out bool createdNew);

			if (!createdNew)
			{
				Application.Current.Shutdown();
			}

			if (e.Args.Length == 1)
			{
				if (e.Args[0].Equals("-debug"))
				{
					LogMode.Debug = true;
				}
			}

			LoaderViewModel loader = _container.GetExportedValue<LoaderViewModel>();
			IWindowManager windowManager = IoC.Get<IWindowManager>();
			windowManager.ShowDialog(loader);
		}
		catch (Exception exception)
		{
			Log.Error(exception);
		}
	}

	protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
	{
		Log.Error(e.Exception);
		Execute.OnUIThread(
			() =>
				MessageBox.Show(
					"There was an UnhandledException. Check the log entries for further information.", "Error", MessageBoxButton.OK, MessageBoxImage.Error));
	}
}