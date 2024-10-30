#region Using Directives

using TestApiHelper.Models;

#endregion

namespace TestApiHelper.Communication.Interfaces
{
    public interface IWorkItemService
    {
        #region Methods

        Task<WorkItemResponse> GetWorkItem(int workItemId);
        Task<int> UpdateAutomationStatus(int workItemId, string newStatus);
        Task<int> UpdateState(int workItemId, string newState);
        Task<int> UpdateTitle(int workItemId, string title);
        Task<int> UpdateDescription(int workItemId, string description);
        Task<int> UpdateSteps(int workItemId, List<string> scenarioSteps, List<Dictionary<string, string>> examples);

        #endregion
    }
}