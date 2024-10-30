#region Using Directives

using TestApiHelper.Models;

#endregion

namespace TestApiHelper.Communication.Interfaces
{
    public interface ITestCaseService
    {
        #region Methods

        Task<TestCasesResponse> GetTestCases(TestSuitesResponse suites);

        #endregion
    }
}