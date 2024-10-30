using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MyResound.GuidingTips
{
    public class ThanksForTurningGuidingTipsOnPage : MenuPageCloseButton
    {
        public IWebElement NextButton => new Buttons().RequestAssistanceNext;
        public IWebElement StartFromTheBeginning => new Buttons().StartFromBeginningButton;
        public IWebElement GoButton => new Buttons().GoButton;
    }
}