using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.Cards.TopPricePoint;
using Gleipner.Pages.Cards.TopPricePoint.Favorites;
using NUnit.Framework;
using Polaris.Base;
using Reqnroll;

namespace Fenris.Steps.Cards
{
    [Binding]
    public sealed class CardSteps : StepsBase
    {
        #region Actions

        [When(@"I press Sound Enhancer button on '(.*)' program")]
        public void WhenIPressSoundEnhancerButtonOnProgram(string Program)
        {
            try
            {
                switch (Program)
                {
                    case "All-Around":
                        var allAroundCard = new AllAroundCard();

                        ClickOnElement(allAroundCard.SoundEnhancer);
                        //IsElementNotDisplayed(allAroundCard.SoundEnhancer);
                        break;

                    case "Hear in Noise":
                        var hearInNoiseCard = new HearInNoiseCard();
                        ClickOnElement(hearInNoiseCard.SoundEnhancer);
                        //IsElementNotDisplayed(hearInNoiseCard.SoundEnhancer);
                        break;

                    case "Outdoor":
                        var outdoorCard = new OutdoorCard();
                        ClickOnElement(outdoorCard.SoundEnhancer);
                        //IsElementNotDisplayed(outdoorCard.SoundEnhancer);
                        break;

                    case "Music":
                        var musicCard = new MusicCard();
                        ClickOnElement(musicCard.SoundEnhancer);
                        //IsElementNotDisplayed(musicCard.SoundEnhancer);
                        break;

                    case "TV1":
                        var tV1Card = new TV1Card();
                        ClickOnElement(tV1Card.SoundEnhancer);
                        IsElementNotDisplayed(tV1Card.SoundEnhancer);
                        break;

                    case "TV2":
                        var tV2Card = new TV2Card();
                        ClickOnElement(tV2Card.SoundEnhancer);
                        IsElementNotDisplayed(tV2Card.SoundEnhancer);
                        break;

                    case "Mic":
                        var micCard = new MicCard();
                        ClickOnElement(micCard.SoundEnhancer);
                        IsElementDisplayed(micCard.SoundEnhancer);
                        break;

                    default:
                        throw new ArgumentException("Unknown program: '" + Program + "'");
                }

                Reporting.Log("Pass", "Pressed Sound Enhancer button on " + Program);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Failed to press Sound Enhancer button on " + Program + ": " + e.Message);
                throw;
            }
        }


        /// <summary>
        ///     tap the volume thumb on a specific side on a specific card
        /// </summary>
        /// <param name="Volume">Volume.</param>
        /// <param name="Side">Side.</param>
        /// <param name="Card">Card.</param>
        [When(@"I set surroundings volume to '(\S*)' on '(\S*)' volume bar of '(.*)' program")]
        public void WhenISetSurroundingsVolumeToOnVolumeBarOfProgram(int Volume, string Side, string Card)
        {
            try
            {
                if (!(Side == "left" || Side == "right"))
                {
                    throw new ArgumentException();
                }

                switch (Card)
                {
                    case "All-Around":
                        var allAroundCard = new AllAroundCard();
                        if (Side == "left")
                        {
                            if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                            {
                                Swipe(allAroundCard.VolumeLeftSliderDot, 0.05, SwipeDirection.Right);
                            }
                            else
                            {
                                TapBycoordinates(366, 663);
                            }
                        }

                        if (Side == "right")
                        {
                            if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                            {
                                Swipe(allAroundCard.VolumeRightSliderDot, 0.3, SwipeDirection.Left);
                            }
                            else
                            {
                                TapBycoordinates(111, 600);
                            }
                        }


                        break;

                    case "Hear in noise":
                        var hearInNoiseCard = new HearInNoiseCard();
                        if (Side == "left")
                        {
                            Swipe(hearInNoiseCard.VolumeLeftSlider, 0.05, SwipeDirection.Right);
                        }

                        if (Side == "right")
                        {
                            Swipe(hearInNoiseCard.VolumeRightSliderDot, 0.3, SwipeDirection.Left);
                        }

                        break;

                    case "Outdoor":
                        var outDoorCard = new OutdoorCard();
                        if (Side == "left")
                        {
                            Swipe(outDoorCard.VolumeLeftSlider, 0.05, SwipeDirection.Right);
                        }

                        if (Side == "right")
                        {
                            Swipe(outDoorCard.VolumeRightSliderDot, 0.3, SwipeDirection.Left);
                        }

                        break;

                    case "Music":
                        var musicCard = new MusicCard();
                        if (Side == "left")
                        {
                            Swipe(musicCard.VolumeLeftSlider, 0.05, SwipeDirection.Right);
                        }

                        if (Side == "right")
                        {
                            Swipe(musicCard.VolumeRightSliderDot, 0.3, SwipeDirection.Left);
                        }

                        break;

                    case "TV1":
                        var tv1Card = new TV1Card();
                        if (Side == "left")
                        {
                            Swipe(tv1Card.VolumeLeftSlider, 0.05, SwipeDirection.Right);
                        }

                        if (Side == "right")
                        {
                            Swipe(tv1Card.VolumeRightSliderDot, 0.05, SwipeDirection.Right);
                        }

                        break;

                    case "TV2":
                        var tv2Card = new TV2Card();
                        if (Side == "left")
                        {
                            Swipe(tv2Card.VolumeLeftSlider, 0.05, SwipeDirection.Right);
                        }

                        if (Side == "right")
                        {
                            Swipe(tv2Card.VolumeRightSliderDot, 0.05, SwipeDirection.Right);
                        }

                        break;

                    case "Mic":
                        var micCard = new MicCard();
                        if (Side == "left")
                        {
                            Swipe(micCard.VolumeLeftSlider, 0.05, SwipeDirection.Right);
                        }

                        if (Side == "right")
                        {
                            Swipe(micCard.VolumeRightSliderDot, 0.05, SwipeDirection.Right);
                        }

                        break;

                    default:
                        throw new ArgumentException();
                }

                Reporting.Log("Pass",
                    "Surroundings volume is " + Volume + " on " + Side + " slider of " + Card + " program.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    " Surroundings volume is not " + Volume + " on " + Side + " slider of " + Card +
                    " program. Exception Error :" + e.Message);
                throw;
            }
        }


        /// <summary>
        ///     tap the streamer volume thumb on a specific side on a specific card
        ///     <summary>
        ///         split hearing aid volume bar on a specific program.
        ///     </summary>
        ///     <param name="Card">Card.</param>
        [Given(@"I press split surroundings volume on '(.*)' program")]
        [When(@"I press split surroundings volume on '(.*)' program")]
        public void WhenIPressSplitSurroundingsVolumeOnProgram(string Card)
        {
            try
            {
                switch (Card)
                {
                    case "All-Around":

                        var allAroundCard = new AllAroundCard();
                        ClickOnElement(allAroundCard.SplitVolumeBarsHearingAids);
                        break;

                    case "Hear in noise":
                        var hearInNoiseCard = new HearInNoiseCard();
                        ClickOnElement(hearInNoiseCard.SplitVolumeBarsHearingAids);
                        break;

                    case "Outdoor":
                        var outdoorCard = new OutdoorCard();
                        ClickOnElement(outdoorCard.SplitVolumeBarsHearingAids);
                        break;

                    case "Music":
                        var musicCard = new MusicCard();
                        ClickOnElement(musicCard.SplitVolumeBarsHearingAids);
                        break;

                    case "TV1":
                        var tv1Card = new TV1Card();
                        ClickOnElement(tv1Card.SplitVolumeBarsHearingAids);
                        break;

                    case "TV2":
                        var tv2Card = new TV2Card();
                        ClickOnElement(tv2Card.SplitVolumeBarsHearingAids);
                        break;

                    case "Mic":
                        var micCard = new MicCard();
                        ClickOnElement(micCard.SplitVolumeBarsHearingAids);
                        break;

                    default:
                        throw new ArgumentException();
                }

                Reporting.Log("Pass", "Surroundings volume bars split on " + Card + ".");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Not able to split surroundings volume bars on " + Card + ". Exception Error :" + e.Message);
                throw;
            }
        }


        /// <summary>
        ///     merge hearing aid volume bars on a specific program.
        /// </summary>
        /// <param name="Card">Card.</param>
        [When(@"I press merge surroundings volume on '(.*)' program")]
        public void WhenIPressMergeSurroundingsVolumeOnProgram(string Card)
        {
            try
            {
                switch (Card)
                {
                    case "All-Around":
                        var allAroundCard = new AllAroundCard();
                        ClickOnElement(allAroundCard.MergeVolumeBarsHearingAids);
                        break;
                    case "Hear in noise":
                        var hearInNoiseCard = new HearInNoiseCard();
                        ClickOnElement(hearInNoiseCard.MergeVolumeBarsHearingAids);
                        break;
                    case "Outdoor":
                        var outdoorCard = new OutdoorCard();
                        ClickOnElement(outdoorCard.MergeVolumeBarsHearingAids);
                        break;
                    case "Music":
                        var musicCard = new MusicCard();
                        ClickOnElement(musicCard.MergeVolumeBarsHearingAids);
                        break;
                    case "TV1":
                        var tv1Card = new TV1Card();
                        ClickOnElement(tv1Card.MergeVolumeBarsHearingAids);
                        break;
                    case "TV2":
                        var tv2Card = new TV2Card();
                        ClickOnElement(tv2Card.MergeVolumeBarsHearingAids);
                        break;
                    case "Mic":
                        var micCard = new MicCard();
                        ClickOnElement(micCard.MergeVolumeBarsHearingAids);
                        break;
                    default:
                        throw new ArgumentException();
                }

                Reporting.Log("Pass", "Surroundings volume bars merged on " + Card + ".");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Surroundings volume bars not merged on " + Card + ". Exception Error :" + e.Message);
                throw;
            }
        }

        #endregion


        #region Assertions

        [Then(@"validate the Sound Enhancer button is displayed on '(.*)' program")]
        [Then(@"the Sound Enhancer button is shown on '(.*)' program")]
        public void ThenSoundEnhancerButtonShownOnProgram(string Program)
        {
            try
            {
                switch (Program)
                {
                    case "All-Around":
                        var allAroundCard = new AllAroundCard();
                        IsElementDisplayed(allAroundCard.SoundEnhancer);
                        break;

                    case "Hear in noise":
                        var hearInNoiseCard = new HearInNoiseCard();
                        IsElementDisplayed(hearInNoiseCard.SoundEnhancer);
                        break;

                    case "Outdoor":
                        var outdoorCard = new OutdoorCard();
                        IsElementDisplayed(outdoorCard.SoundEnhancer);
                        break;

                    case "Music":
                        var musicCard = new MusicCard();
                        IsElementDisplayed(musicCard.SoundEnhancer);
                        break;

                    case "TV1":
                        var tV1Card = new TV1Card();
                        IsElementDisplayed(tV1Card.SoundEnhancer);
                        break;

                    case "TV2":
                        var tV2Card = new TV2Card();
                        IsElementDisplayed(tV2Card.SoundEnhancer);
                        break;

                    case "Mic":
                        var micCard = new MicCard();
                        IsElementDisplayed(micCard.SoundEnhancer);
                        break;

                    default:
                        throw new ArgumentException("Unknown program: '" + Program + "'");
                }

                Reporting.Log("Pass", "Sound Enhancer button is shown on " + Program);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Sound Enhancer button it not shown on " + Program + ": " + e.Message);
                throw;
            }
        }


        [Then(@"validate '(\S*)' surroundings volume slider is displayed on '(.*)' program")]
        public void ThenValidateSurroundingsVolumeSliderIsDisplayedOnProgram(string Side, string Card)
        {
            try
            {
                if (!(Side == "left" || Side == "right"))
                {
                    throw new ArgumentException();
                }

                switch (Card)
                {
                    case "All-Around":
                        var allAroundCard = new AllAroundCard();
                        if (Side == "left")
                        {
                            Assert.IsTrue(IsElementDisplayed(allAroundCard.VolumeLeftSlider));
                        }

                        if (Side == "right")
                        {
                            Assert.IsTrue(IsElementDisplayed(allAroundCard.VolumeRightSlider));
                        }

                        break;

                    case "Hear in noise":
                        var hearInNoiseCard = new HearInNoiseCard();
                        if (Side == "left")
                        {
                            Assert.IsTrue(IsElementDisplayed(hearInNoiseCard.VolumeLeftSlider));
                        }

                        if (Side == "right")
                        {
                            Assert.IsTrue(IsElementDisplayed(hearInNoiseCard.VolumeRightSlider));
                        }

                        break;

                    default:
                        throw new ArgumentException();
                }

                Reporting.Log("Pass", Side + " surroundings volume slider is displayed on " + Card + " program.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    Side + " surroundings volume slider is not displayed on " + Card + " program." +
                    " : Exception Error :" + e.Message);
                throw;
            }
        }


        [Then(@"validate '(.*)' quick button is enabled on '(.*)' program")]
        public void ThenValidateQuickButtonIsEnabledOnProgram(string quickButton, string program)
        {
            try
            {
                var hearInNoiseCard = new HearInNoiseCard();
                switch (program)
                {
                    case "All-Around":
                        var allAroundCard = new AllAroundCard();
                        if (quickButton.Equals("Noise filter"))
                        {
                            Assert.IsTrue(allAroundCard.NoiseFilterActivated);
                        }
                        else if (quickButton.Equals("Speech clarity"))
                        {
                            Assert.IsTrue(allAroundCard.SpeechClarityActivated);
                        }
                        else
                        {
                            throw new ArgumentException(
                                "Unknown quick button input for " + program + ": " + quickButton);
                        }

                        break;


                    default:
                        throw new ArgumentException("Unknown program input: " + program);
                }

                Reporting.Log("Pass", "Quick button " + quickButton + " turned on, on " + program + " program card.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Quick button " + quickButton + " not turned on, on " + program + " program card." + e.Message);
                throw;
            }
        }

        #endregion

        #region Backdoors

        /// <summary>
        ///     Tap the volume thumb to change volume
        /// </summary>
        /// <param name="Index">Program index</param>
        /// <param name="Card">Card.</param>
        [Then(@"validate split surroundings volume button on '(.*)' program is displayed")]
        public void ValidateSplitSurroundingsVolumeButtonOnProgramIsDisplayed(string Card)
        {
            try
            {
                switch (Card)
                {
                    case "All-Around":
                        var allAroundCard = new AllAroundCard();
                        Assert.IsTrue(IsElementDisplayed(allAroundCard.SplitVolumeBarsHearingAids));

                        break;

                    case "Hear in noise":
                        var hearInNoiseCard = new HearInNoiseCard();
                        Assert.IsTrue(IsElementDisplayed(hearInNoiseCard.SplitVolumeBarsHearingAids));
                        break;

                    default:
                        throw new ArgumentException();
                }

                Reporting.Log("Pass", "Surroundings volume bars split button is displayed on " + Card + ".");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Surroundings volume bars split button is not displayed on " + Card + ". Exception Error :" +
                    e.Message);
                throw;
            }
        }

        [Then(@"validate merge surroundings volume button on '(.*)' program is displayed")]
        public void ValidateMergeSurroundingsVolumeButtonOnProgramIsDisplayed(string Card)
        {
            try
            {
                switch (Card)
                {
                    case "All-Around":
                        var allAroundCard = new AllAroundCard();
                        Assert.IsTrue(IsElementDisplayed(allAroundCard.MergeVolumeBarsHearingAids));

                        break;

                    case "Hear in noise":
                        var hearInNoiseCard = new HearInNoiseCard();
                        Assert.IsTrue(IsElementDisplayed(hearInNoiseCard.MergeVolumeBarsHearingAids));
                        break;

                    default:
                        throw new ArgumentException();
                }

                Reporting.Log("Pass", "Surroundings volume bars merge button is displayed on " + Card + ".");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Surroundings volume bars merge button is not displayed on " + Card + ". Exception Error :" +
                    e.Message);
                throw;
            }
        }

        #endregion
    }
}