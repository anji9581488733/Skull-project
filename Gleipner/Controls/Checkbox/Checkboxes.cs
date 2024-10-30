using System;
using OpenQA.Selenium;
using Polaris.Base;

namespace Gleipner.Controls;

internal class Checkboxes : Checkbox
{
    #region UIGallery

    private const string UiGalleryCheckboxNamespace =
        "ReSound.App.Legolas.Plugins.UISamples.CheckBox.Pages.CheckboxPage";

    
    /// <summary>
    ///    Locate Checkbox1 on UIGallery Plugin.
    /// </summary>
    public IWebElement Checkbox1 => SettingsBase.Platform switch
    {
        SettingsBase.PlatformType.iOS => 
            driver.FindElementByAccessibilityId($"{UiGalleryCheckboxNamespace}.Checkbox1"),
        // SettingsBase.PlatformType.Android => _ ,
        _ => throw new NotImplementedException(),
    };
    
    /// <summary>
    ///    Locate Checkbox2 on UIGallery Plugin.
    /// </summary>
    public IWebElement Checkbox2 => SettingsBase.Platform switch
    {
        SettingsBase.PlatformType.iOS => 
            driver.FindElementByAccessibilityId($"{UiGalleryCheckboxNamespace}.Checkbox2"),
        // SettingsBase.PlatformType.Android => _ ,
        _ => throw new NotImplementedException(),
    };
    
    /// <summary>
    ///    Locate Checkbox3 on UIGallery Plugin.
    /// </summary>
    public IWebElement Checkbox3 => SettingsBase.Platform switch
    {
        SettingsBase.PlatformType.iOS => 
            driver.FindElementByAccessibilityId($"{UiGalleryCheckboxNamespace}.Checkbox3"),
        // SettingsBase.PlatformType.Android => _ ,
        _ => throw new NotImplementedException(),
    };
    
    /// <summary>
    ///    Locate Checkbox4 on UIGallery Plugin.
    /// </summary>
    public IWebElement Checkbox4 => SettingsBase.Platform switch
    {
        SettingsBase.PlatformType.iOS => 
            driver.FindElementByAccessibilityId($"{UiGalleryCheckboxNamespace}.Checkbox4"),
        // SettingsBase.PlatformType.Android => _ ,
        _ => throw new NotImplementedException(),
    };

    #endregion
}