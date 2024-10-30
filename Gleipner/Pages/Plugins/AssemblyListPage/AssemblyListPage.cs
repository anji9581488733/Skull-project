using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.Plugins.AssemblyListPage;

public class AssemblyListPage : PageBase
{
    public override IWebElement FindElement(string elementName)
    {
        return driver.FindElementById(GetAutomationID(elementName));
    }
    
    public override string GetAutomationID(string elementName)
    {
        return elementName switch
        {
            "Copy Assembly List" => new Buttons().AssemblyListPageCopyAssemblyListButton,
            "Close Button" => new Buttons().AssemblyListPageCloseButton,
            _ => throw new Exception($"{elementName} is NOT supported")
        };
    }
}