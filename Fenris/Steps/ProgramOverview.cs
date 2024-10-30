using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.ProgramOverview;
using NUnit.Framework;
using Polaris.Base;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public class ProgramOverview : StepsBase
    {
       

        [Then(@"validate '(.*)' button is displayed on Program overview page")]
        public void ThenValidateButtonIsDisplayedOnProgramOverviewPage(string Button)
        {
            try
            {
                var programOverviewPage = new ProgramOverviewPage();
                switch (Button)
                {
                    case "Close":
                        Assert.IsTrue(IsElementDisplayed(programOverviewPage.CloseButton));
                        break;


                    default:
                        throw new ArgumentException("Unknown Button: " + Button);
                }

                Reporting.Log("Pass", Button + " is displayed on Program overview page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", Button + " is not displayed on Program overview page: " + e.Message);
                throw;
            }
        }

       

      
        [When(@"I press '(.*)' program on Program overview")]
        public void WhenIPressProgramOnProgramOverview(string cardName)
        {
            var programOverviewPage = new ProgramOverviewPage();

            try
            {
                switch (cardName)
                {
                    case "All-Around":
                        if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                        {
                            ClickOnElement(programOverviewPage.AllAround);
                        }
                        else
                            // TODO : This method is only tested for iPhone12 resolution
                        {
                            TapBycoordinates(56, 160);
                        }

                        break;

                    case "Hear in Noise":
                        if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                        {
                            ClickOnElement(programOverviewPage.HearInNoise);
                        }
                        else
                            // TODO : This method is only tested for iPhone12 resolution
                        {
                            TapBycoordinates(149, 161);
                        }

                        break;

                    case "Outdoor":
                        if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                        {
                            ClickOnElement(programOverviewPage.Outdoor);
                        }
                        else
                            // TODO : This method is only tested for iPhone12 resolution
                        {
                            TapBycoordinates(236, 161);
                        }

                        break;

                    case "Music":
                        if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                        {
                            ClickOnElement(programOverviewPage.Music);
                        }
                        else
                            // TODO : This method is only tested for iPhone12 resolution
                        {
                            TapBycoordinates(336, 164);
                        }

                        break;


                    default:
                        throw new ArgumentException("Unknown program name: " + cardName);
                }

                Reporting.Log("Pass", "Program " + cardName + " is pressed on on Program overview");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Failed to press program " + cardName + " on Program overview: " + e.Message);
                throw;
            }
        }


        [When(@"I press the '(.*)' button on Program overview")]
        public void WhenIPressTheButtonOnTheProgramOverview(string button)
        {
            try
            {
                var programOverviewPage = new ProgramOverviewPage();

                switch (button)
                {
                    case "Close":

                        ClickOnElement(programOverviewPage.Exit);


                        break;


                    default:
                        throw new ArgumentException("Unsupported button (" + button + ") press requested");
                }

                Reporting.Log("Pass", button + " button is pressed on the program overview");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Failed to press the " + button + " button on the program overview: " + e.Message);
                throw;
            }
        }

     
    }
}