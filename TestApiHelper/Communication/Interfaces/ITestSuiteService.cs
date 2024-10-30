#region Using Directives

using TestApiHelper.Models;

#endregion

namespace TestApiHelper.Communication.Interfaces
{
    public interface ITestSuiteService
    {
        #region Methods

        Task<TestSuitesResponse> GetSuites(TestPlanResponse suite);

        #endregion
    }
}