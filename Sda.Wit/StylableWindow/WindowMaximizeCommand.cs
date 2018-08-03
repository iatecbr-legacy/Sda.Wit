using MaterialDesignThemes.Wpf;
using Sda.Wit.Models;
using Sda.Wit.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sda.Wit.StyleableWindow
{
	public class WindowMaximizeCommand : ICommand
	{

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			var window = parameter as Window;

			if (window != null)
			{
				MainModel vm = (MainModel)window.DataContext;

				if (vm.WindowState == WindowState.Normal || vm.WindowState == WindowState.Maximized)
				{
					vm.WindowState = WindowState.Minimized;
					var miniView = new MiniView(window);
					window.Content = miniView;

					window.Height = miniView.Height;
					window.Width = miniView.Width;
				}
				else if (vm.WindowState == WindowState.Minimized)
				{
					vm.WindowState = WindowState.Normal;
					var normalView = new NormalView(window);
					window.Content = null;

					var btnCloseWindow = (Button)window.Template.FindName("windowCloseButton", window);
					var btnMaximizeWindow = (Button)window.Template.FindName("windowMaximizeButton", window);

					((PackIcon)btnMaximizeWindow.Content).Kind = PackIconKind.ChevronUp;

					if (Properties.Settings.Default.IsDarkTheme)
					{
						btnCloseWindow.Style = (Style)Application.Current.FindResource("WindowButton");
						btnMaximizeWindow.Style = (Style)Application.Current.FindResource("WindowButton");
					}

					window.Height = 640;
					window.Width = 420;
					window.Content = normalView;
				}

				//if (window.WindowState == WindowState.Maximized)
				//{
				//	window.WindowState = WindowState.Normal;
				//}
				//else
				//{
				//	window.WindowState = WindowState.Maximized;
				//}
			}
		}
	}
}
