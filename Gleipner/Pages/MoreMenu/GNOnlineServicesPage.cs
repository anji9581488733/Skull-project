using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MoreMenu
{
    public class GNOnlineServicesPage : MenuPageBackButton
    {
        public IWebElement Close => new Buttons().CloseButtonGN;
        public IWebElement Start => new Buttons().Start;
    }
}