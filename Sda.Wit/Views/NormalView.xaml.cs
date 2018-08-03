using MaterialDesignThemes.Wpf;
using Sda.VSTS.RestApi;
using Sda.VSTS.RestApi.Entities;
using Sda.Wit.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Sda.Wit.Views
{
	/// <summary>
	/// Interaction logic for NormalView.xaml
	/// </summary>
	public partial class NormalView : UserControl
	{
		private MainModel VmData;
		private Client api;
		private Window window;

		public NormalView(Window window)
		{
			InitializeComponent();

			if (window != null)
			{
				this.window = window;
				window.ResizeMode = ResizeMode.CanResizeWithGrip;

				VmData = (MainModel)window.DataContext;
				api = ((MainWindow)window).Api;

				tgbDark.IsChecked = Properties.Settings.Default.IsDarkTheme;

				//if (Properties.Settings.Default.IsDarkTheme)
				//{
				//	var btnCloseWindow = (Button)window.Template.FindName("windowCloseButton", window);
				//	var btnMaximizeWindow = (Button)window.Template.FindName("windowMaximizeButton", window);

				//	btnCloseWindow.Style = (Style)FindResource("WindowButton");
				//	btnMaximizeWindow.Style = (Style)FindResource("WindowButton");
				//}
			}
			else
			{
				throw new Exception("Something went very wrong. Cannot find parent window.");
			}
		}

		private void LoadWorkItems()
		{
			//if (VmData.WorkItems == null || VmData.WorkItems.Count == 0)
			//{
			var result = api.WorkItemTracking.GetWorkItemsByQueryId(VmData.CurrentQuery);

			if (result.Count > 0)
			{
				var orderedResult = result.OrderBy(q => q.Fields.State).ThenBy(q => q.Fields.Title);
				VmData.WorkItems = new ObservableCollection<WorkItem>(orderedResult);
				VmData.CurrentWorkItem = orderedResult.FirstOrDefault(); //TODO: verificar se existe item ativo
			}
			else
			{
				VmData.WorkItems = null;
			}
			//}
		}

		private void TitleBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Application.Current.MainWindow.DragMove();
		}

		private void lbiAlwaysOnTop_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var checkBox = (ToggleButton)((Grid)((ListBoxItem)sender).Content).Children[2];
			checkBox.IsChecked = !checkBox.IsChecked;
		}

		private void ckbAlwaysOnTop_Checked(object sender, RoutedEventArgs e)
		{
			window.Topmost = VmData.AlwaysOnTop;

			Properties.Settings.Default.AlwaysOnTop = VmData.AlwaysOnTop;
			Properties.Settings.Default.Save();
		}

		private async Task OpenPopup()
		{
			var view = new ChangeQuery { DataContext = this.DataContext };
			var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
		}

		private async void DialogHost_Loaded(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrEmpty(VmData.CurrentQuery))
			{
				await OpenPopup();
			}
			else
			{
				LoadWorkItems();
			}
		}

		private async void lbiChangeQuery_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			DrawerHost.CloseDrawerCommand.Execute(Dock.Left, null);
			await OpenPopup();
		}

		private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
		{
			if ((String)eventArgs.Parameter == "Cancel") return;

			var selectedQuery = (Query)((TreeView)((ChangeQuery)eventArgs.Session.Content).FindName("treeQueries")).SelectedItem;

			if (selectedQuery.IsFolder)
			{
				eventArgs.Cancel();
			}
			else
			{
				VmData.CurrentQuery = selectedQuery.Id;
				LoadWorkItems();

				Properties.Settings.Default.QueryId = selectedQuery.Id;
				Properties.Settings.Default.Save();
			}
		}

		private void tgbDark_Checked(object sender, RoutedEventArgs e)
		{
			var isDark = (bool)((ToggleButton)sender).IsChecked;
			new PaletteHelper().SetLightDark(isDark);

			Properties.Settings.Default.IsDarkTheme = isDark;
			Properties.Settings.Default.Save();
		}

		private void lbiDarkTheme_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var checkBox = ((ToggleButton)((Grid)((ListBoxItem)sender).Content).Children[2]);
			checkBox.IsChecked = !checkBox.IsChecked;
		}

        private void lbiLogout_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Client.SignOut();
            Application.Current.Shutdown();
        }

    }
}
