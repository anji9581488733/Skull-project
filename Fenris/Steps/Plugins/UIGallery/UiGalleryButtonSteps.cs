using System;
using Fenris.Steps.Base;
using Gleipner.Pages.UIGallery;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps.Plugins;

[Binding]
public class UiGalleryButtonSteps : StepsBase
{
    [When(@"I press '(.*)' on UIGallery Button Page")]
    public void WhenIPressOnUIGalleryButtonPage(string button)
    {
        try
        {
            var uiGalleryButtonPage = new UiGalleryButtonPage();
            ClickOnElement(uiGalleryButtonPage.FindElement(button));
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [Then(@"Validate that all buttons are disabled on the UIGallery Button Page")]
    public void ThenValidateThatAllButtonsAreDisabledOnTheUiGalleryButtonPage()
    {
        try
        {
            var uiGalleryButtonPage = new UiGalleryButtonPage();
            var buttons = uiGalleryButtonPage.GetAllElements();
            foreach (var button in buttons) Assert.False(button.Enabled);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}