using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MyResound.GuidingTips;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public sealed class GuidingTipsSteps : StepsBase
    {
        #region Assertions

        [Then(@"validate title is '(.*)' on Guiding tips page")]
        public void ThenValidateTitleIsOnGuidingTipsPage(string Title)
        {
            try
            {
                var guidingTipsPage = new GuidingTipsPage();
                Assert.AreEqual(Title, guidingTipsPage.Title.Text);

                Reporting.Log("Pass", "Found title " + Title + " on Guiding tips page.");
            }
            catch (Exception)
            {
                Reporting.Log("Fail", "Title is not " + Title + " on Guiding tips page.");
                throw;
            }
        }

        #endregion

        #region Actions

        [When(@"I scroll down to '(.*)' on Guiding tips")]
        public void WhenIScrollDownToOnGuidingTips(string ListItem)
        {
            try
            {
                var guidingTipsPage = new GuidingTipsPage();
                switch (ListItem)
                {
                    case "Music program":
                        ScrollIOS(SwipeDirection.Down, guidingTipsPage.MusicProgram);
                        break;

                    case "Noise filter":
                        ScrollIOS(SwipeDirection.Down, guidingTipsPage.NoiseFilter);
                        break;

                    default:
                        throw new ArgumentException("Unknown input value: " + ListItem);
                }

                Reporting.Log("Pass", "Scrolled down to " + ListItem + " on Guiding tips page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to scroll down to " + ListItem + " on Guiding tips page. " + e.Message);
                throw;
            }
        }


        [When(@"I press '(.*)' on Guiding tips")]
        public void WhenIPressOnGuidingTips(string ListItem)
        {
            try
            {
                var guidingTipsPage = new GuidingTipsPage();
                switch (ListItem)
                {
                    case "Music program":
                        ClickOnElement(guidingTipsPage.MusicProgram);
                        break;
                    case "Noise filter":
                        ClickOnElement(guidingTipsPage.NoiseFilter);
                        break;
                    case "Back":
                        ClickOnElement(guidingTipsPage.Back);
                        break;
                    default:
                        throw new ArgumentException("Unknown input value: " + ListItem);
                }

                Reporting.Log("Pass", "Tapped " + ListItem + " on Guiding tips page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to tap " + ListItem + " on Guiding tips page. " + e.Message);
                throw;
            }
        }

        [When(@"I press '(.*)' on 'THANKS FOR TURNING GUIDING TIPS ON' Guiding tips page")]
        public void WhenIpressonThanksForTurningOnGuidingTipsPage(string button)
        {
            try
            {
                var thanksForTurningGuidingTipsOnPage = new ThanksForTurningGuidingTipsOnPage();
                switch (button)
                {
                    case "Start from the beginning":
                        ClickOnElement(thanksForTurningGuidingTipsOnPage.StartFromTheBeginning);
                        break;
                    case "Next":
                        ClickOnElement(thanksForTurningGuidingTipsOnPage.NextButton);
                        break;
                    case "Go":
                        ClickOnElement(thanksForTurningGuidingTipsOnPage.GoButton);
                        break;

                    default:
                        throw new ArgumentException("Unknown Button value: " + button);
                }

                Reporting.Log("Pass",
                    "Tapped " + button + " on 'THANKS FOR TURNING GUIDING TIPS ON' Guiding tips page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Unable to press " + button + " on 'THANKS FOR TURNING GUIDING TIPS ON' Guiding tips page " +
                    e.Message);
                throw;
            }
        }

        [When(@"I press '(.*)' on 'YOUR EXPERIENCE LEVEL' Guiding tips page")]
        public void WhenIPressOnYourExperienceLevelOnGuidingTipsPage(string button)
        {
            try
            {
                var yourExperienceLevelPage = new YourExperienceLevelPage();
                switch (button)
                {
                    case "Quite experienced":
                        ClickOnElement(yourExperienceLevelPage.QuiteExperienced);
                        break;
                    case "Go":
                        ClickOnElement(yourExperienceLevelPage.GoButton);
                        break;


                    default:
                        throw new ArgumentException("Unknown Button value: " + button);
                }

                Reporting.Log("Pass", "Tapped " + button + " on 'YOUR EXPERIENCE LEVEL' Guiding tips page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Unable to press " + button + " on 'YOUR EXPERIENCE LEVEL' Guiding tips page " + e.Message);
                throw;
            }
        }

        [When(@"I press Back to tips on '(.*)' nudging dialog")]
        public void WhenIPressBackToTipsOnNudgingDialog(string ListItem)
        {
            try
            {
                switch (ListItem)
                {
                    case "Music program":
                        var musicProgramPage = new MusicProgramPage();
                        ClickOnElement(musicProgramPage.BackToTips);
                        break;

                    case "Noise filter":
                        var noiseFilterPage = new NoiseFilterPage();
                        ClickOnElement(noiseFilterPage.BackToTips);
                        break;

                    default:
                        throw new ArgumentException("Unknown input value: " + ListItem);
                }

                Reporting.Log("Pass", "Tapped Back to tips on " + ListItem + " nudging dialog.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to press Back to tips on " + ListItem + " nudging dialog. " + e.Message);
                throw;
            }
        }


        [Then(@"validate 'Back to tips' button enabled on '(.*)' nudging dialog")]
        public void ThenValidateBacktotipsButtonEnabledOnNudgingDialog(string ListItem)
        {
            try
            {
                switch (ListItem)
                {
                    case "Music program":
                        var musicProgramPage = new MusicProgramPage();
                        Assert.AreEqual(musicProgramPage.BackToTips.Enabled, true);
                        break;

                    case "Noise filter":
                        var noiseFilterPage = new NoiseFilterPage();
                        Assert.AreEqual(noiseFilterPage.BackToTips.Enabled, true);
                        break;

                    default:
                        throw new ArgumentException("Unknown input value: " + ListItem);
                }

                Reporting.Log("Pass", "Back to tips button is enabled on " + ListItem + " nudging dialog.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Back to tips button is disabled on " + ListItem + " nudging dialog. " + e.Message);
                throw;
            }
        }


        [Then(@"validate 'Got it' button enabled on '(.*)' nudging dialog")]
        public void ThenValidateGotitButtonEnabledOnNudgingDialog(string ListItem)
        {
            try
            {
                switch (ListItem)
                {
                    case "Music program":
                        var musicProgramPage = new MusicProgramPage();
                        Assert.AreEqual(musicProgramPage.GotIt.Enabled, true);
                        break;

                    case "Noise filter":
                        var noiseFilterPage = new NoiseFilterPage();
                        Assert.AreEqual(noiseFilterPage.GotIt.Enabled, true);
                        break;


                    default:
                        throw new ArgumentException("Unknown input value: " + ListItem);
                }

                Reporting.Log("Pass", "Got it button is enabled on " + ListItem + " nudging dialog.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to press Got it on " + ListItem + " nudging dialog. " + e.Message);
                throw;
            }
        }


        [When(@"I press Got it on '(.*)' nudging dialog")]
        public void WhenIPressGotItOnNudgingDialog(string ListItem)
        {
            try
            {
                switch (ListItem)
                {
                    case "Music program":
                        var musicProgramPage = new MusicProgramPage();
                        ClickOnElement(musicProgramPage.GotIt);
                        break;

                    case "Noise filter":
                        var noiseFilterPage = new NoiseFilterPage();
                        ClickOnElement(noiseFilterPage.GotIt);
                        break;

                    default:
                        throw new ArgumentException("Unknown input value: " + ListItem);
                }

                Reporting.Log("Pass", "Tapped Got it on " + ListItem + " nudging dialog.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to press Got it on " + ListItem + " nudging dialog. " + e.Message);
                throw;
            }
        }

        #endregion
    }
}