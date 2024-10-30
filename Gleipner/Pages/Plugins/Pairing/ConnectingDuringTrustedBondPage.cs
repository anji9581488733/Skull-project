using System;
using Gleipner.Base;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Pairing
{
    public class ConnectingDuringTrustedBondPage : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Connecting..." => new Texts().ConnectingDuringTrustedBondPageHeader,
                "The app us connecting to the hearing aids" => new Texts().ConnectingDuringTrustedBondPageBodyText1,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}