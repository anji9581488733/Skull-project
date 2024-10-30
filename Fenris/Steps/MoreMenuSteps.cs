using System;
using System.Threading;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages.MoreMenu;
using NUnit.Framework;
using Polaris.Base;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public class MoreMenuSteps : StepsBase
    {
        [When(@"I press '(.*)' switch on More menu")]
        [When(@"I press '(.*)' switch")]
        public void WhenIPressSwitch(string menu)
        {
            try
            {
                var morePage = new MorePage();
                switch (menu)
                {
                    case "Guiding tips":
                        ClickOnElement(morePage.GuidingTipsSwitch);
                        Reporting.Log("Pass", "guiding tips switch pressed");
                        break;
                    case "Auto-activate favorite locations":
                        ClickOnElement(morePage.AutoActivateLocation);
                        Reporting.Log("Pass", "favorite locations switch pressed");
                        break;
                    default:
                        throw new ArgumentException();
                }

                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in  WhenIPressSwitch : " + e.Message);
                throw;
            }
        }


        [When(@"I press more menu item '(.*)'")]
        public void WhenIPressMoreMenuItem(string menu)
        {
            try
            {
                var morePage = new MorePage();
                switch (menu)
                {
                    case "About":
                        ClickOnElement(morePage.About);
                        Reporting.Log("Pass", "About menu item pressed");
                        break;
                    case "Legal information":

                        ClickOnElement(morePage.LegalInformation);
                        Reporting.Log("Pass", "Legal information menu item pressed");
                        break;
                    case "Support":
                        ClickOnElement(morePage.Support);
                        Reporting.Log("Pass", "Support menu item pressed");
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in WhenIPressMoreMenuItem : " + e.Message);
                throw;
            }
        }


        [Then(@"validate '(.*)' switch is on")]
        public void Validateswitcheson(string menuswitch)
        {
            try
            {
                var morePage = new MorePage();
                switch (menuswitch)
                {
                    case "Guiding tips":
                        if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                        {
                            Assert.IsTrue(Status_GuideForAndroid(morePage.GuidingTips));
                            Reporting.Log("Pass", "guiding tips mode switch is on");
                        }
                        else
                        {
                            Assert.IsTrue(Status_Guide(morePage.GuidingTips));
                            Reporting.Log("Pass", "guiding tips mode switch is on");
                        }

                        break;

                    case "Auto-activate favorite locations":
                        if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                        {
                            Assert.IsTrue(Status_favoritesForAndroid(morePage.AutoActivateLocation));
                            Reporting.Log("Pass", "Auto-activate locations switch is on");
                        }
                        else
                        {
                            Assert.IsTrue(Status_favorites(morePage.AutoActivateLocation));
                            Reporting.Log("Pass", "Auto-activate locations switch is on");
                        }

                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in  Validateswitcheson : " + e.Message);
                throw;
            }
        }


        /// <summary>
        ///     Validate switch is disabled
        /// </summary>
        [Then(@"validate '(.+)' is disabled on More page")]
        public void ThenValidateIsDisabledOnMorePage(string menuswitch)
        {
            try
            {
                var morePage = new MorePage();
                switch (menuswitch)
                {
                    case "Guiding tips":
                        Assert.IsFalse(morePage.GuidingTips.Enabled);
                        break;

                    case "Auto-activate favorite locations":
                        Assert.IsFalse(morePage.AutoActivateLocation.Enabled);
                        break;
                    default:
                        throw new ArgumentException();
                }

                Reporting.Log("Pass", menuswitch + " switch is disabled.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] : " + menuswitch + " is not disabled. " + e.Message);
                throw;
            }
        }

        /// <summary>
        ///     Validate that the switch is off
        /// </summary>
        [Then(@"validate '(.*)' switch is off")]
        public void Validateswitchesoff(string menuswitch)
        {
            try
            {
                var morePage = new MorePage();

                switch (menuswitch)
                {
                    case "Guiding tips":
                        if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                        {
                            Assert.IsTrue(Status_GuideForAndroid(morePage.GuidingTips));
                            Reporting.Log("Pass", "guiding tips mode switch is on");
                        }
                        else
                        {
                            Assert.IsTrue(Status_Guide(morePage.GuidingTips));
                            Reporting.Log("Pass", "guiding tips mode switch is on");
                        }

                        break;
                    case "Auto-activate favorite locations":
                        Assert.IsFalse(Status_favorites(morePage.AutoActivateLocation));
                        Reporting.Log("Pass", "Auto-activate locations switch is off");
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in  Validateswitchesoff : " + e.Message);
                throw;
            }
        }

        [Then(@"validate '(.*)' title is displayed on More page")]
        public void ThenValidateTitleIsDisplayedOnMorePage(string title)
        {
            try
            {
                var morePage = new MorePage();
                Assert.AreEqual(title, morePage.Title.Text);
                Reporting.Log("Pass", "More title is displayed on More page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in  ThenValidateTitleIsDisplayedOnMorePage : " + e.Message);
                throw;
            }
        }


        [When(@"I press Legal information item '(.*)'")]
        public void GivenPressLegalInformationItemu(string menu)
        {
            try
            {
                var legalInformationPage = new LegalInformationPage();

                switch (menu)
                {
                    case "MANUFACTURER":
                        ClickOnElement(legalInformationPage.Manufacturer);
                        Reporting.Log("Pass", "Manufacturer menu item pressed");
                        break;
                    case "TERMS AND CONDITIONS":
                        ClickOnElement(legalInformationPage.Terms_and_conditions);
                        Reporting.Log("Pass", "terms and conditions menu item pressed");
                        break;

                    case "PRIVACY POLICY":
                        ClickOnElement(legalInformationPage.Privacypolicy);
                        Reporting.Log("Pass", "Privacy Policy menu item pressed");
                        break;
                    default:
                        throw new ArgumentException();
                }

                Reporting.Log("Pass", "Clicked Legal Information menu item " + menu);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in  GivenPresMoreMenuItemu : " + e.Message);
                throw;
            }
        }


        [Then(@"validate page title is displayed on More page")]
        public void ThenValidatePageTitleIsDisplayedOnMorePage()
        {
            try
            {
                var morePage = new MorePage();
                Assert.True(IsElementDisplayed(morePage.Title));
                Reporting.Log("Pass", "More title is displayed on More page");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to find title on More page : " + e.Message);
                throw;
            }
        }

        [Then(@"validate '(.*)' menu item is displayed on More page")]
        public void ThenValidateMenuItemIsDisplayedOnMorePage(string menu)
        {
            try
            {
                var morePage = new MorePage();
                switch (menu)
                {
                    case "About":
                        Assert.IsTrue(IsElementDisplayed(morePage.About));
                        break;

                    case "Legal information":
                        Assert.IsTrue(IsElementDisplayed(morePage.LegalInformation));
                        break;

                    case "Support":
                        Assert.IsTrue(IsElementDisplayed(morePage.Support));
                        break;

                    default:
                        throw new ArgumentException("Unknown menu " + menu);
                }

                Reporting.Log("Pass", menu + " Menu is displayed on More page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", menu + " Menu is not displayed on More page. " + e.Message);
                throw;
            }
        }

        [Then(@"validate '(.*)' switch is displayed on More page")]
        public void ValidateSwitchIsDisplayedOnMorePage(string menuswitch)
        {
            try
            {
                var morePage = new MorePage();

                switch (menuswitch)
                {
                    case "Guiding tips":
                        Assert.IsTrue(IsElementDisplayed(morePage.GuidingTips));
                        break;

                    case "Auto-activate favorite locations":
                        Assert.IsTrue(IsElementDisplayed(morePage.AutoActivateLocation));
                        break;

                    default:
                        throw new ArgumentException();
                }

                Reporting.Log("Pass", menuswitch + " Switch is displayed on More page.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", menuswitch + " Switch is not displayed on More page. " + e.Message);
                throw;
            }
        }
    }
}