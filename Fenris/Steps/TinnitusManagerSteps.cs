using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.TinnitusManager;
using Gleipner.Pages.TinnitusManager.TopPricePoint;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public class TinnitusManagerSteps : StepsBase
    {
        

        [When(@"I press 'Reset' button on All-Around Tinnitus Manager")]
        public void WhenIPressResetButtonOnAllAroundTinnitusManager()
        {
            try
            {
                var allAroundTinnitusManagerPage = new AllAroundTinnitusManagerPage();
                ClickOnElement(allAroundTinnitusManagerPage.Reset);
                Reporting.Log("Pass", "Pressed Reset Button on All-Around Tinnitus Manager");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "[ERROR] in WhenIPressResetButtonOnAllAroundTinnitusManager function : " + e.Message);

                throw;
            }
        }


        [When(@"I press 'Reset' button on Hear in Noise Tinnitus Manager")]
        public void WhenIPressResetButtonOnHearInNoiseTinnitusManager()
        {
            try
            {
                var hearInNoiseTinnitusManagerPage = new HearInNoiseTinnitusManagerPage();
                ClickOnElement(hearInNoiseTinnitusManagerPage.Reset);
                Reporting.Log("Pass", "Pressed Reset Button on Hear in noise Tinnitus Manager");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "[ERROR] in WhenIPressResetButtonOnHearInNoiseTinnitusManager function : " + e.Message);

                throw;
            }
        }


        [When(@"I press white noise button '(.*)' on '(.*)' Tinnitus Manager")]
        public void WhenIPressWhiteNoiseOnTinnitusManager(string button, string program)
        {
            try
            {
                switch (program)
                {
                    case "All-Around":
                    {
                        var allAroundTinnitusManagerPage = new AllAroundTinnitusManagerPage();

                        if (button == "Slight variation")
                        {
                            ClickOnElement(allAroundTinnitusManagerPage.WhiteNoiseSlightVariation);

                            break;
                        }

                        throw new ArgumentException("Unknown button input: " + button);
                    }

                    case "Hear in Noise":
                    {
                        var hearInNoiseTinnitusManagerPage = new HearInNoiseTinnitusManagerPage();

                        if (button == "Slight variation")
                        {
                            TapBycoordinates(154, 508);
                            //ClickOnElement(hearInNoiseTinnitusManagerPage.WhiteNoiseSlightVariation);
                            break;
                        }

                        throw new ArgumentException("Unknown button input: " + button);
                    }

                    default:
                        throw new ArgumentException("Unknown program input: " + program);
                }

                Reporting.Log("Pass", "Pressed White noise Button " + button + " on " + program + " Tinnitus Manager");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] in WhenIPressWhiteNoiseOnTinnitusManager function : " + e.Message);
                throw;
            }
        }


        [When(@"I press Nature sounds button '(.*)' on '(.*)' Tinnitus Manager")]
        public void WhenIPressNatureSoundsOnTinnitusManager(string button, string program)
        {
            try
            {
                switch (program)
                {
                    case "All-Around":
                    {
                        var allAroundTinnitusManagerPage = new AllAroundTinnitusManagerPage();

                        if (button == "Calming Waves")
                        {
                            ClickOnElement(allAroundTinnitusManagerPage.NatureCalmingWaves);
                            break;
                        }

                        if (button == "Breaking Waves")
                        {
                            ClickOnElement(allAroundTinnitusManagerPage.NatureBreakingWaves);
                            break;
                        }

                        throw new ArgumentException("Unknown button input: " + button);
                    }

                    case "Hear in noise":
                    {
                        var hearInNoiseTinnitusManagerPage = new HearInNoiseTinnitusManagerPage();

                        if (button == "Calming Waves")
                        {
                            ClickOnElement(hearInNoiseTinnitusManagerPage.NatureCalmingWaves);
                            break;
                        }

                        if (button == "Breaking Waves")
                        {
                            ClickOnElement(hearInNoiseTinnitusManagerPage.NatureBreakingWaves);
                            break;
                        }

                        throw new ArgumentException("Unknown button input: " + button);
                    }

                    default:
                        throw new ArgumentException("Unknown program input: " + program);
                }

                Reporting.Log("Pass",
                    "Pressed Nature sounds Button " + button + " on " + program + " Tinnitus Manager.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] in WhenIPressNatureSoundsOnTinnitusManager function : " + e.Message);
                throw;
            }
        }


        [Then(@"validate 'Reset' button is 'Disabled' in '(.*)' Tinnitus Manager page")]
        public void ThenValidateResetButtonIsDisabledInTinnitusManagerPage(string card)
        {
            try
            {
                switch (card)
                {
                    case "All-Around":
                        var allAroundTinnitisManagerPage = new AllAroundTinnitusManagerPage();
                        Assert.IsFalse(allAroundTinnitisManagerPage.Reset.Enabled);
                        break;

                    case "Hear in noise":
                        var hearInNoiseTinnitusManagerPage = new HearInNoiseTinnitusManagerPage();
                        Assert.IsFalse(hearInNoiseTinnitusManagerPage.Reset.Enabled);
                        break;

                    default:
                        throw new ArgumentException("Unknown Card input: " + card);
                }


                Reporting.Log("Pass", "Reset Button is Disabled on " + card + " Tinnitus Manager page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Reset Button is not Disabled on " + card + " Tinnitus Manager page : " + e.Message);

                throw;
            }
        }


        [Then(@"validate 'Reset' button is 'Enabled' in '(.*)' Tinnitus Manager page")]
        public void ThenValidateResetButtonIsEnabledInTinnitusManagerPage(string card)
        {
            try
            {
                switch (card)
                {
                    case "All-Around":
                        var allAroundTinnitisManagerPage = new AllAroundTinnitusManagerPage();
                        Assert.IsTrue(allAroundTinnitisManagerPage.Reset.Enabled);
                        break;

                    case "Hear in noise":
                        var hearInNoiseTinnitusManagerPage = new HearInNoiseTinnitusManagerPage();
                        Assert.IsTrue(hearInNoiseTinnitusManagerPage.Reset.Enabled);
                        break;

                    default:
                        throw new ArgumentException("Unknown Card input: " + card);
                }


                Reporting.Log("Pass", "Reset Button is Enabled on " + card + " Tinnitus Manager page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Reset Button is not Enabled on " + card + " Tinnitus Manager page : " + e.Message);

                throw;
            }
        }

    }
}