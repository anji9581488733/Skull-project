using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MyResoundPage.LearnAboutTheApp
{
    public class LearnAboutTheAppBasePage : MenuPageCloseButton
    {
        /*
         * Internalizing LearnAboutTheAppBasePage suspended to simplify navigation.
           internal LearnAboutTheAppBasePage()
           { }
         */


        public IWebElement Next => new Buttons().LearnAboutTheAppNextButton;
        public IWebElement Back => new Buttons().Back;
    }
}