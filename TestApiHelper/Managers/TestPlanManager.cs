#region Using Directives

using Newtonsoft.Json;
using System.Text.RegularExpressions;
using TestApiHelper.Models;

#endregion

namespace TestApiHelper.Managers
{
    public class TestPlanManager
    {
        #region Public Methods

        public static void GenerateTestPlan(List<WorkItemResponse> testCases, int id, string name)
        {
            // Create test plan object
            TestPlan testPlan = new TestPlan
            {
                TestPlanId = id.ToString(),
                Name = name,
                Tests = new List<Test>()
            };

            // Add test cases to test plan
            foreach (var testCase in testCases)
            {
                testPlan.Tests.Add(new Test
                {
                    Id = testCase.Id.ToString(),
                    Name = testCase.Fields.Title,
                    Description = RemoveHtmlTags(testCase.Fields.Description),
                    Selector = testCase.Fields.Title,
                    Tags = new List<string>(),
                });
            }

            // Serialization to JSON
            string json = JsonConvert.SerializeObject(testPlan, Formatting.Indented);

            // Save JSON to file
            File.WriteAllText("testPlan.json", json);

            Console.WriteLine("Test plan generated successfully.");
        }

        #endregion

        #region Private Methods

        private static string RemoveHtmlTags(string html)
        {
            if (string.IsNullOrEmpty(html))
            {
                return string.Empty;
            }

            return Regex.Replace(html, "<.*?>", string.Empty);
        }

        #endregion
    }
}