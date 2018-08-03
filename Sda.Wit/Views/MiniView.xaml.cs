using MaterialDesignThemes.Wpf;
using Sda.Wit.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Sda.Wit.Views
{
	/// <summary>
	/// Interaction logic for MiniView.xaml
	/// </summary>
	public partial class MiniView : UserControl
	{
		private Window window;
		private MainModel VmData;

		private Button btnCloseWindow;
		private Button btnMaximizeWindow;

		public MiniView(Window window)
		{
			InitializeComponent();

			if (window != null)
			{
				this.window = window;
				window.ResizeMode = ResizeMode.NoResize;

				VmData = (MainModel)window.DataContext;
				this.DataContext = VmData;

				btnCloseWindow = (Button)window.Template.FindName("windowCloseButton", window);
				btnMaximizeWindow = (Button)window.Template.FindName("windowMaximizeButton", window);

				((PackIcon)btnMaximizeWindow.Content).Kind = PackIconKind.ChevronDown;

				if (Properties.Settings.Default.IsDarkTheme)
				{
					colorZone.SetResourceReference(ContentControl.BackgroundProperty, "MaterialDesignPaper");
					colorZone.SetResourceReference(ContentControl.ForegroundProperty, "MaterialDesignBody");

					btnCloseWindow.Style = (Style)FindResource("WindowDarkButton");
					btnMaximizeWindow.Style = (Style)FindResource("WindowDarkButton");
				}
			}
			else
			{
				throw new Exception("Something went very wrong. Cannot find parent window.");
			}
		}

		private void ColorZone_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			gridView.Visibility = Visibility.Collapsed;
			workItemCard.Visibility = Visibility.Visible;

			btnCloseWindow.Visibility = Visibility.Collapsed;
			btnMaximizeWindow.Visibility = Visibility.Collapsed;

			this.Height = 148;
			this.Width = 450;

			window.Height = this.Height;
			window.Width = this.Width;
		}

		private void workItemCard_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			gridView.Visibility = Visibility.Visible;
			workItemCard.Visibility = Visibility.Collapsed;

			btnCloseWindow.Visibility = Visibility.Visible;
			btnMaximizeWindow.Visibility = Visibility.Visible;

			this.Height = 27;
			this.Width = 150;

			window.Height = this.Height;
			window.Width = this.Width;

		}

		private void UserControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Application.Current.MainWindow.DragMove();
		}
	}
}
