using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages
{
    public class MenuPageBackButton : MenuPage
    {
        internal MenuPageBackButton()
        {
        }

        public IWebElement Back => new Buttons().Back;
        public IWebElement BackAbout => new Buttons().BackButton;
    }
}