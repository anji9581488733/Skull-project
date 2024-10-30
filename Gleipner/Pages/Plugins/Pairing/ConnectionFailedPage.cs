using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Pairing
{
    public class ConnectedFailedPage : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Connection failed" => new Texts().ConnectedFailedPageHeader,
                "Your device failed" => new Texts().ConnectedFailedPageBodyText1,
                "Make sure your hearing aids" => new Texts().ConnectedFailedPageBodyText2,
                "Try again" => new Buttons().ConnectedFailedPagePrimaryButton,
                "Need help?" => new Buttons().ConnectedFailedPageTertiaryButton,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}