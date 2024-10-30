using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    public class PricePointPage : PageBase
    {
        public IWebElement Ok => new Buttons().PricePointDialogOk;
    }
}