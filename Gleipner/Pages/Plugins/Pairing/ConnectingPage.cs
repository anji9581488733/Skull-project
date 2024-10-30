using System;
using Gleipner.Base;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Pairing
{
    public class ConnectingPage : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Connecting..." => new Texts().ConnectingPageHeader,
                "The app is connecting to the hearing aids" => new Texts().ConnectingPageBodyText1,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}