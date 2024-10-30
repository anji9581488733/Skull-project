using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MoreMenu;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public sealed class PRIVACYPOLICYSteps : StepsBase
    {
        #region Assertions

        [When(@"validate page title is displayed on PRIVACY POLICY page")]
        public void WhenValidatePageTitleIsDisplayedOnPRIVACYPOLICYPage()
        {
            try
            {
                var privacyPolicyPage = new PrivacyPolicyPage();
                Assert.IsTrue(IsElementDisplayed(privacyPolicyPage.PrivacyPolicyTitle));

                Reporting.Log("Pass", "Found title on Privacy Policy page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to find title on Privacy Policy page: " + e.Message);
                throw;
            }
        }


        [Then(@"validate back button is displayed on PRIVACY POLICY page")]
        public void ThenValidateBackButtonIsDisplayedOnPrivacyPolicyPage()
        {
            try
            {
                var privacyPolicyPage = new PrivacyPolicyPage();
                Assert.True(IsElementDisplayed(privacyPolicyPage.Back));
                Reporting.Log("Pass", "Back button is displayed on Privacy Policy page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Back button is not displayed on Privacy Policy page : " + e.Message);
                throw;
            }
        }

        #endregion
    }
}