using System;
using Gleipner.Controls;
using OpenQA.Selenium;
using Polaris.Base;

namespace Gleipner.Pages.UIGallery;

public class UiGalleryCheckboxPage : PageBase
{
    public IWebElement FirstCheckbox => new Checkboxes().Checkbox1;
    public IWebElement SecondCheckbox => new Checkboxes().Checkbox2;
    public IWebElement ThirdCheckbox => new Checkboxes().Checkbox3;
    public IWebElement FourthCheckbox => new Checkboxes().Checkbox4;
    
    public override IWebElement FindElement(string elementName) => elementName switch
    {
        "Checkbox1" => FirstCheckbox,
        "Checkbox2" => SecondCheckbox,
        "Checkbox3" => ThirdCheckbox,
        "Checkbox4" => FourthCheckbox,
        _ => throw new Exception($"{elementName} is NOT supported")
    };
}