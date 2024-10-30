using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages;
using Gleipner.Pages.DialogBoxes;
using NUnit.Framework;
using Reqnroll;

/// <summary>
/// Steps related to the different dialog boxes
/// </summary>

namespace Fenris.Steps
{
    [Binding]
    public class DialogBox : StepsBase
    {
        [When(@"I press 'No thanks' on 'Welcome - Would you like a quick tour of the app' dialog")]
        public void WhenIPressOnWelcomeWouldYouLikeAQuickTourOfTheAppDialog()
        {
            try
            {
                var quickTourPage = new QuickTourPage();
                ClickOnElement(quickTourPage.NoThanks);

                Reporting.Log("Pass", "'No thanks' is pressed on QuickTourPage dialog");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Failed to press 'No thanks' on QuickTourPage dialog " + e.Message);
                throw;
            }
        }


        [Then(@"validate '(.*)' button is displayed on Quick tour dialog")]
        public void ThenValidateButtonIsDisplayedOnQuickTourDialog(string button)
        {
            try
            {
                var quickTourPage = new QuickTourPage();
                switch (button)
                {
                    case "No thanks":
                        Assert.IsTrue(IsElementDisplayed(quickTourPage.NoThanks));
                        break;
                    default:
                        throw new ArgumentException("Unknown button " + button);
                }

                Reporting.Log("Pass", button + " button is displayed on Quick tour dialog.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", button + " button is not displayed on Quick tour dialog. : " + e.Message);
                throw;
            }
        }

        [Given(@"I press 'Allow While Using App' button in Always Allow dialog")]
        public void GivenIPressAllowWhileUsingAppInAlwaysAllowDialog()
        {
            try
            {
                var alwaysallowpopuppage = new AlwaysAllowPopupPage();

                if (IsElementDisplayed(alwaysallowpopuppage.AlwaysAllowPopup))
                {
                    ClickOnElement(alwaysallowpopuppage.AlwaysAllowPopup);
                }

                Reporting.Log("Pass", "Always Allow popup is displayed");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in the popup : " + e.Message);
                throw;
            }
        }

        [Given(@"I press 'Change to Always Allow' button in Always Allow dialog")]
        public void GivenIPressChangeToAlwaysAllowInAlwaysAllowDialog()
        {
            try
            {
                var alwaysallowpopuppage = new AlwaysAllowPopupPage();

                if (IsElementDisplayed(alwaysallowpopuppage.ChangeAlwayPopup))
                {
                    ClickOnElement(alwaysallowpopuppage.ChangeAlwayPopup);
                }

                Reporting.Log("Pass", "Always Allow popup is displayed");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in the popup : " + e.Message);
                throw;
            }
        }


        #region Demo price point dialog steps

        [Then(@"validate Ok button is displayed on Price point dialog")]
        public void ThenValidateOkButtonIsDisplayedOnPricePointDialog()
        {
            try
            {
                var pricePointPage = new PricePointPage();
                Assert.IsTrue(IsElementDisplayed(pricePointPage.Ok));
                Reporting.Log("Pass", "Ok button is displayed on Price point dialog.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Ok button is not displayed on Price point dialog. : " + e.Message);
                throw;
            }
        }


        [When(@"I press 'OK' on 'Important' dialog if available")]
        [Given(@"I press 'OK' on 'Important' dialog if available")]
        public void WhenIPressOnDialogIfAvailable()
        {
            try
            {
                var importantPage = new ImportantPage();
                if (IsElementNotDisplayed(importantPage.Ok))
                {
                    Reporting.Log("Pass", "'OK' on important dialog not available and skipped");
                }
                else
                {
                    ClickOnElement(importantPage.Ok);
                    Reporting.Log("Pass", "'OK' on important dialog pressed");
                }
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception When I press 'OK' on important dialog" + e.Message);
                throw;
            }
        }


        [When(@"I press 'OK' on '(.*)' dialog")]
        [Given(@"I press 'OK' on '(.*)' dialog")]
        public void WhenIPressOnDialog(string Dialog)
        {
            try
            {
                switch (Dialog)
                {
                    case "Price point":
                        var pricePointPage = new PricePointPage();
                        ClickOnElement(pricePointPage.Ok);
                        break;
                    case "Important":
                        var importantPage = new ImportantPage();
                        ClickOnElement(importantPage.Ok);
                        break;

                    case "Please notice":
                        var pleaseNoticePage = new PleaseNoticePage();
                        ClickOnElement(pleaseNoticePage.OK);
                        break;

                    default:
                        throw new ArgumentException(Dialog + " dialog is unknown");
                }

                Reporting.Log("Pass", "'OK' on " + Dialog + " dialog pressed.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception When I press 'OK' on " + Dialog + " dialog" + e.Message);
                throw;
            }
        }

        #endregion
    }
}