using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    public class MenuPageBackCloseButton : PageBase
    {
        internal MenuPageBackCloseButton()
        {
        }

        public IWebElement Back => new Buttons().Back;
        public IWebElement Close => new Buttons().Close;
    }
}