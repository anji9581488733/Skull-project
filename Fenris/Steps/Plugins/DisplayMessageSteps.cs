using System;
using Gleipner.Pages.Plugins.DisplayMessagePage;
using Gleipner.Pages.Plugins.POCConsent;
using NUnit.Framework;
using Polaris.Base;
using Reqnroll;
using PageBase = Gleipner.Base.PageBase;

namespace Fenris.Steps.Plugins;

[Binding]
public class DisplayMessageSteps : PageBase
{
    [Then(@"Validate '(.*)' text is displayed on the Display Message plugin page")]
        public void ThenValidateTextIsDisplayedOnTheDisplayMessagePluginPage(string status)
        {
            if (PlatformCapabilities.AppPathPackage.Contains("TestMultiplePlugins"))
            {
                return;
            }
            
            var displayMessagePage = new DisplayMessagePage();
            switch (status)
            {
                case "Cancelled":
                    Assert.AreEqual(status, displayMessagePage.FindElement("DisplayMessagePageBody1Text").Text);
                    break;
                case "Completed":
                    Assert.AreEqual(status, displayMessagePage.FindElement("DisplayMessagePageBody1Text").Text);
                    break;
                case "Closed":
                    Assert.AreEqual(status, displayMessagePage.FindElement("DisplayMessagePageBody1Text").Text);
                    break;
                default:
                    throw new ArgumentException("Unknown input value: " + status);
            }
        }

        [When(@"I press Close button on Display Message plugin")]
        public void WhenIPressCloseButtonOnDisplayMessagePlugin()
        {
            if (PlatformCapabilities.AppPathPackage.Contains("TestMultiplePlugins"))
            {
                return;
            }
            
            var displayMessagePage = new DisplayMessagePage();
            var locator = displayMessagePage.GetAutomationID("CloseButton");

            try
            {
                ClickOnElement(displayMessagePage.FindElement("CloseButton"));
            }
            catch (Exception e)
            {
                Assert.Fail($"Unable to click Close button with AutomationID: {locator}. " + e.Message);
            }
        }

        [Then(@"Validate '(.*)' text is displayed on Consent part1 page")]
        public void ThenValidateTitleIsDisplayedOnConsentPart1Page(string text)
        {
            var consentPart1Page = new ConsentPart1Page();
            var locator = consentPart1Page.GetAutomationID("ConsentPart1Header");
            try
            {
                Assert.AreEqual(text, consentPart1Page.FindElement("ConsentPart1Header").Text);
            }
            catch (Exception e)
            {
                Assert.Fail($"Text: {text} with AutomationID: {locator} didn't show up. " + e.Message);
            }
        }
}