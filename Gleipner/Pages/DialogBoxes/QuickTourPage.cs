using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    public class QuickTourPage : PageBase
    {
        public IWebElement NoThanks => new Buttons().DialogConsentNoThanks;
    }
}