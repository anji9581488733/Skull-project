using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Pairing
{
    public class RestartDevicesDuringTrustedBondPage : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Restart hearing aids" => new Texts().RestartDevicesDuringTrustedBondPageHeader,
                "To enable pairing mode" => new Texts().RestartDevicesDuringTrustedBondPageBodyText1,
                "Show me how" => new Buttons().RestartDevicesDuringTrustedBondTertiaryButton,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}