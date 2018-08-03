using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Sda.VSTS.RestApi.Entities
{
    public class WorkItemFields: INotifyPropertyChanged
    {
        [JsonProperty(PropertyName = "System.AreaPath")]
        public string AreaPath { get; set; }

        [JsonProperty(PropertyName = "System.TeamProject")]
        public string TeamProject { get; set; }

        [JsonProperty(PropertyName = "System.IterationPath")]
        public string IterationPath { get; set; }

        [JsonProperty(PropertyName = "System.WorkItemType")]
        string workItemType;
        public string WorkItemType
        {
            get
            {
                return workItemType;
            }
            set
            {
                if (workItemType != value)
                {
                    workItemType = value;
                    RaisePropertyChanged("MyProperty");
                }
            }
        }

        [JsonProperty(PropertyName = "System.State")]
        string state;
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                state = value;
                RaisePropertyChanged("State");
            }
        }

        [JsonProperty(PropertyName = "System.Reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "System.AssignedTo")]
        public string AssignedTo { get; set; }

        [JsonProperty(PropertyName = "System.CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "System.CreatedBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "System.ChangedDate")]
        public DateTime ChangedDate { get; set; }

        [JsonProperty(PropertyName = "System.ChangedBy")]
        public string ChangedBy { get; set; }

        [JsonProperty(PropertyName = "System.Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.RemainingWork")]
        public double RemainingWork { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.OriginalEstimate")]
        double originalEstimate;
        public double OriginalEstimate
        {
            get
            {
                return originalEstimate;
            }
            set
            {
                if (originalEstimate != value)
                {
                    originalEstimate = value;
                    RaisePropertyChanged("OriginalEstimate");
                }
            }
        }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.CompletedWork")]
        double completedWork;
        public double CompletedWork
        {
            get
            {
                return completedWork;
            }
            set
            {
                if (completedWork != value)
                {
                    completedWork = value;
                    RaisePropertyChanged("CompletedWork");
                }
            }
        }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.Activity")]
        public string Activity { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.StateChangeDate")]
        public DateTime StateChangeDate { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.ActivatedDate")]
        public DateTime ActivatedDate { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.ActivatedBy")]
        public string ActivatedBy { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.Priority")]
        public int Priority { get; set; }

        [JsonProperty(PropertyName = "System.Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.StackRank")]
        public double? StackRank { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.Severity")]
        public string Severity { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.ValueArea")]
        public string ValueArea { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.ReproSteps")]
        public string ReproSteps { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.Size")]
        public double Size { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Build.FoundIn")]
        public string FoundIn { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Build.IntegrationBuild")]
        public string IntegrationBuild { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CMMI.Blocked")]
        public string Blocked { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.AcceptedBy")]
        public string AcceptedBy { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.AcceptedDate")]
        public string AcceptedDate { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.ClosedStatus")]
        public string ClosedStatus { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.ClosedStatusCode")]
        public string ClosedStatusCode { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.ClosingComment")]
        public string ClosingComment { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.Context")]
        public string AssociatedContext { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.ContextCode")]
        public string AssociatedContextCode { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.ContextOwner")]
        public string AssociatedContextOwner { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.ContextType")]
        public string AssociatedContextType { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.AcceptanceCriteria")]
        public string AcceptanceCriteria { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.BacklogPriority")]
        public string BacklogPriority { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.BusinessValue")]
        public string BusinessValue { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.ClosedBy")]
        public string ClosedBy { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.ClosedDate")]
        public string ClosedDate { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.Issue")]
        public string Issue { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.Rating")]
        public string Rating { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.Resolution")]
        public string Resolution { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.ReviewedBy")]
        public string ReviewedBy { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.StateCode")]
        public string StateCode { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Feedback.ApplicationLaunchInstructions")]
        public string ApplicationLaunchInstructions { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Feedback.ApplicationStartInformation")]
        public string ApplicationStartInformation { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Feedback.ApplicationType")]
        public string ApplicationType { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.Effort")]
        public string Effort { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.FinishDate")]
        public string FinishDate { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.StartDate")]
        public string StartDate { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.Scheduling.TargetDate")]
        public string TargetDate { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.AutomatedTestId")]
        public string AutomatedTestId { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.AutomatedTestName")]
        public string AutomatedTestName { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.AutomatedTestStorage")]
        public string AutomatedTestStorage { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.AutomatedTestType")]
        public string AutomatedTestType { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.AutomationStatus")]
        public string Automationstatus { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.LocalDataSource")]
        public string LocalDataSource { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.Parameters")]
        public string Parameters { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.QueryText")]
        public string QueryText { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.Steps")]
        public string Steps { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.SystemInfo")]
        public string SystemInfo { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.TestSuiteAudit")]
        public string TestSuiteAudit { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.TestSuiteType")]
        public string TestSuiteType { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.TestSuiteTypeId")]
        public string TestSuiteTypeId { get; set; }

        [JsonProperty(PropertyName = "System.AreaId")]
        public string AreaID { get; set; }

        [JsonProperty(PropertyName = "System.AreaLevel1")]
        public string AreaLevel1 { get; set; }

        [JsonProperty(PropertyName = "System.AreaLevel2")]
        public string AreaLevel2 { get; set; }

        [JsonProperty(PropertyName = "System.AreaLevel3")]
        public string AreaLevel3 { get; set; }

        [JsonProperty(PropertyName = "System.AreaLevel4")]
        public string AreaLevel4 { get; set; }

        [JsonProperty(PropertyName = "System.AreaLevel5")]
        public string AreaLevel5 { get; set; }

        [JsonProperty(PropertyName = "System.AreaLevel6")]
        public string AreaLevel6 { get; set; }

        [JsonProperty(PropertyName = "System.AreaLevel7")]
        public string AreaLevel7 { get; set; }

        [JsonProperty(PropertyName = "System.AttachedFileCount")]
        public string AttachedFileCount { get; set; }

        [JsonProperty(PropertyName = "System.AttachedFiles")]
        public string AttachedFiles { get; set; }

        [JsonProperty(PropertyName = "System.AuthorizedAs")]
        public string AuthorizedAs { get; set; }

        [JsonProperty(PropertyName = "System.AuthorizedDate")]
        public string AuthorizedDate { get; set; }

        [JsonProperty(PropertyName = "System.BISLinks")]
        public string BISLinks { get; set; }

        [JsonProperty(PropertyName = "System.ExternalLinkCount")]
        public string ExternalLinkCount { get; set; }

        [JsonProperty(PropertyName = "System.History")]
        public string History { get; set; }

        [JsonProperty(PropertyName = "System.HyperLinkCount")]
        public string HyperlinkCount { get; set; }

        [JsonProperty(PropertyName = "System.Id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "System.InAdminOnlyTreeFlag")]
        public string InAdminOnlyTreeFlag { get; set; }

        [JsonProperty(PropertyName = "System.InDeletedTreeFlag")]
        public string InDeletedTreeFlag { get; set; }

        [JsonProperty(PropertyName = "System.IterationId")]
        public string IterationID { get; set; }

        [JsonProperty(PropertyName = "System.IterationLevel1")]
        public string IterationLevel1 { get; set; }

        [JsonProperty(PropertyName = "System.IterationLevel2")]
        public string IterationLevel2 { get; set; }

        [JsonProperty(PropertyName = "System.IterationLevel3")]
        public string IterationLevel3 { get; set; }

        [JsonProperty(PropertyName = "System.IterationLevel4")]
        public string IterationLevel4 { get; set; }

        [JsonProperty(PropertyName = "System.IterationLevel5")]
        public string IterationLevel5 { get; set; }

        [JsonProperty(PropertyName = "System.IterationLevel6")]
        public string IterationLevel6 { get; set; }

        [JsonProperty(PropertyName = "System.IterationLevel7")]
        public string IterationLevel7 { get; set; }

        [JsonProperty(PropertyName = "System.LinkedFiles")]
        public string LinkedFiles { get; set; }

        [JsonProperty(PropertyName = "System.Links.LinkType")]
        public string LinkType { get; set; }

        [JsonProperty(PropertyName = "System.NodeName")]
        public string NodeName { get; set; }

        [JsonProperty(PropertyName = "System.NodeType")]
        public string NodeType { get; set; }

        [JsonProperty(PropertyName = "System.PersonId")]
        public string PersonID { get; set; }

        [JsonProperty(PropertyName = "System.ProjectId")]
        public string ProjectID { get; set; }

        [JsonProperty(PropertyName = "System.RelatedLinkCount")]
        public string RelatedLinkCount { get; set; }

        [JsonProperty(PropertyName = "System.RelatedLinks")]
        public string RelatedLinks { get; set; }

        [JsonProperty(PropertyName = "System.Rev")]
        public string Rev { get; set; }

        [JsonProperty(PropertyName = "System.RevisedDate")]
        public string RevisedDate { get; set; }

        [JsonProperty(PropertyName = "System.Tags")]
        public string Tags { get; set; }

        [JsonProperty(PropertyName = "System.TFServer")]
        public string TFServer { get; set; }

        [JsonProperty(PropertyName = "System.Watermark")]
        public string Watermark { get; set; }

        [JsonProperty(PropertyName = "System.WorkItemForm")]
        public string WorkItemForm { get; set; }

        [JsonProperty(PropertyName = "System.WorkItemFormId")]
        public string WorkItemFormID { get; set; }

        [JsonProperty(PropertyName = "WEF_4361695967364731A3A602D54E11A522_Kanban.Column")]
        public string WEF_4361695967364731A3A602D54E11A522_FeaturesColumn { get; set; }

        [JsonProperty(PropertyName = "WEF_4361695967364731A3A602D54E11A522_System.ExtensionMarker")]
        public string WEF_4361695967364731A3A602D54E11A522_ExtensionMarker { get; set; }

        [JsonProperty(PropertyName = "WEF_4E8EFA1942384BC3856B5E64506F5934_Kanban.Column")]
        public string WEF_4E8EFA1942384BC3856B5E64506F5934_FeaturesColumn { get; set; }

        [JsonProperty(PropertyName = "WEF_4E8EFA1942384BC3856B5E64506F5934_System.ExtensionMarker")]
        public string WEF_4E8EFA1942384BC3856B5E64506F5934_ExtensionMarker { get; set; }

        [JsonProperty(PropertyName = "WEF_6CB513B6E70E43499D9FC94E5BBFB784_Kanban.Column")]
        public string WEF_6CB513B6E70E43499D9FC94E5BBFB784_BacklogitemsColumn { get; set; }

        [JsonProperty(PropertyName = "WEF_6CB513B6E70E43499D9FC94E5BBFB784_System.ExtensionMarker")]
        public string WEF_6CB513B6E70E43499D9FC94E5BBFB784_ExtensionMarker { get; set; }

        [JsonProperty(PropertyName = "WEF_82492A114E2B498998D17A01C85E3552_Kanban.Column")]
        public string WEF_82492A114E2B498998D17A01C85E3552_FeaturesColumn { get; set; }

        [JsonProperty(PropertyName = "WEF_82492A114E2B498998D17A01C85E3552_System.ExtensionMarker")]
        public string WEF_82492A114E2B498998D17A01C85E3552_ExtensionMarker { get; set; }

        [JsonProperty(PropertyName = "WEF_855DC225BBCF4310BFC0EBE016173F80_Kanban.Column")]
        public string WEF_855DC225BBCF4310BFC0EBE016173F80_BacklogitemsColumn { get; set; }

        [JsonProperty(PropertyName = "WEF_855DC225BBCF4310BFC0EBE016173F80_System.ExtensionMarker")]
        public string WEF_855DC225BBCF4310BFC0EBE016173F80_ExtensionMarker { get; set; }

        [JsonProperty(PropertyName = "WEF_BAA7879501C0497D8036CC13CF6122B2_Kanban.Column")]
        public string WEF_BAA7879501C0497D8036CC13CF6122B2_BacklogitemsColumn { get; set; }

        [JsonProperty(PropertyName = "WEF_BAA7879501C0497D8036CC13CF6122B2_System.ExtensionMarker")]
        public string WEF_BAA7879501C0497D8036CC13CF6122B2_ExtensionMarker { get; set; }

        [JsonProperty(PropertyName = "WEF_EE49F472197F4A5BA0F259BA7251D994_Kanban.Column")]
        public string WEF_EE49F472197F4A5BA0F259BA7251D994_BacklogitemsColumn { get; set; }

        [JsonProperty(PropertyName = "WEF_EE49F472197F4A5BA0F259BA7251D994_System.ExtensionMarker")]
        public string WEF_EE49F472197F4A5BA0F259BA7251D994_ExtensionMarker { get; set; }

        [JsonProperty(PropertyName = "WEF_F9C56016EE7B42ECA999258C1E1204B5_Kanban.Column")]
        public string WEF_F9C56016EE7B42ECA999258C1E1204B5_FeaturesColumn { get; set; }

        [JsonProperty(PropertyName = "WEF_F9C56016EE7B42ECA999258C1E1204B5_System.ExtensionMarker")]
        public string WEF_F9C56016EE7B42ECA999258C1E1204B5_ExtensionMarker { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}