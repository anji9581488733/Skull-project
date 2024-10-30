using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using Gleipner.Controls.Slider;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    /// <summary>
    ///     Class is only used internally in Gleipner. Can not be instantiated externally.
    /// </summary>
    public class TinnitusManagerBase : PageBase
    {
        /// <summary>
        ///     Class is only used for inheritance.
        ///     Secures the intermediate layers of the POM facade from Fenris use through internalizing instantiation.
        /// </summary>
        internal TinnitusManagerBase()
        {
        }

        public IWebElement Close => new Buttons().SoundEnhancerClose;
        public IWebElement Reset => new Buttons().SoundEnhancerReset;
        public IWebElement VolumeLeftSlider => new HorizontalSliders().VolumeLeftSliderLine;
        public IWebElement VolumeLeftSliderDot => new HorizontalSliders().VolumeLeft;
        public IWebElement VolumeRightSlider => new HorizontalSliders().VolumeRightSliderLine;
        public IWebElement VolumeRightSliderDot => new HorizontalSliders().VolumeRight;
    }
}