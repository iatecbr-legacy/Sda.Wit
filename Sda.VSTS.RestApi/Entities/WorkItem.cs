using Newtonsoft.Json;
using System.ComponentModel;

namespace Sda.VSTS.RestApi.Entities
{
	public class WorkItem : INotifyPropertyChanged
    {
		public int Id { get; set; }

		[JsonProperty(PropertyName = "rev")]
		public int Revision { get; set; }

		//public WorkItemFields Fields { get; set; }

        private WorkItemFields fields;
        public WorkItemFields Fields
        {
            get
            {
                return this.fields;
            }
            set
            {
                this.fields = value;
                this.NotifyPropertyChanged("Fields");
            }
        }

        public string Url { get; set; }


		public override string ToString()
		{
			return string.Format("{0} - {1}", this.Id.ToString(), this.Fields.Title);
		}

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
