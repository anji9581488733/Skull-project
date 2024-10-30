#region Using Directives

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using TestApiHelper.Communication.Interfaces;
using TestApiHelper.Models;

#endregion

namespace TestApiHelper.Communication.Services
{
    public class WorkItemService : AzureDevOpsService, IWorkItemService
    {
        #region Constructors

        public WorkItemService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
            // Empty constructor - all initialization logic is in the base class AzureDevOpsService
        }

        #endregion

        #region Private Methods

        private string FormatStepAsXml(string stepText, string stepType)
        {
            // Replace '<parameter>' with '@parameter' without quotes
            string formattedStep = Regex.Replace(stepText, @"'<([^']*)>'", @"@$1");

            string escapedStep = System.Security.SecurityElement.Escape(formattedStep);
            escapedStep = ColorizeStepText(escapedStep); // Colorize the step text
            StringBuilder stepXml = new StringBuilder();
            stepXml.Append($"<step id=\"2\" type=\"{stepType}\">");
            if (stepType == "ActionStep")
            {
                stepXml.Append($"<parameterizedString isformatted=\"true\">&lt;DIV&gt;&lt;P&gt;{escapedStep}&lt;/P&gt;&lt;/DIV&gt;</parameterizedString>");
                stepXml.Append("<parameterizedString isformatted=\"true\">&lt;DIV&gt;&lt;P&gt;&lt;BR/&gt;&lt;/P&gt;&lt;/DIV&gt;</parameterizedString>");
            }
            else
            {
                // For ValidateStep, we need to put the step text in the Expected Results section
                stepXml.Append("<parameterizedString isformatted=\"true\">&lt;DIV&gt;&lt;P&gt;&lt;BR/&gt;&lt;/P&gt;&lt;/DIV&gt;</parameterizedString>");
                stepXml.Append($"<parameterizedString isformatted=\"true\">&lt;DIV&gt;&lt;P&gt;{escapedStep}&lt;/P&gt;&lt;/DIV&gt;</parameterizedString>");
            }
            stepXml.Append("<description/></step>");
            return stepXml.ToString();
        }

        // Colorize the step text
        private string ColorizeStepText(string step)
        {
            // Colorize the first occurrence of the Gherkin keywords
            var match = Regex.Match(step, @"\b(Given|When|Then|And)\b");
            if (match.Success)
            {
                step = step.Substring(0, match.Index) +
                       "&lt;span style=\"color: blue;\">" + match.Value + "&lt;/span>" +
                       step.Substring(match.Index + match.Length);
            }

            // Colorize @parameter
            step = Regex.Replace(step, @"(@\S*)", "&lt;span style=\"color: Red;\">$1&lt;/span&gt;");

            // Colorize text within single quotes (using literal single quotes)
            step = Regex.Replace(step, @"&apos;([^&]+)&apos;", "&lt;span style=\"color: DarkViolet;\">'$1'&lt;/span&gt;");

            return step;
        }

        private async Task<HttpResponseMessage> SendPatchRequestAsync(string requestUri, string patchDocument)
        {
            using var patchValue = new StringContent(patchDocument, Encoding.UTF8, "application/json-patch+json");
            var request = new HttpRequestMessage(HttpMethod.Patch, requestUri) { Content = patchValue };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        }

        private string GetWorkItemUri(int workItemId)
        {
            return $"{_azureUrl}/{_organizationName}/{_projectName}/_apis/wit/workitems/{workItemId}/?api-version=4.1";
        }

        private string CreateJsonPatchDocument(string operation, string path, string value)
        {
            var patch = new[]
            {
                new
                {
                    op = operation,
                    path = path,
                    value = value
                }
            };
            return JsonConvert.SerializeObject(patch);
        }

        #endregion

        #region Public Methods

        public async Task<WorkItemResponse> GetWorkItem(int workItemId)
        {
            var requestUri = GetWorkItemUri(workItemId);

            try
            {
                var response = await _httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.NonAuthoritativeInformation)
                {
                    throw new UnauthorizedAccessException("Access denied. Check the Personal Access Token or user permissions.");
                }

                var json = await response.Content.ReadAsStringAsync();
                var workItemData = JsonConvert.DeserializeObject<WorkItemResponse>(json);

                if (workItemData.Fields.State is null)
                    Environment.Exit(1);

                return workItemData;
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

        public async Task<int> UpdateAutomationStatus(int workItemId, string newStatus)
        {
            var requestUri = GetWorkItemUri(workItemId);
            var patchDocument = CreateJsonPatchDocument("add", "/fields/Microsoft.VSTS.TCM.AutomationStatus", newStatus);
            using var patchValue = new StringContent(patchDocument, Encoding.UTF8, "application/json-patch+json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = patchValue };

            try
            {
                var response = await SendPatchRequestAsync(requestUri, patchDocument);
                Console.WriteLine($"AutomationStatus of workitem: {workItemId} has been changed to Automation status: {newStatus}.");
                return 0;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request exception: {e.Message}. Probably new automation status: {newStatus} is not available");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                return 1;
            }
        }

        public async Task<int> UpdateState(int workItemId, string newState)
        {
            var requestUri = GetWorkItemUri(workItemId);
            var patchDocument = CreateJsonPatchDocument("add", "/fields/System.State", newState);
            using var patchValue = new StringContent(patchDocument, Encoding.UTF8, "application/json-patch+json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = patchValue };

            try
            {
                var response = await SendPatchRequestAsync(requestUri, patchDocument);
                Console.WriteLine($"State of workitem {workItemId} has been successfully changed to \"{newState}\".");
                return 0;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request exception: {e.Message}. New state: {newState} is not available");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                return 1;
            }
        }

        public async Task<int> UpdateTitle(int workItemId, string title)
        {
            var requestUri = GetWorkItemUri(workItemId);
            var patchDocument = CreateJsonPatchDocument("add", "/fields/System.Title", title);
            using var patchValue = new StringContent(patchDocument, Encoding.UTF8, "application/json-patch+json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = patchValue };

            try
            {
                var response = await SendPatchRequestAsync(requestUri, patchDocument);
                Console.WriteLine($"Title of workitem {workItemId} has been successfully updated to \"{title}\".");
                return 0;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request exception: {e.Message}. Unable to update Title");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}.");
                return 1;
            }
        }

        public async Task<int> UpdateDescription(int workItemId, string description)
        {
            var requestUri = GetWorkItemUri(workItemId);
            var patchDocument = CreateJsonPatchDocument("add", "/fields/System.Description", description);
            using var patchValue = new StringContent(patchDocument, Encoding.UTF8, "application/json-patch+json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = patchValue };

            try
            {
                var response = await SendPatchRequestAsync(requestUri, patchDocument);
                Console.WriteLine($"Description of workitem {workItemId} has been successfully updated to \"{description}\".");
                return 0;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request exception: {e.Message}. Unable to update Description");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}.");
                return 1;
            }
        }

        public async Task<int> UpdateSteps(int workItemId, List<string> scenarioSteps, List<Dictionary<string, string>> examples)
        {
            try
            {
                // Prepare the steps in XML format
                var stepsXml = new StringBuilder();
                int lastStepId = scenarioSteps.Count + examples.Count;
                stepsXml.Append($"<steps id=\"0\" last=\"{lastStepId}\">");

                // Add scenario outline steps
                string lastNonAndStepType = "ActionStep"; // Default to "ActionStep" if the first step is "And"
                foreach (var step in scenarioSteps)
                {
                    string trimmedStep = step.TrimStart();
                    string stepType;

                    if (trimmedStep.StartsWith("And "))
                    {
                        // If the step starts with "And", use the last non-"And" step type
                        stepType = lastNonAndStepType;
                    }
                    else
                    {
                        // Determine the step type based on the current step's keyword
                        stepType = trimmedStep.StartsWith("Then ") ? "ValidateStep" : "ActionStep";
                        // Update the last non-"And" step type
                        lastNonAndStepType = stepType;
                    }

                    stepsXml.Append(FormatStepAsXml(step, stepType));
                }


                // Close the steps tag
                stepsXml.Append("</steps>");

                // Prepare the parameter values in XML format
                var parametersXml = new StringBuilder();
                var localDataSourceXml = new StringBuilder();

                if (examples.Any())
                {
                    parametersXml.Append("<parameters>");
                    localDataSourceXml.Append("<NewDataSet>");

                    // Generate schema based on the first example's keys
                    var schemaBuilder = new StringBuilder();
                    schemaBuilder.Append("<xs:schema id='NewDataSet' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata'><xs:element name='NewDataSet' msdata:IsDataSet='true' msdata:Locale=''><xs:complexType> <xs:choice minOccurs='0' maxOccurs = 'unbounded'><xs:element name='Table1'><xs:complexType><xs:sequence>");

                    foreach (var key in examples.First().Keys)
                    {
                        schemaBuilder.Append($"<xs:element name='{key}' type='xs:string' minOccurs='0' />");
                        parametersXml.Append($"<param name=\"{key}\" bind=\"default\"/>");
                    }

                    schemaBuilder.Append("</xs:sequence></xs:complexType></xs:element></xs:choice></xs:complexType></xs:element></xs:schema>");
                    localDataSourceXml.Append(schemaBuilder.ToString());

                    foreach (var example in examples)
                    {
                        localDataSourceXml.Append("<Table1>");
                        foreach (var (key, value) in example)
                        {
                            localDataSourceXml.Append($"<{key}>{System.Security.SecurityElement.Escape(value)}</{key}>");
                        }
                        localDataSourceXml.Append("</Table1>");
                    }

                    parametersXml.Append("</parameters>");
                    localDataSourceXml.Append("</NewDataSet>");
                }

                var patchDocument = JsonConvert.SerializeObject(new[]
                {
                    new { op = "replace", path = "/fields/Microsoft.VSTS.TCM.Steps", value = stepsXml.ToString() },
                    new { op = "replace", path = "/fields/Microsoft.VSTS.TCM.Parameters", value = parametersXml.ToString() },
                    new { op = "replace", path = "/fields/Microsoft.VSTS.TCM.LocalDataSource", value = localDataSourceXml.ToString() }
                });

                var requestUri = GetWorkItemUri(workItemId);
                var response = await SendPatchRequestAsync(requestUri, patchDocument);
                Console.WriteLine($"Test steps of work item {workItemId} have been updated.");
                return 0;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request exception: {e.Message}");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                return 1;
            }
        }

        #endregion
    }
}