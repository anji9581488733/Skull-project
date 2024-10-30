using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.MyResound.GuidingTips
{
    public class GuidingTipsPage : PageBase
    {
        public IWebElement Title => new Texts().MenuTitle;

        public IWebElement Back => new Buttons().Back;

        // Programs

        public IWebElement MusicProgram => new Buttons().NudgingFunctionalTip1Week3Header;

        // Quick Buttons

        public IWebElement NoiseFilter => new Buttons().NudgingFunctionalTip1Week5Header;
    }
}