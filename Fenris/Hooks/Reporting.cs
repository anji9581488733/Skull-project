using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using Gleipner.Base;
using Gleipner.ConfigElement;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Polaris;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Reqnroll;

/// <summary>
/// Extent report
/// </summary>/

namespace Fenris.Hooks
{

    public class Reporting : PageBase
    {
        /// <summary>
        /// Global Variable for Extend report
        /// </summary>

        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private static ExtentTest step;
        public static String resultPath;
        public static string pathForScenario;

        //The variable that tracks the current number of the scenario.
        private static int counter = 0;


        // Used because Mac does not work with Aftertest. Puts the enviroment variable into report
        public static bool ExtentInitFlag;

        //The variable that keeps track of how many times the current scenario has failed.
        private static int fail_counter = 0;


        // A set of actions that must happen before executing each step
        public static ExtentTest CreateStepNode(FeatureContext featureContext, ScenarioContext scenarioContext)
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var re_string = "";

            //If the current scenario has failed before, a "retry nr" is added to the report
            if (featureContext.Get<int>("FailCount") > 0) re_string = "  - retry nr. " + featureContext.Get<int>("FailCount");

            if (stepType == "Given")
            {
                step = scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text + re_string);
            }
            else if (stepType == "When")
            {
                step = scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text + re_string);
            }
            else if (stepType == "Then")
            {
                step = scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text + re_string);
            }
            else if (stepType == "And")
            {
                step = scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text + re_string);
            }

            return step;
        }

        /// <summary>
        /// The logging of test results to Extend report
        /// </summary>        

        public static void Log(String Result, String desc)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            //switch (Result.ToUpper().Trim())
            //{
            //    case "PASS":
            //        step.Log(Status.Pass, desc);
            //        break;
            //    case "FAIL":
            //        step.Log(Status.Fail, desc);
            //        break;
            //    case "INFO":
            //        step.Log(Status.Info, desc);
            //        break;
            //    default:
            //        throw new ArgumentException("Unknown Result type: " + Result + " in Log.");
            //}
        }



        /// <summary>
        /// The set of actions happening only once throughout a test run
        /// </summary>        
        public static void InitializeReport()
        {
            // ChangeExtentFlag();
            ExtentInitFlag = true;

            string jobName = Environment.GetEnvironmentVariable("JOB_NAME");
            string appName = Environment.GetEnvironmentVariable("APP_NAME");
            string buildNumber = Environment.GetEnvironmentVariable("BUILD_NUMBER");
            string extendConfigPath = null;
            string resultDir = "TestResults";
            //string currentDir = Environment.CurrentDirectory;
            string currentDir = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName).FullName;
            //string execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string execPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName).FullName).FullName;
            string homeEnv = (Environment.GetEnvironmentVariables().Contains("HOMEPATH")) ? "HOMEPATH" : "HOME";
            string reportDir = Path.GetFullPath(Path.Combine(Environment.GetEnvironmentVariable(homeEnv), resultDir));
            try
            {
                Console.WriteLine("this is the variable " + Environment.GetEnvironmentVariable("JOB_NAME"));
            }
            catch (Exception) { throw; }

            //If no variables are received from Jenkins the resulting path of the Extend report is specified as a combination of the current date folder with the subfolder resembling time of test execution
            if (string.IsNullOrEmpty(jobName) || string.IsNullOrEmpty(appName) || string.IsNullOrEmpty(buildNumber))
            {
                DateTime now = DateTime.Now;
                resultPath = new Uri(Path.Combine(reportDir, now.ToString("yyyyMMdd"), now.ToString("HHmmss"))).LocalPath;
            }

            //Otherwise, the Extend report path is specified as the name of the application and a subfolder represented by the number of the current build
            else
            {
                resultPath = new Uri(Path.Combine(reportDir, jobName, string.Format("{0}_Build_{1}", appName, buildNumber))).LocalPath;
            }

            System.IO.Directory.CreateDirectory(resultPath);

            if (string.IsNullOrEmpty(AppSettings.ExtentConfigPath))
                throw new IOException("Unable to find extend-config.xml");

            var htmlReporter = new ExtentSparkReporter(Path.Combine(resultPath, "TestAutomation_Appium.html"));
            htmlReporter.LoadXMLConfig(AppSettings.ExtentConfigPath);
            Assert.AreEqual(htmlReporter.Config.Theme, Theme.Standard);
            Assert.AreEqual(htmlReporter.Config.DocumentTitle, "Extent Framework");
            Assert.AreEqual(htmlReporter.Config.Protocol, Protocol.HTTPS);
            //htmlReporter.LoadConfig(extendConfigPath);
            // AppDefinition(Settings.Platform); // ApplicationContext is not ready atm, so makes no sense initializing now.

            // Attach report to reporter.
            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
        }


        //Steps that are executed before each Feature
        public static void BeforeFeature(FeatureContext featureContext)
        {

            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed)
                featureName = extent.CreateTest<Feature>("<strong>" + featureContext.FeatureInfo.Title + "</strong>");

            //In the start of a new feature reset all of test retry variables
            featureContext.Add("ScenarioCount", 0);
            featureContext.Add("FailCount", 0);
            featureContext.Add("StepFail", 0);
        }


        //Steps execute after each step is done
        public static void InsertReportingSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {


            scenarioContext["StepCount"] = scenarioContext.Get<int>("StepCount") + 1;
            //attach it to the Report 

            if (scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                Console.WriteLine("ScenarioExecutionStatus: " + scenarioContext.ScenarioExecutionStatus.ToString());
                step.Skip("The step is undefined").AddScreenCaptureFromPath(SaveScreenshot());
            }
            else if (scenarioContext.TestError == null && Settings.ScreenshotOnPass == true)
            {
                Console.WriteLine("Current TestError: " + scenarioContext.TestError?.ToString() +
                    " Settings.ScreenshotOnPass: " + Settings.ScreenshotOnPass.ToString());
                step.AddScreenCaptureFromPath(SaveScreenshot());
            }
            else if ((scenarioContext.TestError != null) && (featureContext.Get<int>("StepFail") == 0))
            {
                Console.WriteLine("TestError: " + scenarioContext.TestError.ToString() +
                    " StepFail counter: " + featureContext.Get<int>("StepFail"));
                if (Polaris.Base.PageBase.driver != null)
                {
                    var screenshotPath = SaveScreenshot();
                    var embeddedImage = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();
                    step.Fail(scenarioContext.TestError.Message).Fail("Screenshot", embeddedImage);
                    featureContext["StepFail"] = 1;
                }

                //The next code is executed ONLY if the current test run is a RETRY
                if (featureContext.Get<int>("FailCount") > 0 && featureContext.Get<int>("FailCount") <= Settings.RetriesOnError)
                {
                    //The next code both increases the fail count and decreases the scenario count so that the scenario number in Extend report stays the same upon retry
                    featureContext["ScenarioCount"] = featureContext.Get<int>("ScenarioCount") - 1;
                    featureContext["FailCount"] = featureContext.Get<int>("FailCount") + 1;
                    featureContext["StepFail"] = 1;
                }
            }

            extent.Flush();

            if (featureContext.Get<int>("StepFail") == 1) Assert.Fail();
        }


        public static void CaptureScreenshot()
        {
            try
            {
                var screenshot = ((ITakesScreenshot)Polaris.Base.PageBase.driver).GetScreenshot().AsBase64EncodedString;
                var test = extent.CreateTest("Test Name"); // Replace "Test Name" with the actual test name
                test.AddScreenCaptureFromBase64String(screenshot, "Screenshot Description"); // Replace "Screenshot Description" with a description
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to capture screenshot: " + ex.ToString());
            }
        }
        public static string GetScreenshotPath()
        {
            // Capture the screenshot
            var screenshot = ((ITakesScreenshot)Polaris.Base.PageBase.driver).GetScreenshot();

            // Define the folder path for screenshots
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");

            // Create the folder if it doesn't exist
            Directory.CreateDirectory(folderPath);

            // Generate a unique image file name
            var imageName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            var imagePath = Path.Combine(folderPath, imageName);

            // Save the screenshot to the specified path
            screenshot.SaveAsFile(imagePath, ScreenshotImageFormat.Png);

            return imagePath;
        }

        private static string GetTimestamp(DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMddHHmmss");
        }
        public static string SaveScreenshot()
        {
            try
            {

                var screenshot = ((ITakesScreenshot)Polaris.Base.PageBase.driver).GetScreenshot();
                var screenshotPath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
                Console.WriteLine(screenshotPath);
                Directory.CreateDirectory(screenshotPath);
                var fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                var filePath = Path.Combine(screenshotPath, fileName);
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
                return filePath;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save screenshot: " + ex.ToString());
                return null;
            }
        }

        //The next code executes after each scenario AND sceanrio retry execution.
        public static void RepeatHandling(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            if (scenarioContext.ScenarioExecutionStatus.ToString() == "UndefinedStep")
            {
                try
                {
                    step = scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                catch (Exception e)
                {
                    step = scenario.CreateNode<Given>("The step is not defined in the framework");
                    step.Fail("Failed to execute step: " + e.Message);
                    extent.Flush();
                }
            }
            //This if is executed when there is an errror in the steps and the scenario has been retried less than x times.
            if ((scenarioContext.TestError != null) && (featureContext.Get<int>("FailCount") < Settings.RetriesOnError))
            {

                //this step figures the path of the Fenris project
                System.IO.DirectoryInfo directoryInfo = System.IO.Directory.GetParent(pathForScenario);
                while (directoryInfo.FullName.Contains("Fenris"))
                    directoryInfo = System.IO.Directory.GetParent(directoryInfo.FullName);

                //This variable is responsible to invoke the TestFixureSetUp method from currently running scenario
                object scenarioRetryObject;

                //This code finds the namespace and method name of the currently running feature and scenario
                //First the .cs file of the feature is found
                var fileList = Directory.GetFiles(directoryInfo.FullName + @"/Fenris", featureContext.FeatureInfo.Title + ".feature.cs", SearchOption.AllDirectories);

                String featurePathObject = fileList[0];


                //Afterwards, the path to the .cs file is edited so that it represents the full name of the feature's method
                featurePathObject = featurePathObject.Substring(featurePathObject.IndexOf("Fenris"));
                featurePathObject = featurePathObject.Replace("/", ".");
                featurePathObject = featurePathObject.Replace("\\", ".");
                featurePathObject = featurePathObject.Replace("-", "_");
                featurePathObject = featurePathObject.Remove(featurePathObject.Length - 11);

                for (int i = 0; i < featurePathObject.Length; i++)
                {
                    if (char.IsWhiteSpace(featurePathObject[i]))
                    {
                        string tempoChar = char.ToUpper(featurePathObject[i + 1]).ToString();
                        featurePathObject = featurePathObject.Remove(i + 1, 1).Insert(i + 1, tempoChar);
                    }
                    else if (featurePathObject[i].Equals('_'))
                    {
                        string tempoChar = char.ToUpper(featurePathObject[i + 1]).ToString();
                        featurePathObject = featurePathObject.Remove(i + 1, 1).Insert(i + 1, tempoChar);
                    }
                }

                featurePathObject = featurePathObject.Replace(" ", "");
                featurePathObject = featurePathObject + "Feature";
                //ScenarioRetryObject is then assigned the identity of the current feature method from .cs file.
                Console.WriteLine(featurePathObject);

                scenarioRetryObject = System.Activator.CreateInstance(Type.GetType(featurePathObject));

                //The failure counter is increased by 1 and set to the variables of this environment
                counter = featureContext.Get<int>("ScenarioCount");
                fail_counter = featureContext.Get<int>("FailCount") + 1;

                //A new FeatureContext is established and created for the retry function
                Type thisType = scenarioRetryObject.GetType();
                MethodInfo theMethod = thisType.GetMethod("FeatureSetup");
                theMethod.Invoke(scenarioRetryObject, null);

                //The new FeatureContext is assigned the variables from its predecessor and the scenario count is reduced to get this file and FeatureContext in sync
                featureContext["ScenarioCount"] = counter - 1;
                featureContext["FailCount"] = fail_counter;
                featureContext["StepFail"] = 0;

                //A check if the scenario has variables in a list
                String[] fooArray = null;
                if (TestContext.CurrentContext.Test.Name.Contains('('))
                {
                    string aMethod = TestContext.CurrentContext.Test.Name.Substring(0, TestContext.CurrentContext.Test.Name.IndexOf('('));
                    theMethod = thisType.GetMethod(aMethod);
                    aMethod = TestContext.CurrentContext.Test.Name.Substring(TestContext.CurrentContext.Test.Name.IndexOf('(') + 1, TestContext.CurrentContext.Test.Name.IndexOf(')') - TestContext.CurrentContext.Test.Name.IndexOf('(') - 1);
                    aMethod = aMethod.Replace("\"", "");
                    fooArray = aMethod.Split(',');

                    fooArray[fooArray.Length - 1] = null;
                    //Execution of the specific scenario and a specific variable from the list 
                    try
                    {
                        theMethod.Invoke(scenarioRetryObject, fooArray);
                    }
                    catch (Exception e) { Console.WriteLine("The error is " + e); }
                }
                else
                {
                    string aMethod = TestContext.CurrentContext.Test.Name;
                    theMethod = thisType.GetMethod(aMethod);

                    //Execution of the specific scenario
                    try
                    {

                        theMethod.Invoke(scenarioRetryObject, null);
                    }
                    catch { }
                }

                //If it is the second retry this code adds it to the report but does not initialize another retry
                while (fail_counter != featureContext.Get<int>("FailCount"))
                {
                    if (featureContext.Get<int>("FailCount") > Settings.RetriesOnError)
                        break;

                    //Launch app
                    try
                    {
                        fail_counter = (featureContext.Get<int>("FailCount"));
                        //Invoke the previously established scenario
                        theMethod.Invoke(scenarioRetryObject, fooArray);
                    }
                    catch { }
                }

                //Increase the scenario counter and reset other Context specific variables
                var failer = featureContext.Get<int>("FailCount");
                featureContext["FailCount"] = 0;

                //if this was the last retry but it did not fail the test is passed
                if ((failer <= Settings.RetriesOnError) && (fail_counter <= Settings.RetriesOnError))
                {
                    Assert.Pass();
                }
            }

            //if the test did not fail then reset the FeatureContext variables
            else
            {
                featureContext["FailCount"] = 0;
            }


            if (ExtentInitFlag)
            {
                ExtentInitFlag = false;
                extent.AddSystemInfo("Pictues taken on passes", Convert.ToString(Settings.ScreenshotOnPass));
                extent.AddSystemInfo("SpeedLink IP", Settings.SpeedLinkIp);
                extent.AddSystemInfo("HI Platform", Settings.HearingInstrumentPlatform);
                extent.AddSystemInfo("Phone", Settings.DeviceName);
                extent.AddSystemInfo("Phone OS", Settings.Platform.ToString());
                //   extent.AddSystemInfo("Phone OS system version", InvokeFunctions.InvokeAppSystemVersion());
                extent.AddSystemInfo("Retrys", Convert.ToString(Settings.RetriesOnError));
                //     extent.AddSystemInfo("Application name", InvokeFunctions.InvokeAppName());
                //    extent.AddSystemInfo("Application version", InvokeFunctions.InvokeAppSystemVersion());
                //    extent.AddSystemInfo("Application build date", InvokeFunctions.InvokeAppManufactureDate());
                //   extent.AddSystemInfo("Application language", InvokeFunctions.InvokeAppCurrentCulture());
                //   extent.AddSystemInfo("Application language name", InvokeFunctions.InvokeAppCurrentCultureName());
                extent.Flush();
            }
        }


        public static void Initialize(FeatureContext featureContext, ScenarioContext scenarioContext)
        {

            pathForScenario = Directory.GetCurrentDirectory();

            //Create a node for the specific scenario
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);

            //Set new value of the Scenario counter to Feature context
            scenarioContext.Add("StepCount", 1);
            featureContext["ScenarioCount"] = featureContext.Get<int>("ScenarioCount") + 1;
            featureContext["StepFail"] = 0;
        }

    }
}
