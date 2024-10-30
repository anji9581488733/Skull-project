using Gleipner.Base;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    public class MenuPage : PageBase
    {
        internal MenuPage()
        {
        }

        public IWebElement Title => new Texts().AboutMenuTitle;
        public IWebElement ManufacturingTitle => new Texts().ManufacturingTitle;
        public IWebElement TermsAndConditionsTitle => new Texts().TermsAndConditionsTitle;
        public IWebElement PrivacyPolicyTitle => new Texts().PrivacyPolicyTitle;
        public IWebElement SupportTitle => new Texts().SupportTitle;
    }
}