using Reqnroll;
using System;
using System.Collections.Generic;
using Gleipner.Controls.ServiceProviderControls;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Fenris.Steps.ServiceProvider;


[Binding]
public class ServiceProviderConfigurationPage: ServiceProviderbase
{
    [When(@"I press '(.*)' in service configuration")]
    public void WhenIPressInServiceConfiguration(string label)
    {
        try
        {
            ClickOnElement(ClickElementByLabel(label));
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        
    }
    
    [When(@"I enter '(.*)' text in Enter Configuration name")]
    public void WhenIEnterTextInEnterConfigurationName(string text)
    {
        try
        {
            TextBoxByType.SendKeys(text);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        
    }

    [When(@"I press recently modified configuration")]
    public void WhenIPressRecentlyModifiedConfiguration()
    {
        try
        {
            ClickOnElement(ClickElementByPartialtext("Test"));
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [When(@"I '(.*)' - '(.*)' using '(.*)'")]
    public void WhenIPerformActionOnElement(string action, string element, string property)
    {
        Dictionary<string, IWebElement> xpath = new Dictionary<string, IWebElement>()
        {
            { "Partialtext", ClickElementByPartialtext(element) },
            { "Name", ClickElementByName(element) },
            { "Type", TextBoxByType },
        };
        try
        {      
            IWebElement elementByName = xpath[property];
            switch (action.ToLower()) 
            {
                case "swipe down to":
                    SwipeByCoordinates(SwipeDirection.Down, elementByName);
                    break;
                case "swipe up to":
                    SwipeByCoordinates(SwipeDirection.Up, elementByName);
                    break;
                case "press":
                    ClickOnElement(elementByName);
                    break;
                case "swipe down to and press":
                    SwipeByCoordinates(SwipeDirection.Down, elementByName);   
                    ClickOnElement(elementByName);
                    break;
                case "swipe up to and press":
                    SwipeByCoordinates(SwipeDirection.Up, elementByName);  
                    ClickOnElement(elementByName);
                    break;
            }
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        
    }
    [When(@"I press '(.*)' button in multi page")]
    public void WhenIPressButtonInMultiPage(string Name)
    {
        try
        {
            ClickOnElement(ClickElementByLabel(Name));
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
    [When(@"I press '(.*)' button in service configuration")]
    public void WhenIPressButtonInServiceConfiguration(string Name)
    {
        try
        {
            ClickOnElement(ClickElementByName(Name));
        }
        catch (Exception e)
        {
           Assert.Fail(e.Message);
        }
    }
    
    [When(@"I press Close button in Service Provider from header")]
    public void WhenIPressCloseButtonInServiceProviderFromHeader()
    {
        try
        {
            IWebElement elementByName = ServiceByName("ReSound.App.Legolas.Plugins.DynamicServiceProviderConfiguration.Pages.SelectServiceProviderPropertyPage.CloseButton");
            ClickOnElement(elementByName);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        
    }
   
    [When(@"I press Close button from header")]
    public void WhenIPressCloseButtonInSConnectHearingAidFromHeader()
    {
        try
        {
            IWebElement elementByName = ClickElementByPartialtext("CloseButton");
            ClickOnElement(elementByName);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        
    }
    
    [Given(@"I press '(.*)' in Manage Application Mode")]
    public void GivenIPressInManageApplicationMode(string label)
    {
        try
        {
            ClickOnElement(ClickElementByLabel(label));
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
    
    [Given(@"I check '(.*)' checkbox")]
    public void GivenICheckCheckbox(string checkbox)
    {
        try
        {
            ClickOnElement(CheckElementByLabel(checkbox));
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
    
    [Then(@"Validate Back button is '(.*)' for Service Provider from header")]
    public void WhenIPressBackButtonForServiceProviderFromHeader(string display)
    {
        try
        {
            IWebElement elementByName = ClickElementByPartialtext("BackButton");
            if(display.ToLower() == "displayed")
                Assert.IsTrue(elementByName.Displayed);
            else
                Assert.IsTrue(!elementByName.Displayed);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        
    }
    
    [When(@"I select '(.*)' Service provider and base as '(.*)' and plugin as '(.*)' for '(.*)'")]
    [Given(@"I select '(.*)' Service provider and base as '(.*)' and plugin as '(.*)' for '(.*)'")]
    public void GivenISelectServiceProviderAndBaseAsAndPluginAs(string serviceProvider, string serviceProviderBase,string pluginName, string service)
    {
        ScrollToAndPressTheElement("Down", serviceProvider);
        WhenIPressInServiceConfiguration("Create new configuration");
        WhenIEnterTextInEnterConfigurationName("Test" + service);
        WhenIPressButtonInServiceConfiguration("OK");
        WhenIPressRecentlyModifiedConfiguration();
        WhenIPressButtonInServiceConfiguration("Activate");
        WhenIPressRecentlyModifiedConfiguration();
        WhenIPressButtonInServiceConfiguration("Edit");
        WhenIPressInServiceConfiguration("Edit base");
        ScrollToAndPressTheElement("Down", serviceProviderBase);
        WhenIPressCloseButtonInServiceProviderFromHeader();
        ScrollToAndPressTheElement("Down", pluginName);
    }

    [Given(@"I am in Dynamic service provider page after enabling '(.*)'")]
    public void GivenIAmInDynamicServiceProviderPageAfterEnabling(string service)
    {
        ScrollToAndPressTheElement("Down", "ManageApplicationMode. ManageApplicationModePlugin");
        GivenICheckCheckbox(service);
        GivenIPressInManageApplicationMode("Continue");
        ScrollToAndPressTheElement("Down", "DynamicServiceProviderConfiguration. DynamicServiceProviderConfigurationPlugin");
    }
}