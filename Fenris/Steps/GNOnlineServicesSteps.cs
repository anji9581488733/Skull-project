using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MoreMenu;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public sealed class GNOnlineServicesSteps : StepsBase
    {
        #region Assertions

        [Then(@"validate page title is displayed on GN Online Services page")]
        public void ThenValidatePageTitleIsDisplayedOnGNOnlineServicesPage()
        {
            try
            {
                var gNOnlineServicesPage = new GNOnlineServicesPage();
                Assert.IsTrue(IsElementDisplayed(gNOnlineServicesPage.Title));

                Reporting.Log("Pass", "Found title on GN Online Services page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to find title on GN Online Services page: " + e.Message);
                throw;
            }
        }


        [Then(@"validate back button is displayed on GN Online Services page")]
        public void ThenValidateBackButtonIsDisplayedOnGNOnlineServicesPagePage()
        {
            try
            {
                var gNOnlineServicesPage = new GNOnlineServicesPage();
                Assert.True(IsElementDisplayed(gNOnlineServicesPage.Back));
                Reporting.Log("Pass", "Back button is displayed on GN Online Services page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Back button is not displayed on GN Online Services page : " + e.Message);
                throw;
            }
        }

        [When(@"I press close button on GN Online Services page when available")]
        public void WhenIPressCloseButtonOnGNOnlineServicesPageWhenAvailable()
        {
            try
            {
                var gNOnlineServicesPage = new GNOnlineServicesPage();
                if (IsElementNotDisplayed(gNOnlineServicesPage.Close))
                {
                    Reporting.Log("Pass", "Close Button is not available hence skipped on GNOnline services page.");
                }
                else
                {
                    ClickOnElement(gNOnlineServicesPage.Close);
                    Reporting.Log("Pass", "Close Button is pressed on GNOnline services page.");
                }
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Unable to press Close button on GN Online Services page or skip if GN Online Services is not shown." +
                    e.Message);
                throw;
            }
        }

        [When(@"I press close button on GN Online Services page")]
        public void WhenIPressCloseButtonOnGNOnlineServicesPage()
        {
            try
            {
                var gNOnlineServicesPage = new GNOnlineServicesPage();
                ClickOnElement(gNOnlineServicesPage.Close);
                Reporting.Log("Pass", "Close Button is pressed on GNOnline services page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Unable to press Close button on GN Online Services page or skip if GN Online Services is not shown." +
                    e.Message);
                throw;
            }
        }

        [When(@"I press Start button on GN Online Services page when available")]
        public void WhenIPressStartButtonOnGNOnlineServicesPageWhenAvailable()
        {
            try
            {
                var gNOnlineServicesPage = new GNOnlineServicesPage();
                if (IsElementNotDisplayed(gNOnlineServicesPage.Start))
                {
                    Reporting.Log("Pass", "Start Button is not displayed hence skipped on GNOnline services page.");
                }
                else
                {
                    ClickOnElement(gNOnlineServicesPage.Start);
                    Reporting.Log("Pass", "Start Button is pressed on GNOnline services page.");
                }
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Unable to press Start button on GN Online Services page or skip if GN Online Services is not shown." +
                    e.Message);
                throw;
            }
        }

        [When(@"I press Start button on GN Online Services page")]
        public void WhenIPressStartButtonOnGNOnlineServicesPage()
        {
            try
            {
                var gNOnlineServicesPage = new GNOnlineServicesPage();

                ClickOnElement(gNOnlineServicesPage.Start);
                Reporting.Log("Pass", "Start Button is pressed on GNOnline services page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Unable to press Start button on GN Online Services page or skip if GN Online Services is not shown." +
                    e.Message);
                throw;
            }
        }

        #endregion
    }
}