using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Pairing
{
    public class MFiFullyConnectedPage : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }

        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Use connected" => new Texts().MFiFullyConnectedHeader,
                "[HI NAME] are connected" => new Texts().MFiFullyConnectedBodyText1,
                "Use these" => new Buttons().MFiFullyConnectedPrimaryButton,
                "No, remove and pair new" => new Buttons().MFiFullyConnectedTertiaryButton,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}