using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    public class WhatsNewPage : PageBase
    {
        public IWebElement Exit => new Buttons().Close;
    }
}