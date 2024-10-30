using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Pairing
{
    public class TrustedBondCompletedPage : PageBase
    { 
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Well done" => new Texts().TrustedBondCompletedPageHeader,
                "You are all set" => new Texts().TrustedBondCompletedPageBodyText1,
                "Continue" => new Buttons().TrustedBondCompletedPagePrimaryButton,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}