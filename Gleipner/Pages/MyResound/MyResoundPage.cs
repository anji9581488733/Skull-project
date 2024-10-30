using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MyResound
{
    public class MyResoundPage : PageBase
    {
        public IWebElement LearnAboutApp => new Buttons().LearnAboutApp;
        public IWebElement GuidingTips => new Buttons().GuidingTips;
    }
}