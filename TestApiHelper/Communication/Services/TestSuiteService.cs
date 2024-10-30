#region Using Directives

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TestApiHelper.Communication.Interfaces;
using TestApiHelper.Models;

#endregion

namespace TestApiHelper.Communication.Services
{
    public class TestSuiteService : AzureDevOpsService, ITestSuiteService
    {
        #region Constructors

        public TestSuiteService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
            // Empty constructor - all initialization logic is in the base class AzureDevOpsService
        }

        #endregion

        #region Public Methods

        public async Task<TestSuitesResponse> GetSuites(TestPlanResponse suite)
        {
            try
            {
                var response = await _httpClient.GetAsync(suite.RootSuite.Url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var testPlanResponse = JsonConvert.DeserializeObject<TestSuitesResponse>(json);

                return testPlanResponse;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request exception: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }

            return null;
        }

        #endregion
    }
}