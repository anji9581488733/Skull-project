using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.SoundEnhancer;
using Gleipner.Pages.SoundEnhancer.TopPricePoint;
using NUnit.Framework;
using Polaris.Base;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public class SoundEnhancerSteps : StepsBase
    {
        [Then(@"validate Tinnitus Manager button is displayed on '(.*)' Sound Enhancer page")]
        public void ThenValidateTinnitusManagerButtonIsDisplayedOnSoundEnhancer(string card)
        {
            try
            {
                switch (card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage = new AllAroundSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(allAroundSoundEnhancerPage.TinnitusManager));
                        break;

                    case "Hear in noise":
                        var hearInNoiseSoundEnhancerPage = new HearInNoiseSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(hearInNoiseSoundEnhancerPage.TinnitusManager));
                        break;

                    case "Outdoor":
                        var outdoorSoundEnhancerPage = new OutdoorSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(outdoorSoundEnhancerPage.TinnitusManager));
                        break;

                    case "Music":
                        var musicSoundEnhancerPage = new MusicSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(musicSoundEnhancerPage.TinnitusManager));
                        break;

                    case "TV1":
                        var tv1SoundEnhancerPage = new TV1SoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(tv1SoundEnhancerPage.TinnitusManager));
                        break;

                    case "TV2":
                        var tv2SoundEnhancerPage = new TV2SoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(tv2SoundEnhancerPage.TinnitusManager));
                        break;

                    case "Mic":
                        var micSoundEnhancerPage = new MicSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(micSoundEnhancerPage.TinnitusManager));
                        break;

                    default:
                        throw new ArgumentException("Unknown program: '" + card + "'");
                }

                Reporting.Log("Pass", "Tinnitus Manager button is displayed on " + card + " Sound Enhancer page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Tinnitus Manager button is not displayed on " + card + " Sound Enhancer page : " + e.Message);

                throw;
            }
        }


        [When(@"I press Reset button on '(.*)' Sound Enhancer page")]
        public void WhenIPressResetButtonOnSoundEnhancerPage(string card)
        {
            try
            {
                switch (card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage = new AllAroundSoundEnhancerPage();
                        ClickOnElement(allAroundSoundEnhancerPage.Reset);
                        break;

                    case "Hear in noise":
                        var hearInNoiseSoundEnhancerPage = new HearInNoiseSoundEnhancerPage();
                        ClickOnElement(hearInNoiseSoundEnhancerPage.Reset);
                        break;

                    case "Outdoor":
                        var outdoorSoundEnhancerPage = new OutdoorSoundEnhancerPage();
                        ClickOnElement(outdoorSoundEnhancerPage.Reset);
                        break;

                    case "Music":
                        var musicSoundEnhancerPage = new MusicSoundEnhancerPage();
                        ClickOnElement(musicSoundEnhancerPage.Reset);
                        break;

                    case "TV1":
                        var tv1SoundEnhancerPage = new TV1SoundEnhancerPage();
                        ClickOnElement(tv1SoundEnhancerPage.Reset);
                        break;

                    case "TV2":
                        var tv2SoundEnhancerPage = new TV2SoundEnhancerPage();
                        ClickOnElement(tv2SoundEnhancerPage.Reset);
                        break;

                    case "Mic":
                        var micSoundEnhancerPage = new MicSoundEnhancerPage();
                        ClickOnElement(micSoundEnhancerPage.Reset);
                        break;

                    default:
                        throw new ArgumentException("Unknown program: '" + card + "'");
                }

                Reporting.Log("Pass", "Pressed Reset button on " + card + " Sound Enhancer page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Failed to press Reset button on " + card + " Sound Enhancer page : " + e.Message);
                throw;
            }
        }


        [Then(@"validate Reset button is displayed on '(.*)' Sound Enhancer page")]
        public void ThenValidateResetButtonIsDisplayedOnSoundEnhancer(string card)
        {
            try
            {
                switch (card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage = new AllAroundSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(allAroundSoundEnhancerPage.Reset));
                        break;

                    case "Hear in noise":
                        var hearInNoiseSoundEnhancerPage = new HearInNoiseSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(hearInNoiseSoundEnhancerPage.Reset));
                        break;

                    case "Outdoor":
                        var outdoorSoundEnhancerPage = new OutdoorSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(outdoorSoundEnhancerPage.Reset));
                        break;

                    case "Music":
                        var musicSoundEnhancerPage = new MusicSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(musicSoundEnhancerPage.Reset));
                        break;

                    case "TV1":
                        var tv1SoundEnhancerPage = new TV1SoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(tv1SoundEnhancerPage.Reset));
                        break;

                    case "TV2":
                        var tv2SoundEnhancerPage = new TV2SoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(tv2SoundEnhancerPage.Reset));
                        break;

                    case "Mic":
                        var micSoundEnhancerPage = new MicSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(micSoundEnhancerPage.Reset));
                        break;

                    default:
                        throw new ArgumentException("Unknown program: '" + card + "'");
                }

                Reporting.Log("Pass", "Reset button is displayed on " + card + " Sound Enhancer page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Reset button is not displayed on " + card + " Sound Enhancer page : " + e.Message);

                throw;
            }
        }


        [Then(@"validate 'Reset' button is 'Disabled' in '(.*)' Sound Enhancer page")]
        public void ThenValidateButtonIsdisabledInSoundEnhancer(string card)
        {
            try
            {
                switch (card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage = new AllAroundSoundEnhancerPage();
                        Assert.IsFalse(allAroundSoundEnhancerPage.Reset.Enabled);
                        break;

                    case "Hear in noise":
                        var hearInNoiseSoundEnhancerPage = new HearInNoiseSoundEnhancerPage();
                        Assert.IsFalse(hearInNoiseSoundEnhancerPage.Reset.Enabled);
                        break;

                    case "Outdoor":
                        var outdoorSoundEnhancerPage = new OutdoorSoundEnhancerPage();
                        Assert.IsFalse(outdoorSoundEnhancerPage.Reset.Enabled);
                        break;

                    case "Music":
                        var musicSoundEnhancerPage = new MusicSoundEnhancerPage();
                        Assert.IsFalse(musicSoundEnhancerPage.Reset.Enabled);
                        break;

                    case "TV1":
                        var tv1SoundEnhancerPage = new TV1SoundEnhancerPage();
                        Assert.IsFalse(tv1SoundEnhancerPage.Reset.Enabled);
                        break;

                    case "TV2":
                        var tv2SoundEnhancerPage = new TV2SoundEnhancerPage();
                        Assert.IsFalse(tv2SoundEnhancerPage.Reset.Enabled);
                        break;

                    case "Mic":
                        var micSoundEnhancerPage = new MicSoundEnhancerPage();
                        Assert.IsFalse(micSoundEnhancerPage.Reset.Enabled);

                        break;

                    default:
                        throw new ArgumentException("Unknown program: '" + card + "'");
                }

                Reporting.Log("Pass", "Pressed Reset Button on " + card + " Sound Enhancer");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Failed to Press Reset Button On " + card + " Sound Enhancer page : " + e.Message);

                throw;
            }
        }


        [Then(@"validate 'Reset' button is 'Enabled' in '(.*)' Sound Enhancer page")]
        public void ThenValidateButtonIsEnabledInSoundEnhancer(string card)
        {
            try
            {
                switch (card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage = new AllAroundSoundEnhancerPage();
                        Assert.IsTrue(allAroundSoundEnhancerPage.Reset.Enabled);
                        break;

                    case "Hear in noise":
                        var hearInNoiseSoundEnhancerPage = new HearInNoiseSoundEnhancerPage();
                        Assert.IsTrue(hearInNoiseSoundEnhancerPage.Reset.Enabled);
                        break;

                    case "Outdoor":
                        var outdoorSoundEnhancerPage = new OutdoorSoundEnhancerPage();
                        Assert.IsTrue(outdoorSoundEnhancerPage.Reset.Enabled);
                        break;

                    case "Music":
                        var musicSoundEnhancerPage = new MusicSoundEnhancerPage();
                        Assert.IsTrue(musicSoundEnhancerPage.Reset.Enabled);
                        break;

                    case "TV1":
                        var tv1SoundEnhancerPage = new TV1SoundEnhancerPage();
                        Assert.IsTrue(tv1SoundEnhancerPage.Reset.Enabled);
                        break;

                    case "TV2":
                        var tv2SoundEnhancerPage = new TV2SoundEnhancerPage();
                        Assert.IsTrue(tv2SoundEnhancerPage.Reset.Enabled);
                        break;

                    case "Mic":
                        var micSoundEnhancerPage = new MicSoundEnhancerPage();
                        Assert.IsTrue(micSoundEnhancerPage.Reset.Enabled);
                        break;

                    default:
                        throw new ArgumentException("Unknown program: '" + card + "'");
                }

                Reporting.Log("Pass", "Pressed Reset Button on " + card + " Sound Enhancer");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Failed to Press Reset Button On " + card + " Sound Enhancer page : " + e.Message);

                throw;
            }
        }


        [When(@"I press the exit button on 'Favorite 1' Sound Enhancer page based on '(.*)'")]
        public void WhenIPressTheExitButtonOnSoundEnhancerPageBasedOn(string Card)
        {
            try
            {
                switch (Card)
                {
                    case "All-Around":
                        var FavoriteAllAroundSoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.AllAroundSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(FavoriteAllAroundSoundEnhancerPage.Close));
                        ClickOnElement(FavoriteAllAroundSoundEnhancerPage.Close);
                        break;

                    case "Hear in noise":
                        var FavoriteHearInNoiseSoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.HearInNoiseSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(FavoriteHearInNoiseSoundEnhancerPage.Close));
                        ClickOnElement(FavoriteHearInNoiseSoundEnhancerPage.Close);
                        break;

                    case "Outdoor":
                        var FavoriteOutdoorSoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.OutdoorSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(FavoriteOutdoorSoundEnhancerPage.Close));
                        ClickOnElement(FavoriteOutdoorSoundEnhancerPage.Close);
                        break;

                    case "Music":
                        var FavoriteMusicSoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.MusicSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(FavoriteMusicSoundEnhancerPage.Close));
                        ClickOnElement(FavoriteMusicSoundEnhancerPage.Close);
                        break;

                    case "TV1":
                        var FavoriteTv1SoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.TV1SoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(FavoriteTv1SoundEnhancerPage.Close));
                        ClickOnElement(FavoriteTv1SoundEnhancerPage.Close);
                        break;

                    case "TV2":
                        var FavoriteTv2SoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.TV2SoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(FavoriteTv2SoundEnhancerPage.Close));
                        ClickOnElement(FavoriteTv2SoundEnhancerPage.Close);
                        break;

                    case "Mic":
                        var FavoriteMicSoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.MicSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(FavoriteMicSoundEnhancerPage.Close));
                        ClickOnElement(FavoriteMicSoundEnhancerPage.Close);
                        break;

                    default:
                        throw new ArgumentException("Unknown card: '" + Card + "'");
                }

                Reporting.Log("Pass", "Favorite 1 based on " + Card + " Sound Enhancer exit button pressed");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Failed to press Sound Enhancer exit button on Favorite based on" + Card + ": " + e.Message);
                throw;
            }
        }


        [When(@"I press the exit button on '(.*)' Sound Enhancer")]
        public void WhenIPressExitOnSoundEnhancer(string Card)
        {
            try
            {
                switch (Card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage = new AllAroundSoundEnhancerPage();
                        ClickOnElement(allAroundSoundEnhancerPage.Close);
                        break;

                    case "Hear in Noise":
                        var hearInNoiseSoundEnhancerPage = new HearInNoiseSoundEnhancerPage();
                        ClickOnElement(hearInNoiseSoundEnhancerPage.Close);
                        break;

                    case "Outdoor":
                        var outdoorSoundEnhancerPage = new OutdoorSoundEnhancerPage();
                        ClickOnElement(outdoorSoundEnhancerPage.Close);
                        break;

                    case "Music":
                        var musicSoundEnhancerPage = new MusicSoundEnhancerPage();
                        ClickOnElement(musicSoundEnhancerPage.Close);
                        break;

                    case "TV1":
                        var tv1SoundEnhancerPage = new TV1SoundEnhancerPage();
                        ClickOnElement(tv1SoundEnhancerPage.Close);
                        break;

                    case "TV2":
                        var tv2SoundEnhancerPage = new TV2SoundEnhancerPage();
                        ClickOnElement(tv2SoundEnhancerPage.Close);
                        break;

                    case "Mic":
                        var micSoundEnhancerPage = new MicSoundEnhancerPage();
                        ClickOnElement(micSoundEnhancerPage.Close);
                        break;

                    default:
                        throw new ArgumentException("Unknown card: '" + Card + "'");
                }

                Reporting.Log("Pass", Card + " Sound Enhancer exit button pressed");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Failed to press Sound Enhancer exit button on " + Card + ": " + e.Message);
                throw;
            }
        }


        #region Bass

        [When(@"I set Bass gain to '(.*)' on '(.*)' Sound Enhancer")]
        public void WhenISetBassGainToOnSoundEnhancer(int Gain, string Card)
        {
            try
            {
                if (Gain < -6 || Gain > 6)
                {
                    throw new ArgumentException("Gain outside valid limits of -6/6");
                }

                switch (Card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage = new AllAroundSoundEnhancerPage();
                        //allAroundSoundEnhancerPage.BassSlider.Set(Gain);
                        if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                            // TODO : This method is only tested for iPhone12 resolution
                        {
                            TapBycoordinates(178, 612);
                        }
                        else
                            // TODO : This method is only tested for iPhone12 resolution
                        {
                            TapBycoordinates(53, 199);
                        }

                        break;

                    default:
                        throw new ArgumentException("Unknown card: '" + Card + "'");
                }

                Reporting.Log("Pass", "Bass gain set to " + Gain + " on " + Card + " Sound Enhancer");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Bass gain not set to " + Gain + " on " + Card + " Sound Enhancer: " + e.Message);
                throw;
            }
        }

        #endregion


        [When(@"I press 'Tinnitus Manager' on '(.*)' Sound Enhancer")]
        public void WhenIPressTinnitusManagerOnSoundEnhancer(string Card)
        {
            try
            {
                switch (Card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage = new AllAroundSoundEnhancerPage();
                        ClickOnElement(allAroundSoundEnhancerPage.TinnitusManager);
                        break;

                    case "Hear in Noise":

                        var hearInNoiseSoundEnhancerPage = new HearInNoiseSoundEnhancerPage();
                        ClickOnElement(hearInNoiseSoundEnhancerPage.TinnitusManager);
                        break;

                    case "Outdoor":
                        var outdoorSoundEnhancerPage = new OutdoorSoundEnhancerPage();
                        ClickOnElement(outdoorSoundEnhancerPage.TinnitusManager);
                        break;

                    case "Music":
                        var musicSoundEnhancerPage = new MusicSoundEnhancerPage();
                        ClickOnElement(musicSoundEnhancerPage.TinnitusManager);
                        break;

                    case "TV1":
                        var tv1SoundEnhancerPage = new TV1SoundEnhancerPage();
                        ClickOnElement(tv1SoundEnhancerPage.TinnitusManager);
                        break;

                    case "TV2":
                        var tv2SoundEnhancerPage = new TV2SoundEnhancerPage();
                        ClickOnElement(tv2SoundEnhancerPage.TinnitusManager);
                        break;

                    case "Mic":
                        var micSoundEnhancerPage = new MicSoundEnhancerPage();
                        ClickOnElement(micSoundEnhancerPage.TinnitusManager);
                        break;

                    default:
                        throw new ArgumentException("Unknown card: '" + Card + "'");
                }


                Reporting.Log("Pass", "Pressed Tinnitus Manager button on " + Card + " Sound Enhancer page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Unable to press Tinnitus Manager button on " + Card + " Sound Enhancer page. " + e.Message);
                throw;
            }
        }


        [When(@"I press Tinnitus Manager button on 'Favorite 1' Sound Enhancer based on '(.*)'")]
        public void WhenIPressTinnitusManagerButtonOnFavoriteSoundEnhancerBasedOn(string card)
        {
            try
            {
                switch (card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.AllAroundSoundEnhancerPage();
                        ClickOnElement(allAroundSoundEnhancerPage.TinnitusManager);
                        break;

                    case "Hear in noise":
                        var hearInNoiseSoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.HearInNoiseSoundEnhancerPage();
                        ClickOnElement(hearInNoiseSoundEnhancerPage.TinnitusManager);
                        break;

                    case "Outdoor":
                        var outdoorSoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.OutdoorSoundEnhancerPage();
                        ClickOnElement(outdoorSoundEnhancerPage.TinnitusManager);
                        break;

                    case "Music":
                        var musicSoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.MusicSoundEnhancerPage();
                        ClickOnElement(musicSoundEnhancerPage.TinnitusManager);
                        break;

                    case "TV1":
                        var tv1SoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.TV1SoundEnhancerPage();
                        ClickOnElement(tv1SoundEnhancerPage.TinnitusManager);
                        break;

                    case "TV2":
                        var tv2SoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.TV2SoundEnhancerPage();
                        ClickOnElement(tv2SoundEnhancerPage.TinnitusManager);
                        break;

                    case "Mic":
                        var micSoundEnhancerPage =
                            new Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites.MicSoundEnhancerPage();
                        ClickOnElement(micSoundEnhancerPage.TinnitusManager);
                        break;

                    default:
                        throw new ArgumentException("Unknown card: '" + card + "'");
                }


                Reporting.Log("Pass",
                    "Pressed Tinnitus Manager button on favorite Sound Enhancer based on " + card + ".");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Unable to press Tinnitus Manager button on favorite Sound Enhancer based on " + card + ": " +
                    e.Message);
                throw;
            }
        }


        #region Middle

        [When(@"I set Middle gain to '(.*)' on '(.*)' Sound Enhancer")]
        public void WhenISetMiddleGainToOnSoundEnhancer(int Gain, string Card)
        {
            try
            {
                if (Gain < -6 || Gain > 6)
                {
                    throw new ArgumentException("Gain outside valid limits of -6/6");
                }

                switch (Card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage = new AllAroundSoundEnhancerPage();
                        //allAroundSoundEnhancerPage.MiddleSlider.Set(Gain);
                        if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                            // TODO : This method is only tested for iPhone12 resolution
                        {
                            TapBycoordinates(540, 1258);
                        }
                        else
                            // TODO : This method is only tested for iPhone12 resolution
                        {
                            TapBycoordinates(187, 341);
                        }

                        break;

                    default:
                        throw new ArgumentException("Unknown card: '" + Card + "'");
                }

                Reporting.Log("Pass", "Middle gain set to " + Gain + " on " + Card + " Sound Enhancer");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Middle gain not set to " + Gain + " on " + Card + " Sound Enhancer: " + e.Message);
                throw;
            }
        }

        #endregion

        #region Treble

        [When(@"I set Treble gain to '(.*)' on '(.*)' Sound Enhancer")]
        public void WhenISetTrebleGainToOnSoundEnhancer(int Gain, string Card)
        {
            try
            {
                if (Gain < -6 || Gain > 6)
                {
                    throw new ArgumentException("Gain outside valid limits of -6/6");
                }

                switch (Card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage = new AllAroundSoundEnhancerPage();
                        //allAroundSoundEnhancerPage.TrebleSlider.Set(Gain);
                        if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                            // TODO : This method is only tested for iPhone12 resolution
                        {
                            TapBycoordinates(892, 520);
                        }
                        else
                            // TODO : This method is only tested for iPhone12 resolution
                        {
                            TapBycoordinates(324, 177);
                        }

                        break;


                    default:
                        throw new ArgumentException("Unknown card: '" + Card + "'");
                }

                Reporting.Log("Pass", "Treble gain set to " + Gain + " on " + Card + " Sound Enhancer");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Treble gain not set to " + Gain + " on " + Card + " Sound Enhancer: " + e.Message);
                throw;
            }
        }

        #endregion

        #region Assertions

        [Then(@"validate X button is displayed on '(.*)' Sound Enhancer page")]
        public void ThenValidateXButtonIsDisplayedOnSoundEnhancer(string card)
        {
            try
            {
                switch (card)
                {
                    case "All-Around":
                        var allAroundSoundEnhancerPage = new AllAroundSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(allAroundSoundEnhancerPage.Close));
                        break;

                    case "Hear in noise":
                        var hearInNoiseSoundEnhancerPage = new HearInNoiseSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(hearInNoiseSoundEnhancerPage.Close));
                        break;

                    case "Outdoor":
                        var outdoorSoundEnhancerPage = new OutdoorSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(outdoorSoundEnhancerPage.Close));
                        break;

                    case "Music":
                        var musicSoundEnhancerPage = new MusicSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(musicSoundEnhancerPage.Close));
                        break;

                    case "TV1":
                        var tv1SoundEnhancerPage = new TV1SoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(tv1SoundEnhancerPage.Close));
                        break;

                    case "TV2":
                        var tv2SoundEnhancerPage = new TV2SoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(tv2SoundEnhancerPage.Close));
                        break;

                    case "Mic":
                        var micSoundEnhancerPage = new MicSoundEnhancerPage();
                        Assert.IsTrue(IsElementDisplayed(micSoundEnhancerPage.Close));
                        break;

                    default:
                        throw new ArgumentException("Unknown program: '" + card + "'");
                }

                Reporting.Log("Pass", "X button is displayed on " + card + " Sound Enhancer page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "X button is not displayed on " + card + " Sound Enhancer page : " + e.Message);

                throw;
            }
        }

        #endregion
    }
}