using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    public class MenuPageCloseButton : PageBase
    {
        internal MenuPageCloseButton()
        {
        }

        public IWebElement Exit => new Buttons().Close;
    }
}