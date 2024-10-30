using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Pairing
{
    public class AllowBluetoothFromAppSettingsPage : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Allow Bluetooth" => new Texts().AllowBluetoothFromAppSettingsPageHeader,
                "Go to app settings" => new Texts().AllowBluetoothFromAppSettingsPageBodyText1,
                "Open Settings" => new Buttons().AllowBluetoothFromAppSettingsPagePrimaryButton,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}