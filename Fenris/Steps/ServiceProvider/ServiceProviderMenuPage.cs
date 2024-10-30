using Fenris.Steps.Base;
using Polaris.Base;
using Reqnroll;
namespace Fenris.Steps.ServiceProvider;

[Binding]
public class ServiceProviderMenuPage: ServiceProviderbase
{
    [When(@"I scroll '(.*)' to and press '(.*)'")]
    [Given(@"I scroll '(.*)' to and press '(.*)'")]
    public void GivenIScrollToAndPress(string direction, string service)
    {
        if (PlatformCapabilities.AppPathPackage.Contains("TestSinglePlugin"))
        {
            CommonSteps commonSteps = new CommonSteps();
            commonSteps.WhenIPressOnAssemblyListPluginPage("Close Button");
            commonSteps.WhenIPressStartPluginButtonToStartThePlugin("StartPluginButton");
            return;
        }
        ScrollToAndPressTheElement(direction, service);
    }
}