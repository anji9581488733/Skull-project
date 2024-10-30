using System;
using System.Diagnostics;
using System.Threading;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages;
using Gleipner.Pages.SoundEnhancer;
using Gleipner.Pages.SoundEnhancer.TopPricePoint.Favorites;
using Polaris.Base;
using Reqnroll;

namespace Fenris.Steps
{
    [Binding]
    public class SimulatorSteps : StepsBase
    {
        #region Preconditions

        [Given(@"I start the Android emulator")]
        public void GivenIStartAndroidEmulator()
        {
            try
            {
                var simulatorPage = new SimulatorPage();

                // Terminate running emulators to provide known good state, before starting starting emulator
                if (simulatorPage.EmulatorBooted())
                {
                    simulatorPage.KillAllEmulators();
                }

                // Launch the emulator
                simulatorPage.StartEmulator();

                Reporting.Log("Pass", "Booted Android emulator with device :" + SettingsBase.DeviceName);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Error starting up Android simulator: " + e.Message);
                throw;
            }
        }

        [Given(@"I start the simulator")]
        public void GivenIStartTheSimulator()
        {
            try
            {
                // Boot the simulator with a ID from Settings.
                var proc = new Process();

                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c " +
                                           "\"xcrun simctl boot " +
                                           SettingsBase.DeviceId +
                                           "\"";

                Console.WriteLine("xcrun simctl boot: " + proc.StartInfo.Arguments);

                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();


                // Report boot status
                var terminalOutput = "";

                while (!proc.StandardOutput.EndOfStream)
                {
                    terminalOutput = proc.StandardOutput.ReadLine();
                    Console.WriteLine("Booting " + SettingsBase.DeviceId);
                }

                proc.WaitForExit();

                Thread.Sleep(10000);

                Reporting.Log("Pass", "Booted " + SettingsBase.DeviceId);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Unable to boot simulator: " + e.Message);
                throw;
            }
        }

        [Given(@"I change language on emulator to '(.*)'")]
        [When(@"I change language on emulator to '(.*)'")]
        public void WhenIChangeSimulatorLanguage(string Language)
        {
            try
            {
                var simulatorPage = new SimulatorPage();
                simulatorPage.ChangeEmulatorLanguage(Language);
                Reporting.Log("Pass", "I change language on simulator to : " + Language);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in change SimulatorLanguage : " + e.Message);
                throw;
            }
        }

        [Given(@"I change language on iOS simulator to '(.*)' and '(.*)'")]
        public void GivenIChangeiOSLanguage(string language, string region)
        {
            try
            {
                //System.Threading.Thread.Sleep(10000);
                var arguments = language + " " + region;
                var p = new Process();
                var psi = new ProcessStartInfo();
                //System.Threading.Thread.Sleep(3000);
                psi.FileName = "/bin/bash";
                psi.Arguments = "../../ExtSupportFiles/Scripts/batch.sh " + arguments + " " + SettingsBase.DeviceId;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.CreateNoWindow = false;
                p.StartInfo = psi;
                p.ErrorDataReceived += (s, a) => Console.WriteLine("Error: " + a.Data);
                p.OutputDataReceived += (s, a) => Console.WriteLine("Output: " + a.Data);

                if (p.Start())
                {
                    Console.WriteLine("Starting: " + arguments);
                }
                else
                {
                    Console.WriteLine("Unable to start: " + arguments);
                }

                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
                p.WaitForExit();
                Reporting.Log("Pass", "Run batch command from terminal");

                //System.Threading.Thread.Sleep(5000);
            }

            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in GivenIRunCommandFromCMD :" + e.Message);
                throw;
            }
        }

        [Given(@"I uninstall the iOS app")]
        public void GivenIUninstallTheApp()
        {
            try
            {
                Console.WriteLine("Attempting to uninstall the app...");

                var proc = new Process();

                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \"xcrun simctl uninstall " + SettingsBase.DeviceId + " " +
                                           SettingsBase.AppBundleId + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                proc.WaitForExit();

                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \"xcrun simctl uninstall " + SettingsBase.DeviceId +
                                           " sh.calaba.DeviceAgent.xctrunner" + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                proc.WaitForExit();
                // debug maybe check if app is really uninstalled

                Console.WriteLine("Processes for uninstalling the app has completed.");

                Reporting.Log("Pass", "Uninstalled the app.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Unable to uninstall the app: " + e.Message);
                throw;
            }
        }


        /// <summary>
        ///     Gets the build number from the running app.
        /// </summary>
        [Given(@"I get AppBuildNumber from App")]
        [Then(@"I get AppBuildNumber from App")]
        public void AppBuildNumber()
        {
            try
            {
                var welcomePage = new WelcomePage();
                var bulidNumber = welcomePage.AppVersionBuildInfo;

                var split = bulidNumber.Split('.');
                split = bulidNumber.Split('.');
                SettingsBase.AppBuildNumber = split[3];
                SettingsBase.AppVersionNumber = split[0] + "." + split[1] + "." + split[2];

                Reporting.Log("Pass", "AppBuildNumber update from app using the backdoor.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] AppBuildNumber not updated from app using the backdoor. " + e.Message);
                throw;
            }
        }

        /// <summary>
        ///     Gets the app name from the running app.
        /// </summary>
        [Given(@"I get AppName from App")]
        [Then(@"I get AppName from App")]
        public void AppName()
        {
            try
            {
                var welcomePage = new WelcomePage();
                SettingsBase.AppName = welcomePage.AppNameInfo;
                Console.WriteLine("AppName : " + SettingsBase.AppName);

                Reporting.Log("Pass", "AppName update from app using the backdoor.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] AppName not updated from app using the backdoor.: " + e.Message);
                throw;
            }
        }

        [Given(@"I press No Thanks button on Quick Tour dialog")]
        [When(@"I press No Thanks button on Quick Tour dialog")]
        public void WhenIPressNoThanksOnQuickTourDialog()
        {
            try
            {
                var quickTourPage = new QuickTourPage();
                ClickOnElement(quickTourPage.NoThanks);

                Reporting.Log("Pass", "No thanks button is pressed on Quick Tour dialog.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in WhenIPressNoThanksOnQuickTourDialog : " + e.Message);
                throw;
            }
        }

        #endregion Preconditions

        #region Actions

        [When(@"I halt execution by '(.*)' milliseconds")]
        public void WhenIHaltExecutionByMilliseconds(int milliseconds)
        {
            Thread.Sleep(milliseconds);
            Reporting.Log("Pass", $"Halted execution by {milliseconds} milliseconds.");
        }


        [When(@"I press menu item '(.*)' on bottom ribbon bar on simulator")]
        public void GivenPressBottom_Menu(string menu)
        {
            try
            {
                var bottomRibbonBar = new BottomRibbonBar();

                switch (menu)
                {
                    case "Status":
                        ClickOnElement(bottomRibbonBar.Status);
                        break;

                    case "More":
                        ClickOnElement(bottomRibbonBar.More);
                        break;

                    case "Home":
                        ClickOnElement(bottomRibbonBar.Home);
                        break;

                    case "My ReSound":
                    case "My Discover":
                    case "My AGXR":
                    case "My BeMore":
                        ClickOnElement(bottomRibbonBar.MyResound);
                        break;

                    default:
                        throw new ArgumentException("Unknown input value: " + menu);
                }

                Reporting.Log("Pass", "Succesfully  Pressed Bottom Menu  '" + menu + "'");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "[ERROR] Exception in  GivenPressBottom_Menu : " + e.Message);
                throw;
            }
        }


        [When(@"I press close button on Hear in noise Sound Enhancer on simulator")]
        public void WhenIPressCloseButtonsoundenhancersimulator()
        {
            try
            {
                var soundEnhancer = new HearInNoiseSoundEnhancerPage();
                ClickOnElement(soundEnhancer.Close);
                Reporting.Log("Pass", "Close button is pressed on Hear in noise Sound Enhancer on simulator.");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail",
                    "[ERROR] Exception in WhenIPressCloseButtonsoundenhancersimulator : " + e.Message);
                throw;
            }
        }

        #endregion
    }
}