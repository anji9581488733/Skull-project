using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.EntryFlow;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public sealed class TermsAndConditionsEntryFlow : StepsBase
    {
       

        [When(@"I press scroll to bottom button on Terms and Conditions at the Entry Flow")]
        public void WhenIScrollToTheBottomOfTermsAndConditionsAtTheEntryFlow()
        {
            try
            {
                var termsAndConditionsPage = new TermsAndConditionPageEntryFlow();

                if (IsElementDisplayed(termsAndConditionsPage.ScrollToBottom))
                {
                    ClickOnElement(termsAndConditionsPage.ScrollToBottom);
                    Reporting.Log("Pass", "Scroll to the bottom of the terms and conditions screen");
                }
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "[ERROR] Exception in  WhenIScrollToTheBottomOfTermsAndConditions : " + e.Message);
                throw;
            }
        }


        [When(@"I check the Accept box on Terms and Conditions at the Entry Flow")]
        public void WhenICheckTheAcceptBoxOnTermsAndConditionsAtTheEntryFlow()
        {
            try
            {
                var termsAndConditionsPage = new TermsAndConditionPageEntryFlow();

                if (IsElementDisplayed(termsAndConditionsPage.AcceptCheckBox))
                {
                    ClickOnElement(termsAndConditionsPage.AcceptCheckBox);
                    Reporting.Log("Pass", "Scroll to the bottom of the terms and conditions screen");
                }
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "[ERROR] Exception in  WhenICheckTheBoxOnTermsAndConditionsAtTheEntryFlow : " + e.Message);
                throw;
            }
        }


        [When(@"I press the Continue button on Terms and Conditions at the Entry Flow")]
        public void WhenIPressTheContinueButtonOnTermsAndConditionsAtTheEntryFlow()
        {
            try
            {
                var termsAndConditionsPage = new TermsAndConditionPageEntryFlow();

                if (IsElementDisplayed(termsAndConditionsPage.Continue))
                {
                    ClickOnElement(termsAndConditionsPage.Continue);

                    Reporting.Log("Pass", "Press Continue button at the bottom of the terms and conditions screen");
                }
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "[ERROR] Exception in  WhenIPressTheContinueButtonOnTermsAndConditionsAtTheEntryFlow : " +
                    e.Message);
                throw;
            }
        }

    }
}