using System;
using Gleipner.Controls.Text;
using Gleipner.Namespaces;
using Polaris.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
namespace Gleipner.Controls.Link;

public class Links : Link
{
    #region TestMultiplePlugins
    
    //ReadPrivacyPolicy Link//
    
        public string ReadPrivacyPolicyLinkText => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "ReadPrivacyPolicy_TranslationPack_PrivacyPolicyCta",
            // SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.ReadPrivacyPolicyNamespace}.ReadPrivacyPolicyPage.ReadLegalTextButton",
            _ => throw new NotImplementedException(),
        };

    #endregion
}