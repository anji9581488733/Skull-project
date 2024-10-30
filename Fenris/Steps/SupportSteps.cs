using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MoreMenu;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public sealed class SupportSteps : StepsBase
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public SupportSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }



        [When(@"validate page title is displayed on Support page")]
        public void WhenValidatePageTitleIsDisplayedOnSupportPage()
        {
            try
            {
                var supportPage = new SupportPage();
                Assert.True(IsElementDisplayed(supportPage.SupportTitle));

                Reporting.Log("Pass", "Found title on 'Support' page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to find title on 'Support' page : " + e.Message);
                throw;
            }
        }

        
    }
}