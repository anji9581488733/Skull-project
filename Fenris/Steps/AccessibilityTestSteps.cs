using System;
using Fenris.Steps.Base;
using Gleipner.Controls.Button;
using Gleipner.Pages.Native;
using NUnit.Framework;
using Polaris.Base;
using Reqnroll;

namespace Fenris.Steps;

[Binding]
public class AccessibilityTestSteps: StepsBase
{
    private int _initialSize;
    

    [When(@"I move the slider to '(.*)' percent")]
    public void WhenIMoveTheSliderToPercent(int percent)
    {
        try
        {
            var accessibilityPage = new NativeAccessibilityPage();
            accessibilityPage.ResetSliderToZero(new Buttons().LargerTextSlider, LocatorStrategy.XPath);
            accessibilityPage.MoveSliderToPercentage(new Buttons().LargerTextSlider, percent, LocatorStrategy.XPath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }

    [Then(@"The text size of '(.*)' should be modified")]
    public void ThenTheTextSizeOfShouldBeModified(string button)
    {
        try
        {
            var accessibilityPage = new NativeAccessibilityPage();
            int modifiedSize = accessibilityPage.GetTextSize(button);
            Assert.AreNotEqual(_initialSize, modifiedSize, $"Expected text size of {button} to be modified but it remained the same");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }

    [Given(@"I get the initial text size of '(.*)'")]
    public void GivenIGetTheInitialTextSizeOf(string button)
    {
        try
        { 
            var accessibilityPage = new NativeAccessibilityPage();
            _initialSize = accessibilityPage.GetTextSize(button);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }

    [When(@"I press '(.*)' toggle on '(.*)'")]
    public void WhenIPressToggleOn(string button, string nativeAccessibilityPage)
    {
        var accessibilityPage = new NativeAccessibilityPage();
        try
        {
            accessibilityPage.HandleLargerAccessibilitySizes();
            ClickOnElement(accessibilityPage.FindElement(button));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }

    [Given(@"I terminate the plugin app")]
    public void GivenITerminateThePluginApp()
    {
        try
        { 
            AppInitializer.terminateApp(PlatformCapabilities.AppPathPackage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }

    [When(@"I reset the slider to '(.*)' percent")]
    public void WhenIResetTheSliderToPercent(string p0)
    {
        try
        { 
            var accessibilityPage = new NativeAccessibilityPage();
            accessibilityPage.ResetSliderToZero(new Buttons().LargerTextSlider, LocatorStrategy.XPath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Assert.Fail(e.Message);
        }
    }
}