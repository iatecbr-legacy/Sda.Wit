using MaterialDesignThemes.Wpf;
using Sda.VSTS.RestApi.Entities;
using Sda.Wit.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace Sda.Wit.Views
{
    /// <summary>
    /// Interaction logic for WorkItemCard.xaml
    /// </summary>
    public partial class WorkItemCard : UserControl
    {


        #region WorkItem

        //public static readonly DependencyProperty WorkItemProperty = DependencyProperty.Register("WorkItem", typeof(WorkItem), typeof(WorkItemCard), new PropertyMetadata(WorkItemChangedStatic));
        public static readonly DependencyProperty WorkItemProperty = DependencyProperty.Register("WorkItem", typeof(WorkItem), typeof(WorkItemCard));
        public WorkItem WorkItem
        {
            get
            {
                return (WorkItem)GetValue(WorkItemProperty);
            }
            set
            {
                SetValue(WorkItemProperty, value);
            }
        }

        //private static void WorkItemChangedStatic(Object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    ((WorkItemCard)sender).WorkItemChanged(e.NewValue);
        //}

        //private void WorkItemChanged(object parameter)
        //{
        //    var workItem = (WorkItem)parameter;

        //    if (workItem != null)
        //    {
        //        this.DataContext = workItem;

        //        if (workItem.Fields.State == "Active")
        //        {
        //            Card.SetResourceReference(ContentControl.BackgroundProperty, "PrimaryHueMidBrush");
        //            Card.SetResourceReference(ContentControl.ForegroundProperty, "PrimaryHueMidForegroundBrush");
        //            Icon.Kind = PackIconKind.Pause;
        //        }
        //        else
        //        {
        //            //Card.SetResourceReference(ContentControl.BackgroundProperty, "PrimaryHueMidBrush");
        //            //Card.SetResourceReference(ContentControl.ForegroundProperty, "PrimaryHueMidForegroundBrush");
        //            Icon.Kind = PackIconKind.Play;
        //        }

        //        //if (workItem.Fields.WorkItemType == "Bug")
        //        //{
        //        //    TypeIcon.Kind = PackIconKind.Bug;
        //        //}
        //    }
        //}
        #endregion

        private MainModel VmData;

        public WorkItemCard()
        {
            InitializeComponent();

            //DataContext = this.WorkItem;
            VmData = (MainModel)Application.Current.MainWindow.DataContext;


            var a = new WorkItemCardModel((WorkItem)this.DataContext);
        }

        private void btnTaskTimer_Click(object sender, RoutedEventArgs e)
        {
            WorkItem workItem = (WorkItem)this.DataContext;
            if (this.WorkItem == null)
            {
                this.WorkItem = workItem;
            }

            if (this.WorkItem != VmData.CurrentWorkItem)
            {
                VmData.CurrentWorkItem = this.WorkItem;

            }
            else
            {


            }

            if (this.WorkItem.Fields.State == "Active")
            {
                VmData.StopTimer();
                this.WorkItem.Fields.State = "New";

                SetPlayButton(this.Card);
            }
            else
            {
                VmData.StartTimer();
                this.WorkItem.Fields.State = "Active";

                Card.SetResourceReference(ContentControl.BackgroundProperty, "PrimaryHueMidBrush");
                Card.SetResourceReference(ContentControl.ForegroundProperty, "PrimaryHueMidForegroundBrush");
                TypeIcon.Foreground = TypeToColorConverter.GetIconColor(this.WorkItem.Fields.WorkItemType, this.WorkItem.Fields.State);
                Icon.Kind = PackIconKind.Pause;
            }

            WorkItem a = new WorkItem();
            VmData.WorkItems.Add(a);
            VmData.WorkItems.Remove(a);
            //VmData.WorkItems = null;
            VmData.CurrentWorkItem = workItem;
            VmData.NotifyPropertyChanged("WorkItems");
            VmData.NotifyPropertyChanged("CurrentWorkItem");
        }

        private void SetPlayButton(Card card)
        {
            Card.SetResourceReference(ContentControl.BackgroundProperty, "MaterialDesignBackground");
            Card.SetResourceReference(ContentControl.ForegroundProperty, "MaterialDesignBody");
            TypeIcon.Foreground = TypeToColorConverter.GetIconColor(this.WorkItem.Fields.WorkItemType, this.WorkItem.Fields.State);
            Icon.Kind = PackIconKind.Play;
        }

        private void btnOpenInBrowser_Click(object sender, RoutedEventArgs e)
        {
            WorkItem workItem = (WorkItem)this.DataContext;

            var uri = new Uri(workItem.Url);
            var url = String.Format("{0}://{1}/{2}/{3}", uri.Scheme, uri.Host, "_workitems/edit", workItem.Id);
            System.Diagnostics.Process.Start(url);
        }

    }

    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value as string;

            switch (s)
            {
                case "New":
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#B2B2B2"));
                case "Active":
                case "Resolved": //se for bug, Resolved é amarelo
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#007ACC"));
                case "Closed":
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#339933"));
                case "Removed":
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));

                default:
                    break;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class TypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = value as string;

            switch (type)
            {
                case "Bug": return "";
                case "Task": return "";
                case "Epic": return "";
                case "Feature": return "";
                case "Issue": return "";
                case "Test Case": return "";
                case "Test Task": return "";
                case "User Story": return "";
                default: return "";
            }
        }

        public object ConvertBack(object valuex, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class TypeToColorConverter : IMultiValueConverter
    {
        public static SolidColorBrush GetIconColor(string type, string status)
        {
            if (status == "Active")
            {
                return (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            }

            switch (type)
            {
                case "Bug": return (SolidColorBrush)(new BrushConverter().ConvertFrom("#CC293D"));
                case "Task": return (SolidColorBrush)(new BrushConverter().ConvertFrom("#F2CB1D"));
                case "Epic": return (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF7B00"));
                case "Feature": return (SolidColorBrush)(new BrushConverter().ConvertFrom("#773B93"));
                case "Issue": return (SolidColorBrush)(new BrushConverter().ConvertFrom("#B4009E"));
                case "Test Case": return (SolidColorBrush)(new BrushConverter().ConvertFrom("#004B50"));
                case "Test Task": return (SolidColorBrush)(new BrushConverter().ConvertFrom("#00643A"));
                case "User Story": return (SolidColorBrush)(new BrushConverter().ConvertFrom("#009CCC"));
                default: return (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            }
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue && values[1] == DependencyProperty.UnsetValue)
            {
                return null;
            }
            var type = (string)values[0];
            var status = (string)values[1];

            return GetIconColor(type, status);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
