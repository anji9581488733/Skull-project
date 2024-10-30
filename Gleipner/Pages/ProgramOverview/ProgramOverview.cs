using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.ProgramOverview
{
    public class ProgramOverview : MenuPageCloseButton
    {
        internal ProgramOverview()
        {
        }

        public IWebElement CloseButton => new Buttons().Close;
        public IWebElement AllAround => new Buttons().ProgramOverviewAllAround;
        public IWebElement HearInNoise => new Buttons().ProgramOverviewHearInNoise;
        public IWebElement Outdoor => new Buttons().ProgramOverviewOutdoor;
        public IWebElement Music => new Buttons().ProgramOverviewMusic;


        public void ProgramOverviewCard(string Menu)
        {
            switch (Menu.ToUpper())
            {
                case "ALL-AROUND":
                    ClickOnElement(AllAround);
                    break;

                case "HEAR IN NOISE":
                    ClickOnElement(HearInNoise);
                    break;
                case "OUTDOOR":
                    ClickOnElement(Outdoor);
                    break;

                case "MUSIC":
                    ClickOnElement(Music);
                    break;
            }
        }
    }
}