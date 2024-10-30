#region Using Directives

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Services.Common.CommandLine;
using Newtonsoft.Json.Linq;
using TestApiHelper.Communication.Interfaces;
using TestApiHelper.Communication.Services;
using TestApiHelper.Managers;

#endregion

namespace TestApiHelper
{
    public class Program
    {
        #region Private Methods

        private static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddHttpClient();

                        services.AddTransient<IWorkItemService, WorkItemService>();
                        services.AddTransient<ITestPlanService, TestPlanService>();
                        services.AddTransient<ITestSuiteService, TestSuiteService>();
                        services.AddTransient<ITestCaseService, TestCaseService>();
                    });


        private static void DisplayHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  [command] [arguments]");
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine("  help - Display this help message.");
            Console.WriteLine("  update-state-of-modified-test-cases [\"state\"] [aftermerge:true/false] - Update the state of modified test cases to \"state\". The 'aftermerge' argument is optional and defaults to 'false'.");
            Console.WriteLine("  synchronize-modified-test-cases - Synchronize the steps of modified test cases with Azure DevOps.");
            Console.WriteLine("  update-automation-status-of-modified-test-cases [\"Automation status\"] [aftermerge:true/false] - Update the Automation status of modified test cases to \"Automation status\". The 'aftermerge' argument is optional and defaults to 'false'.");
            Console.WriteLine("  generate-test-plan [testPlanId] - Generate a test plan.");
            Console.WriteLine("  update-results-after-execution [testPlanId] [testRunId] - (Not implemented) Update test results after execution.");
            Console.WriteLine("  extract-all-tests-from-project - Extract all tests from the current project directory.");
            Console.WriteLine("  extract-changed-tests-from-project - Extract changed tests from the current project directory.");
            Console.WriteLine("  set-workitem-state-to [workItemID] [\"state\"] - Update work item state in Azure DevOps.");
            Console.WriteLine("  synchronize-test-case [workItemID] - Synchronize test case in Azure DevOps from the associated feature file and ID.");
            Console.WriteLine("  get-workitem-state [workItemID] - Get the state of a work item in Azure DevOps.");
            Console.WriteLine("  get-workitem-automation-status [workItemID] - Get the automation status of a work item in Azure DevOps.");
            Console.WriteLine("  set-workitem-automation-status [workItemID] [\"state\"] - Set the automation status of a work item in Azure DevOps.");
            Console.WriteLine();
            Console.WriteLine("For more information on a specific command, type 'help [command]'.");
        }

        #endregion

        #region Public Methods

        public static async Task Main(string[] args)
        {
            bool aftermerge = false;
            var host = CreateHostBuilder(args).Build();
            var services = host.Services;

            var workItemService = services.GetRequiredService<IWorkItemService>();
            var testPlanService = services.GetRequiredService<ITestPlanService>();
            var testSuiteService = services.GetRequiredService<ITestSuiteService>();
            var testCaseService = services.GetRequiredService<ITestCaseService>();

            // No arguments provided, display help
            if (args.Length == 0)
            {
                DisplayHelp();
                return;
            }

            // Interpret arguments and invoke the corresponding function
            switch (args[0].ToLower())
            {
                case "h":
                case "-h":
                case "help":
                case "--help":
                    DisplayHelp();
                    break;
                case "update-state-of-modified-test-cases":
                    if (args.Length >= 2)
                    {
                        string state = args[1];

                        if (args.Length >= 3 && !bool.TryParse(args[2], out aftermerge))
                        {
                            Console.WriteLine("Invalid AfterMerge argument. Using default value: false.");
                        }

                        var testCases = FeatureFileProcessor.AnalyzeChangedScenariosInFeatureFiles(aftermerge);
                        int finalExitCode = 0;

                        foreach (var testCase in testCases)
                        {
                            // Check if the test case has the @Example tag and no ID
                            if (testCase.HasTag("@Example") && string.IsNullOrEmpty(testCase.Id))
                            {
                                Console.WriteLine("Scenario with @Example tag and no ID found. Skipping ADO synchronization.");
                                continue;
                            }
                            if (testCase != null && int.TryParse(testCase.Id, out int id))
                            {
                                try
                                {
                                    int exitCode = await workItemService.UpdateState(id, state);
                                    if (exitCode != 0)
                                    {
                                        Console.WriteLine($"Failed to update test case {id} with exit code {exitCode}.");
                                        finalExitCode = exitCode; // Set to non-zero to indicate failure
                                                                  // Optionally, break out of the loop if you want to stop processing further updates
                                                                  // break;
                                    }
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine($"Failed to update test case {id}: {ex.Message}");
                                    finalExitCode = 1;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"An unexpected error occurred while updating test case {id}: {ex.Message}");
                                    finalExitCode = 1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Test case not found or invalid ID.");
                                finalExitCode = 1;
                            }
                        }

                        Environment.Exit(finalExitCode);
                    }
                    else
                    {
                        Console.WriteLine("Not enough arguments provided. Expected work item ID.");
                        Environment.Exit(1);
                    }
                    break;
                case "synchronize-modified-test-cases":
                    if (args.Length >= 1)
                    {
                        if (args.Length >= 3 && !bool.TryParse(args[2], out aftermerge))
                        {
                            Console.WriteLine("Invalid AfterMerge argument. Using default value: false.");
                        }

                        var testCases = FeatureFileProcessor.AnalyzeChangedScenariosInFeatureFiles(aftermerge);
                        int finalExitCode = 0;

                        foreach (var testCase in testCases)
                        {
                            int exitCode1 = 0, exitCode2 = 0, exitCode3 = 0;
                            // Check if the test case has the @Example tag and no ID
                            if (testCase.HasTag("@Example") && string.IsNullOrEmpty(testCase.Id))
                            {
                                Console.WriteLine("Scenario with @Example tag and no ID found. Skipping ADO synchronization.");
                                continue;
                            }
                            if (testCase != null && int.TryParse(testCase.Id, out int id))
                            {
                                try
                                {
                                    var workItem = await workItemService.GetWorkItem(id);

                                    if (workItem.Fields.State != "Under Review")
                                    {
                                        string errorMessage = $"Cannot update test steps because the work item {id} is not in 'Under Review' state. Current state: {workItem.Fields.State}";
                                        Console.WriteLine(errorMessage);
                                        finalExitCode = 1;
                                        continue;
                                    }

                                    if (workItem.Fields.AutomationStatus != "Planned")
                                    {
                                        string errorMessage = $"Cannot update test steps because automation status of the work item {id} is not 'Planned'. Current automation status: {workItem.Fields.AutomationStatus}";
                                        Console.WriteLine(errorMessage);
                                        finalExitCode = 1;
                                        continue;
                                    }

                                    if (!string.IsNullOrEmpty(testCase.Title))
                                        exitCode1 = await workItemService.UpdateTitle(id, testCase.Title);

                                    if (!string.IsNullOrEmpty(testCase.Description))
                                        exitCode2 = await workItemService.UpdateDescription(id, testCase.Description);

                                    if (testCase.Steps != null)
                                        exitCode3 = await workItemService.UpdateSteps(id, testCase.Steps, testCase.Examples);

                                    if (exitCode1 != 0 || exitCode2 != 0 || exitCode3 != 0)
                                    {
                                        Console.WriteLine($"Failed to update test case {id} with exit code 1.");
                                        finalExitCode = 1;        // Set to non-zero to indicate failure
                                    }
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine($"Failed to update test case {id}: {ex.Message}");
                                    finalExitCode = 1;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"An unexpected error occurred while updating test case {id}: {ex.Message}");
                                    finalExitCode = 1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Test case not found or invalid ID.");
                                finalExitCode = 1;
                            }
                        }

                        Environment.Exit(finalExitCode);
                    }
                    break;
                case "update-automation-status-of-modified-test-cases":
                    if (args.Length >= 2)
                    {
                        if (args.Length >= 3 && !bool.TryParse(args[2], out aftermerge))
                        {
                            Console.WriteLine("Invalid AfterMerge argument. Using default value: false.");
                        }

                        var testCases = FeatureFileProcessor.AnalyzeChangedScenariosInFeatureFiles(aftermerge);
                        string automationstatus = args[1];
                        int finalExitCode = 0;

                        foreach (var testCase in testCases)
                        {
                            // Check if the test case has the @Example tag and no ID
                            if (testCase.HasTag("@Example") && string.IsNullOrEmpty(testCase.Id))
                            {
                                Console.WriteLine("Scenario with @Example tag and no ID found. Skipping ADO synchronization.");
                                continue;
                            }
                            if (testCase != null && int.TryParse(testCase.Id, out int id))
                            {
                                try
                                {
                                    int exitCode = await workItemService.UpdateAutomationStatus(id, automationstatus);
                                    if (exitCode != 0)
                                    {
                                        Console.WriteLine($"Failed to update test case {id} with exit code {exitCode}.");
                                        finalExitCode = exitCode; // Set to non-zero to indicate failure
                                                                  // Optionally, break out of the loop if you want to stop processing further updates
                                                                  // break;
                                    }
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine($"Failed to update test case {id}: {ex.Message}");
                                    finalExitCode = 1;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"An unexpected error occurred while updating test case {id}: {ex.Message}");
                                    finalExitCode = 1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Test case not found or invalid ID.");
                                finalExitCode = 1;
                            }
                        }

                        Environment.Exit(finalExitCode);
                    }
                    else
                    {
                        Console.WriteLine("Not enough arguments provided. Expected \"Automation status\".");
                        Environment.Exit(1);
                    }
                    break;
                case "generate-test-plan":
                    if (args.Length >= 2)
                    {
                        if (int.TryParse(args[1], out int testPlanId))
                        {
                            int finalExitCode = 0;
                            try
                            {
                                var tests = await testPlanService.FetchTestCasesForTestPlan(testPlanService, testSuiteService, testCaseService, workItemService, testPlanId);

                                if (tests.Count == 0)
                                {
                                    Console.WriteLine("No test cases to execute for the provided test plan ID.");
                                    finalExitCode = 1;
                                }
                                else
                                {
                                    TestPlanManager.GenerateTestPlan(tests, testPlanId, await testPlanService.GetTestPlanName(testPlanId));
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred while executing the test plan: {ex.Message}");
                                finalExitCode = 1;
                            }
                            Environment.Exit(finalExitCode);
                        }
                        else
                        {
                            Console.WriteLine("Invalid test plan ID.");
                            Environment.Exit(1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Test plan ID not provided.");
                        Environment.Exit(1);
                    }
                    break;
                case "update-results-after-execution":
                    if (args.Length >= 3)
                    {
                        if (int.TryParse(args[1], out int testPlanId) && int.TryParse(args[2], out int testRunId))
                        {
                            Console.WriteLine("Not implemented.");
                            // await TestManager.UpdateTestResults(testPlanId, testRunId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid test plan ID or test run ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Insufficient arguments provided for update-results.");
                    }
                    break;
                case "extract-all-tests-from-project":
                    FeatureFileProcessor.AnalyzeProjectAndCollectAllTestCases();
                    break;
                case "extract-changed-tests-from-project":
                    FeatureFileProcessor.AnalyzeChangedScenariosInFeatureFiles();
                    break;
                case "set-workitem-state-to":
                    if (args.Length >= 3)
                    {
                        if (int.TryParse(args[1], out int workItemID))
                        {
                            string state = args[2];
                            await workItemService.UpdateState(workItemID, state);
                        }
                        else
                        {
                            Console.WriteLine("Invalid work item ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough arguments provided. Expected work item ID and state.");
                    }
                    break;
                case "synchronize-test-case":
                    if (args.Length >= 2)
                    {
                        if (int.TryParse(args[1], out int workItemID))
                        {
                            var testCase = FeatureFileProcessor.FindTestCaseByTag(workItemID);
                            if (testCase != null)
                            {
                                int exitCode1 = 0, exitCode2 = 0, exitCode3 = 0;

                                if (!string.IsNullOrEmpty(testCase.Title))
                                    exitCode1 = await workItemService.UpdateTitle(workItemID, testCase.Title);

                                if (!string.IsNullOrEmpty(testCase.Description))
                                    exitCode2 = await workItemService.UpdateDescription(workItemID, testCase.Description);

                                if (testCase.Steps != null)
                                    exitCode3 = await workItemService.UpdateSteps(workItemID, testCase.Steps, testCase.Examples);

                                if (exitCode1 != 0 || exitCode2 != 0 || exitCode3 != 0)
                                {
                                    Console.WriteLine($"Failed to update test case {workItemID} with exit codes: {exitCode1}, {exitCode2}, {exitCode3}.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Test case not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid work item ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough arguments provided. Expected work item ID.");
                    }
                    break;
                case "get-workitem-state":
                    if (args.Length >= 2)
                    {
                        if (int.TryParse(args[1], out int workItemID))
                        {
                            var workItem = await workItemService.GetWorkItem(workItemID);
                            if (workItem != null)
                            {
                                Console.WriteLine($"Work item state: {workItem.Fields.State}");
                            }
                            else
                            {
                                Console.WriteLine("Work item not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid work item ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough arguments provided. Expected work item ID.");
                    }
                    break;
                case "get-workitem-automation-status":
                    if (args.Length >= 2)
                    {
                        if (int.TryParse(args[1], out int workItemID))
                        {
                            var workItem = await workItemService.GetWorkItem(workItemID);
                            if (workItem != null)
                            {
                                Console.WriteLine($"Work item Automation Status: {workItem.Fields.AutomationStatus}");
                            }
                            else
                            {
                                Console.WriteLine("Work item not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid work item ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough arguments provided. Expected work item ID.");
                    }
                    break;
                case "set-workitem-automation-status":
                    if (args.Length >= 3)
                    {
                        if (int.TryParse(args[1], out int workItemID))
                        {
                            var automationStatus = args[2];
                            await workItemService.UpdateAutomationStatus(workItemID, automationStatus);
                        }
                        else
                        {
                            Console.WriteLine("Invalid work item ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough arguments provided. Expected work item ID.");
                    }
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }

        #endregion
    }
}