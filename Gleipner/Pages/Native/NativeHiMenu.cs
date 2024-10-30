using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Gleipner.Pages.Native;

public class NativeHiMenu : PageBase
{
    public override IWebElement FindElement(string elementName)
    {
        return elementName switch
        {
            "Pair" => driver.FindElement(MobileBy.IosClassChain(new Buttons().Pair)),
            "Forget this device" => driver.FindElement(MobileBy.IosClassChain(new Buttons().ForgetThisDevice)),
            _ => driver.FindElementByAccessibilityId(GetAutomationID(elementName)),
        };
    }
    
    public override string GetAutomationID(string elementName)
    {
        return elementName switch
        {
            "R" => new Texts().R,
            "L" => new Texts().L,
            "Forget this device" => new Buttons().ForgetThisDevice,
            "Forget" => new Buttons().Forget,
            "Pair" => new Buttons().Pair,
            _ => throw new Exception($"{elementName} is NOT supported")
        };
    }
}