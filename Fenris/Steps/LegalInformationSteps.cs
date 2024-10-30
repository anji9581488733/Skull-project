using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MoreMenu;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public sealed class LegalInformationSteps : StepsBase
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public LegalInformationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        #region Actions

        [When(@"I press '(.*)' menu item on Legal information page")]
        public void WhenIPressMenuItemOnLegalInformationPage(string menu)
        {
            try
            {
                var legalInformationPage = new LegalInformationPage();
                switch (menu)
                {
                    case "MANUFACTURER":

                        ClickOnElement(legalInformationPage.Manufacturer);
                        break;

                    case "TERMS AND CONDITIONS":
                        ClickOnElement(legalInformationPage.Terms_and_conditions);
                        break;

                    default:
                        throw new ArgumentException("Unknown menu " + menu);
                }

                Reporting.Log("Pass", "Clicked Legal Information menu item " + menu);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "Unable to press " + menu + " menu item on Legal information page : " + e.Message);
                throw;
            }
        }

        #endregion

        #region Preconditions

        #endregion


        #region Assertions

        [Then(@"validate page title is displayed on Legal information page")]
        public void ThenValidatePageTitleIsDisplayedOnLegalInformationPage()
        {
            try
            {
                var legalInformationPage = new LegalInformationPage();
                Assert.IsTrue(IsElementDisplayed(legalInformationPage.Title));

                Reporting.Log("Pass", "Found title on Legal information page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to find title on Legal information page : " + e.Message);
                throw;
            }
        }

        [Then(@"validate '(.*)' menu item is displayed on Legal information page")]
        public void ThenValidateMenuItemIsDisplayedOnLegalInformationPage(string menu)
        {
            try
            {
                var legalInformationPage = new LegalInformationPage();
                switch (menu)
                {
                    case "MANUFACTURER":
                        Assert.IsTrue(IsElementDisplayed(legalInformationPage.Manufacturer));
                        break;
                    case "TERMS AND CONDITIONS":
                        Assert.IsTrue(IsElementDisplayed(legalInformationPage.Terms_and_conditions));
                        break;

                    case "PRIVACY POLICY":
                        Assert.IsTrue(IsElementDisplayed(legalInformationPage.Privacypolicy));
                        break;
                    default:
                        throw new ArgumentException("Unknown menu " + menu);
                }

                Reporting.Log("Pass", menu + " Menu is displayed on Legal information page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", menu + " Menu is not displayed on Legal information page. " + e.Message);
                throw;
            }
        }


        [Then(@"validate back button is displayed on Legal information page")]
        public void ThenValidateBackButtonIsDisplayedOnLegalInformationPage()
        {
            try
            {
                var legalInformationPage = new LegalInformationPage();
                Assert.True(IsElementDisplayed(legalInformationPage.Back));
                Reporting.Log("Pass", "Back button is displayed on Legal information page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Back button is not displayed on Legal information page : " + e.Message);
                throw;
            }
        }

        #endregion
    }
}