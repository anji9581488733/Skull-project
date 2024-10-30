using System;
using System.Threading;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages;
using NUnit.Framework;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public class WelcomeSteps : StepsBase
    {
        [Given(@"I am at the welcome screen")]
        public void GivenIAmAtTheWelcomeScreen()
        {
            try
            {
                var welcomePage = new WelcomePage();
                //Welcome Screen does not load properly so using the Sleep method
                Thread.Sleep(20000);
                Assert.IsTrue(IsElementDisplayed(welcomePage.Welcome));
                Reporting.Log("Pass", "Welcome screen is displayed");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in  GivenIAmAtTheWelcomeScreen : " + e.Message);
                throw;
            }
        }

        [Given(@"I press '(.*)' button on Welcome page")]
        [When(@"I press '(.*)' button on Welcome page")]
        public void WhenIPressButtonOnWelcomePage(string Button)
        {
            try
            {
                var welcomePage = new WelcomePage();
                switch (Button)
                {
                    case "Yes, connect now":
                        ClickOnElement(welcomePage.ConnectNow);
                        break;

                    default:
                        throw new ArgumentException("Unknown button " + Button);
                }

                Reporting.Log("Pass", "Button: " + Button + " is pressed on Welcome page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to press button: " + Button + " on Welcome page. : " + e.Message);
                throw;
            }
        }


        [Then(@"validate '(.*)' button is displayed on Welcome page")]
        public void ThenValidateButtonIsDisplayedOnWelcomePage(string Button)
        {
            try
            {
                var welcomePage = new WelcomePage();
                switch (Button)
                {
                    case "Yes, connect now":

                        Assert.IsTrue(IsElementDisplayed(welcomePage.ConnectNow));
                        break;


                    default:
                        throw new ArgumentException("Unknown button " + Button);
                }

                Reporting.Log("Pass", Button + " button is displayed on Welcome page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", Button + " button is not displayed on Welcome page. : " + e.Message);
                throw;
            }
        }

        [Then(@"validate welcome text header is displayed on Welcome page")]
        public void ThenValidateWelcomeTextHeaderIsDisplayedOnWelcomePage()
        {
            try
            {
                var welcomePage = new WelcomePage();
                Assert.IsTrue(welcomePage.Welcome.Displayed);
                Reporting.Log("Pass", "Welcome text header is displayed on Welcome page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Welcome text header is not displayed on Welcome page : " + e.Message);
                throw;
            }
        }
    }
}