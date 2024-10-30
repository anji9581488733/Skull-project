using System;
using OpenQA.Selenium;
using Polaris.Base;

namespace Gleipner.Controls.Slider
{
    public class HorizontalSliders : HorizontalSlider
    {
        /// <summary>
        ///     Right side volume slider dot of all program cards (Top slider)
        ///     Also works on Tinnitus Manager volume.
        /// </summary>


        public IWebElement VolumeRight
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "//android.view.ViewGroup[@resource-id='dk.resound.smart3d:id/seekBar_top']/child::*[@resource-id='dk.resound.smart3d:id/volume_thumb_outercircle']");
                else
                    throw new NotImplementedException();
                return element;
            }
        }

        /// <summary>
        ///     Right side volume slider of all program cards (Top slider)
        ///     Also works on Tinnitus Manager volume.
        /// </summary>


        public IWebElement VolumeRightSliderLine
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "//android.view.ViewGroup[@resource-id='dk.resound.smart3d:id/seekBar_top']/child::*[@class='android.view.View']");
                else
                    throw new NotImplementedException();
                return element;
            }
        }


        /// <summary>
        ///     Left side volume slider dot of all program cards (Bottom slider)
        ///     Also works on Tinnitus Manager volume.
        /// </summary>


        public IWebElement VolumeLeft
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "//android.view.ViewGroup[@resource-id='dk.resound.smart3d:id/seekBar_bottom']/child::*[@resource-id='dk.resound.smart3d:id/volume_thumb_outercircle']");
                else
                    throw new NotImplementedException();
                return element;
            }
        }

        /// <summary>
        ///     Left side volume slider line of all program cards (Bottom slider)
        ///     Also works on Tinnitus Manager volume.
        /// </summary>


        public IWebElement VolumeLeftSliderLine
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "//android.view.ViewGroup[@resource-id='dk.resound.smart3d:id/seekBar_bottom']/child::*[@class='android.view.View']");
                else
                    throw new NotImplementedException();
                return element;
            }
        }
    }
}