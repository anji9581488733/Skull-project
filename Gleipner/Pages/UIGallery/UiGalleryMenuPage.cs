using System;
using Gleipner.Controls.Button;
using Gleipner.Controls.Text;
using OpenQA.Selenium;
using Polaris.Base;

namespace Gleipner.Pages.UIGallery;

public class UiGalleryMenuPage : PageBase
{
    public IWebElement ButtonPage => new Buttons().ButtonPageStart;
    public IWebElement CheckboxPage => new Buttons().CheckboxPageStart;
    
    public override IWebElement FindElement(string elementName)
    {
        return elementName switch
        {
            "Button Page" => ButtonPage,
            "Checkbox Page" => CheckboxPage,
            _ => throw new Exception($"{elementName} is NOT supported")
        };
    }
}