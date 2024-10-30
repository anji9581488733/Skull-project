using System;
using System.Collections.Generic;
using Fenris.Steps.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using Polaris.Base;
using Reqnroll;


namespace Fenris.Steps
{
    [Binding]
    public class TestSteps : StepsBase
    {
        [Given("I launch the app")]
        public void GivenUserLaunchesApp()
        {
            // Load the app with a clear cache each time.
            if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
            {
                AppInitializer.StartApp(AppInitializer.PlatformType.Android);
            }
            // UITest not supporting Clear for iOS at the moment so uninstall/install mimic this
            else
            {
                AppInitializer.StartApp(AppInitializer.PlatformType.iOS);
            }
        }
        
        [When(@"I launch the plugin app")]
        [Given(@"I launch the plugin app")]
        public void GivenILaunchThePluginApp()
        {
            try
            {
                if (driver is null)
                {
                    var platformType = SettingsBase.Platform == SettingsBase.PlatformType.Android
                        ? AppInitializer.PlatformType.Android
                        : AppInitializer.PlatformType.iOS;

                    driver = AppInitializer.StartApp(platformType);
                }
                else
                {
                    AppInitializer.OpenApp(PlatformCapabilities.AppPathPackage);
                }
                
                // Check if the app has launched properly
                if (driver is AndroidDriver<IWebElement> androidDriver)
                {
                    try
                    {
                        var wait = new WebDriverWait(androidDriver, TimeSpan.FromSeconds(10));
                        wait.Until(drv => !((AndroidDriver<IWebElement>)drv).CurrentActivity.EndsWith("LauncherActivity"));
                    }
                    catch (WebDriverTimeoutException)
                    {
                        throw new ApplicationException("The application has not been launched correctly. CurrentActivity is still pointing to LauncherActivity.");
                    }
                }
                else if (driver is IOSDriver<IWebElement> iosDriver)
                {
                    string? appId = AppInitializer.ReturnMappedAppID(PlatformCapabilities.AppPathPackage);
                    if (appId != null)
                    {
                        var parameters = new Dictionary<string, object> { { "bundleId", appId } };

                        try
                        {
                            var wait = new WebDriverWait(iosDriver, TimeSpan.FromSeconds(10));
                            bool isAppLaunchedCorrectly = wait.Until(drv =>
                            {
                                var appElement = ((IOSDriver<IWebElement>)drv).FindElementByXPath("//XCUIElementTypeApplication");
                                var appName = appElement.GetAttribute("name");
                                return !string.IsNullOrWhiteSpace(appName);
                            });

                            if (!isAppLaunchedCorrectly)
                            {
                                throw new ApplicationException("Failed to launch the app or the app name is null, empty, or whitespace.");
                            }
                        }
                        catch (WebDriverTimeoutException)
                        {
                            throw new ApplicationException("Failed to launch the app within the given time.");
                        }

                        // Check if the app is running using the mobile: queryAppState command
                        var runningAppState = iosDriver.ExecuteScript("mobile: queryAppState", parameters);
                        if (!(runningAppState is long state && state == 4)) // 4 corresponds to the 'running' state
                        {
                            throw new ApplicationException($"The app with bundle id '{appId}' is not running. Current state: {runningAppState}");
                        }
                    }
                    else
                    {
                        throw new ApplicationException("App ID is null. Cannot launch the app.");
                    }
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error launching the app: {ex.Message}");
                throw;
            }
        }
        
        [Given(@"I launch the plugin app in '(.*)' and '(.*)'")]
        public void GivenILaunchThePluginAppInDifferentLanguages(string language, string region)
        {
            if (driver is null)
            {
                var platformType = SettingsBase.Platform == SettingsBase.PlatformType.Android
                    ? AppInitializer.PlatformType.Android
                    : AppInitializer.PlatformType.iOS;

                AppInitializer.StartApp(platformType, false, language, region);
            }
            else
            {
                AppInitializer.OpenApp(PlatformCapabilities.AppPathPackage);
            }
        }
    }
}