using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MoreMenu;
using Gleipner.Pages.MyResound.GuidingTips;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public sealed class NavigationSteps : StepsBase
    {
       

        [When(@"I press back from '(.*)' page")]
        public void WhenIPressBackFromPage(string Page)
        {
            try
            {
                switch (Page)
                {
                    case "Guiding tips":
                        var guidingTipsPage = new GuidingTipsPage();
                        ClickOnElement(guidingTipsPage.Back);
                        break;
                    case "About":
                        var aboutPage = new AboutPage();
                        ClickOnElement(aboutPage.BackAbout);
                        break;
                    case "Legal information":
                        var legalInformationPage = new LegalInformationPage();
                        ClickOnElement(legalInformationPage.BackAbout);
                        break;
                    case "Support":
                        var supportPage = new SupportPage();
                        ClickOnElement(supportPage.BackAbout);
                        break;
                    case "Manufacturer":
                        var manufacturerPage = new ManufacturerPage();
                        ClickOnElement(manufacturerPage.BackAbout);
                        break;
                    case "Terms and Conditions":
                        var termsAndConditionsPage = new TermsAndConditionsPage();
                        ClickOnElement(termsAndConditionsPage.BackAbout);
                        break;
                    case "GN Online Services":
                        var gnOnlineServicesPage = new GNOnlineServicesPage();
                        ClickOnElement(gnOnlineServicesPage.Back);
                        break;
                    case "PRIVACY POLICY":
                        var privacyPolicyPage = new PrivacyPolicyPage();
                        ClickOnElement(privacyPolicyPage.BackAbout);
                        break;

                    default:
                        throw new ArgumentException();
                }

                Reporting.Log("Pass", "Pressed 'Back' button on " + Page + " Page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to press 'Back' button on " + Page + " : " + e.Message);
                throw;
            }
        }

       
    }
}