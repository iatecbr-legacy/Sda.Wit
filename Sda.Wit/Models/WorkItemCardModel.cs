using Sda.VSTS.RestApi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sda.Wit.Models
{
    class WorkItemCardModel : INotifyPropertyChanged
    {
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

        public WorkItemCardModel()
        {

        }

        public WorkItemCardModel(WorkItem workItem)
        {
            this.CurrentWorkItem = workItem;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
