using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;
using Polaris.Base;

namespace Gleipner.Pages
{
    public class TopRibbonBar : PageBase

    {
        public IWebElement ProgramOveview => new Buttons().ProgramOverview;
        public IWebElement SoundEnhancer => new Buttons().SoundEnhancer;

        public IWebElement AllAround => new Buttons().AllAround;
        public IWebElement HearInNoise => new Buttons().HearInNoise;
        public IWebElement Outdoor => new Buttons().Outdoor;
        public IWebElement Music => new Buttons().Music;


        public IWebElement AllAroundTopRibbonBar => new Buttons().AllAroundTop;
        public IWebElement HearInNoiseTopRibbonBar => new Buttons().HearInNoiseTop;
        public IWebElement OutdoorTopRibbonBar => new Buttons().OutdoorTop;
        public IWebElement MusicTopRibbonBar => new Buttons().MusicTop;


        /// <summary>
        ///     Swipes down program overview until it reaches the sound enhancer button
        /// </summary>

        //public void SwipeDownProgramOverview()
        //{
        //    ApplicationContext.DragCoordinates(ProgramOveview.Rect.CenterX, ProgramOveview.Rect.CenterY, ProgramOveview.Rect.CenterX, SoundEnhancer.Rect.CenterY);
        //}
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

        /// <summary>
        ///     Selects the top ribbon program.
        /// </summary>
        /// <param name="Menu">The program to change to</param>
        /// This function has been moved to Program overview. and corrected in the step.
        /// Please remove this function when it has been tested proberly with iOS and Android that is not used anymore.
        public void SelectTopRibbonProgram(string Menu)
        {
            switch (Menu.ToUpper())
            {
                case "ALL-AROUND":
                    if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                        ClickOnElement(AllAroundTopRibbonBar);
                    else
                        TapBycoordinates(43, 84);

                    break;

                case "HEAR IN NOISE":
                    if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                        ClickOnElement(HearInNoiseTopRibbonBar);
                    else
                        TapBycoordinates(133, 79);
                    break;
                case "OUTDOOR":
                    if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                        ClickOnElement(OutdoorTopRibbonBar);
                    else
                        TapBycoordinates(210, 83);

                    break;

                case "MUSIC":
                    if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                        ClickOnElement(MusicTopRibbonBar);
                    else
                        TapBycoordinates(313, 81);
                    break;
            }
        }
    }
}