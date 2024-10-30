using System;
using System.Threading;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages;
using Gleipner.Pages.EntryFlow;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public class GettingConnectedSteps : StepsBase
    {
        #region Preconditions

        #endregion


        #region Actions

        [When(@"I press 'Skip' button on Notifications Page")]
        public void WhenIPressSkipButtonOnNotificationsPage()
        {
            try
            {
                var notificationsPage = new NotificationsPage();
                ClickOnElement(notificationsPage.Skip);

                Reporting.Log("Pass", "'Skip' button is pressed on notifications page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Skip button could not be pressed on notifications page : " + e.Message);
                throw;
            }
        }


        [When(@"I press 'Continue' button on Notifications Page")]
        public void WhenIPressContinueButtonOnNotificationsPage()
        {
            try
            {
                var notificationsPage = new NotificationsPage();
                ClickOnElement(notificationsPage.Continue);

                Reporting.Log("Pass", "'Continue' button is pressed on notifications page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Continue button could not be pressed on notifications page : " + e.Message);
                throw;
            }
        }

        [When(@"I press 'Allow' button on Getting connected Page")]
        public void WhenIPressAllowButtonOnGettingConnectedPage()
        {
            try
            {
                var gettingConnectedPage = new GettingConnectedPage();
                ClickOnElement(gettingConnectedPage.Allow);

                Reporting.Log("Pass", "'Allow' button is pressed on Getting connected page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Allow button could not be pressed on Getting connected page : " + e.Message);
                throw;
            }
        }

        [When(@"I press 'Allow' button on Getting connected Page if Available")]
        public void WhenIPressAllowButtonOnGettingConnectedPageIfAvailable()
        {
            try
            {
                var gettingConnectedPage = new GettingConnectedPage();
                if (!IsElementDisplayed(gettingConnectedPage.Allow))
                {
                    Reporting.Log("Pass", "'Allow' button is available hence skipped on Getting connected page");
                }
                else
                {
                    ClickOnElement(gettingConnectedPage.Allow);
                    Reporting.Log("Pass", "'Allow' button is pressed on Getting connected page");
                }
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Allow button could not be pressed on Getting connected page : " + e.Message);
                throw;
            }
        }

        [When(@"I press 'Allow' button on Notifications Page")]
        public void WhenIPressButtonOnNotificationsPage()
        {
            try
            {
                var notificationsPage = new NotificationsPage();
                ClickOnElement(notificationsPage.AllowButton);

                Reporting.Log("Pass", "'OK' button is pressed on Getting connected page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "OK button could not be pressed on Getting connected page : " + e.Message);
                throw;
            }
        }

        [When(@"I press 'OK' button on Getting connected Page")]
        public void WhenIPressOKButtonOnGettingConnectedPage()
        {
            try
            {
                var gettingConnectedPage = new GettingConnectedPage();
                
                WaitForElementUsingExplicitWait(gettingConnectedPage.OK, TimeSpan.FromSeconds(50));
                ClickOnElement(gettingConnectedPage.OK);
                Reporting.Log("Pass", "'OK' button is pressed on Getting connected page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "OK button could not be pressed on Getting connected page : " + e.Message);
                throw;
            }
        }

        [When(@"I press 'Continue' button on Getting connected Page")]
        public void WhenIPressContinueButtonOnGettingConnected()
        {
            try
            {
                var gettingConnectedPage = new GettingConnectedPage();

                ClickOnElement(gettingConnectedPage.Continue);

                Reporting.Log("Pass", "'Continue' message is pressed");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in WhenIPressContinueButtonOnGettingConnected : " + e.Message);
                throw;
            }
        }


        [When(@"I press 'Start' button on Getting connected Page")]
        public void WhenIPressStartButtonOnGettingConnected()
        {
            try
            {
                var gettingConnectedPage = new GettingConnectedPage();
                WaitForElementUsingExplicitWait(gettingConnectedPage.WellDoneStart, TimeSpan.FromSeconds(45));
                ClickOnElement(gettingConnectedPage.WellDoneStart);

                Reporting.Log("Pass", "'Start' message is pressed");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in WhenIPressStartButtonOnGettingConnected : " + e.Message);
                throw;
            }
        }


        [When(@"I press 'Hearing aids with replaceable batteries' option on Getting connected Page")]
        public void WhenIPressOptionOnGettingConnected()
        {
            try
            {
                var gettingConnectedPage = new GettingConnectedPage();

                ClickOnElement(gettingConnectedPage.HIReplaceableBatteries);

                Reporting.Log("Pass", "'Hearing aids with replaceable batteries' option is pressed");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in WhenIPressOptionOnGettingConnected : " + e.Message);
                throw;
            }
        }


        [When(@"I abort Getting connected")]
        [When(@"I press close button on Getting connected")]
        public void WhenIPressCloseButtonOnGettingConnected()
        {
            try
            {
                var gettingConnectedPage = new GettingConnectedPage();
                ClickOnElement(gettingConnectedPage.Exit);

                Reporting.Log("Pass", "Close button is pressed on Getting connected.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in WhenIPressCloseButtonOnGettingConnected : " + e.Message);
                throw;
            }
        }


        [When(@"I press '(.*)' button on Are these your hearing aids dialog")]
        public void WhenIPressYesButtonOnAreTheseYourHearingAidsDialog(string button)
        {
            try
            {
                var gettingConnectedAreTheseYourHearingAidsPage = new GettingConnectedAreTheseYourHearingAidsPage();
                switch (button)
                {
                    case "Yes":
                        ClickOnElement(gettingConnectedAreTheseYourHearingAidsPage.Yes);
                        break;

                    default:
                        throw new ArgumentException(button + " button on dialog is unknown");
                }

                Reporting.Log("Pass", button + " : button is pressed on Are these your hearing aids dialog.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "[ERROR] Exception in WhenIPressYesButtonOnAreTheseYourHearingAidsDialog : " + e.Message);
                throw;
            }
        }

        #endregion


        #region Assertions

        [Then(@"validate '(.*)' is shown on Getting connected Page")]
        public void ThenValidateIsShownOnGettingConnectedPage(string text)
        {
            try
            {
                var gettingConnectedPage = new GettingConnectedPage();
                Assert.AreEqual(text, gettingConnectedPage.ConnectingTitle.Text);


                Reporting.Log("Pass", "The text is " + text + " on Getting connected page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Unable to verify page text " + text + " on Getting connected page: " + e.Message);
                throw;
            }
        }


        [Then(@"validate '(.*)' connection dialog is shown")]
        public void ThenIValidateAreTheseYourHearingAidsDialog(string title)
        {
            try
            {
                var gettingConnectedAreTheseYourHearingAidsPage = new GettingConnectedAreTheseYourHearingAidsPage();
                WaitForElementUsingExplicitWait(gettingConnectedAreTheseYourHearingAidsPage.DialogFrame, TimeSpan.FromSeconds(30));
                IsElementDisplayed(gettingConnectedAreTheseYourHearingAidsPage.DialogFrame);
                switch (title)
                {
                    case "Are these your hearing aids?":
                        Assert.AreEqual(title, gettingConnectedAreTheseYourHearingAidsPage.Title.Text);
                        break;
                    case "Is this your hearing aid?":
                        Assert.AreEqual(title, gettingConnectedAreTheseYourHearingAidsPage.Title.Text);
                        break;
                    default:
                        throw new ArgumentException(title + " dialog is unknown");
                }

                Reporting.Log("Pass", title + " : dialog is shown");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Unable to verify page title to be " + title + " on Getting connected page:  " + e.Message);
                throw;
            }
        }

        [Then(@"validate 'Continue' button is shown on Getting connected Page")]
        public void ThenValidateContinueButtonMessageIsShownOnGettingConnected()
        {
            try
            {
                var gettingConnectedPage = new GettingConnectedPage();

                Assert.IsTrue(IsElementDisplayed(gettingConnectedPage.Continue));
                Reporting.Log("Pass", "'Continue' message is shown");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "[ERROR] Exception in ThenValidateContinueButtonMessageIsShownOnGettingConnected : " + e.Message);
                throw;
            }
        }


        [Then(@"validate '(.*)' button is displayed on Getting connected page")]
        public void ThenValidateButtonIsDisplayedOnGettingConnectedPage(string Button)
        {
            try
            {
                var gettingConnectedPage = new GettingConnectedPage();
                switch (Button)
                {
                    case "X":
                        Assert.AreEqual(true, IsElementDisplayed(gettingConnectedPage.Exit));
                        break;

                    default:
                        throw new ArgumentException("Unknown button: " + Button);
                }

                Reporting.Log("Pass", Button + " button is displayed on Getting connected page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", Button + " button is not displayed on Getting connected page: " + e.Message);
                throw;
            }
        }

        #endregion
    }
}