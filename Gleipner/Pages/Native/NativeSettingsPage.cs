using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Switch;
using Gleipner.Controls.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Gleipner.Pages.Native;

public class NativeSettingsPage : PageBase
{
    public override IWebElement FindElement(string elementName)
    {
        return elementName switch
        {
            "AirplaneMode" => driver.FindElement(MobileBy.IosClassChain(new Switches().AirplaneMode)),
            _ => driver.FindElementById(GetAutomationID(elementName)),
        };
    }
        
    public override string GetAutomationID(string elementName)
    {
        return elementName switch
        {
            "Bluetooth" => new Buttons().Bluetooth,
            "Settings" => new Texts().NativeSettingsHeader,
            "Accessibility" => new Buttons().Accessibility,
            "AirplaneMode" => new Switches().AirplaneMode,
            _ => throw new Exception($"{elementName} is NOT supported")
        };
    }
}
