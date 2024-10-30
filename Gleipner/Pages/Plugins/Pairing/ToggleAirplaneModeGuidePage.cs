using System;
using Gleipner.Base;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Pairing
{
    public class ToggleAirplaneModeGuidePage : PageBase
    {
        public override IWebElement FindElement(string elementName)
        { 
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Airplane mode" => new Texts().ToggleAirplaneModeGuidePageHeader,
                "To toggle airplane mode" => new Texts().ToggleAirplaneModeGuidePageBodyText1,
                "Step1" => new Texts().ToggleAirplaneModeGuidePageStep1,
                "Step2" => new Texts().ToggleAirplaneModeGuidePageStep2,
                "Step3" => new Texts().ToggleAirplaneModeGuidePageStep3,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}