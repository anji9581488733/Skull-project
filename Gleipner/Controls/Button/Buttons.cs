using System;
using Gleipner.Namespaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Appium.PageObjects.Attributes.Abstract;
using Polaris.Base;

namespace Gleipner.Controls.Button
{
    public class Buttons : Button
    {
        //////////////////////////////////////////////////////////////
        //
        // Bottom menu buttons
        //
        //////////////////////////////////////////////////////////////

        #region Bottom Menu

        /// <summary>
        ///     Home button on bottom ribbon bar
        /// </summary>

        public IWebElement BottomRibbonBarHome
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("home_tab");
                else
                    element = driver.FindElementByAccessibilityId("Home");
                return element;
            }
        }

        /// <summary>
        ///     Status button on bottom ribbon bar
        /// </summary>

        public IWebElement BottomRibbonBarStatus
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("icon_status_default_s");
                else
                    element = driver.FindElementByAccessibilityId("icon_status_default_s");
                return element;
            }
        }

        /// <summary>
        ///     My ReSound button on bottom ribbon bar
        /// </summary>


        public IWebElement BottomRibbonMyResound
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("personal_tab");
                else
                    element = driver.FindElementByAccessibilityId("My ReSound");
                return element;
            }
        }

        /// <summary>
        ///     More button on bottom ribbon bar
        /// </summary>

        public IWebElement BottomRibbonBarMore
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("more_tab");
                else
                    element = driver.FindElementByAccessibilityId("More");
                return element;
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        //
        // Welcome page buttons
        //
        //////////////////////////////////////////////////////////////

        #region Welcome page

        /// <summary>
        ///     Yes, connect now button on welcome page
        /// </summary>

        public IWebElement ConnectNow
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("connect_button");
                else
                    element = driver.FindElementByXPath("//XCUIElementTypeButton[@name='Yes, connect now']");
                return element;
            }
        }

        /// <summary>
        ///     Always Allow popup on welcome page
        /// </summary>

        public IWebElement AlwaysAllow
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElementByAccessibilityId("Allow While Using App");
                return element;
            }
        }

        /// <summary>
        ///     Change Always popup on welcome page
        /// </summary>

        public IWebElement ChangeAlways
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElementByAccessibilityId("Change to Always Allow");
                return element;
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        //
        // CARD BUTTONS
        //
        //////////////////////////////////////////////////////////////

        #region Card Buttons

        public IWebElement SmartButtonAllAroundNoiseFilter
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //To-do as there is no unique attribute to create relative xpath
                    element = driver.FindElementByXPath(
                        "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/androidx.viewpager.widget.ViewPager/android.view.ViewGroup/android.widget.FrameLayout/androidx.viewpager.widget.ViewPager/android.view.ViewGroup/android.widget.LinearLayout/android.widget.TextView[1]");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Noise filter'`][1]"));
                return element;
            }
        }


        /// <summary>
        ///     Noise filter Smart button on/off status on All-Around program card
        /// </summary>
        public bool SmartButtonAllAroundNoiseFilterSelected
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                {
                    //To-do as there is no unique attribute to create relative xpath
                    var res = IsElementSelected(driver.FindElementByXPath(
                        "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/androidx.viewpager.widget.ViewPager/android.view.ViewGroup/android.widget.FrameLayout/androidx.viewpager.widget.ViewPager/android.view.ViewGroup/android.widget.LinearLayout/android.widget.TextView[1]"));

                    if (!res)
                        return false;
                    return true;
                }
                else
                {
                    var res = IsElementSelected(driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Noise filter'`][1]")));

                    if (!res)
                        return false;
                    return true;
                }
            }
        }


        public IWebElement SmartButtonAllAroundSpeechClarity
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //To-do as there is no unique attribute to create relative xpath
                    element = driver.FindElementByXPath(
                        "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/androidx.viewpager.widget.ViewPager/android.view.ViewGroup/android.widget.FrameLayout/androidx.viewpager.widget.ViewPager/android.view.ViewGroup/android.widget.LinearLayout/android.widget.TextView[2]");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Speech clarity'`]"));
                return element;
            }
        }


        /// <summary>
        ///     Speech clarity Smart button on/off status on All-Around program card
        /// </summary>
        public bool SmartButtonAllAroundSpeechClaritySelected
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                {
                    //To-do as there is no unique attribute to create relative xpath
                    var res = IsElementSelected(driver.FindElementByXPath(
                        "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/androidx.viewpager.widget.ViewPager/android.view.ViewGroup/android.widget.FrameLayout/androidx.viewpager.widget.ViewPager/android.view.ViewGroup/android.widget.LinearLayout/android.widget.TextView[2]"));

                    if (!res)
                        return false;
                    return true;
                }
                else
                {
                    var res = IsElementSelected(
                        driver.FindElement(
                            MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Speech clarity'`]")));

                    if (!res)
                        return false;
                    return true;
                }
            }
        }


        /// <summary>
        ///     Sound Enhancer button on card pages.
        /// </summary>


        public IWebElement SoundEnhancer
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("dk.resound.smart3d:id/finetune_button");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Sound Enhancer'`]"));
                return element;
            }
        }

        /// <summary>
        ///     Split merged volume bar for hearing aids
        /// </summary>
        public IWebElement SplitVolumeBarsHearingAids
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("dk.resound.smart3d:id/SplitImageView_bottom");
                else
                    element = driver.FindElementByAccessibilityId("icon split2 s");
                return element;
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // TINNITUS MANAGER
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region Tinnitus Manager

        /// <summary>
        ///     Switches to Tinnitus Manager on Sound Enhancer page.
        /// </summary>


        public IWebElement TinnitusManagerSwitch
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.widget.LinearLayout[@resource-id='dk.resound.smart3d:id/finetune_tabpane']//android.widget.TextView[@text='Tinnitus Manager']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Tinnitus Manager'`]"));
                return element;
            }
        }

        public IWebElement TSGAmplitudeSlightVariation
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElement(MobileBy.IosClassChain(
                    "**/XCUIElementTypeWindow/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[1]/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeImage[2]"));
                return element;
            }
        }

        /// <summary>
        ///     Tinnitus Manager page, Calming Waves mode.
        /// </summary>

        public IWebElement CalmingWaves
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElementByXPath(
                    "//XCUIElementTypeApplication[@name='Smart 3D']/XCUIElementTypeWindow/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[1]/XCUIElementTypeOther/XCUIElementTypeOther[3]/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeImage[3]");
                return element;
            }
        }


        /// <summary>
        ///     Tinnitus Manager page, Breaking Waves mode.
        /// </summary>


        public IWebElement BreakingWaves
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();

                element = driver.FindElementByXPath(
                    "//XCUIElementTypeApplication[@name='Smart 3D']/XCUIElementTypeWindow/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[1]/XCUIElementTypeOther/XCUIElementTypeOther[3]/XCUIElementTypeOther/XCUIElementTypeOther[6]/XCUIElementTypeImage[3]");
                return element;
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // DIALOG BOX BUTTONS
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region Dialog Box Buttons

        // New implementations of buttons for each dialog box ( need to be done when adding iOS )


        public IWebElement PricePointDialogOk
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'OK'`]"));
                return element;
            }
        }


        /// <summary>
        ///     No thanks button on dialog box. Used on QuickTour dialogs and Rate My Sound Elaborate page
        /// </summary>


        public IWebElement DialogConsentNoThanks
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='No thanks']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'No thanks'`]"));
                return element;
            }
        }


        public IWebElement GettingConnectedAreTheseYourHearingAidsYes
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Yes']");
                else
                    throw new NotImplementedException();
                return element;
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Common menu buttons
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region Common menu

        public IWebElement Close
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.widget.TextView[@text='Program overview']/following-sibling::*[@class='android.view.ViewGroup']");
                else
                    element = driver.FindElementByAccessibilityId("icon close m");
                return element;
            }
        }

        public IWebElement CloseButton
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.widget.TextView[@text='Volume control']/following-sibling::*[@class='android.view.ViewGroup']");
                else
                    element = driver.FindElementByAccessibilityId("icon close m");
                return element;
            }
        }

        public IWebElement CloseButtonGN
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.widget.TextView[@text='GN Online Services']/following-sibling::*[@class='android.view.ViewGroup']");
                else
                    element = driver.FindElementByAccessibilityId("icon close m");
                return element;
            }
        }

        /// <summary>
        ///     Back button on all menu pages.
        /// </summary>

        public IWebElement Back
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.view.ViewGroup[@resource-id='dk.resound.smart3d:id/personal_header']/child::*[@class='android.view.ViewGroup']");
                else
                    element = driver.FindElementByAccessibilityId("icon arrow back m");
                return element;
            }
        }

        /// <summary>
        ///     Back button on all menu pages.
        /// </summary>

        public IWebElement BackButton
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.view.ViewGroup[@resource-id='dk.resound.smart3d:id/header']/child::*[@class='android.view.ViewGroup']");
                else
                    element = driver.FindElementByAccessibilityId("icon arrow back m");
                return element;
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // My Resound page
        //
        ////////////////////////////////////////////////////////////////////////////////////////////


        #region my menu page

        /// <summary>
        ///     Learn about the app menu item on My ReSound menu.
        /// </summary>


        public IWebElement LearnAboutApp
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Learn about the app']");
                else
                    element = driver.FindElementByAccessibilityId("Learn about the app");
                return element;
            }
        }

        /// <summary>
        ///     Guiding tips menu item on My ReSound menu.
        /// </summary>


        public IWebElement GuidingTips
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Guiding tips']");
                else
                    element = driver.FindElementByAccessibilityId("Guiding tips");
                return element;
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Status Page
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Top menu bar program buttons 
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region top menu program buttons

        public IWebElement AllAround
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("dk.resound.smart3d:id/card_title");
                else
                    element = driver.FindElementByAccessibilityId("All-Around");
                return element;
            }
        }

        public IWebElement AllAroundTop
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//(androidx.recyclerview.widget.RecyclerView[@resource-id='dk.resound.smart3d:id/top_carousel']//android.widget.ImageView[@resource-id='dk.resound.smart3d:id/preset_item_icon'])[1]");
                else
                    throw new NotImplementedException();
                return element;
            }
        }


        public IWebElement HearInNoise
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("dk.resound.smart3d:id/card_title");
                else
                    element = driver.FindElementByAccessibilityId("Hear in Noise");
                return element;
            }
        }

        public IWebElement HearInNoiseTop
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//(androidx.recyclerview.widget.RecyclerView[@resource-id='dk.resound.smart3d:id/top_carousel']//android.widget.ImageView[@resource-id='dk.resound.smart3d:id/preset_item_icon'])[2]");
                else
                    throw new NotImplementedException();
                return element;
            }
        }


        public IWebElement Outdoor
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("dk.resound.smart3d:id/card_title");
                else
                    element = driver.FindElementByAccessibilityId("Outdoor");
                return element;
            }
        }

        public IWebElement OutdoorTop
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//(androidx.recyclerview.widget.RecyclerView[@resource-id='dk.resound.smart3d:id/top_carousel']//android.widget.ImageView[@resource-id='dk.resound.smart3d:id/preset_item_icon'])[3]");
                else
                    throw new NotImplementedException();
                return element;
            }
        }


        public IWebElement Music
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("dk.resound.smart3d:id/card_title");
                else
                    element = driver.FindElementByAccessibilityId("Music");
                return element;
            }
        }

        public IWebElement MusicTop
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//(androidx.recyclerview.widget.RecyclerView[@resource-id='dk.resound.smart3d:id/top_carousel']//android.widget.ImageView[@resource-id='dk.resound.smart3d:id/preset_item_icon'])[4]");
                else
                    throw new NotImplementedException();
                return element;
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Program overview
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region Program overview

        public IWebElement ProgramOverview
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("dk.resound.smart3d:id/program_overview_drag_button");
                else
                    element = driver.FindElementByAccessibilityId("button_allprogram");
                return element;
            }
        }

        /// <summary>
        ///     All-Around program button on Program overview
        /// </summary>


        public IWebElement ProgramOverviewAllAround
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "(//androidx.recyclerview.widget.RecyclerView[@resource-id='dk.resound.smart3d:id/program_overview_recyclerview']//android.widget.ImageView[@resource-id='dk.resound.smart3d:id/preset_item_icon'])[1]");
                else
                    throw new NotImplementedException();
                return element;
            }
        }


        /// <summary>
        ///     HearInNoise program button on Program overview
        /// </summary>
        public IWebElement ProgramOverviewHearInNoise
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "(//androidx.recyclerview.widget.RecyclerView[@resource-id='dk.resound.smart3d:id/program_overview_recyclerview']//android.widget.ImageView[@resource-id='dk.resound.smart3d:id/preset_item_icon'])[2]");
                else
                    throw new NotImplementedException();
                return element;
            }
        }


        /// <summary>
        ///     Outdoor program button on Program overview
        /// </summary>
        public IWebElement ProgramOverviewOutdoor
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "(//androidx.recyclerview.widget.RecyclerView[@resource-id='dk.resound.smart3d:id/program_overview_recyclerview']//android.widget.ImageView[@resource-id='dk.resound.smart3d:id/preset_item_icon'])[3]");
                else
                    throw new NotImplementedException();
                return element;
            }
        }


        /// <summary>
        ///     Music program button on Program overview
        /// </summary>
        public IWebElement ProgramOverviewMusic
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "(//androidx.recyclerview.widget.RecyclerView[@resource-id='dk.resound.smart3d:id/program_overview_recyclerview']//android.widget.ImageView[@resource-id='dk.resound.smart3d:id/preset_item_icon'])[4]");
                else
                    throw new NotImplementedException();
                return element;
            }
        }


        public IWebElement StartFromBeginningButton
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Start from the beginning']");
                else
                    element = driver.FindElementByAccessibilityId("Start from the beginning");
                return element;
            }
        }

        #endregion


        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Edit program
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region Edit program

        /// <summary>
        ///     Start button on GN Online Services page
        /// </summary>

        public IWebElement Start
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("dk.resound.smart3d:id/wizard_page_control_footer");
                else
                    throw new NotImplementedException();
                return element;
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Sound enhancer
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region Sound Enhancer

        /// <summary>
        ///     SoundEnhancer page, close page.
        ///     Also works on Tinnitus Manager page.
        /// </summary>
        public IWebElement SoundEnhancerClose
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.view.ViewGroup[@resource-id='dk.resound.smart3d:id/finetune_header']/child::*[@class='android.view.ViewGroup']");
                else
                    element = driver.FindElementByAccessibilityId("icon close m");
                return element;
            }
        }


        /// <summary>
        ///     Reset button on Sound Enhancer page, reset to defaults.
        ///     Also works on Tinnitus Manager page.
        /// </summary>

        public IWebElement SoundEnhancerReset
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Reset'`]"));
                return element;
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // More menu page
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region More menu page

        /// <summary>
        ///     About menu item from the more menu
        /// </summary>

        public IWebElement About
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='About']");
                else
                    element = driver.FindElementByAccessibilityId("About");
                return element;
            }
        }

        /// <summary>
        ///     Legal information menu item from the more menu
        /// </summary>

        public IWebElement Legal_information
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Legal information']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'Legal information'`]"));
                return element;
            }
        }

        /// <summary>
        ///     Support menu item from the more menu
        /// </summary>

        public IWebElement Support
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Support']");
                else
                    element = driver.FindElementByAccessibilityId("Support");
                return element;
            }
        }

        /// <summary>
        ///     Manufacturer menu item on Legal information menu
        /// </summary>

        public IWebElement Manufacturer
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='MANUFACTURER']");
                else
                    element = driver.FindElementByAccessibilityId("MANUFACTURER");
                return element;
            }
        }

        /// <summary>
        ///     Terms and conditions menu item on Legal information menu
        /// </summary>

        public IWebElement TermsAndConditions
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='TERMS AND CONDITIONS']");
                else
                    element = driver.FindElementByAccessibilityId("TERMS AND CONDITIONS");
                return element;
            }
        }

        /// <summary>
        ///     Privacy policy menu item on Legal information menu
        /// </summary>

        public IWebElement PrivacyPolicy
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='PRIVACY POLICY']");
                else
                    element = driver.FindElementByAccessibilityId("PRIVACY POLICY");
                return element;
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Guiding tips
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region Guiding tips

        /// <summary>
        ///     'Back to tips' button common for all Guiding tips nudging dialogs.
        /// </summary>
        public IWebElement NudgingTipBackToArchiveButton
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Back to tips']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Back to tips'`]"));
                return element;
            }
        }


        /// <summary>
        ///     'Got it' button common for all Guiding tips nudging dialogs.
        /// </summary>


        public IWebElement NudgingTipConfirmButton
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Got it']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Got it'`]"));
                return element;
            }
        }


        /// <summary>
        ///     'OK button on Please Notice dialog
        /// </summary>
        public IWebElement PleaseNoticeDialogOK
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementById("dk.resound.smart3d:id/custom_dialog_buttons_container");
                else
                    element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'OK'`]"));
                return element;
            }
        }

        /// <summary>
        ///     Button for "Music program" on Programs section of Guiding tips on My ReSound.
        ///     Button is generated on the fly by the app, so it has to be in view before it is accessible.
        /// </summary>

        public IWebElement NudgingFunctionalTip1Week3Header
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Music program']");
                else
                    element = driver.FindElementByAccessibilityId("Music program");
                return element;
            }
        }


        /// <summary>
        ///     Button for "Noise filter" on Quick Buttons section of Guiding tips on My ReSound.
        ///     Button is generated on the fly by the app, so it has to be in view before it is accessible.
        /// </summary>

        public IWebElement NudgingFunctionalTip1Week5Header
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Noise filter']");
                else
                    element = driver.FindElementByAccessibilityId("Noise filter");
                return element;
            }
        }

        #endregion


        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Learn about the app
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region learn about the app

        public IWebElement LearnAboutTheAppVolumeControl
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Volume control']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'Volume control'`]"));
                return element;
            }
        }


        public IWebElement LearnAboutTheAppVolumeControlNextButton
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'Next'`]"));
                return element;
            }
        }


        /// <summary>
        ///     Learn about the app next button on help page
        /// </summary>

        public IWebElement LearnAboutTheAppNextButton
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Next']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'Next'`]"));
                return element;
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Entry flow
        //
        ////////////////////////////////////////////////////////////////////////////////////////////

        #region Entry flow / Getting connected

        /// <summary>
        ///     Skip button on Notifications page on iOS.
        /// </summary>

        public IWebElement NotificationSkip
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Skip'`]"));
                return element;
            }
        }


        /// <summary>
        ///     Skip button on Notifications page on iOS.
        /// </summary>

        public IWebElement NotificationContinue
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Continue'`]"));
                return element;
            }
        }

        /// <summary>
        ///     Allow button on Notifications page on iOS.
        /// </summary>
        public IWebElement NotificationAllow
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Allow'`]"));
                return element;
            }
        }

        /// <summary>
        ///     Continue button on Getting connected page.
        /// </summary>


        public IWebElement Continue
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.widget.TextView[contains(@text,'Continue')]/parent::*[@class='android.view.ViewGroup']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Continue'`]"));
                return element;
            }
        }

        /// <summary>
        ///     "Hearing aids with replaceable batteries" button on Getting connected page.
        /// </summary>

        public IWebElement HIReplaceableBatteries
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath(
                        "//android.widget.TextView[@text='Hearing aids with replaceable batteries']");
                else
                    element = driver.FindElementByAccessibilityId("Hearing aids with replaceable batteries");
                return element;
            }
        }

        #endregion


        /// <summary>
        ///     'Go!' button for Guiding tips Your Experience Level page.
        /// </summary>
        public IWebElement GoButton
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Go!']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'Go!'`]"));
                return element;
            }
        }


        /// <summary>
        ///     'Quite experienced' button for Guiding tips Your Experience Level page.
        /// </summary>

        public IWebElement QuiteExperiencedButton
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Quite experienced']");
                else
                    element = driver.FindElementByAccessibilityId("Quite experienced");
                return element;
            }
        }

        #endregion


        #region Request assistance

        /// <summary>
        ///     Next button for Request assistance 'BEFORE WE BEGIN', 'DEFINE YOUR PROBLEM', 'WHEN IS IT OCCURRING' 'HOW SEVERE IS
        ///     THE PROBLEM' pages
        /// </summary>

        public IWebElement RequestAssistanceNext
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.TextView[@text='Next']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == 'Next'`]"));
                return element;
            }
        }

        #endregion

        #region Terms And Conditions Page

        /// <summary>
        ///     Continue button on Terms and conditions page.
        /// </summary>

        public IWebElement TermsAndConditionsContinueButton
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "//android.widget.TextView[contains(@text,'Continue')]/parent::*[@class='android.view.ViewGroup']");
                else
                    element = driver.FindElementByXPath("//XCUIElementTypeButton[@name='Continue']");
                return element;
            }
        }


        /// <summary>
        ///     Scroll to buttom button on Terms and conditions page.
        /// </summary>

        public IWebElement ScrollToBottomButton
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "//android.widget.TextView[@text='Scroll to bottom']/parent::*[@class='android.view.ViewGroup']");
                else
                    element = driver.FindElementByXPath("//XCUIElementTypeButton[@name='Scroll to bottom']");
                return element;
            }
        }

        #endregion

        /// <summary>
        ///     Allow Bluetooth button on Getting connected page.
        /// </summary>

        public IWebElement Allow
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    throw new NotImplementedException();
                element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Allow'`]"));
                return element;
            }
        }


        /// <summary>
        ///     Secure pairing OK button on Getting connected page.
        /// </summary>

        public IWebElement SecuredPairingOK
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "//android.widget.TextView[@text='OK']/parent::*[@class='android.view.ViewGroup']");
                else
                    element = driver.FindElement(MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'OK'`]"));
                return element;
            }
        }


        /// <summary>
        ///     Getting connected Well done Start button on Getting connected page.
        /// </summary>


        public IWebElement WellDoneStart
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "//android.widget.TextView[@text='Start']/parent::*[@class='android.view.ViewGroup']");
                else
                    element = driver.FindElement(
                        MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == 'Start'`]"));
                return element;
            }
        }


        /// <summary>
        ///     Allow Device Location for the Android Devices.
        /// </summary>


        public IWebElement AllowDeviceLocation
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    //Todo in the new app to remove the app-name from xpath
                    element = driver.FindElementByXPath(
                        "//android.widget.TextView[@text='Allow']/parent::*[@class='android.view.ViewGroup']");
                else
                    throw new NotImplementedException();
                return element;
            }
        }

        /// <summary>
        ///     Allow Location Access on the popup for the Android Devices.
        /// </summary>


        public IWebElement AllowLocationAccess
        {
            get
            {
                if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                    element = driver.FindElementByXPath("//android.widget.Button[@text='Allow']");
                else
                    throw new NotImplementedException();
                return element;
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////
        //
        // PLUGINS BUTTONS
        //
        //////////////////////////////////////////////////////////////

        #region TestMultiplePlugins

        /// <summary>
        ///    Locate AcceptTermsAndConditionsPlugin.
        /// </summary>
        public string AcceptTermsAndConditionsPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.AcceptTermsAndConditionsPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.AcceptTermsAndConditionsPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate AdjustSoundPlugin.
        /// </summary>
        public string AdjustSoundPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.AdjustSoundPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.AdjustSoundPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate AdjustVolumePlugin.
        /// </summary>
        public string AdjustVolumePlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.AdjustVolumePlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.AdjustVolumePlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate AssemblyListPlugin.
        /// </summary>
        public string AssemblyListPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.AssemblyListPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.AssemblyListPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate AssistLiveGuidePlugin.
        /// </summary>
        public string AssistLiveGuidePlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.AssistLiveGuidePlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.AssistLiveGuidePlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate BackgroundLocationPermissionPlugin.
        /// </summary>
        public string BackgroundLocationPermissionPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.BackgroundLocationPermissionPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.BackgroundLocationPermissionPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate BluetoothPermissionPlugin.
        /// </summary>
        public string BluetoothPermissionPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.BluetoothPermissionPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.BluetoothPermissionPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate CameraPermissionPlugin.
        /// </summary>
        public string CameraPermissionPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.CameraPermissionPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.CameraPermissionPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate CloudRegistrationPlugin.
        /// </summary>
        public string CloudRegistrationPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.CloudRegistrationPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.CloudRegistrationPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate ComponentTestPlugin.
        /// </summary>
        public string ComponentTestPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ComponentTestPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ComponentTestPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate DisplayMessagePlugin.
        /// </summary>
        public string DisplayMessagePlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.DisplayMessagePlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.DisplayMessagePlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate DynamicServiceProviderConfigurationPlugin.
        /// </summary>
        public string DynamicServiceProviderConfigurationPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.DynamicServiceProviderConfigurationPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.DynamicServiceProviderConfigurationPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate FontListPlugin.
        /// </summary>
        public string FontListPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.FontListPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.FontListPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate ForegroundLocationPermissionPlugin.
        /// </summary>
        public string ForegroundLocationPermissionPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ForegroundLocationPermissionPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ForegroundLocationPermissionPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate FullscreenNotificationPermissionPlugin.
        /// </summary>
        public string FullscreenNotificationPermissionPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.FullscreenNotificationPermissionPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.FullscreenNotificationPermissionPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate HearingTestPlugin.
        /// </summary>
        public string HearingTestPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.HearingTestPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.HearingTestPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate HearingTestWelcomePlugin.
        /// </summary>
        public string HearingTestWelcomePlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.HearingTestWelcomePlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.HearingTestWelcomePlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate HiFirmwareUpdateIntegrationPlugin.
        /// </summary>
        public string HiFirmwareUpdateIntegrationPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.HiFirmwareUpdateIntegrationPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.HiFirmwareUpdateIntegrationPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate ManageApplicationModePlugin.
        /// </summary>
        public string ManageApplicationModePlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ManageApplicationModePlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ManageApplicationModePlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate MicrophonePermissionPlugin.
        /// </summary>
        public string MicrophonePermissionPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.MicrophonePermissionPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.MicrophonePermissionPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate PairingPlugin.
        /// </summary>
        public string PairingPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.PairingPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.PairingPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate PhonePermissionPlugin.
        /// </summary>
        public string PhonePermissionPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.PhonePermissionPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.PhonePermissionPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate POCConsentPlugin.
        /// </summary>
        public string POCConsentPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.POCConsentPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.POCConsentPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate PrepareAssistLivePlugin.
        /// </summary>
        public string PrepareAssistLivePlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.PrepareAssistLivePlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.PrepareAssistLivePlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate PushNotificationPermissionPlugin.
        /// </summary>
        public string PushNotificationPermissionPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.PushNotificationPermissionPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.PushNotificationPermissionPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate ReadPrivacyPolicyPlugin.
        /// </summary>
        public string ReadPrivacyPolicyPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ReadPrivacyPolicyPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ReadPrivacyPolicyPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate ReadTermsAndConditionsPlugin.
        /// </summary>
        public string ReadTermsAndConditionsPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ReadTermsAndConditionsPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ReadTermsAndConditionsPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate RemoteFineTuningPlugin.
        /// </summary>
        public string RemoteFineTuningPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.RemoteFineTuningPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.RemoteFineTuningPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate RemoteServiceRequestPlugin.
        /// </summary>
        public string RemoteServiceRequestPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.RemoteServiceRequestPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.RemoteServiceRequestPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate SelectProgramsPlugin.
        /// </summary>
        public string SelectProgramsPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.SelectProgramsPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.SelectProgramsPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate SkinningPlugin.
        /// </summary>
        public string SkinningPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.SkinningPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.SkinningPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate TestAppSDKBootstrapperPlugin.
        /// </summary>
        public string TestAppSDKBootstrapperPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.TestAppSDKBootstrapperPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.TestAppSDKBootstrapperPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate ClearConsentPart1Plugin.
        /// </summary>
        public string ClearConsentPart1Plugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ClearConsentPart1Plugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ClearConsentPart1Plugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate ClearConsentPart2Plugin.
        /// </summary>
        public string ClearConsentPart2Plugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ClearConsentPart2Plugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.ClearConsentPart2Plugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate DisplayConsentStatusPlugin.
        /// </summary>
        public string DisplayConsentStatusPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.DisplayConsentStatusPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.DisplayConsentStatusPlugin",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate TinnitusPlugin.
        /// </summary>
        public string TinnitusPlugin => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.TinnitusPlugin",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.TestMultiplePluginsMenuPageNamespace}.MenuPage.MenuItem.TinnitusPlugin",
            _ => throw new NotImplementedException(),
        };
        
        #endregion

        #region Display Message Plugin

        /// <summary>
        ///    Locate the Start plugin button.
        /// </summary>
        public string DisplayMessagePagePrimaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                $"{NAPNamespaces.DisplayMessageNamespace}.DisplayMessagePage.PrimaryButton",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.DisplayMessageNamespace}.DisplayMessagePage.PrimaryButton",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate the Back plugin button.
        /// </summary>
        public string DisplayMessagePageBackButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.DisplayMessageNamespace}.DisplayMessagePage.BackButton",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.DisplayMessageNamespace}.DisplayMessagePage.BackButton",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate the Close plugin button.
        /// </summary>
        public string DisplayMessagePageCloseButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.DisplayMessageNamespace}.DisplayMessagePage.CloseButton",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.DisplayMessageNamespace}.DisplayMessagePage.CloseButton",
            _ => throw new NotImplementedException(),
        };

        #endregion

        #region Assembly List Plugin

        /// <summary>
        ///    Locate Copy Assembly List button on Assembly List Plugin.
        /// </summary>
        public string AssemblyListPageCopyAssemblyListButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                $"{NAPNamespaces.AssemblyListNamespace}.AssemblyListPage.CopyAssemblyListButton",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.AssemblyListNamespace}.AssemblyListPage.CopyAssemblyListButton",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Close button on Assembly List Plugin.
        /// </summary>
        public string AssemblyListPageCloseButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.AssemblyListNamespace}.AssemblyListPage.CloseButton",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.AssemblyListNamespace}.AssemblyListPage.CloseButton",
            _ => throw new NotImplementedException(),
        };

        #endregion

        #region UIGallery

        /// <summary>
        ///    Locate Button Page on UIGallery Plugin.
        /// </summary>
        public IWebElement ButtonPageStart => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                driver.FindElementByAccessibilityId("Button. ButtonPlugin"),
            // SettingsBase.PlatformType.Android => _ ,
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Checkbox Page on UIGallery Plugin.
        /// </summary>
        public IWebElement CheckboxPageStart => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                driver.FindElementByAccessibilityId("CheckBox. CheckBoxPlugin"),
            // SettingsBase.PlatformType.Android => _ ,
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Primary Style Button on UIGallery Plugin.
        /// </summary>
        public IWebElement PrimaryStyle => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                driver.FindElementByAccessibilityId(
                    $"{NAPNamespaces.UiGalleryNamespace}.ButtonPage.PrimarySampleButton"),
            // SettingsBase.PlatformType.Android => _ ,
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Secondary Style Button on UIGallery Plugin.
        /// </summary>
        public IWebElement SecondaryStyle => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                driver.FindElementByAccessibilityId(
                    $"{NAPNamespaces.UiGalleryNamespace}.ButtonPage.SecondarySampleButton"),
            // SettingsBase.PlatformType.Android => _ ,
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Discrete Style Button on UIGallery Plugin.
        /// </summary>
        public IWebElement DiscreteStyle => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                driver.FindElementByAccessibilityId(
                    $"{NAPNamespaces.UiGalleryNamespace}.ButtonPage.DiscreteSampleButton"),
            // SettingsBase.PlatformType.Android => _ ,
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Navigation Bar Style Button on UIGallery Plugin.
        /// </summary>
        public IWebElement NavigationBarStyle => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                driver.FindElementByAccessibilityId(
                    $"{NAPNamespaces.UiGalleryNamespace}.ButtonPage.NavigationBarSampleButton"),
            // SettingsBase.PlatformType.Android => _ ,
            _ => throw new NotImplementedException(),
        };

        #endregion

        #region ConsentPart1

        /// <summary>
        ///    Locate the Scroll to bottom button.
        /// </summary>
        public string ConsentPart1PageSecondaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PocConsentNamespace}.ConsentPart1Page.SecondaryButton",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.PocConsentNamespace}.ConsentPart1Page.SecondaryButton",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate the Accept And Continue Part1 button.
        /// </summary>
        public string ConsentPart1PagePrimaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PocConsentNamespace}.ConsentPart1Page.PrimaryButton",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.PocConsentNamespace}.ConsentPart1Page.PrimaryButton",
            _ => throw new NotImplementedException(),
        };

        #endregion

        #region ConsentPart2

        /// <summary>
        ///    Locate the Scroll to bottom button.
        /// </summary>
        public string ConsentPart2PageSecondaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.SecondaryButton",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.SecondaryButton",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate the Accept And Continue Part2 button
        /// </summary>
        public string ConsentPart2PageAcceptConsentPart2 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.AcceptConsentPart2",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.AcceptConsentPart2",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate the Decline button.
        /// </summary>
        public string ConsentPart2PageDeclineConsentPart2 => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                $"{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.DeclineConsentPart2",
            SettingsBase.PlatformType.Android =>
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.PocConsentNamespace}.ConsentPart2Page.DeclineConsentPart2",
            _ => throw new NotImplementedException(),
        };

        #endregion

        #region Allow Bluetooth

        public string AllowBluetoothPagePrimaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.AllowBluetoothPage.PrimaryButton",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        #endregion

        #region Allow Bluetooth From App Settings

        /// <summary>
        /// AllowBluetoothFromAppSettingsPage PrimaryButton.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public string AllowBluetoothFromAppSettingsPagePrimaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                $"{NAPNamespaces.PairingNamespace}.AllowBluetoothFromAppSettingsPage.PrimaryButton",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        #endregion

        #region Toggle Airplane Mode

        public string ToggleAirplaneModePagePrimaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ToggleAirplaneModePage.PrimaryButton",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        public string ToggleAirplaneModePageTertiaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ToggleAirplaneModePage.TertiaryButton",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        #endregion

        #region MFiFullyConnected

        /// <summary>
        ///     MFiFullyConnectedPage PrimaryButton.
        /// </summary>
        public string MFiFullyConnectedPrimaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.MFiFullyConnectedPage.PrimaryButton",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///     MFiFullyConnectedPage TertiaryButton.
        /// </summary>
        public string MFiFullyConnectedTertiaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.MFiFullyConnectedPage.TertiaryButton",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///     RestartDevicesDuringTrustedBondPage TertiaryButton.
        /// </summary>
        public string RestartDevicesDuringTrustedBondTertiaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                $"{NAPNamespaces.PairingNamespace}.RestartDevicesDuringTrustedBondPage.TertiaryButton",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///     TrustedBondCompletedPage PrimaryButton.
        /// </summary>
        public string TrustedBondCompletedPagePrimaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.TrustedBondCompletedPage.PrimaryButton",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///     WaitingForBootPage PrimaryButton.
        /// </summary>
        public string WaitingForBootPagePrimaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.WaitingForBootPage.PrimaryButton",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///     ConnectedFailedPage PrimaryButton.
        /// </summary>
        public string ConnectedFailedPagePrimaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ConnectionFailedPage.PrimaryButton",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///     ConnectedFailedPage TertiaryButton.
        /// </summary>
        public string ConnectedFailedPageTertiaryButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"{NAPNamespaces.PairingNamespace}.ConnectionFailedPage.TertiaryButton",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        #endregion

        //////////////////////////////////////////////////////////////
        //
        // NATIVE BUTTONS
        //
        //////////////////////////////////////////////////////////////

        #region NativeButtons

        /// <summary>
        ///    Locate Bluetooth button.
        /// </summary>
        public string Bluetooth => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Bluetooth",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Accessibility button.
        /// </summary>
        public string Accessibility => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Accessibility",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Return to Settings button.
        /// </summary>
        public string ReturnToSettings => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "**/XCUIElementTypeButton[`label == \"Settings\"`]",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        /// Allow button for Bluetooth on Android
        /// </summary>
        public string AllowBluetooth => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Allow",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// Deny button for Bluetooth on Android
        /// </summary>
        public string DenyBluetooth => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Don’t Allow",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Hearing Devices button.
        /// </summary>
        public string HearingDevices => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "HEARING_AID_TITLE",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate HI Devices button using HIName from Config.
        /// </summary>
        public string HIName => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => $"**/XCUIElementTypeStaticText[`name == \"{SettingsBase.HIName}\"`]",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Forget this device button.
        /// </summary>
        public string ForgetThisDevice => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "**/XCUIElementTypeStaticText[`name == \"Forget this device\"`]",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Forget button.
        /// </summary>
        public string Forget => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Forget",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///    Locate Pair button.
        /// </summary>
        public string Pair => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "**/XCUIElementTypeButton[`name == \"Pair\"`]",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };

        #endregion

        #region ComponentTest

        /// <summary>
        ///    Button to start execution only for selected grup of tests.
        /// </summary>
        public string ComponentTestRunSelectedButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS or 
                SettingsBase.PlatformType.Android => "Run selected",
            _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///    Grant Permisson button / Positive Button for Component tests.
        /// </summary>
        public string ComponentTestPositiveButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => 
                $"{NAPNamespaces.ComponentTestNamespace}.StartPage.PositiveButton",
            SettingsBase.PlatformType.Android => 
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.ComponentTestNamespace}.StartPage.PositiveButton",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        ///   Negative Button for Component tests.
        /// </summary>
        public string ComponentTestNegativeButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS =>
                $"{NAPNamespaces.ComponentTestNamespace}.StartPage.NegativeButton",
            SettingsBase.PlatformType.Android => 
                $"com.ReSound.{PlatformCapabilities.AppType}:id/{NAPNamespaces.ComponentTestNamespace}.StartPage.NegativeButton",
            _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///     'OK button on For Allow Permissions
        /// </summary>
        public IWebElement OK => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => driver.FindElementById(
            "ReSound.App.Legolas.Plugins.ComponentTest.Pages.StartPage.PositiveButton"),
            SettingsBase.PlatformType.Android or
            _ => throw new NotImplementedException(),
        };
        
        
        #endregion
        
        //////////////////////////////////////////////////////////////
        //
        // Accessibility Test
        //
        //////////////////////////////////////////////////////////////
        
        #region AccessibilityTest
        
        /// <summary>
        ///    Locate Display & Text Size button.
        /// </summary>
        public string DisplayTextSize => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Display & Text Size",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///    Locate Larger Text button.
        /// </summary>
        public string LargerTextButton => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "Larger Text",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///    Locate Larger Text button.
        /// </summary>
        public string LargerAccessibilitySizes => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "**/XCUIElementTypeSwitch[`label == \"Larger Accessibility Sizes\"`]",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        
        /// <summary>
        ///    Locate Larger Text Slider.
        /// </summary>
        public string LargerTextSlider => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "//XCUIElementTypeSlider",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
        
        /// <summary>
        ///    Locate Settings button
        /// </summary>
        public string Settings => SettingsBase.Platform switch
        {
            SettingsBase.PlatformType.iOS => "**/XCUIElementTypeButton[`label == \"Settings\"`]",
            SettingsBase.PlatformType.Android or
                _ => throw new NotImplementedException(),
        };
       
        #endregion
        
       #region BackButton&CloseButton
       
       /// <summary>
       ///    Locate BacK Button
       /// </summary>
       public string clickBackButton => SettingsBase.Platform switch
       {
           SettingsBase.PlatformType.iOS => $"{NAPNamespaces.ReadPrivacyPolicyNamespace}.ReadPrivacyPolicy.Pages.ReadPrivacyPolicyPage.BackButton",
           // SettingsBase.PlatformType.Android =>"",
           _ => throw new NotImplementedException(),
       };
       
       public string clickCloseButton => SettingsBase.Platform switch
       {
           SettingsBase.PlatformType.iOS => "Close",
           // SettingsBase.PlatformType.Android =>"",
           _ => throw new NotImplementedException(),
       };
       
       #endregion
       
       
}
}