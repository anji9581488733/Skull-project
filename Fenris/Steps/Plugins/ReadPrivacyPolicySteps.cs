using System;
using Gleipner.Pages.Plugins.BackHeaderPage;
using Gleipner.Pages.Plugins.ReadPrivacyPolicyPage;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
namespace Fenris.Steps.Plugins;

[Binding]
public class ReadPrivacyPolicySteps : BackHeaderPage
{
    [Then(@"Validate header is displayed on the '(.*)' page")]
    public void ThenValidateHeaderIsDisplayedOnThePage(string pluginPage)
    {
        switch (pluginPage)
        {
            case "ReadPrivacyPolicyPlugin":
                Assert.IsTrue(IsHeaderDisplayed("Header"), "Page header is not displayed.");
                break;
            case "MenuPage":
                Assert.IsTrue(IsHeaderDisplayed("MenuPageHeader"), "Page header is not displayed.");
                break;
            default:
                throw new ArgumentException("Unknown input value: " + pluginPage);
        }
        
    }

    [Then(@"Validate '(.*)' button is '(.*)' on the ReadPrivacyPolicyPlugin page")]
    public void ThenValidateButtonIsOnTheReadPrivacyPolicyPluginPage(string button, string buttonStatus)
    {
        try
        {
            switch (button)
            {
                case "back":
                    Assert.IsTrue(IsBackButtonDisplayed(), "Back button is not displayed.");
                    break;
            
                case "close":
                    Assert.IsTrue(IsCloseButtonNotDisplayed(), "Back button is displayed.");
                    break;
                default:
                    Assert.Fail($"Button '{button}' is not supported.");
                    break;
            }
        }
        catch (NoSuchElementException ex)
        {
            if (button == "back")
            {
                Assert.Fail("Back button is not found.");
            }
            else if (button == "close")
            {
                Assert.Fail("Close button is not found.");
            }
            else
            {
                throw; 
            }
        }
    }

    [Then(@"Validate '(.*)' is displayed on the ReadPrivacyPolicyPlugin page")]
    public void ThenValidateIsDisplayedOnTheReadPrivacyPolicyPluginPage(string elementName)
    {
        var readPrivacyPolicyPage = new ReadPrivacyPolicyPage();
        switch (elementName)
        {
            case "PrivacyPolicyBody":
                Assert.IsTrue(readPrivacyPolicyPage.FindElement("PP_BodyId").Displayed,"The privacy policy body is not displayed");
                break;
            
            case "PrivacyPolicyLink":
                Assert.IsTrue(readPrivacyPolicyPage.FindElement("PrivacyPolicyLink").Displayed,"The privacy policy link is not displayed");
                break;
        }
    }

    [When(@"I press back button on the ReadPrivacyPolicyPlugin Page")]
    public void WhenIPressBackButtonOnTheReadPrivacyPolicyPluginPage()
    {
        var backHeaderPage = new BackHeaderPage();
        backHeaderPage.PressBackButton();
    }
}
