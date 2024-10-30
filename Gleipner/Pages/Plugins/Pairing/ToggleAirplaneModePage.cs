using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Pairing
{
    public class ToggleAirplaneModePage : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Ready for takeoff?" => new Texts().ToggleAirplaneModePageHeader,
                "Before we begin" => new Texts().ToggleAirplaneModePageBodyText1,
                "Done" => new Buttons().ToggleAirplaneModePagePrimaryButton,
                "Show me how" => new Buttons().ToggleAirplaneModePageTertiaryButton,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}

