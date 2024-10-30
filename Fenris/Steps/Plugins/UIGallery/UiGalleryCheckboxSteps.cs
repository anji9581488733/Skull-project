using System;
using Fenris.Steps.Base;
using Gleipner.Pages.UIGallery;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps.Plugins;

[Binding]
public class UiGalleryCheckboxSteps : StepsBase
{
    [When("I press '(.*)' on UIGallery Checkbox Page")]
    public void WhenIPressOnUIGalleryCheckboxPage(string checkboxLabel)
    {
        try
        {
            var uiGalleryCheckboxPage = new UiGalleryCheckboxPage();
            ClickOnElement(uiGalleryCheckboxPage.FindElement(checkboxLabel));
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [Then(@"Validate that the checkbox '(.*)' is (enabled|disabled) on the UIGallery Checkbox Page")]
    public void ThenValidateThatTheCheckboxIsInExpectedStateOnTheUiGalleryCheckboxPage(string checkboxLabel, string state)
    {
        try
        {
            var uiGalleryCheckboxPage = new UiGalleryCheckboxPage();
            var checkbox = uiGalleryCheckboxPage.FindElement(checkboxLabel);
            bool isEnabled = state is "enabled";
    
            Assert.AreEqual(isEnabled, checkbox.Enabled, $"Expected checkbox '{checkboxLabel}' to be {state}.");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
    
    [Then("Validate that the checkbox '(.*)' is (checked|unchecked) on the UIGallery Checkbox Page")]
    public void ThenValidateThatTheCheckboxIsCheckedOnTheUiGalleryCheckboxPage(string checkboxLabel, string state)
    {
        try
        {
            var uiGalleryCheckboxPage = new UiGalleryCheckboxPage();
            var checkbox = uiGalleryCheckboxPage.FindElement(checkboxLabel);
            bool isChecked = state is "checked";
        
            Assert.AreEqual(isChecked, checkbox.Selected, $"Expected checkbox '{checkboxLabel}' to be {state}.");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}