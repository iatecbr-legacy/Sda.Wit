using MaterialDesignThemes.Wpf;
using Sda.VSTS.RestApi;
using Sda.Wit.Models;
using Sda.Wit.Views;
using System;
using System.Windows;

namespace Sda.Wit
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainModel VmData
		{
			get { return DataContext as MainModel; }
			set { DataContext = value; }
		}

		public Client Api;

		public MainWindow()
		{
			Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;

			InitializeComponent();

            Api = new Client("Sda.Afs"); //"rblzoqzbfkxiuqnnd5bgqpifrsurs5jiplmofipyhejesxjaqpoa"


            VmData = new MainModel();

            this.Content = new NormalView(this);
            CheckSettings();

            try
            {
                VmData.Queries = Api.WorkItemTracking.GetAllQueries().Items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //VmData.StartTimer();
        }

        private void SendError(string error)
		{
			//var messageQueue = snackbar.MessageQueue;
			//Task.Factory.StartNew(() => messageQueue.Enqueue(error));
		}

		public void CheckSettings()
		{
			this.Topmost = Properties.Settings.Default.AlwaysOnTop;
			VmData.AlwaysOnTop = Properties.Settings.Default.AlwaysOnTop;
			VmData.CurrentQuery = Properties.Settings.Default.QueryId;
			new PaletteHelper().SetLightDark(Properties.Settings.Default.IsDarkTheme);
		}

		private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			SendError(e.Exception.Message);
			//e.Handled = true;
		}

		private void Window_StateChanged(object sender, EventArgs e)
		{
			if (WindowState == WindowState.Maximized)
			{
				WindowState = WindowState.Normal;
			}
		}

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var a = 1;
        }
    }

}
