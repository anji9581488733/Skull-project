using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using Polaris.Base;

namespace Gleipner.Controls.Switch
{
    internal class Switches : Switch
    {
        /// <summary>
        ///     This is the Guiding tips toggle switch from the more menu
        /// </summary>

        public IWebElement GuidingTips_Switch
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "(//androidx.recyclerview.widget.RecyclerView[@resource-id='dk.resound.smart3d:id/menu_layout']//android.widget.Switch[@resource-id='dk.resound.smart3d:id/menu_item_switch'])[1]");
                else
                    element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeSwitch[`value == '1'`][1]"));
                return element;
            }
        }

        public IWebElement GuidingTips_Switch_Off
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "(//androidx.recyclerview.widget.RecyclerView[@resource-id='dk.resound.smart3d:id/menu_layout']//android.widget.Switch[@resource-id='dk.resound.smart3d:id/menu_item_switch'])[1]");
                else
                    element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeSwitch[`value == '0'`][1]"));
                return element;
            }
        }

        /// <summary>
        ///     This is the Auto-activate favorite locations toggle switch from the more menu
        /// </summary>

        public IWebElement FavoriteLocations_Switch
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "(//androidx.recyclerview.widget.RecyclerView[@resource-id='dk.resound.smart3d:id/menu_layout']//android.widget.Switch[@resource-id='dk.resound.smart3d:id/menu_item_switch'])[2]");
                else
                    element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeSwitch[`value == '1'`]"));
                return element;
            }
        }

        #region NativeControls

        public string AirplaneMode => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "**/XCUIElementTypeSwitch[`name == \"Airplane Mode\"`]",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException()
        };
        
        public string BluetoothSwitch => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "**/XCUIElementTypeSwitch[`label == \"Bluetooth\"`]",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException()
        };
        public IWebElement AppBluetoothSwitch => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => driver.FindElementByXPath("//XCUIElementTypeSwitch[@name=\"Bluetooth\"]/XCUIElementTypeSwitch"),
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException()
        };
        #endregion
    }
}