#region Using Directives

using Newtonsoft.Json;
using System;

#endregion

namespace TestApiHelper.Models
{
    public class WorkItemResponse
    {
        #region Properties

        public int Id { get; set; }
        public int Rev { get; set; }
        public Fields Fields { get; set; }

        #endregion
    }

    public class Fields
    {
        #region Properties

        [JsonProperty("System.AreaPath")]
        public string AreaPath { get; set; }
        [JsonProperty("System.TeamProject")]
        public string TeamProject { get; set; }
        [JsonProperty("System.IterationPath")]
        public string IterationPath { get; set; }
        [JsonProperty("System.WorkItemType")]
        public string WorkItemType { get; set; }
        [JsonProperty("System.State")]
        public string State { get; set; }
        [JsonProperty("System.Reason")]
        public string Reason { get; set; }
        [JsonProperty("System.AssignedTo")]
        public string AssignedTo { get; set; }
        [JsonProperty("System.CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("System.CreatedBy")]
        public string CreatedBy { get; set; }
        [JsonProperty("System.ChangedDate")]
        public DateTime ChangedDate { get; set; }
        [JsonProperty("System.ChangedBy")]
        public string ChangedBy { get; set; }
        [JsonProperty("System.Title")]
        public string Title { get; set; }
        [JsonProperty("Microsoft.VSTS.Common.StateChangeDate")]
        public DateTime StateChangeDate { get; set; }
        [JsonProperty("Microsoft.VSTS.Common.ActivatedDate")]
        public DateTime ActivatedDate { get; set; }
        [JsonProperty("Microsoft.VSTS.Common.ActivatedBy")]
        public string ActivatedBy { get; set; }
        [JsonProperty("Microsoft.VSTS.Common.ClosedDate")]
        public DateTime ClosedDate { get; set; }
        [JsonProperty("Microsoft.VSTS.Common.ClosedBy")]
        public string ClosedBy { get; set; }
        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public int Priority { get; set; }
        [JsonProperty("Microsoft.VSTS.TCM.AutomationStatus")]
        public string AutomationStatus { get; set; }
        [JsonProperty("System.Description")]
        public string Description { get; set; }
        [JsonProperty("Microsoft.VSTS.TCM.Steps")]
        public string Steps { get; set; }
        [JsonProperty("Microsoft.VSTS.TCM.LocalDataSource")]
        public string LocalDataSource { get; set; }
        [JsonProperty("GNR.Cloned")]
        public string Cloned { get; set; }
        [JsonProperty("GNR.UnderChange")]
        public string UnderChange { get; set; }

        #endregion
    }
}