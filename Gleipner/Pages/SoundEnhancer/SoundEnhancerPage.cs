using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.SoundEnhancer
{
    /// <summary>
    ///     Class is only used internally in Gleipner. Can not be instantiated externally.
    /// </summary>
    public class SoundEnhancerPage : PageBase
    {
        /// <summary>
        ///     Class is only used for inheritance.
        ///     Secures the intermediate layers of the POM facade from Fenris use through internalizing instantiation.
        /// </summary>
        internal SoundEnhancerPage()
        {
        }

        // Controls common for all variations and pricepoints of Sound Enhancer.
        // Additional controls for toppricepoint: SoundEnhancerPageTopPricePoint.  

        public IWebElement Close => new Buttons().SoundEnhancerClose;
        public IWebElement TinnitusManager => new Buttons().TinnitusManagerSwitch;
        public IWebElement Reset => new Buttons().SoundEnhancerReset;
    }
}