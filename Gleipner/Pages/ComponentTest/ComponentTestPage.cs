using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;
using System;
using Gleipner.Controls.Image;

namespace Gleipner.Pages.ComponentTest;

public class ComponentTestPage : PageBase
{
    public override IWebElement FindElement(string elementName)
    {
        return elementName switch
        {
            "NotificationAlert" => driver.FindElementByClassName("XCUIElementTypeAlert"),
            "PermissionRequestDeniedComponentTests" => driver.FindElementByXPath(new Texts().PermissionRequestDeniedComponentTests),
            "PermissionRequestGrantedComponentTests" => driver.FindElementByXPath(new Texts().PermissionRequestGrantedComponentTests),
            _ => driver.FindElementById(GetAutomationID(elementName)),
        };
    }
    
    public override string GetAutomationID(string elementName)
    {
        return elementName switch
        {
            "Arrange" => new Texts().Arrange,
            "Run selected" => new Buttons().ComponentTestRunSelectedButton,
            "PermissionRequestDeniedComponentTests" => new Texts().PermissionRequestDeniedComponentTests,
            "PermissionRequestGrantedComponentTests" => new Texts().PermissionRequestGrantedComponentTests,
            "ComponentTestState" => new Texts().ComponentTestState,
            "Component Test Status" => new Texts().ComponentTestStatus,
            "ComponentTestResult" => new Texts().ComponentTestResult,
            "ComponentTestPositiveButton" => new Buttons().ComponentTestPositiveButton, 
            "ComponentTestNegativeButton" => new Buttons().ComponentTestNegativeButton, 
            "ActivityIndicator" => new Images().ActivityIndicator,
            "NotificationAlert" => new Images().NotificationAlert,
            _ => throw new Exception($"{elementName} is NOT supported")
        };
    }
}