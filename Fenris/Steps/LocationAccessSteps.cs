using System;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.DialogBoxes;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public class LocationAccessSteps : StepsBase
    {
        [When(@"I press '(.*)' button for the Mobile device location access on location access dialog")]
        public void WhenIPressButtonForTheMobileDeviceLocationAccessOnLocationAccessDialog(string allow)
        {
            try
            {
                var locationAccesspage = new LocationAccessPage();

                if (IsElementDisplayed(locationAccesspage.AllowDialog))
                {
                    ClickOnElement(locationAccesspage.AllowDialog);
                }

                Reporting.Log("Pass", "Allow Dialog is displayed");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in the dialog : " + e.Message);
                throw;
            }
        }

        [When(@"I press '(.*)' button to access the device location on location access popup")]
        public void WhenIPressButtonToAccessTheDeviceLocationOnLocationAccessPopup(string allow0)
        {
            try
            {
                var locationAccesspage = new LocationAccessPage();

                if (IsElementDisplayed(locationAccesspage.AllowPopup))
                {
                    ClickOnElement(locationAccesspage.AllowPopup);
                }

                Reporting.Log("Pass", "Allow on the location acess popup is displayed");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in the popup : " + e.Message);
                throw;
            }
        }
    }
}