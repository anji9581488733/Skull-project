using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MyResound.MyRequestsAndNewSettings
{
    public class FailedRequestPage : PageBase
    {
        public IWebElement Back => new Buttons().Back;
    }
}