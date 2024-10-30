using System;
using System.Collections.Generic;
using Gleipner.Controls.Button;
using OpenQA.Selenium;
using Polaris.Base;

namespace Gleipner.Pages.UIGallery;

public class UiGalleryButtonPage : PageBase
{
    public IWebElement PrimaryStyleButton => new Buttons().PrimaryStyle;
    public IWebElement SecondaryStyleButton => new Buttons().SecondaryStyle;
    public IWebElement DiscreteStyleButton => new Buttons().DiscreteStyle;
    public IWebElement NavigationBarStyleButton => new Buttons().NavigationBarStyle;


    public override IWebElement FindElement(string elementName) => elementName switch
    {
        "Primary Button" => PrimaryStyleButton,
        "Secondary Button" => SecondaryStyleButton,
        "Discrete Button" => DiscreteStyleButton,
        "Navigation Bar Button" => NavigationBarStyleButton,
        _ => throw new Exception($"{elementName} is NOT supported")
    };

    public List<IWebElement> GetAllElements() =>
        [PrimaryStyleButton, SecondaryStyleButton, DiscreteStyleButton, NavigationBarStyleButton];

}