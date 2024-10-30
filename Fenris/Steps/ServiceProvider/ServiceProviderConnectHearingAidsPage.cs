using Reqnroll;
using System;
using System.Collections.Generic;
using Gleipner.Controls.ServiceProviderControls;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Fenris.Steps.ServiceProvider;


[Binding]
public class ServiceProviderConnectHearingAidsPage: ServiceproviderControls
{
    [Then(@"Validate '(.*)' is displayed")]
    public void ThenValidateIsDisplayed(string Label)
    {
        try
        {
            Assert.AreEqual(Label,ClickElementByLabel(Label).Text);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
    [Then(@"Validate '(.*)' is not displayed")]
    public void ThenValidateIsNotDisplayed(string Label)
    {
        try
        {
            Assert.IsFalse(ClickElementByLabel(Label).Displayed);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}