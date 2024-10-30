using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages;
using Gleipner.Pages.Cards.TopPricePoint;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public class HomeSteps : StepsBase
    {
        /// <summary>
        ///     Swipeto the specified direction and program.
        /// </summary>
        /// <param name="Direction">Direction left/right.</param>
        /// <param name="Program">Program.</param>
        [Given(@"I swipe '(.*)' to '(.*)' program from current program")]
        [When(@"I swipe '(.*)' to '(.*)' program from current program")]
        public void Swipeto(string Direction, string Program)
        {
            var topRibbonBar = new TopRibbonBar();
            try
            {
                switch (Program.ToLower())
                {
                    case "All-Around":
                        var allAroundCard = new AllAroundCard();
                        //allAroundCard.SwipeToCard(Direction, Program);
                        SwipeByCoordinates(SwipeDirection.Left, allAroundCard.AllAround);
                        break;
                    case "hear in noise":

                        Swipe(topRibbonBar.AllAround, 0.5, SwipeDirection.Left);
                        break;
                    case "outdoor":

                        Swipe(topRibbonBar.HearInNoise, 0.5, SwipeDirection.Left);
                        break;
                    case "music":

                        Swipe(topRibbonBar.Outdoor, 0.5, SwipeDirection.Left);
                        break;
                }

                Reporting.Log("Pass", "Swiped " + Direction + " to " + Program);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in Swipeto: " + e.Message);
                throw;
            }
        }
    }
}