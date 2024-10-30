using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Plugins.POCConsent
{
    public class ConsentPart2Page : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "ConsentPart2Header" => new Texts().ConsentPart2Header,
                "ConsentPart2Body1" => new Texts().ConsentPart2Body1,
                "ConsentPart2Body2" => new Texts().ConsentPart2Body2,
                "ScrollToBottomPart2" => new Buttons().ConsentPart2PageSecondaryButton,
                "AcceptAndContinuePart1Button" => new Buttons().ConsentPart1PagePrimaryButton,
                "AcceptAndContinuePart2Button" => new Buttons().ConsentPart2PageAcceptConsentPart2,
                "DeclineConsentPart2" => new Buttons().ConsentPart2PageDeclineConsentPart2,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}