using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MoreMenu;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public sealed class ManufacturerSteps : StepsBase
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public ManufacturerSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }



        [Then(@"validate page title is displayed on Manufacturer page")]
        public void ThenValidatePageTitleIsDisplayedOnManufacturerPage()
        {
            try
            {
                var manufacturerPage = new ManufacturerPage();
                Assert.IsTrue(IsElementDisplayed(manufacturerPage.ManufacturingTitle));

                Reporting.Log("Pass", "Found title on Manufacturer page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to find title on Manufacturer page: " + e.Message);
                throw;
            }
        }


        [Then(@"validate back button is displayed on Manufacturer page")]
        public void ThenValidateBackButtonIsDisplayedOnManufacturerPage()
        {
            try
            {
                var manufacturerPage = new ManufacturerPage();
                Assert.True(IsElementDisplayed(manufacturerPage.Back));
                Reporting.Log("Pass", "Back button is displayed on Manufacturer page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Back button is not displayed on Manufacturer page : " + e.Message);
                throw;
            }
        }

    }
}