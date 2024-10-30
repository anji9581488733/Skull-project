using System;
using System.Transactions;
using Gleipner.Namespaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using Polaris.Base;

namespace Gleipner.Controls.Text
{
    internal sealed class Texts : Text
    {
        /// <summary>
        ///     Gets the App version and build from the running app
        /// </summary>
        public string AppVersionBuild
        {
            get
            {
                var appVersion = driver.Capabilities.GetCapability("appVersion").ToString();
                var buildNumber = driver.Capabilities.GetCapability("buildNumber").ToString();
                var appVersionBuild = appVersion + buildNumber;
                return appVersionBuild;
            }
        }

        /// <summary>
        ///     Gets the AppName from the running app
        /// </summary>
        public string AppName
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                {
                    var appName = driver.Capabilities.GetCapability("AppName").ToString();
                }

                else

                {
                    var appName = driver.Capabilities.GetCapability("AppName").ToString();
                }

                return AppName;
            }
        }

        #region Welcome screen

        /// <summary>
        ///     Welcome text header on welcome page
        /// </summary>


        public IWebElement Welcome
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Welcome']");
                else
                    element = driver.FindElementByAccessibilityId("Welcome");
                return element;
            }
        }

        #endregion

        #region Card fields

        public int CardSurroundingsVolumeRight
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();

                var element = int.Parse(driver
                    .FindElement(MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == '3'`]")).Text);
                return element;
            }
        }

        #endregion
        
        #region Top ribbon bar

        /*
         * See region for Program Overview sharing most label queries.
         *
         */

        #endregion
        
        #region Getting started / Entry flow

        /// <summary>
        ///     Getting connected page title
        /// </summary>
        public IWebElement ConnectedTitle
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElementByAccessibilityId("Connecting your hearing aids");
                return element;
            }
        }


        /// <summary>
        ///     Gets the title on More page.
        /// </summary>
        /// <value>The page title.</value>

        public IWebElement MenuTitle
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.view.ViewGroup[@resource-id='dk.resound.smart3d:id/header']//android.widget.TextView[@text='Guiding tips']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'Guiding tips'`]"));
                return element;
            }
        }

        public IWebElement AboutMenuTitle
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='About']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'About'`]"));
                return element;
            }
        }

        public IWebElement ManufacturingTitle
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Manufacturer']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'Manufacturer'`]"));
                return element;
            }
        }

        public IWebElement TermsAndConditionsTitle
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Terms and Conditions']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'Terms and Conditions'`]"));
                return element;
            }
        }

        public IWebElement PrivacyPolicyTitle
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='PRIVACY POLICY']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'PRIVACY POLICY'`]"));
                return element;
            }
        }

        public IWebElement SupportTitle
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Support']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'Support'`]"));
                return element;
            }
        }

        #endregion
        
        #region AllowBluetooth

        /// <summary>
        ///     AllowBluetoothPage Header.
        /// </summary>
        public string AllowBluetoothHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.AllowBluetoothPage.Header",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     AllowBluetoothPage BodyText1.
        /// </summary>
        public string AllowBluetoothBodyText1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.AllowBluetoothPage.Header",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ToggleAirplaneModePage Header.
        /// </summary>
        public string ToggleAirplaneModePageHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ToggleAirplaneModePage.Header",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ToggleAirplaneModePage BodyText1.
        /// </summary>
        public string ToggleAirplaneModePageBodyText1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ToggleAirplaneModePage.BodyText1",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     AllowBluetoothFromAppSettingsPage Header.
        /// </summary>
        public string AllowBluetoothFromAppSettingsPageHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.AllowBluetoothFromAppSettingsPage.Header",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     AllowBluetoothFromAppSettingsPage BodyText1.
        /// </summary>
        public string AllowBluetoothFromAppSettingsPageBodyText1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.AllowBluetoothPage.BodyText1",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        #endregion
        
        #region Pairing
        
        /// <summary>
        ///     MFiFullyConnectedPage Header.
        /// </summary>
        public string MFiFullyConnectedHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.MFiFullyConnectedPage.Header",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     MFiFullyConnectedPage BodyText1.
        /// </summary>
        public string MFiFullyConnectedBodyText1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.MFiFullyConnectedPage.BodyText1",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ConnectingPage Header.
        /// </summary>
        public string ConnectingPageHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ConnectingPage.Header",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ConnectingPage BodyText1.
        /// </summary>
        public string ConnectingPageBodyText1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ConnectingPage.BodyText1",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ConnectingDuringTrustedBondPage Header.
        /// </summary>
        public string ConnectingDuringTrustedBondPageHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ConnectingDuringTrustedBondPage.Title",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ConnectingDuringTrustedBondPage BodyText1.
        /// </summary>
        public string ConnectingDuringTrustedBondPageBodyText1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ConnectingDuringTrustedBondPage.DescriptionText",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ConnectedFailedPage Header.
        /// </summary>
        public string ConnectedFailedPageHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ConnectionFailedPage.Header",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ConnectedFailedPage BodyText1.
        /// </summary>
        public string ConnectedFailedPageBodyText1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ConnectionFailedPage.BodyText1",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ConnectedFailedPage BodyText2.
        /// </summary>
        public string ConnectedFailedPageBodyText2 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ConnectionFailedPage.BodyText2",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     RestartDevicesDuringTrustedBondPage Header.
        /// </summary>
        public string RestartDevicesDuringTrustedBondPageHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.RestartDevicesDuringTrustedBondPage.Header",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     RestartDevicesDuringTrustedBondPage BodyText1.
        /// </summary>
        public string RestartDevicesDuringTrustedBondPageBodyText1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.RestartDevicesDuringTrustedBondPage.BodyText1",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     TrustedBondCompletedPage Header.
        /// </summary>
        public string TrustedBondCompletedPageHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.TrustedBondCompletedPage.Header",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     TrustedBondCompletedPage BodyText1.
        /// </summary>
        public string TrustedBondCompletedPageBodyText1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.TrustedBondCompletedPage.BodyText1",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     WaitingForBootPage Header.
        /// </summary>
        public string WaitingForBootPageHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.WaitingForBootPage.Header",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     WaitingForBootPage BodyText1.
        /// </summary>
        public string WaitingForBootPageBodyText1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.WaitingForBootPage.BodyText1",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ToggleAirplaneModeGuidePage Header.
        /// </summary>
        public string ToggleAirplaneModeGuidePageHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ToggleAirplaneModeGuidePage.Title",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ToggleAirplaneModeGuidePage BodyText1.
        /// </summary>
        public string ToggleAirplaneModeGuidePageBodyText1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ToggleAirplaneModeGuidePage.BodyText1",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ToggleAirplaneModeGuidePage Step1.
        /// </summary>
        public string ToggleAirplaneModeGuidePageStep1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ToggleAirplaneModeGuidePage.Step1",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ToggleAirplaneModeGuidePage Step2.
        /// </summary>
        public string ToggleAirplaneModeGuidePageStep2 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ToggleAirplaneModeGuidePage.Step2",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ToggleAirplaneModeGuidePage Step3.
        /// </summary>
        public string ToggleAirplaneModeGuidePageStep3 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ToggleAirplaneModeGuidePage.Step3",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        #endregion

        #region TestSinglePlugin

        /// <summary>
        ///     State text ID.
        /// </summary>
        public string DisplayMessagePageHeaderText => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.DisplayMessageNamespace}.DisplayMessagePage.HeaderText",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.DisplayMessageNamespace}.DisplayMessagePage.HeaderText",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///     Plugin status text ID.
        /// </summary>
        public string DisplayMessagePageBody1Text => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.DisplayMessageNamespace}.DisplayMessagePage.Body1Text",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.DisplayMessageNamespace}.DisplayMessagePage.Body1Text",
            _ => throw new NotImplementedException(),
        };
        
        #endregion
        
        #region ConsentPart1
        
        /// <summary>
        ///     ConsentPart1 Header.
        /// </summary>
        public string ConsentPart1Header => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PocConsentNamespace}.ConsentPart1Page.ConsentPart1Header",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.PocConsentNamespace}.ConsentPart1Page.ConsentPart1Header",
            _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ConsentPart1 Body1.
        /// </summary>
        public string ConsentPart1Body1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PocConsentNamespace}.ConsentPart1Page.ConsentPart1Body1",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.PocConsentNamespace}.ConsentPart1Page.ConsentPart1Body1",
            _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ConsentPart1 Body2.
        /// </summary>
        public string ConsentPart1Body2 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PocConsentNamespace}.ConsentPart1Page.ConsentPart1Body2",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.PocConsentNamespace}.ConsentPart1Page.ConsentPart1Body2",
            _ => throw new NotImplementedException(),
        };
        
        #endregion
        
        #region ComponentTest
        
        public string ComponentTestState => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.ComponentTestNamespace}.StartPage.HeaderText",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.ComponentTestNamespace}.StartPage.HeaderText",
            _ => throw new NotImplementedException(),
        };
        
        public string ComponentTestStatus => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => 
                $"{NAPNamespaces.ComponentTestNamespace}.StartPage.Body1Text",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.ComponentTestNamespace}.StartPage.Body1Text",
            _ => throw new NotImplementedException(),
        };
        
        public string ComponentTestResult => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => 
                $"{NAPNamespaces.ComponentTestNamespace}.StartPage.TestResultJson",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.ComponentTestNamespace}.StartPage.TestResultJson",
            _ => throw new NotImplementedException(),
        };
            
        public string PermissionRequestDeniedComponentTests => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS or
                SettingsBase.PlatformType.Android => "//XCUIElementTypeStaticText[@label=\"PermissionRequestDeniedComponentTests\"]",
            _ => throw new NotImplementedException(),
        };
            
        public string PermissionRequestGrantedComponentTests => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS or 
                SettingsBase.PlatformType.Android => "//XCUIElementTypeStaticText[@label=\"PermissionRequestGrantedComponentTests\"]", 
            _ => throw new NotImplementedException(),
        };
        
        public string Arrange => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS or 
                SettingsBase.PlatformType.Android => "Arrange", 
            _ => throw new NotImplementedException(),
        };
        
        #endregion

        #region ConsentPart2
        
        /// <summary>
        ///     ConsentPart2 Header.
        /// </summary>
        public string ConsentPart2Header => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.ConsentPart2Header",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.ConsentPart2Header",
            _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ConsentPart2 Body1.
        /// </summary>
        public string ConsentPart2Body1 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.ConsentPart2Body1",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.ConsentPart2Body1",
            _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     ConsentPart2 Body2.
        /// </summary>
        public string ConsentPart2Body2 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.ConsentPart2Body2",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.ConsentPart2Body2",
            _ => throw new NotImplementedException(),
        };
        
        #endregion

        #region Native

        /// <summary>
        ///     Native settings Header.
        /// </summary>
        public string NativeSettingsHeader => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Settings",
            SettingsBase.PlatformType.Android or
            _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     Selector for Searching in hearing devices.
        /// </summary>
        public string Searching => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Searching…",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     Selector for Connected Text in hearing devices.
        /// </summary>
        public string Connected => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Connected",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     Selector for Connected Text in hearing devices.
        /// </summary>
        public string NotPaired => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Not Paired",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     Selector for R Text in HI menu.
        /// </summary>
        public string R => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "R",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     Selector for L Text in HI menu.
        /// </summary>
        public string L => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "L",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     Locator for Allow App To Access.
        /// </summary>
        public string AllowAppToAccess => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS when PlatformCapabilities.AppPathPackage.Contains("TestSinglePlugin") => "Allow Test Single Plugin To Access",
            SettingsBase.PlatformType.iOS when PlatformCapabilities.AppPathPackage.Contains("TestMultiplePlugins") => "Allow Test Multiple Plugins To Access",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        #endregion
        
        #region TermsAndConditions
        
        //TermsAndConditions BodyText
        
        public string TermsAndConditionsBodyText => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.ReadTermsAndConditionsNamespace}.TermsAndConditionsPage.Page",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.ReadTermsAndConditionsNamespace}.MenuPage.Page",
            _ => throw new NotImplementedException(),
        };
        
        #endregion
        
        #region ReadPrivacyPolicy
        
        //verify ReadPrivacyPolicy Link
        public string ReadPrivacyPolicyLinkText => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.ReadPrivacyPolicyNamespace}.ReadPrivacyPolicy.Pages.ReadPrivacyPolicyPage.PrivacyPolicyCta",
            // SettingsBase.PlatformType.Android => "",
            _ => throw new NotImplementedException(),
        };
        
        //verify PrivacyPolicy Header
        
        public string PrivacyPolicyHeaderId => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "PageTitle",
            SettingsBase.PlatformType.Android => $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.ReadPrivacyPolicyNamespace}.ReadPrivacyPolicyPage.ReadLegalTextButton",
            _ => throw new NotImplementedException(),
        };
        
        //verify PrivacyPolicy Body
        public string PrivacyPolicyBodyId => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.ReadPrivacyPolicyNamespace}.ReadPrivacyPolicy.Pages.ReadPrivacyPolicyPage.PrivacyPolicyBody",
            // SettingsBase.PlatformType.Android => "PrivacyPolicyBody.ReadLegalTextButton",
            _ => throw new NotImplementedException(),
        };
        
        #endregion
        
        #region NavigationBar
    
        public string BackButtonID => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.ReadPrivacyPolicyNamespace}.ReadPrivacyPolicy.Pages.ReadPrivacyPolicyPage.BackButton",
            SettingsBase.PlatformType.Android => "back",
            _ => throw new NotImplementedException(),
        };
        
        public string HeaderTextID => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Privacy Policy",
            SettingsBase.PlatformType.Android => "PageTitle",
            _ => throw new NotImplementedException(),
        };
        
        public string CloseButtonID => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "",
            SettingsBase.PlatformType.Android => "",
            _ => throw new NotImplementedException(),
        };
        #endregion
        
        #region MenuPage
        
        //verify MenuPage title
        
        public string MenuPageTitle => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "MenuPage",
            SettingsBase.PlatformType.Android => "new UiSelector().text(\"MenuPage\")",
            _ => throw new NotImplementedException(),
        };
         #endregion
    }
    
}
