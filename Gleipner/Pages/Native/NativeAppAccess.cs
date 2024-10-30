using Gleipner.Base;
using OpenQA.Selenium;
using System;
using Gleipner.Controls.Text;

namespace Gleipner.Pages.Native;

public class NativeAppAccess : PageBase
{
    public override IWebElement FindElement(string elementName)
    {
        return driver.FindElementByName(GetAutomationID(elementName));
    }
    
    public override string GetAutomationID(string elementName)
    {
        return elementName switch
        {
            "Allow APP To Access" => new Texts().AllowAppToAccess,
            _ => throw new Exception($"{elementName} is NOT supported")
        };
    }
}