using System;
using System.Collections.Generic;
using Gleipner.Controls.ServiceProviderControls;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace Fenris.Steps.ServiceProvider;

[Binding]
public class ServiceProviderbase: ServiceproviderControls
{
    public void ScrollToAndPressTheElement(string direction, string service)
    {
        SwipeDirection swipeTo = SwipeDirection.Down;
        swipeTo = direction.ToLower() switch
        {
            "down" => SwipeDirection.Down,
            "up" => SwipeDirection.Up,
            _ => throw new Exception("Swipe direction not applicable")
        };
        try
        {
            IWebElement elementByName = ServiceByName(service);
            ScrollUsingPointer(swipeTo, elementByName);
            ClickOnElement(elementByName);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
    
    [When(@"I press Back button for Service Provider from header")]
    public void WhenIPressBackButtonForServiceProviderFromHeader()
    {
        try
        {
            IWebElement elementByName = ServiceByName("ReSound.App.Legolas.Plugins.DynamicServiceProviderConfiguration.Pages.SelectServiceProviderPropertyPage.BackButton");
            ClickOnElement(elementByName);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        
    }
    
}