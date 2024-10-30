using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Pairing
{
    public class WaitingForBootPage : PageBase
    { 
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Connected" => new Texts().WaitingForBootPageHeader,
                "Next step is to restart" => new Texts().WaitingForBootPageBodyText1,
                "Continue" => new Buttons().WaitingForBootPagePrimaryButton,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}