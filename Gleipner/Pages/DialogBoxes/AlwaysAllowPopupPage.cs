
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.DialogBoxes
{
    public class AlwaysAllowPopupPage : DialogPage
    {
        public IWebElement AlwaysAllowPopup => new Buttons().AlwaysAllow;
        public IWebElement ChangeAlwayPopup => new Buttons().ChangeAlways;
    }
}