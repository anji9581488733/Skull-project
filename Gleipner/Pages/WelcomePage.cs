using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    public class WelcomePage : PageBase
    {
        public IWebElement ConnectNow => new Buttons().ConnectNow;
        public IWebElement Welcome => new Texts().Welcome;
    }
}