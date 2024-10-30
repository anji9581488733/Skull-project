using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Gleipner.Pages.Native
{
    public class NativeAccessibilityPage : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return elementName switch
            {
                "Larger Accessibility Sizes" => driver.FindElement(MobileBy.IosClassChain(new Buttons().LargerAccessibilitySizes)),
                "LargerTextSlider" => driver.FindElementByXPath(new Buttons().LargerTextSlider),
                "Font List Plugin" => driver.FindElement(MobileBy.IosClassChain(new Buttons().FontListPlugin)),
                "Settings" => driver.FindElement(MobileBy.IosClassChain(new Buttons().Settings)),
                _ => driver.FindElementById(GetAutomationID(elementName))
            };
        }
        
        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Hearing Devices" => new Buttons().HearingDevices,
                "Accessibility" => new Buttons().Accessibility,
                "Display & Text Size" => new Buttons().DisplayTextSize,
                "Larger Text" => new Buttons().LargerTextButton,
                "Larger Accessibility Sizes" => new Buttons().LargerAccessibilitySizes,
                "LargerTextSlider" => new Buttons().LargerTextSlider,
                "Font List Plugin" => new Buttons().FontListPlugin,
                "Settings" => new Buttons().Settings,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
        
        public int GetTextSize(string elementId)
            {
                var element = FindElement("Font List Plugin");
                if (element.Displayed)
                {
                    return element.Size.Height; // or Width depending on your needs
                }
                else
                {
                    throw new Exception("Element is not visible on the screen.");
                }
            }
        
        public void HandleLargerAccessibilitySizes()
        {
            IWebElement largerAccessibilitySizesSwitch = FindElement("Larger Accessibility Sizes");
            // Check if the switch is on
            if (largerAccessibilitySizesSwitch.GetAttribute("value") == "1")
            {
                // If the switch is on, click it to turn it off
                largerAccessibilitySizesSwitch.Click();
            }
        }
    }
}