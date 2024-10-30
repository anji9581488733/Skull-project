using Fenris.Hooks;
using Gleipner.Pages.Plugins;
using NUnit.Framework;
using Reqnroll;
using System;
using Gleipner.Pages.Plugins.DisplayMessagePage;
using Gleipner.Pages.Plugins.POCConsent;
using Polaris.Base;
using PageBase = Gleipner.Base.PageBase;

namespace Fenris.Steps.Plugins
{

    [Binding]
    public class ConsentSteps : PageBase
    {
        [Then(@"Validate '(.*)' text is displayed on Consent part2 page")]
        public void ThenValidateTitleIsDisplayedOnConsentPart2Page(string text)
        {
            var consentPart2Page = new ConsentPart2Page();
            WaitForElementUsingImplicitWait(1);
            try
            {
                Assert.AreEqual(text, consentPart2Page.FindElement("ConsentPart2Header").Text);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Then(@"Take a screenshot for the language test with '(.*)' and '(.*)'")]
        public void ThenTakeAScreenshotForTheLanguageTest(string language, string region)
        {
            try
            {
                AllureReporting.TakeAndSaveScreenshot(language, region);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}