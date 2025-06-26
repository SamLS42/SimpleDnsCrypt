using Caliburn.Micro;
using System.Windows;

namespace SimpleDnsCrypt.ViewModels;

public class SystemTrayViewModel(IWindowManager windowManager, MainViewModel mainViewModel) : Screen
{
	protected override void OnActivate()
	{
		base.OnActivate();

		NotifyOfPropertyChange(() => CanShowWindow);
		NotifyOfPropertyChange(() => CanHideWindow);
	}

	public void ShowWindow()
	{
		if (!mainViewModel.IsActive)
		{
			windowManager.ShowWindow(mainViewModel);
		}
		NotifyOfPropertyChange(() => CanShowWindow);
		NotifyOfPropertyChange(() => CanHideWindow);
	}

	public bool CanShowWindow => !mainViewModel.IsActive;

	public void HideWindow()
	{
		mainViewModel.TryClose();

		NotifyOfPropertyChange(() => CanShowWindow);
		NotifyOfPropertyChange(() => CanHideWindow);
	}

	public bool CanHideWindow => mainViewModel.IsActive;

	public void ExitApplication()
	{
		Application.Current.Shutdown();
	}
}
