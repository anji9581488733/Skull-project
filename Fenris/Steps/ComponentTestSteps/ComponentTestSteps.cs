using Allure.Net.Commons;
using Fenris.Steps.Base;
using Gleipner.Pages.ComponentTest;
using Newtonsoft.Json;
using NUnit.Framework;
using Reqnroll;
using System;
using System.Collections.Generic;
using Fenris.Hooks;
using Microsoft.AspNetCore.Razor.Language;
using OpenQA.Selenium;

namespace Fenris.Steps.ComponentTestSteps;

[Binding]
public class ComponentTestSteps : StepsBase
{
    [Then(@"Validate the result on Component Test page")]
    public void ValidateTheResultOnComponentTestPage()
    {
        try
        {
            string componentResult = null;
            int failCounter = 0;
            int testCounter = 0;
            int skippedCounter = 0;

            var componentPage = new ComponentTestPage();
            WaitForElementToBeVisible(componentPage, "ComponentTestResult", 5);
            var resultComponentTest = componentPage.FindElement("ComponentTestResult").Text.ToString();
        
            if (string.IsNullOrEmpty(resultComponentTest))
            {
                throw new AssertionException("The results from ComponentTestResult are empty. Something went wrong");
            }
        
            string jsonOutput = resultComponentTest.Replace("True", "true").Replace("False", "false");
            TestResult result = JsonConvert.DeserializeObject<TestResult>(jsonOutput);

            // Access the deserialized object 
            foreach (var testResult in result.test_suites)
            {
                string results = null;
                AllureApi.Step("Test Suite Name:  " + testResult.Name);
                foreach (var testCase in testResult.test_cases)
                {
                    // Treat null result as skipped
                    if (testCase?.Result == null)
                    {
                        componentResult = "Skipped";
                        skippedCounter++;
                        ExtendedApi.StartStep(testCounter + ":  " + testCase?.Name + "  " + ":           " + componentResult);
                        ExtendedApi.SkipStep(s => s.description = "Test Case: " + testCase?.Name + " Skipped.");
                    }
                    else
                    {
                        componentResult = (testCase.Result == true) ? "Pass" : "Fail";
                        if (componentResult == "Fail")
                        {
                            failCounter++;
                            ExtendedApi.StartStep(testCounter + ":  " + testCase?.Name + "  " + ":           " + componentResult);
                            ExtendedApi.FailStep(s => s.description = "Test Case: " + testCase?.Name + " failed.");
                        }
                        else
                        {
                            AllureApi.Step(testCounter + ":  " + testCase?.Name + "  " + ":           " + componentResult);
                        }
                    }
                    testCounter++;
                }

                if (testCounter > 0)
                {
                    results = "# " + failCounter.ToString() + " tests failed out of " + testCounter + " (Skipped: " + skippedCounter + ") in Test Suite:  " + testResult.Name;
                    if (failCounter > 0)
                    {
                        ExtendedApi.StartStep(results);
                        ExtendedApi.FailStep(s => s.description = "Test Suite: " + testResult.Name + " has " + failCounter + " failed tests.");
                    }
                    else
                    {
                        AllureApi.Step(results); // Log the step as passed
                    }
                    AllureApi.Step("---------------------------------------------------------------------------");
                }
            }

            WaitForElementToBeVisible(componentPage, "Component Test Status", 5);
            string topStatus = componentPage.FindElement("Component Test Status").Text;

            // Check if the top status is "Pass"
            bool isTopStatusPass = topStatus == "Pass";
            // Check if failCounter is zero
            bool isFailCounterZero = failCounter == 0;

            // Collect error messages
            List<string> errorMessages = new List<string>();
            if (!isTopStatusPass)
            {
                errorMessages.Add("The top status is not 'Pass'.");
            }
            if (!isFailCounterZero)
            {
                errorMessages.Add("There are failed tests.");
            }

            // If any of the checks failed, throw an exception with all error messages
            if (errorMessages.Count > 0)
            {
                throw new AssertionException(string.Join("; ", errorMessages));
            }
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [When(@"I '([^']*)' all access permission requests")]
    public void WhenICompleteAllAccessPermissionRequests(string action)
    {
        bool grantPermission = action.ToUpper() == "GRANT";
        
        try
        {
            ComponentTestPage componentPage = new ComponentTestPage();

            HandlePermissionRequest(grantPermission, componentPage);
        }
        catch (Exception e)
        {
            Reporting.Log("Fail", "Exception thrown: " + e.Message);
        }
    }

    private void HandlePermissionRequest(bool grantPermission, ComponentTestPage componentPage)
    {
        bool arrangeDisplayed = false;

        do
        {
            try
            {
                arrangeDisplayed = IsArrangeDisplayed(componentPage);

                if (arrangeDisplayed)
                {
                    WaitForElementToBeVisible(componentPage, "ComponentTestPositiveButton", 5);
                    ClickOnElement(componentPage.FindElement("ComponentTestPositiveButton"));

                    Console.WriteLine("Pass - Arrange message has been displayed");
                    ExtendedApi.StartStep("Pass - Arrange message has been displayed");
                    ExtendedApi.PassStep(s => s.description = "Pass - Arrange message has been displayed");

                    bool alertDisplayed = IsAlertDisplayed(componentPage);

                    if (alertDisplayed)
                    {
                        Console.WriteLine("Pass - Native Alert Dialog has been displayed");
                        ExtendedApi.StartStep("Pass - Native Alert Dialog has been displayed");
                        ExtendedApi.PassStep(s => s.description = "Pass - Native Alert Dialog has been displayed");

                        if (grantPermission)
                        {
                            driver.SwitchTo().Alert().Accept();
                            Console.WriteLine("The permit was granted");
                            ExtendedApi.StartStep("The permit was granted");
                            ExtendedApi.PassStep(s => s.description = "The permit was granted");
                        }
                        else
                        {
                            driver.SwitchTo().Alert().Dismiss();
                            Console.WriteLine("The permit was denied");
                            ExtendedApi.StartStep("The permit was denied");
                            ExtendedApi.PassStep(s => s.description = "The permit was denied");
                        }

                        WaitForElementToBeVisible(componentPage, "ComponentTestPositiveButton", 5);
                        ClickOnElement(componentPage.FindElement("ComponentTestPositiveButton"));
                    }
                    else
                    {
                        Console.WriteLine("Fail - Native Alert Dialog has NOT been displayed");
                        ExtendedApi.StartStep("Fail - Native Alert Dialog has NOT been displayed");
                        ExtendedApi.FailStep(s => s.description = "Fail - Native Alert Dialog has NOT been displayed");

                        WaitForElementToBeVisible(componentPage, "ComponentTestNegativeButton", 5);
                        ClickOnElement(componentPage.FindElement("ComponentTestNegativeButton"));
                    }
                }
                else
                {
                    Console.WriteLine("Fail - Arrange message has NOT been displayed");
                    ExtendedApi.StartStep("Fail - Arrange message has NOT been displayed");
                    ExtendedApi.FailStep(s => s.description = "Fail - Native Alert Dialog has NOT been displayed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fail - It seems that some element was not found. Exception: {e}");
                ExtendedApi.StartStep($"Fail - It seems that some element was not found. Exception: {e}");
                ExtendedApi.FailStep(s => s.description = $"Fail - It seems that some element was not found. Exception: {e}");

                WaitForElementToBeVisible(componentPage, "ComponentTestNegativeButton", 5);
                ClickOnElement(componentPage.FindElement("ComponentTestNegativeButton"));
            }
        } while (arrangeDisplayed);
    }

    private bool IsArrangeDisplayed(ComponentTestPage componentPage)
    {
        try
        {
            WaitForElementToBeVisible(componentPage, "Arrange", 5);
            return componentPage.FindElement("Arrange").Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    private bool IsAlertDisplayed(ComponentTestPage componentPage)
    {
        try
        {
            WaitForElementToBeVisible(componentPage, "NotificationAlert", 5);
            return componentPage.FindElement("NotificationAlert").Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
    
    public class TestCase
    {
        public string Name { get; set; }
        public bool? Result { get; set; }
    }

    public class TestSuite
    {
        public string Name { get; set; }
        public List<TestCase?> test_cases { get; set; }
    }

    public class TestResult
    {
        public List<TestSuite?> test_suites { get; set; }
        public bool Result { get; set; }
    }
}