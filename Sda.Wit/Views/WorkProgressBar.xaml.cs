using System;
using System.Windows;
using System.Windows.Controls;

namespace Sda.Wit.Views
{
    /// <summary>
    /// Interaction logic for WorkProgressBar.xaml
    /// </summary>
    public partial class WorkProgressBar : UserControl
    {
        #region Estimated
        public static readonly DependencyProperty EstimatedProperty = DependencyProperty.Register("Estimated", typeof(double), typeof(WorkProgressBar), new PropertyMetadata(EstimatedChangedStatic));
        public double Estimated
        {
            get { return (double)GetValue(EstimatedProperty); }
            set { SetValue(EstimatedProperty, value); }
        }

        private static void EstimatedChangedStatic(Object sender, DependencyPropertyChangedEventArgs e)
        {
            ((WorkProgressBar)sender).EstimatedChanged(e.NewValue);
        }

        private void EstimatedChanged(object parameter)
        {
            background.ToolTip = String.Format("Original Estimate: {0}", parameter.ToString());
        }
        #endregion

        #region Remaining
        public static readonly DependencyProperty RemainingProperty = DependencyProperty.Register("Remaining", typeof(double), typeof(WorkProgressBar), new PropertyMetadata(RemainingChangedStatic));
        public double Remaining
        {
            get { return (double)GetValue(RemainingProperty); }
            set { SetValue(RemainingProperty, value); }
        }

        private static void RemainingChangedStatic(Object sender, DependencyPropertyChangedEventArgs e)
        {
            ((WorkProgressBar)sender).RemainingChanged(e.NewValue);
        }

        private void RemainingChanged(object parameter)
        {

        }
        #endregion

        #region Completed
        public static readonly DependencyProperty CompletedProperty = DependencyProperty.Register("Completed", typeof(double), typeof(WorkProgressBar), new PropertyMetadata(CompletedChangedStatic));
        public double Completed
        {
            get { return (double)GetValue(CompletedProperty); }
            set { SetValue(CompletedProperty, value); }
        }

        private static void CompletedChangedStatic(Object sender, DependencyPropertyChangedEventArgs e)
        {
            ((WorkProgressBar)sender).CompletedChanged(e.NewValue);
        }

        private void CompletedChanged(object parameter)
        {
            double estimated = (double)GetValue(EstimatedProperty);
            double completed = (double)parameter;
            double remaining = estimated - completed;

            if (estimated > 0)
            {
                var percentRealized = (completed * 100) / (estimated + completed);
                var percentEstimated = ((estimated - completed) * 100) / (estimated + completed);
                var percentDue = (completed - estimated) * 100 / (estimated + completed);

                colRealized.Width = new GridLength(percentRealized > 100 ? percentRealized - Math.Abs(percentEstimated * 2) : percentRealized, GridUnitType.Star);
                colEstimated.Width = new GridLength(percentEstimated < 0 ? 0 : percentEstimated, GridUnitType.Star);
                colDue.Width = new GridLength(percentDue < 0 ? 0 : percentDue, GridUnitType.Star);

                barRealized.ToolTip = String.Format("Completed: {0}", completed.ToString());
                barDue.ToolTip = String.Format("Overdue: {0}", (completed - estimated).ToString());
            }
        }
        #endregion


        public WorkProgressBar()
        {
            InitializeComponent();
        }
    }
}
