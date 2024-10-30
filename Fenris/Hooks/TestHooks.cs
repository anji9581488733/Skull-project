using Gleipner.Pages;
using Polaris;
using Polaris.Base;
using Polaris.Hooks;
using Reqnroll;
using System;
using System.Diagnostics;
using Allure.Net.Commons;
using AppInitializer = Gleipner.ConfigElement.AppInitializer;

namespace Fenris.Hooks
{
    /// <summary>
    ///     Single point of entry for all test hooks related to Fenris and Gleipner project funtionality.
    ///     Only use test hook binding decorators related to Fenris & Gleipner scope here.
    ///     Routes to Polaris TestHook for common functionality.
    /// </summary>
    [Binding]
    internal class TestHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            TestHook.BeforeTestRun();
            
            //Flush the Hics host
            if (SettingsBase.PhysicalDevice && SettingsBase.EnableHIs)
            {
                HIControlPage.ResetHearingAids();
                Console.WriteLine("Reset hics client before new scenario.");
            }

            // Local execution requirements
            TestInitializer.BeforeTestRun();

            AllureReporting.InitializeReport();

            AllureReporting.RestoreHistory();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            TestHook.BeforeFeature();

            //Flush the Hics host
            if (SettingsBase.PhysicalDevice && SettingsBase.EnableHIs)
            {
                HIControlPage.ResetHearingAids();
                Console.WriteLine("Reset hics client before new scenario.");
            }
        }

        [BeforeScenario]
        public static void BeforeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
            {
                AppBase.ExecuteCommand("adb uninstall io.appium.uiautomator2.server");
                AppBase.ExecuteCommand("adb uninstall io.appium.uiautomator2.server.test");
                AppBase.ExecuteCommand("adb uninstall io.appium.settings");
            }
            
            // Global test hooks executed first
            TestHook.BeforeScenario();

            //Flush the Hics host
            if (SettingsBase.PhysicalDevice && SettingsBase.EnableHIs)
            {
                HIControlPage.ResetHearingAids();
                Console.WriteLine("Reset hics client before new scenario.");
            }

            // Reset all settings to defaults between each scenario run, to avoid bleed-through of unintentional changes.
            AppInitializer.InitializeSettings();

            if (SettingsBase.Platform is SettingsBase.PlatformType.iOS && SettingsBase.PhysicalDevice)
            {
                var proc = new Process();

                proc.StartInfo.FileName = "/bin/bash";

                proc.StartInfo.Arguments = "-c \" " +
                                           "ios-deploy --uninstall_only --bundle_id sh.calaba.DeviceAgent.xctrunner" +
                                           " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                proc.WaitForExit();
                Console.WriteLine("Uninstall of device agent on physical ios device done.");
            }

            if (SettingsBase.Platform is SettingsBase.PlatformType.iOS && !SettingsBase.PhysicalDevice)
            {
                var proc = new Process();

                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \"xcrun simctl uninstall " + SettingsBase.DeviceId + " " +
                                           SettingsBase.AppBundleId + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                proc.WaitForExit();

                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \"xcrun simctl uninstall " + SettingsBase.DeviceId +
                                           " sh.calaba.DeviceAgent.xctrunner" + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                proc.WaitForExit();
            }
        }

        [BeforeStep]
        public static void BeforeStep(FeatureContext featureContext)
        {
            TestHook.BeforeStep();
        }

        [AfterStep]
        public static void AfterStep(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            TestHook.AfterStep();
            // Take a screenshot after each step
            string screenshotPath = AllureReporting.TakesAndSaveScreenshot();

            // If there is an error, attach the screenshot to the Allure report
            if (scenarioContext.TestError != null && !string.IsNullOrEmpty(screenshotPath))
            {
                AllureApi.AddAttachment("Screenshot", "image/png", screenshotPath);
            }
        }

        [AfterScenario]
        public static void AfterScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            TestHook.AfterScenario();

            if (Polaris.Base.AppInitializer.AppiumDriver is not null)
            {
                Polaris.Base.AppInitializer.AppiumDriver.Quit();
                Polaris.Base.AppInitializer.AppiumDriver = null;
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            TestHook.AfterFeature();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            // Resetting controller and client flush to release HicsImpl for next execution.
            if (SettingsBase.PhysicalDevice && SettingsBase.EnableHIs)
            {
                HIControlPage.ResetHearingAids(); // This will release HicsImpl
                Console.WriteLine("Reset hics client before new scenario.");
            }
            
            AllureReporting.GenerateHistory();
            AllureReporting.SaveHistory();
            
            if (SettingsBase.ServeLocalAllureReport)
            {
                string command = AppSettings.IsWindows
                    ? $"start allure serve {AppSettings.AllureResultsDirectory}"
                    : $"allure serve {AppSettings.AllureResultsDirectory} &";
                
                AppBase.ExecuteCommand(command);
            }
        }
    }
}