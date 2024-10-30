using Gleipner.Controls.Button;
using Gleipner.Controls.Image;
using Gleipner.Controls.Text;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using Polaris.Base;
using PageBase = Gleipner.Base.PageBase;

namespace Gleipner.Pages.Native;

public class NativeHearingDevices : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return elementName switch
            {
                "HINameFromConfig" => driver.FindElement(MobileBy.IosClassChain(new Buttons().HIName)),
                _ => driver.FindElementById(GetAutomationID(elementName)),
            };
        }

        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "Searching..." => new Texts().Searching,
                "HINameFromConfig" => new Buttons().HIName,
                "Connected" => new Texts().Connected,
                "Not Paired" => new Texts().NotPaired,
                "In progress" => new Images().InProgress,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
        
        /// <summary>
        /// Checks if the specified hearing device is paired by verifying the presence of "Connected" or "Not Connected" labels.
        /// </summary>
        /// <returns>
        /// Returns <c>true</c> if specified hearing device is paired; otherwise, <c>false</c>.
        /// </returns>
        public bool IsHearingDevicePaired()
        {
            try
            {
                // Create a WebDriverWait instance
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                
                // Find the hearing device element by name from config
                var deviceXPath = $"//XCUIElementTypeCell[@name=\"{SettingsBase.HIName}\"]";
                var deviceElement = wait.Until(driver => driver.FindElement(By.XPath(deviceXPath)));

                // Check if the device has a "Connected" or "Not Connected" label
                bool isConnected = false;
                bool isNotConnected = false;

                try
                {
                    var connectedText = wait.Until(driver =>
                    {
                        try
                        {
                            var element = deviceElement.FindElement(By.XPath(".//XCUIElementTypeStaticText[@name='Connected']"));
                            return element.Displayed ? element : null;
                        }
                        catch (NoSuchElementException)
                        {
                            return null;
                        }
                    });
                    isConnected = connectedText != null;
                }
                catch (WebDriverTimeoutException)
                {
                    // Ignore and proceed to check for "Not Connected"
                }

                try
                {
                    var notConnectedText = wait.Until(driver =>
                    {
                        try
                        {
                            var element = deviceElement.FindElement(By.XPath(".//XCUIElementTypeStaticText[@name='Not Connected']"));
                            return element.Displayed ? element : null;
                        }
                        catch (NoSuchElementException)
                        {
                            return null;
                        }
                    });
                    isNotConnected = notConnectedText != null;
                }
                catch (WebDriverTimeoutException)
                {
                    // Ignore
                }

                if (isConnected || isNotConnected)
                {
                    return true; // Found a paired device
                }

                return false; // No paired device found
            }
            catch (WebDriverTimeoutException)
            {
                return false; // No hearing device found within the timeout
            }
            catch (NoSuchElementException)
            {
                return false; // No hearing device found
            }
        }
    }