
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.DialogBoxes
{
    public class PleaseNoticePage
    {
        public IWebElement OK => new Buttons().PleaseNoticeDialogOK;
    }
}