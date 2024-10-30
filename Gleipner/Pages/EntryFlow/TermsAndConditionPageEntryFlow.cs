using Gleipner.Controls;
using Gleipner.Controls.Button;
using Gleipner.Controls.Image;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.EntryFlow
{
    public class TermsAndConditionPageEntryFlow : MenuPageBackButton
    {
        public new IWebElement Back => new Buttons().Back;
        public IWebElement ScrollToBottom => new Buttons().ScrollToBottomButton;
        public IWebElement Continue => new Buttons().TermsAndConditionsContinueButton;

        public new IWebElement Title => new Texts().MenuTitle;

        public IWebElement AcceptCheckBox => new Images().TermsAndConditionsAcceptCheckBox;
    }
}