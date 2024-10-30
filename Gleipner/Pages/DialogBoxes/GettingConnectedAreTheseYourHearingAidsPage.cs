using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    public class GettingConnectedAreTheseYourHearingAidsPage : DialogPage
    {
        public IWebElement Yes => new Buttons().GettingConnectedAreTheseYourHearingAidsYes;
    }
}