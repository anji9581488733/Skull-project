using System;
using Fenris.Steps.Base;
using Gleipner.Pages.UIGallery;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps.Plugins;

[Binding]
public class UiGallerySteps : StepsBase
{
    [When(@"I press '(.*)' on UIGallery Menu Page")]
    public void WhenIPressOnUIGalleryMenuPage(string subPage)
    {
        try
        {
            var uiGalleryMenuPage = new UiGalleryMenuPage();
            ClickOnElement(uiGalleryMenuPage.FindElement(subPage));
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}