using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Switch;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Gleipner.Pages.Native;

public class NativeBluetoothPage : PageBase
{
    public IWebElement AppBluetoothSwitch => new Switches().AppBluetoothSwitch;
    public override IWebElement FindElement(string elementName)
    {
        return elementName switch
        {
            "BluetoothSwitch" => driver.FindElement(MobileBy.IosClassChain(new Switches().BluetoothSwitch)),
            "Settings" => driver.FindElement(MobileBy.IosClassChain(new Buttons().ReturnToSettings)),
            _ => driver.FindElementById(GetAutomationID(elementName)),
        };
    }
    
    public override string GetAutomationID(string elementName)
    {
        return elementName switch
        {
            "BluetoothSwitch" => new Switches().BluetoothSwitch,
            "Settings" => new Buttons().ReturnToSettings,
            "AllowBluetooth" => new Buttons().AllowBluetooth,
            "DenyBluetooth" => new Buttons().DenyBluetooth,
            _ => throw new Exception($"{elementName} is NOT supported")
        };
    }
}