using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.TinnitusManager.TopPricePoint
{
    /*
     * Current understanding of what will be differentiated controls available in the top price point.
     * It may be that middle and top price points will share some information, but the recommendation
     * is to abstain from the overkill of creating this crossbreed.
     */

    /// <summary>
    ///     Class is only used internally in Gleipner. Can not be instantiated externally.
    /// </summary>
    public class TinnitusManagerPageTopPricePoint : TinnitusManagerBase
    {
        /// <summary>
        ///     Class is only used for inheritance.
        ///     Secures the intermediate layers of the POM facade from Fenris use through internalizing instantiation.
        /// </summary>
        internal TinnitusManagerPageTopPricePoint()
        {
        }


        public IWebElement WhiteNoiseSlightVariation => new Buttons().TSGAmplitudeSlightVariation;

        public IWebElement NatureCalmingWaves => new Buttons().CalmingWaves;

        public IWebElement NatureBreakingWaves => new Buttons().BreakingWaves;
    }
}