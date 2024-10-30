using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages;
using Gleipner.Pages.ProgramOverview;
using Reqnroll;

namespace Resoundautomation.Steps
{
    [Binding]
    public class Top_Menu : StepsBase
    {
       

        [When(@"I press '(.*)' program on the top ribbon bar")]
        [When(@"I Press Top_Ribbon_Program '(.*)'")]
        public void WhenPressTop_Ribbon_Program(string Program)
        {
            try
            {
                var topRibbonBar = new TopRibbonBar();

                topRibbonBar.SelectTopRibbonProgram(Program);
                Reporting.Log("Pass", "Successfully selected  Top_Menu : " + Program);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "    [ERROR] Exception in  WhenPressTop_Ribbon_Program  : " + e.Message);
                throw;
            }
        }

        [When(@"I press Program overview button on topribbonbar")]
        public void WhenPressProgramOverview()
        {
            try
            {
                var topRibbonBar = new TopRibbonBar();

                ClickOnElement(topRibbonBar.ProgramOveview);
                Reporting.Log("Pass", "Successfully pressed program overview button ");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "    [ERROR] Exception in WhenPressProgramOverview  : " + e.Message);
                throw;
            }
        }


        /// <summary>
        ///     Change program using the program overview page
        /// </summary>
        [When(@"I change to program '(.*)' using program overview")]
        public void WhenPressProgramOverviewCard(string Program)
        {
            try
            {
                var topRibbonBar = new TopRibbonBar();
                var programOverviewPage = new ProgramOverviewPage();

                ClickOnElement(topRibbonBar.ProgramOveview);
                programOverviewPage.ProgramOverviewCard(Program);
                ClickOnElement(programOverviewPage.Exit);
                Reporting.Log("Pass", "Successfully pressed program overview button ");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "    [ERROR] Exception in  WhenPressTop_Menu  : " + e.Message);
                throw;
            }
        }

    }
}