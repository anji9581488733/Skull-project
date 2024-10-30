using Fenris.Steps.Base;
using NUnit.Framework;
using Reqnroll;
using System;
using Gleipner.Pages.Plugins.AssemblyListPage;
using Polaris.Base;

namespace Fenris.Steps.Plugins;

[Binding]
public class AssemblyListSteps : StepsBase
{
    [When(@"I press '(.*)' on Assemble List Plugin Page and copy contents to the report")]
    public void WhenIPressOnAssembleListPluginPageAndCopyContentsToTheReport(string button)
    {
        var assemblyListPage = new AssemblyListPage();
        try
        {
            ClickOnElement(assemblyListPage.FindElement(button));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }
}