using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.DialogBoxes
{
    public class LocationAccessPage : DialogPage
    {
        public IWebElement AllowPopup => new Buttons().AllowLocationAccess;
        public IWebElement AllowDialog => new Buttons().AllowDeviceLocation;
    }
}