using System;
using Gleipner.Base;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.Plugins.TestMultiplePlugins
{
    public class TestMultiplePluginsMenuPage : PageBase
    {
        public override IWebElement FindElement(string elementName)
        {
            return driver.FindElementById(GetAutomationID(elementName));
        }

        public override string GetAutomationID(string elementName)
        {
            return elementName switch
            {
                "AcceptTermsAndConditionsPlugin" => new Buttons().AcceptTermsAndConditionsPlugin,
                "AdjustSoundPlugin" => new Buttons().AdjustSoundPlugin,
                "AdjustVolumePlugin" => new Buttons().AdjustVolumePlugin,
                "AssemblyListPlugin" => new Buttons().AssemblyListPlugin,
                "AssistLiveGuidePlugin" => new Buttons().AssistLiveGuidePlugin,
                "BackgroundLocationPermissionPlugin" => new Buttons().BackgroundLocationPermissionPlugin,
                "BluetoothPermissionPlugin" => new Buttons().BluetoothPermissionPlugin,
                "CameraPermissionPlugin" => new Buttons().CameraPermissionPlugin,
                "CloudRegistrationPlugin" => new Buttons().CloudRegistrationPlugin,
                "ComponentTestPlugin" => new Buttons().ComponentTestPlugin,
                "DisplayMessagePlugin" => new Buttons().DisplayMessagePlugin,
                "DynamicServiceProviderConfigurationPlugin" => new Buttons().DynamicServiceProviderConfigurationPlugin,
                "FontListPlugin" => new Buttons().FontListPlugin,
                "ForegroundLocationPermissionPlugin" => new Buttons().ForegroundLocationPermissionPlugin,
                "FullscreenNotificationPermissionPlugin" => new Buttons().FullscreenNotificationPermissionPlugin,
                "HearingTestPlugin" => new Buttons().HearingTestPlugin,
                "HearingTestWelcomePlugin" => new Buttons().HearingTestWelcomePlugin,
                "HiFirmwareUpdateIntegrationPlugin" => new Buttons().HiFirmwareUpdateIntegrationPlugin,
                "ManageApplicationModePlugin" => new Buttons().ManageApplicationModePlugin,
                "MicrophonePermissionPlugin" => new Buttons().MicrophonePermissionPlugin,
                "PairingPlugin" => new Buttons().PairingPlugin,
                "PhonePermissionPlugin" => new Buttons().PhonePermissionPlugin,
                "POCConsentPlugin" => new Buttons().POCConsentPlugin,
                "PrepareAssistLivePlugin" => new Buttons().PrepareAssistLivePlugin,
                "PushNotificationPermissionPlugin" => new Buttons().PushNotificationPermissionPlugin,
                "ReadPrivacyPolicyPlugin" => new Buttons().ReadPrivacyPolicyPlugin,
                "ReadTermsAndConditionsPlugin" => new Buttons().ReadTermsAndConditionsPlugin,
                "RemoteFineTuningPlugin" => new Buttons().RemoteFineTuningPlugin,
                "RemoteServiceRequestPlugin" => new Buttons().RemoteServiceRequestPlugin,
                "SelectProgramsPlugin" => new Buttons().SelectProgramsPlugin,
                "SkinningPlugin" => new Buttons().SkinningPlugin,
                "TestAppSDKBootstrapperPlugin" => new Buttons().TestAppSDKBootstrapperPlugin,
                "ClearConsentPart1Plugin" => new Buttons().ClearConsentPart1Plugin,
                "ClearConsentPart2Plugin" => new Buttons().ClearConsentPart2Plugin,
                "DisplayConsentStatusPlugin" => new Buttons().DisplayConsentStatusPlugin,
                "TinnitusPlugin" => new Buttons().TinnitusPlugin,
                _ => throw new Exception($"{elementName} is NOT supported")
            };
        }
    }
}