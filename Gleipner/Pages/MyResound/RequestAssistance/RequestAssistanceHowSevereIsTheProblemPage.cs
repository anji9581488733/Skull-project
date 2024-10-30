using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MyResound.RequestAssistance
{
    public class RequestAssistanceHowSevereIsTheProblemPage : MenuPageCloseButton
    {
        public IWebElement Next => new Buttons().RequestAssistanceNext;
    }
}