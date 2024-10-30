#region Using Directives

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TestApiHelper.Communication.Interfaces;
using TestApiHelper.Models;

#endregion

namespace TestApiHelper.Communication.Services
{
    public class TestCaseService : AzureDevOpsService, ITestCaseService
    {
        #region Constructors

        public TestCaseService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
            // Empty constructor - all initialization logic is in the base class AzureDevOpsService
        }

        #endregion

        #region Public Methods

        public async Task<TestCasesResponse> GetTestCases(TestSuitesResponse suites)
        {
            try
            {
                var response = await _httpClient.GetAsync(suites.TestCasesUrl);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var testPlanResponse = JsonConvert.DeserializeObject<TestCasesResponse>(json);

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