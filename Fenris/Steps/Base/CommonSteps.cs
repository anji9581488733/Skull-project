using System;
using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.IO;
using System.Linq;
using System.Threading;
using Gleipner.Pages.ComponentTest;
using System.Threading.Tasks;
using Fenris.Hooks;
using Gleipner.Pages.Pairing;
using Gleipner.Pages.Plugins.AssemblyListPage;
using Gleipner.Pages.Plugins.DisplayMessagePage;
using Gleipner.Pages.Plugins.POCConsent;
using Gleipner.Pages.Native;
using NUnit.Framework;
using OpenQA.Selenium;
using Polaris.Base;
using Reqnroll;
using Image = SixLabors.ImageSharp.Image;
using PageBase = Gleipner.Base.PageBase;

namespace Fenris.Steps.Base;

[Binding]
public class CommonSteps : StepsBase
{
    [When(@"I press '([^']*)' on '([^']*)'$")]
    public void WhenIPressButtonOnPage(string button, string pageName)
    {
        var page = CreatePageInstance(pageName);
        try
        {
            WaitForElementToBeVisible(page, button, 5);
            ClickOnElement(page.FindElement(button));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }
    
    [When(@"I press '([^']*)' on '([^']*)' with timeout '(\d+)'$")]
    public void WhenIPressButtonOnPageWithTimeout(string button, string pageName, int seconds)
    {
        var page = CreatePageInstance(pageName);
        try
        {
            WaitForElementToBeVisible(page, button, seconds);
            ClickOnElement(page.FindElement(button));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }
    
    [Then(@"The following elements are displayed on '([^']*)'")]
    public void ThenFollowingElementsAreDisplayedOnPage(string pageName, Table table)
    {
        var page = CreatePageInstance(pageName);
        foreach (var row in table.Rows)
        {
            string elementName = row["Element"];
            bool shouldBeDisplayed = bool.Parse(row["ShouldBeDisplayed"]);

            try
            {
                if (shouldBeDisplayed)
                {
                    WaitForElementToBeVisible(page, elementName, 5);
                }
                else
                {
                    WaitForElementToBeNotVisible(page, elementName, 5);
                }
                // If the wait methods do not throw an exception, the element's visibility state is as expected.
            }
            catch (ElementVisibilityException e)
            {
                // Log the detailed message to the console and Allure report
                Console.WriteLine(e.Message);

                // Fail the test with the detailed message
                Assert.Fail(e.Message);
            }
        }
        // If we reached this point, it means that all elements meet the expectations and the test can be considered successful.
    }
    
    [Then(@"The following elements are displayed on '([^']*)' with timeout '(\d+)'$")]
    public void ThenFollowingElementsAreDisplayedOnPageWithTimeout(string pageName, int seconds, Table table)
    {
        var page = CreatePageInstance(pageName);
        foreach (var row in table.Rows)
        {
            string elementName = row["Element"];
            bool shouldBeDisplayed = bool.Parse(row["ShouldBeDisplayed"]);

            try
            {
                if (shouldBeDisplayed)
                {
                    WaitForElementToBeVisible(page, elementName, seconds);
                }
                else
                {
                    WaitForElementToBeNotVisible(page, elementName, seconds);
                }
                // If the wait methods do not throw an exception, the element's visibility state is as expected.
            }
            catch (ElementVisibilityException e)
            {
                // Log the detailed message to the console and Allure report
                Console.WriteLine(e.Message);

                // Fail the test with the detailed message
                Assert.Fail(e.Message);
            }
        }
        // If we reached this point, it means that all elements meet the expectations and the test can be considered successful.
    }
    
    [Then(@"I wait '(.*)' seconds")]
    public void ThenIWaitSeconds(int seconds)
    {
        Thread.Sleep(TimeSpan.FromSeconds(seconds));
    }
    
    [When(@"I press '(.*)' button to start the Single Plugin")]
    public void WhenIPressStartPluginButtonToStartThePlugin(string elementName)
    {
        if (PlatformCapabilities.AppPathPackage.Contains("TestMultiplePlugins"))
        {
            return;
        }

        var displayMessagePage = new DisplayMessagePage();
        string locatorName = displayMessagePage.GetAutomationID(elementName);
        try
        {
            ClickOnElement(displayMessagePage.FindElement(elementName));
        }
        catch (Exception e)
        {
            Assert.Fail("Unable to click " + elementName+ $" with AutomationID: {locatorName} button to start the plugin " + e.Message);
        }
    }
    
    [When(@"I press '(.*)' on Assembly List Plugin Page")]
    public void WhenIPressOnAssemblyListPluginPage(string button)
    {
        if (PlatformCapabilities.AppPathPackage.Contains("TestMultiplePlugins"))
        {
            return;
        }

        var assemblyListPage = new AssemblyListPage();
        string locatorName = assemblyListPage.GetAutomationID(button);
        try
        {
            ClickOnElement(assemblyListPage.FindElement(button));
        }
        catch (Exception e)
        {
            
            Console.WriteLine(e.Message);
            Assert.Fail($"Unable to click {button} with AutomationID: {locatorName}" + e.Message);
        }
    }
    
    [When(@"I scroll '([^']*)' and press '([^']*)' on '([^']*)'$")]
    public void ScrollToAndPressTheElement(string direction, string element, string pageName)
    {
        var page = CreatePageInstance(pageName);
        
        SwipeDirection swipeTo = SwipeDirection.Down;
        swipeTo = direction.ToLower() switch
        {
            "down" => SwipeDirection.Down,
            "up" => SwipeDirection.Up,
            _ => throw new Exception("Swipe direction not applicable")
        };
        try
        {
            ScrollToElement(swipeTo, element, page);
            ClickOnElement(page.FindElement(element));
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    /// <summary>
    /// This step was mainly prepared for ComponentTest, where some group of tests may not exist in the provided application. But it can also be used for other purposes.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="element"></param>
    /// <param name="pageName"></param>
    /// <exception cref="Exception"></exception>
    [When(@"I scroll '([^']*)' and press '([^']*)' on '([^']*)' if exists$")]
    public void ScrollToAndPressTheElementIfExists(string direction, string element, string pageName)
    {
        var page = CreatePageInstance(pageName);

        SwipeDirection swipeTo = SwipeDirection.Down;
        swipeTo = direction.ToLower() switch
        {
            "down" => SwipeDirection.Down,
            "up" => SwipeDirection.Up,
            _ => throw new Exception("Swipe direction not applicable")
        };
        try
        {
            ScrollToElement(swipeTo, element, page);
            ClickOnElement(page.FindElement(element));
        }
        catch (Exception e)
        {
            Assert.Ignore($"Test has been skipped. {element} - It is likely that this group of tests was not included in the application");
        }
    }

    [When(@"Take screenshot with name '(.*)'")]
    public void TakeScreenhotWithName(string service)
    {
        try
        {
            TakeScreenshot(service);
            //commonSteps.MoveScreenshotToInspectProComparePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots",service+".png"));
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
    
    private PageBase CreatePageInstance(string pageName)
    {
        switch (pageName)
        {
            case "ComponentTestPage":
                return new ComponentTestPage();
            case "NativeHiMenu":
                return new NativeHiMenu();
            case "NativeBluetoothPage":
                return new NativeBluetoothPage();
            case "NativeHearingDevices":
                return new NativeHearingDevices();
            case "NativeAccessibilityPage":
                return new NativeAccessibilityPage();
            case "NativeSettingsPage":
                return new NativeSettingsPage();
            case "DisplayMessagePage":
                return new DisplayMessagePage();
            case "ConsentPart1Page":
                return new ConsentPart1Page();
            case "ConsentPart2Page":
                return new ConsentPart2Page();
            case "AllowBluetoothFromAppSettingsPage":
                return new AllowBluetoothFromAppSettingsPage();
            case "AllowBluetoothPage":
                return new AllowBluetoothPage();
            case "ConnectingDuringTrustedBondPage":
                return new ConnectingDuringTrustedBondPage();
            case "ConnectingPage":
                return new ConnectingPage();
            case "ConnectionFailedPage":
                return new ConnectedFailedPage();
            case "MFiFullyConnectedPage":
                return new MFiFullyConnectedPage();
            case "RestartDevicesDuringTrustedBondPage":
                return new RestartDevicesDuringTrustedBondPage();
            case "ToggleAirplaneModePage":
                return new ToggleAirplaneModePage();
            case "TrustedBondCompletedPage":
                return new TrustedBondCompletedPage();
            case "WaitingForBootPage":
                return new WaitingForBootPage();
            case "ToggleAirplaneModeGuidePage":
                return new ToggleAirplaneModeGuidePage();
            default:
                throw new ArgumentException($"Unknown page: {pageName}");
        }
    }
}