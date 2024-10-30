using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MyResound.RequestAssistance
{
    public sealed class RequestAssistanceDefineYourProblemPage : MenuPageCloseButton
    {
        public IWebElement Next => new Buttons().RequestAssistanceNext;
    }
}