using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MoreMenu;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public sealed class TermsAndConditionsSteps : StepsBase
    {
       

        [Then(@"validate page title is displayed on Terms and Conditions page")]
        public void ThenValidatePageTitleIsDisplayedOnTermsAndConditionsPage()
        {
            try
            {
                var termsAndConditionsPage = new TermsAndConditionsPage();
                Assert.IsTrue(IsElementDisplayed(termsAndConditionsPage.TermsAndConditionsTitle));

                Reporting.Log("Pass", "Found title on Terms and Conditions page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to find title on Terms and Conditions page : " + e.Message);
                throw;
            }
        }


        [Then(@"validate back button is displayed on Terms and Conditions page")]
        public void ThenValidateBackButtonIsDisplayedOnTermsAndConditionsPage()
        {
            try
            {
                var termsAndConditionsPage = new TermsAndConditionsPage();
                Assert.True(IsElementDisplayed(termsAndConditionsPage.Back));
                Reporting.Log("Pass", "Back button is displayed on Terms and Conditions page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Back button is not displayed on Terms and Conditions page : " + e.Message);
                throw;
            }
        }

    }
}