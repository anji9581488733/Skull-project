using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Appium.PageObjects.Attributes.Abstract;
using Polaris.Base;

namespace Gleipner.Controls.ServiceProviderControls;

public class ServiceproviderControls: ControlBase
{
    public IWebElement ServiceByName(string Service) => SettingsBase.Platform switch
    {
        SettingsBase.PlatformType.iOS => driver.FindElementByName(
            Service),
        _ => throw new NotImplementedException(),
    };
    public IWebElement CheckElementByLabel(string Label) => SettingsBase.Platform switch
    {
        SettingsBase.PlatformType.iOS => driver.FindElementByXPath("//XCUIElementTypeStaticText[@label='"+Label+"']"),
        _ => throw new NotImplementedException(),
    };
    public IWebElement ClickElementByLabel(string Label) => SettingsBase.Platform switch
    {
        SettingsBase.PlatformType.iOS => driver.FindElementByXPath("//XCUIElementTypeStaticText[@label='"+Label+"']"),
        _ => throw new NotImplementedException(),
    };
    public IWebElement ClickElementByName(string Label) => SettingsBase.Platform switch
    {
        SettingsBase.PlatformType.iOS => driver.FindElementByXPath("//XCUIElementTypeButton[@name='"+Label+"']"),
        _ => throw new NotImplementedException(),
    };
    public IWebElement TextBoxByType => SettingsBase.Platform switch
    {
        SettingsBase.PlatformType.iOS => driver.FindElementByXPath("//XCUIElementTypeStaticText"),
        _ => throw new NotImplementedException(),
    };
    public IWebElement ClickElementByPartialtext(string Text) => SettingsBase.Platform switch
    {
        SettingsBase.PlatformType.iOS => driver.FindElementByXPath("//*[contains(@name,'"+Text+"')]"),
        _ => throw new NotImplementedException(),
    };
    public IWebElement ServiceByXPath(string Service) => SettingsBase.Platform switch
    {
        SettingsBase.PlatformType.iOS => driver.FindElementByName(
            Service),
        _ => throw new NotImplementedException(),
    };
}