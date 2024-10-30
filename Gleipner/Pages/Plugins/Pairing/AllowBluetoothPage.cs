using System;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;
using PageBase = Gleipner.Base.PageBase;

namespace Gleipner.Pages.Pairing
{
    public class AllowBluetoothPage : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Allow Bluetooth" => new Texts().AllowBluetoothHeader,
                "In order to connect" => new Texts().AllowBluetoothBodyText1,
                "Ok" => new Buttons().AllowBluetoothPagePrimaryButton,
                "AllowBluetoothPopup" => new Buttons().AllowBluetooth,
                "DontAllowBluetoothPopup" => new Buttons().DenyBluetooth,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}