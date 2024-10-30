#region Using Directives

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using TestApiHelper.Communication.Interfaces;
using TestApiHelper.Models;

#endregion

namespace TestApiHelper.Communication.Services
{
    public class TestPlanService : AzureDevOpsService, ITestPlanService
    {
        #region Constructors

        public TestPlanService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
            // Empty constructor - all initialization logic is in the base class AzureDevOpsService
        }

        #endregion

        #region Public Methods

        public async Task<string> GetTestPlanName(int testPlanId)
        {
            var testPlanResponse = await GetTestPlan(testPlanId);
            return testPlanResponse?.Name ?? "Unknown Test Plan";
        }

        public async Task<TestPlanResponse> GetTestPlan(int testplanid)
        {
            try
            {
                var response = await _httpClient.GetAsync(GetUri() + $"/test/plans/{testplanid}");
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.NonAuthoritativeInformation)
                {
                    throw new UnauthorizedAccessException("Access denied. Check the Personal Access Token or user permissions.");
                }

                var json = await response.Content.ReadAsStringAsync();
                var testPlanResponse = JsonConvert.DeserializeObject<TestPlanResponse>(json);

                if (testPlanResponse is null)
                    Environment.Exit(1);

                return testPlanResponse;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request exception: {e.Message}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                throw;
            }
        }

        public async Task<List<WorkItemResponse>> FetchTestCasesForTestPlan(ITestPlanService testPlanService, ITestSuiteService testSuiteService, ITestCaseService testCaseService, IWorkItemService workItemService, int testPlanId)
        {
            var testPlanResponse = await testPlanService.GetTestPlan(testPlanId);
            var testSuiteResponse = await testSuiteService.GetSuites(testPlanResponse);
            var testsFromSuite = await testCaseService.GetTestCases(testSuiteResponse);

            if (testsFromSuite is null || !testsFromSuite.Value.Any())
            {
                Console.WriteLine("No test cases found in the test suite.");
                return new List<WorkItemResponse>();
            }

            var workItemTasks = testsFromSuite.Value.Select(async testCase =>
            {
                if (int.TryParse(testCase.TestCase.Id, out int workItemID))
                {
                    return await workItemService.GetWorkItem(workItemID);
                }
                return null;
            });

            var workItems = await Task.WhenAll(workItemTasks);
            return workItems.Where(wi => wi != null).ToList(); // Filter out any null responses
        }

        #endregion

        #region Private Methods

        private string GetUri()
        {
            return $"{_azureUrl}/{_organizationName}/{_projectName}/_apis";
        }

        #endregion
    }
}