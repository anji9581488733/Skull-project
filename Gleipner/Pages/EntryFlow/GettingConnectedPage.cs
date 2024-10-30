using Gleipner.Controls;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.EntryFlow
{
    public class GettingConnectedPage : MenuPageCloseButton
    {
        public IWebElement Allow => new Buttons().Allow;
        public IWebElement OK => new Buttons().SecuredPairingOK;
        public IWebElement WellDoneStart => new Buttons().WellDoneStart;
        public IWebElement Continue => new Buttons().Continue;
        public IWebElement HIReplaceableBatteries => new Buttons().HIReplaceableBatteries;
        public IWebElement ConnectingTitle => new Texts().ConnectedTitle;
    }
}