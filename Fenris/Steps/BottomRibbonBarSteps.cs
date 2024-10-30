using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages;
using NUnit.Framework;
using Reqnroll;



namespace Fenris.Steps
{
    [Binding]
    public class BottomRibbonBarSteps : StepsBase
    {
     

        [Given(@"I press menu item '(.*)' on bottom ribbon bar")]
        [When(@"I press menu item '(.*)' on bottom ribbon bar")]
        public void GivenPressBottom_Menu(string menu)
        {
            try
            {
                var bottomRibbonBar = new BottomRibbonBar();

                switch (menu)
                {
                    case "Status":
                        ClickOnElement(bottomRibbonBar.Status);
                        break;

                    case "More":
                        ClickOnElement(bottomRibbonBar.More);
                        break;

                    case "Home":
                        ClickOnElement(bottomRibbonBar.Home);
                        break;

                    case "My ReSound":
                        ClickOnElement(bottomRibbonBar.MyResound);
                        break;

                    default:
                        throw new ArgumentException("Unknown input value: " + menu);
                }

                Reporting.Log("Pass", "Succesfully  Pressed Bottom Menu  '" + menu + "'");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in  GivenPressBottom_Menu : " + e.Message);
                throw;
            }
        }

     

        [Then(@"validate '(.*)' button is displayed on bottom ribbon bar")]
        public void ThenValidateButtonIsDisplayedOnBottomRibbonBar(string Button)
        {
            try
            {
                var bottomRibbonBar = new BottomRibbonBar();

                switch (Button)
                {
                    case "Home":
                        Assert.IsTrue(IsElementDisplayed(bottomRibbonBar.Home));
                        break;

                    case "Status":
                        Assert.IsTrue(IsElementDisplayed(bottomRibbonBar.Status));
                        break;

                    case "My ReSound":
                        Assert.IsTrue(IsElementDisplayed(bottomRibbonBar.MyResound));
                        break;

                    case "More":
                        Assert.IsTrue(IsElementDisplayed(bottomRibbonBar.More));
                        break;

                    default:
                        throw new ArgumentException("Unknown button: " + Button);
                }

                Reporting.Log("Pass", Button + " button is displayed on bottom ribbon bar");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", Button + " button is not displayed on bottom ribbon bar: " + e.Message);
                throw;
            }
        }

    }
}