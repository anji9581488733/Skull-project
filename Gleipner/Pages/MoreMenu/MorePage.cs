using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using Gleipner.Controls.Switch;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.MoreMenu

{
    public class MorePage : PageBase
    {
        public IWebElement Title => new Texts().MenuTitle;
        public IWebElement About => new Buttons().About;
        public IWebElement LegalInformation => new Buttons().Legal_information;
        public IWebElement Support => new Buttons().Support;
        public IWebElement GuidingTips => new Switches().GuidingTips_Switch;
        public IWebElement GuidingTipsSwitch => new Switches().GuidingTips_Switch_Off;
        public IWebElement AutoActivateLocation => new Switches().FavoriteLocations_Switch;
    }
}