using Gleipner.Base;

using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    public class BottomRibbonBar : PageBase
    {
        public IWebElement Home => new Buttons().BottomRibbonBarHome;
        public IWebElement Status => new Buttons().BottomRibbonBarStatus;
        public IWebElement MyResound => new Buttons().BottomRibbonMyResound;
        public IWebElement More => new Buttons().BottomRibbonBarMore;
    }
}