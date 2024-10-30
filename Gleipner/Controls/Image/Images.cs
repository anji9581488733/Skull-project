using System;
using Gleipner.Namespaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using Polaris.Base;

namespace Gleipner.Controls.Image
{
    internal class Images : Image
    {
        #region My requests and new settings

        /// <summary>
        ///     I accept terms and conditions checkbox on terms and conditions page.
        /// </summary>

        public IWebElement TermsAndConditionsAcceptCheckBox
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.widget.TextView[@text='I accept the Terms and Conditions']/preceding-sibling::*[@class='android.widget.ImageView']");
                else
                    element = driver.FindElement(MobileBy.IosNSPredicate("type == 'XCUIElementTypeImage'"));
                return element;
            }
        }

        #endregion HearingAidSoftwareUpdates

        #region NativeSettings

        /// <summary>
        ///     Selector for In progress image.
        /// </summary>
        public string InProgress => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "In progress",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        #endregion

        #region Componenttest

        /// <summary>
        ///    Activity indicator for Component tests.
        /// </summary>
        public string ActivityIndicator => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => 
                $"{NAPNamespaces.ComponentTestNamespace}.StartPage.ActivityIndicator1",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.ComponentTestNamespace}.StartPage.ActivityIndicator1",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Activity indicator for Component tests.
        /// </summary>
        public string NotificationAlert => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "XCUIElementTypeAlert",
            SettingsBase.PlatformType.Android => "com.android.permissioncontroller:id/permission_allow_button",
                _ => throw new NotImplementedException(),
        };
        #endregion
    }
}