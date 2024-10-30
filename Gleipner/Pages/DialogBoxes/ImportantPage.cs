using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.DialogBoxes
{
    public class ImportantPage : PageBase
    {
        public IWebElement Ok => new Buttons().PricePointDialogOk;
    }
}