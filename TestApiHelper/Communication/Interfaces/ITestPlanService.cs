#region Using Directives

using TestApiHelper.Models;

#endregion

namespace TestApiHelper.Communication.Interfaces
{
    public interface ITestPlanService
    {
        #region Methods

        Task<string> GetTestPlanName(int testPlanId);

        Task<TestPlanResponse> GetTestPlan(int testplanid);

        Task<List<WorkItemResponse>> FetchTestCasesForTestPlan(ITestPlanService testPlanService, ITestSuiteService testSuiteService, ITestCaseService testCaseService, IWorkItemService workItemService, int testPlanId);

        #endregion
    }
}