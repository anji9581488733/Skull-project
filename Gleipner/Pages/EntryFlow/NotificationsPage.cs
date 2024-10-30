using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.EntryFlow
{
    public class NotificationsPage : PageBase
    {
        //TODO : No model test for this page and controls are created yet
        public IWebElement Skip => new Buttons().NotificationSkip;
        public IWebElement Continue => new Buttons().NotificationContinue;
        public IWebElement AllowButton => new Buttons().NotificationAllow;
    }
}