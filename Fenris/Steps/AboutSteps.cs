using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MoreMenu;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public sealed class AboutSteps : StepsBase
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public AboutSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [When(@"I press About title 6 times on About page")]
        public void WhenIPressAboutTitle6TimesOnAboutPage()
        {
            try
            {
                var aboutPage = new AboutPage();
                ClickOnElement(aboutPage.Title);
                ClickOnElement(aboutPage.Title);
                ClickOnElement(aboutPage.Title);
                ClickOnElement(aboutPage.Title);
                ClickOnElement(aboutPage.Title);
                ClickOnElement(aboutPage.Title);
                Reporting.Log("Pass", "About label title is pressed 6 times on About page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "not able to press About label title on About page : " + e.Message);
                throw;
            }
        }

    

        #region Assertions

        [Then(@"validate page title is displayed on About page")]
        public void ThenValidatePageTitleIsDisplayedOnAboutPage()
        {
            try
            {
                var aboutPage = new AboutPage();
                Assert.True(IsElementDisplayed(aboutPage.Title));

                Reporting.Log("Pass", "Found title on 'About' page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to find title on 'About' page : " + e.Message);
                throw;
            }
        }


        [Then(@"validate back button is displayed on About page")]
        public void ThenValidateBackButtonIsDisplayedOnAboutPage()
        {
            try
            {
                var aboutPage = new AboutPage();
                Assert.True(IsElementDisplayed(aboutPage.Back));
                Reporting.Log("Pass", "Back button is displayed on About page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Back button is not displayed on About page : " + e.Message);
                throw;
            }
        }

        #endregion
    }
}