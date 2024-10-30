using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MyResound.LearnAboutTheApp
{
    public class LearnAboutTheAppPage : MenuPageBackButton
    {
        public IWebElement VolumeControl => new Buttons().LearnAboutTheAppVolumeControl;

        public IWebElement Close => new Buttons().Close;
        public IWebElement Exit => new Buttons().CloseButton;
    }
}