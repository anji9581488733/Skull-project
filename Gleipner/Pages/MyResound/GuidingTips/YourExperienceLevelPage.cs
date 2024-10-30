using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MyResound.GuidingTips
{
    public class YourExperienceLevelPage : MenuPageCloseButton
    {
        public IWebElement GoButton => new Buttons().GoButton;

        public IWebElement QuiteExperienced => new Buttons().QuiteExperiencedButton;
    }
}