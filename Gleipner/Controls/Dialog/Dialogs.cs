using System;
using OpenQA.Selenium;
using Polaris.Base;

namespace Gleipner.Controls.Dialog
{
    internal class Dialogs : Dialog
    {
        /// <summary>
        ///     Dialog title on all custom dialogs
        /// </summary>


        public IWebElement Title
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("dk.resound.smart3d:id/custom_dialog_title");
                else
                    throw new NotImplementedException();
                return element;
            }
        }


        /// <summary>
        ///     Dialog frame on all custom dialogs
        /// </summary>


        public IWebElement DialogFrame
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.widget.FrameLayout[@resource-id='android:id/content']");
                else
                    throw new NotImplementedException();
                return element;
            }
        }
    }
}