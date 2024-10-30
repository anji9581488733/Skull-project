using Gleipner.Base;
using Gleipner.Controls.Dialog;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    public class DialogPage : PageBase
    {
        public IWebElement DialogFrame => new Dialogs().DialogFrame;
        public IWebElement Title => new Dialogs().Title;
    }
}