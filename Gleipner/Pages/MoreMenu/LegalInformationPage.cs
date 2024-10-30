using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MoreMenu
{
    public class LegalInformationPage : MenuPageBackButton
    {
        public IWebElement Manufacturer => new Buttons().Manufacturer;
        public IWebElement Terms_and_conditions => new Buttons().TermsAndConditions;
        public IWebElement Privacypolicy => new Buttons().PrivacyPolicy;
    }
}