using Gleipner.Controls;
using Gleipner.Controls.Button;
using Gleipner.Controls.Slider;
using Gleipner.Controls.Text;
using OpenQA.Selenium;
using Polaris.Base;

namespace Gleipner.Pages.Cards.TopPricePoint
{
    /// <summary>
    ///     Class is only used internally in Gleipner. Can not be instantiated externally.
    /// </summary>
    public class Card : PageBase
    {
        internal Card()
        {
        }
        
        public int SurroundingsVolumeRight => new Texts().CardSurroundingsVolumeRight;
        public IWebElement VolumeLeftSliderDot => new HorizontalSliders().VolumeLeft;
        public IWebElement VolumeLeftSlider => new HorizontalSliders().VolumeLeftSliderLine;
        public IWebElement VolumeRightSlider => new HorizontalSliders().VolumeRightSliderLine;
        public IWebElement VolumeRightSliderDot => new HorizontalSliders().VolumeRight;
        public IWebElement SplitVolumeBarsHearingAids => new Buttons().SplitVolumeBarsHearingAids;
        public IWebElement MergeVolumeBarsHearingAids => new Buttons().SplitVolumeBarsHearingAids;
        public IWebElement SoundEnhancer => new Buttons().SoundEnhancer;
    }
}