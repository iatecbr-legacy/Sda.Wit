using Sda.VSTS.RestApi.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace Sda.Wit.Models
{
	public class MainModel : INotifyPropertyChanged
	{
        public MainModel()
        {
            dispatcherTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            dispatcherTimer.Tick += dispatcherTimer_Tick;
        }

        #region Timer

        DispatcherTimer dispatcherTimer;

		private void dispatcherTimer_Tick(object sender, EventArgs e)
		{
			this.ElapsedTime = this.ElapsedTime.Add(((DispatcherTimer)sender).Interval);
		}


        public void StartTimer()
        {
            this.IsTimerRunning = true;
            this.StartTime = DateTime.Now;
            dispatcherTimer.Start();
        }

        public void StopTimer()
        {
            this.IsTimerRunning = false;
            this.ElapsedTime = TimeSpan.Zero;
            this.EndTime = DateTime.Now;

            dispatcherTimer.Stop();
        }

        private TimeSpan elapsedTime;
		public TimeSpan ElapsedTime
		{
			get
			{
				return this.elapsedTime;
			}
			set
			{
				this.elapsedTime = value;
				this.NotifyPropertyChanged("ElapsedTime");
			}
		}

        private DateTime startTime;
        public DateTime StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                this.startTime = value;
                this.NotifyPropertyChanged("StartTime");
            }
        }

        private DateTime endTime;
        public DateTime EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                this.endTime = value;
                this.NotifyPropertyChanged("EndTime");
            }
        }

        private bool isTimerRunning;
        public bool IsTimerRunning
        {
            get
            {
                return this.isTimerRunning;
            }
            set
            {
                this.isTimerRunning = value;
                this.NotifyPropertyChanged("IsTimerRunning");
            }
        }

        #endregion

        private ObservableCollection<WorkItem> workItems;
		public ObservableCollection<WorkItem> WorkItems
		{
			get
			{
				return this.workItems;
			}
			set
			{
				this.workItems = value;
				this.NotifyPropertyChanged("WorkItems");
			}
		}

		private List<Query> queries;
		public List<Query> Queries
		{
			get
			{
				return this.queries;
			}
			set
			{
				this.queries = value;
				this.NotifyPropertyChanged("Queries");
			}
		}

		private string currentQuery;
		public string CurrentQuery
		{
			get
			{
				return this.currentQuery;
			}
			set
			{
				this.currentQuery = value;
				this.NotifyPropertyChanged("CurrentQuery");
			}
		}

		private bool alwaysOnTop;
		public bool AlwaysOnTop
		{
			get
			{
				return this.alwaysOnTop;
			}
			set
			{
				this.alwaysOnTop = value;
				this.NotifyPropertyChanged("AlwaysOnTop");
			}
		}

		private WindowState windowState;
		public WindowState WindowState
		{
			get
			{
				return this.windowState;
			}
			set
			{
				this.windowState = value;
				this.NotifyPropertyChanged("WindowState");
			}
		}

		private WorkItem currentWorkItem;
		public WorkItem CurrentWorkItem
		{
			get
			{
				return this.currentWorkItem;
			}
			set
			{
				this.currentWorkItem = value;
				this.NotifyPropertyChanged("CurrentWorkItem");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged(string propName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
	}
}
