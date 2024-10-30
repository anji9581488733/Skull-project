using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using Gleipner.Controls.Link;
using Gleipner.Controls.Text;
using OpenQA.Selenium;

namespace Gleipner.Pages.Plugins.ReadPrivacyPolicyPage;

public class ReadPrivacyPolicyPage : PageBase
{
    public override IWebElement FindElement(string elementName)
    {
        return driver.FindElementById(GetAutomationID(elementName));
    }
    
    public override string GetAutomationID(string elementName)
    {
        return elementName switch
        {
            
            "PrivacyPolicyLink" => new Texts().ReadPrivacyPolicyLinkText,
            "ReadPPBackButton" => new Buttons().clickBackButton,
            "MenuPageTitle" => new Texts().MenuPageTitle,
            "PP_HeaderId"=> new Texts().PrivacyPolicyHeaderId,
            "PP_BodyId"=> new Texts().PrivacyPolicyBodyId,
            _ => throw new Exception($"{elementName} is NOT supported")
        };
    }
    
   
}
