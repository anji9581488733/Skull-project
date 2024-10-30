using System;
using Gleipner.Base;
using OpenQA.Selenium;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
namespace Gleipner.Pages.Plugins.CloseHeaderPage;

public class CloseHeaderPage : PageBase
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
            "closeButtonText" => new Texts().CloseButtonID,
            "MenuPageHeader" => new Texts().MenuPageTitle,
            "closeButton"=> new Buttons().clickBackButton,
            _ => throw new Exception($"{elementName} is NOT supported")
        };
    }
    public bool IsCloseButtonDisplayed()
    {
        var backButton = FindElement("closeButtonText");
        return backButton.Displayed;
    }
    public bool IsBackButtonNotDisplayed()
    {
        try
        {
            var closeButton = FindElement("backButtonText");
            return !closeButton.Displayed;
        }
        catch (NoSuchElementException)
        {
            return true;
        }
    }
    
    public bool IsHeaderDisplayed(string elementId)
    {
        var headerElement = FindElement("Header");
        return headerElement.Displayed;
    }
    
    public void PressCloseButton()
    {
        try
        {
            ClickOnElement(FindElement("closeButton"));
        }
        catch (Exception e)
        {
            throw new Exception($"Unable to click Back button: {e.Message}", e);
        }
    }
}