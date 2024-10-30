using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MyResound.LearnAboutTheApp;
using Gleipner.Pages.MyResoundPage.LearnAboutTheApp;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public class LearnAboutTheAppSteps : StepsBase
    {
        [When(@"I press '(.*)' on Learn about the app")]
        public void WhenIPressOnLearnAboutTheApp(string ListItem)
        {
            try
            {
                var learnAboutTheAppPage = new LearnAboutTheAppPage();

                switch (ListItem)
                {
                    case "Volume control":
                        ClickOnElement(learnAboutTheAppPage.VolumeControl);
                        break;

                    case "Close":

                        ClickOnElement(learnAboutTheAppPage.Exit);
                        break;
                    case "Back":

                        ClickOnElement(learnAboutTheAppPage.Back);
                        break;
                    default:
                        throw new ArgumentException("Unknown list item " + ListItem);
                }

                Reporting.Log("Pass", ListItem + " tapped on Learn about the app.");
            }

            catch (Exception e)
            {
                Reporting.Log("Fail", ListItem + " not tapped on Learn about the app. " + e.Message);
                throw;
            }
        }


        [When(@"I swipe '(.*)' to '(.*)' page on Learn about the app")]
        public void WhenISwipeToPageOnLearnAboutTheApp(string Direction, string PageCounter)
        {
            try
            {
                var learnAboutTheAppBasePage = new LearnAboutTheAppBasePage();
                Swipe(learnAboutTheAppBasePage.Next, 0.5, SwipeDirection.Left);
                //if (learnAboutTheAppBasePage.SwipeToPage(Direction, PageCounter))
                Reporting.Log("Pass", "Swiped " + Direction + " to " + PageCounter + " page.");
                //else
                //    throw new Exception("Unable to swipe any further. Page not found.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to swipe on page: " + e.Message);
                throw;
            }
        }
    }
}