using Fenris.Steps.Base;
using Gleipner.Pages.Native;
using NUnit.Framework;
using Polaris.Base;
using Reqnroll;
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;
using AppInitializer = Polaris.Base.AppInitializer;

namespace Fenris.Steps;

[Binding]
public sealed class NativeSettingsSteps : StepsBase
{
    [Given("Go to native settings")]
    public void GivenGoToNativeSettings()
    {
        if (driver is null)
        {
            var platformType = SettingsBase.Platform == SettingsBase.PlatformType.Android
                ? AppInitializer.PlatformType.Android
                : AppInitializer.PlatformType.iOS;

            AppInitializer.StartApp(platformType, goToSettings: true);
            
        }
        else
        {
            AppInitializer.OpenApp(PlatformCapabilities.SettingsActivity);
            Thread.Sleep(1000);
            AppInitializer.TerminateApp("Preferences");
            Thread.Sleep(1000);
            AppInitializer.OpenApp("Preferences");
        }
    }

    [When(@"I press '(.*)' button on Settings Page")]
    public void WhenIPressButtonOnNativeSettingsPage(string button)
    {
        var nativePage = new NativeSettingsPage();
        try
        {
            ClickOnElement(nativePage.FindElement(button));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }

    [When(@"I turn '(.*)' Bluetooth")]
    public void WhenITurnBluetooth(string turnON)
    {
        if (SettingsBase.Platform is SettingsBase.PlatformType.iOS)
        {
            WaitForElementUsingImplicitWait(3);
            var bluetoothPage = new NativeBluetoothPage();
            bool expectedBluetoothState = turnON.ToUpper() == "ON";
            bool currentBluetoothState = bluetoothPage.FindElement("BluetoothSwitch").GetAttribute("value") == "1";

            if (expectedBluetoothState != currentBluetoothState)
                ClickOnElement(bluetoothPage.FindElement("BluetoothSwitch"));
        }
        else
        {
            var bluetoothPage = new NativeBluetoothPage();
            string commands = (turnON == "ON")
                ? "adb shell am start -a android.bluetooth.adapter.action.REQUEST_ENABLE"
                : "adb shell am start -a android.bluetooth.adapter.action.REQUEST_DISABLE";
            string bluetoothStatus = ExecuteCommandAndReturnOutput("adb shell settings get global bluetooth_on");
            if ((bluetoothStatus.Trim() == "0" && turnON == "ON") || (bluetoothStatus.Trim() == "1" && turnON == "OFF"))
            {
                ExecuteCommand(commands);
            }
        }
    }
    
    [When(@"I turn '(.*)' Airplane Mode")]
    public void WhenITurnAirplaneMode(string turnON)
    {
        if (SettingsBase.Platform is SettingsBase.PlatformType.iOS)
        {
            WaitForElementUsingImplicitWait(3);
            var nativePage = new NativeSettingsPage();
            bool expectedBluetoothState = turnON.ToUpper() == "ON";
            bool currentBluetoothState = nativePage.FindElement("AirplaneMode").GetAttribute("value") == "1";

            if (expectedBluetoothState != currentBluetoothState)
                ClickOnElement(nativePage.FindElement("AirplaneMode"));
        }
        else
        {
            var bluetoothPage = new NativeBluetoothPage();
            string commands = (turnON == "ON")
                ? "adb shell am start -a android.bluetooth.adapter.action.REQUEST_ENABLE"
                : "adb shell am start -a android.bluetooth.adapter.action.REQUEST_DISABLE";
            string bluetoothStatus = ExecuteCommandAndReturnOutput("adb shell settings get global bluetooth_on");
            if ((bluetoothStatus.Trim() == "0" && turnON == "ON") || (bluetoothStatus.Trim() == "1" && turnON == "OFF"))
            {
                ExecuteCommand(commands);
            }
        }
    }

    [When(@"I scroll '(.*)' with '(.*)' full-screen scrolls")]
    public void WhenIScroll(string direction, double distance)
    {
        // Convert the first character to uppercase and the rest to lowercase
        string formattedDirection = char.ToUpper(direction[0]) + direction.Substring(1).ToLower();
        
        // Try to parse the direction string to the SwipeDirection enum
        if (Enum.TryParse(formattedDirection, out SwipeDirection swipeDirection))
        {
            Scroll(swipeDirection, distance);
        }
        else
        {
            throw new ArgumentException($"'{formattedDirection}' is not a valid swipe direction.", nameof(direction));
        }
    }

    [When(@"I return to '(.*)'")]
    public void WhenIReturnToSettings(string button)
    {
        var blueToothPage = new NativeBluetoothPage();
        try
        {
            ClickOnElement(blueToothPage.FindElement(button));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }

    [Then(@"Check if Bluetooth is '(.*)'")]
    public void ThenVerifyIfBluetoothIsOff(string turnON)
    {
        WaitForElementUsingImplicitWait(3);

        var bluetoothPage = new NativeBluetoothPage();
        bool expectedBluetoothState = turnON.ToUpper() == "ON";
        bool currentBluetoothState = bluetoothPage.FindElement("BluetoothSwitch").GetAttribute("value") == "1";

        Assert.That(currentBluetoothState == expectedBluetoothState, $"Current state of Bluetooth switch is expected to be {turnON}.");
    }

    [Then(@"Verify if specified Hearing Instruments are already Paired")]
    public void ThenVerifyIfHiNameDevicesAreVisible()
    {
        var hearingDevices = new NativeHearingDevices();
        Assert.IsTrue(hearingDevices.IsHearingDevicePaired(), "The specified hearing instruments are not paired.");
    }

    [When(@"I press HI on Hearing Devices Page")]
    public void WhenIPressHiDevicesOnHearingDevicesPage()
    {
        WaitForElementUsingImplicitWait(3);

        var hearingDevices = new NativeHearingDevices();
        try
        {
            ClickOnElement(hearingDevices.FindElement("HINameFromConfig"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }

    [Then(@"Verify R and L are visible")]
    public void ThenVerifyRAndLAreVisible()
    {
        WaitForElementUsingImplicitWait(3);

        var hiMenu = new NativeHiMenu();
        Assert.IsNotNull(hiMenu.FindElement("R"), "R should be visible.");
        Assert.IsNotNull(hiMenu.FindElement("L"), "L should be visible.");
    }

    [When(@"I press Pair on alert")]
    public void WhenIPressForgetThisDevice()
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.AlertIsPresent());
            driver.SwitchTo().Alert().Accept();
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Pair alert is NOT present");
            Assert.Fail("Pair alert is NOT present");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }

    [Then(@"validate native settings bluetooth is in '(.*)' state")]
    public void ThenValidateNativeSettingsBluetoothIsInState(string AppSwitch)
    {
        var bluetoothPage = new NativeBluetoothPage();
        switch (AppSwitch)
        {
            case "Off":
                Assert.AreEqual(bluetoothPage.AppBluetoothSwitch.GetAttribute("value"),0);
                break;
            case "On":
                Assert.AreEqual(bluetoothPage.AppBluetoothSwitch.GetAttribute("value"),1);
                break;
        }
    }
    
    [Then(@"Verify if '(.*)' label is visible")]
    public void ThenVerifyIfBluetoothOptionIsVisible(string label)
    {
        var appAccess = new NativeAppAccess();
        try
        {
            WaitForElementToBeVisible(appAccess, label, 5);
        }
        catch(Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [When(@"I close the settings")]
    public void WhenICloseTheSettings()
    {
        try
        {
            if (SettingsBase.Platform == SettingsBase.PlatformType.Android)
            {
                ((AndroidDriver<IWebElement>)driver).PressKeyCode(AndroidKeyCode.Back);
            }
            else if (SettingsBase.Platform == SettingsBase.PlatformType.iOS)
            {
                // For iOS, you can use the home button to close the settings app
                ((IOSDriver<IWebElement>)driver).BackgroundApp(TimeSpan.FromSeconds(-1))
                ;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }
}