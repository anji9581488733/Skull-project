using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Plugins.DisplayMessagePage;

public class DisplayMessagePage : PageBase
{
    public override IWebElement FindElement(string elementName)
    {
        return driver.FindElementById(GetAutomationID(elementName));
    }
    
    public override string GetAutomationID(string elementName)
    {
        return elementName switch
        {
            "StartPluginButton" => new Buttons().DisplayMessagePagePrimaryButton,
            "CloseButton" => new Buttons().DisplayMessagePageCloseButton,
            "DisplayMessagePageHeaderText" => new Texts().DisplayMessagePageHeaderText,
            "DisplayMessagePageBody1Text" => new Texts().DisplayMessagePageBody1Text,
            _ => throw new Exception($"{elementName} is NOT supported")
        };
    }
}