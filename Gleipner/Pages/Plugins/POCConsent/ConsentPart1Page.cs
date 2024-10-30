using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Plugins.POCConsent
{
    public class ConsentPart1Page : PageBase
    { 
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "ScrollToBottomPart1" => new Buttons().ConsentPart1PageSecondaryButton,
                "ConsentPart1Header" => new Texts().ConsentPart1Header,
                "ConsentPart1Body1" => new Texts().ConsentPart1Body1,
                "ConsentPart1Body2" => new Texts().ConsentPart1Body2,
                "AcceptAndContinuePart1Button" => new Buttons().ConsentPart1PagePrimaryButton,
                "DeclineConsentPart2" => new Buttons().ConsentPart2PageDeclineConsentPart2,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}