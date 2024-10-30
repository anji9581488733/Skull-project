using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MyResound;
using Gleipner.Pages.MyResoundPage;
using NUnit.Framework;
using Reqnroll;


namespace Fenris.Steps
{
    [Binding]
    public class MyResound : StepsBase
    {
        [Given(@"I press '(.*)' on My ReSound")]
        [When(@"I press '(.*)' on My ReSound")]
        public void WhenIPressOnMyReSound(string ListItem)
        {
            try
            {
                var myResoundPage = new MyResoundPage();
                switch (ListItem)
                {
                    case "Learn about the app":
                        ClickOnElement(myResoundPage.LearnAboutApp);
                        break;
                    case "Guiding tips":

                        ClickOnElement(myResoundPage.GuidingTips);
                        break;

                    default:
                        throw new ArgumentException("Unknown list item " + ListItem);
                }

                Reporting.Log("Pass", "" + ListItem + " tapped on My ReSound.");
            }

            catch (Exception e)
            {
                Reporting.Log("Fail", ListItem + " not tapped on My ReSound. " + e.Message);
                throw;
            }
        }


        [Then(@"validate '(.*)' menu item is displayed on My ReSound page")]
        public void ThenValidateMenuItemIsDisplayedOnMyResoundPage(string ListItem)
        {
            try
            {
                var myResoundPage = new MyResoundPage();
                switch (ListItem)
                {
                    case "Learn about the app":
                        Assert.True(IsElementDisplayed(myResoundPage.LearnAboutApp));
                        break;
                    case "Guiding tips":
                        Assert.True(IsElementDisplayed(myResoundPage.GuidingTips));
                        break;

                    default:
                        throw new ArgumentException("Unknown list item " + ListItem);
                }

                Reporting.Log("Pass", ListItem + " is displayed on My ReSound page.");
            }

            catch (Exception e)
            {
                Reporting.Log("Fail", ListItem + " is not displayed on My ReSound page. " + e.Message);
                throw;
            }
        }
    }
}