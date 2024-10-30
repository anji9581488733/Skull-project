using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    internal class CombinedSteps : Reqnroll.Steps
    {
        /* Removed calling other steps with string
         * link: https://docs.reqnroll.net/latest/guides/migrating-from-specflow.html
         * 
         * The SpecFlow v3 functionality of calling a step from a step like this is not available in Reqnroll (has been removed in SpecFlow v4):
         * 
         * 
         * Example:
         * [Binding]
         *   public class CallingStepsFromStepDefinitionSteps : Steps
         *   {
         *       [Given(@"the user (.*) exists")]
         *       public void GivenTheUserExists(string name) { ... }
         *
         *       [Given(@"I log in as (.*)")]
         *       public void GivenILogInAs(string name) { ... }
         *
         *       [Given(@"(.*) is logged in")]
         *       public void GivenIsLoggedIn(string name)
         *       {
         *           Given(string.Format("the user {0} exists", name));
         *           Given(string.Format("I log in as {0}", name));
         *       }
         *   }
         */
    }
}