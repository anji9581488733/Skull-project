using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MyResound.RateMySound
{
    public class RateMySoundElaboratePage : PageBase
    {
        public IWebElement NoThanks => new Buttons().DialogConsentNoThanks;
    }
}