using System;
using Gleipner.Base;
using OpenQA.Selenium;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
namespace Gleipner.Pages.Plugins.BackHeaderPage;

public class BackHeaderPage : PageBase
{
    public override IWebElement FindElement(string elementName)
    {
        return driver.FindElementById(GetAutomationID(elementName));
    }

    public override string GetAutomationID(string elementName)
    {
        return elementName switch
        {
            "backButtonText" => new Texts().BackButtonID,
            "Header" => new Texts().HeaderTextID,
            "closeButton" => new Texts().CloseButtonID,
            "backButton" => new Buttons().clickBackButton,
            "MenuPageHeader"=>new Texts().MenuPageTitle,
            _ => throw new Exception($"{elementName} is NOT supported")
        };
    }
    public bool IsCloseButtonNotDisplayed()
    {
        try
        {
            var closeButton = FindElement("closeButton");
            return !closeButton.Displayed;
        }
        catch (NoSuchElementException)
        {
            return true;
        }
    }
    public bool IsBackButtonDisplayed()
    {
        var backButton = FindElement("backButtonText");
        return backButton.Displayed;
    }
    
    public bool IsHeaderDisplayed(string elementId)
    {
        var headerElement = FindElement(elementId);
        return headerElement.Displayed;
    }
    
    public void PressBackButton()
    {
        try
        {
            ClickOnElement(FindElement("backButton"));
        }
        catch (Exception e)
        {
            throw new Exception($"Unable to click Back button: {e.Message}", e);
        }
    }
}


