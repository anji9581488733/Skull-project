using System;
using System.Threading;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Gleipner.Pages;
using NUnit.Framework;
using Reqnroll;


/// <summary>
/// Steps used to control HI
/// </summary>

namespace Fenris.Steps
{
    [Binding]
    public class HIControlSteps : StepsBase
    {
        #region Preconditions

        [Given(@"I initialize left hearing aid through HIC")]
        public void GivenIInitializeLeftHearingAidThroughHIC()
        {
            try
            {
                var hiControlPage = new HIControlPage();
                hiControlPage.InitLeftHearingAid();

                Reporting.Log("Pass", "Initialize left hearing aid command sent to HIC");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to initialize left hearing aid through HIC : " + e.Message);
                throw;
            }
        }


        [Given(@"I initialize right hearing aid through HIC")]
        public void GivenIInitializeRightHearingAidThroughHIC()
        {
            try
            {
                var hiControlPage = new HIControlPage();
                hiControlPage.InitRightHearingAid();

                Reporting.Log("Pass", "Initialize right hearing aid command sent to HIC");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to initialize right hearing aid through HIC : " + e.Message);
                throw;
            }
        }

        #endregion


        #region Actions

        [Given(@"I initialize the hearing aids through HIC")]
        [When(@"I initialize the hearing aids through HIC")]
        public void WhenIInitializeTheHearingAidsThroughHIC()
        {
            try
            {
                HIControlPage.HI_InitializeHearingAids();

                Reporting.Log("Pass", "Hearing aids initialize command sent to HIC");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to initialize hearing aids through HIC : " + e.Message);
                throw;
            }
        }


        [Given(@"I set up speedlink connection to the hearing aids through HIC")]
        public void GivenISetUpSpeedlinkConnectionToTheHearingAidsThroughHIC()
        {
            try
            {
                HIControlPage.SetUpSpeedLink();
                Reporting.Log("Pass", "Speedlink connection set up through HIC");
            }
            catch (Exception)
            {
                Reporting.Log("Fail", "Unable to set up Speedlink connection through HIC");
                throw;
            }
        }


        [Given(@"I reboot the hearing aids through HIC")]
        [When(@"I reboot the hearing aids through HIC")]
        public void WhenIRebootTheHearingAidsThroughHIC()
        {
            try
            {
                var hiControl = new HIControlPage();


                hiControl.HI_BootHearingAids();

                /*
                 * Implementation of "wait for reboot to finish" dont work as intended.
                 * Audio plays for longer than reboot sequence takes, promting undesired frontrunning by the app.
                 * Hence, reboot must be done without implicit testing of progress.
                 * Note and below code kept for future reference.
                 */

                /*
                Console.Write("Waiting for restart melody.");
                int i = 0;
                while ((hiControl.HI_Melody_Check("right") == "0") || (hiControl.HI_Melody_Check("left") == "0"))
                {
                    System.Threading.Thread.Sleep(500);

                    if (i > 20)
                        throw new TimeoutException("Timed out waiting for reboot of both hearing aids.");  // break if more than 10 seconds has elapsed.

                    i++;
                }
                Console.WriteLine("Played melody on right side: '" + hiControl.HI_Melody_Check("right") + "'");
                Console.WriteLine("Played melody on left side: '" + hiControl.HI_Melody_Check("left") + "'");
                */

                Reporting.Log("Pass", "Reboot hearing aids command sent to HIC");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to reboot hearing aids through HIC: " + e.Message);
                throw;
            }
        }


        [Given(@"I reboot left hearing aid though HIC")]
        [When(@"I reboot left hearing aid though HIC")]
        public void GivenIRebootLeftHearingAidThoughHIC()
        {
            try
            {
                var hiControl = new HIControlPage();
                hiControl.BootLeftHearingAid();

                Reporting.Log("Pass", "Reboot left hearing aid command sent to HIC");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to reboot left hearing aid through HIC: " + e.Message);
                throw;
            }
        }


        [Given(@"I reboot right hearing aid though HIC")]
        [When(@"I reboot right hearing aid though HIC")]
        public void GivenIRebootRightHearingAidThoughHIC()
        {
            try
            {
                var hiControl = new HIControlPage();
                hiControl.BootRightHearingAid();

                Reporting.Log("Pass", "Reboot right hearing aid command sent to HIC");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to reboot right hearing aid through HIC: " + e.Message);
                throw;
            }
        }


        [When(@"I reset the hearing aids through HIC")]
        public void WhenIResetTheHearingAidsThroughHIC()
        {
            try
            {
                HIControlPage.ResetHearingAids();

                Reporting.Log("Pass", "Executed reset function on hearing aids");
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Unable to execute reset of hearing aids: " + e.Message);
                throw;
            }
        }

        #endregion


        #region Assertions

        /// <summary>
        ///     Check if the program on the app is matching the HI program.
        ///     sleep function is because of time delay in HI's
        /// </summary>
        /// <param name="program">expected program on app</param>
        [Then(@"HI Program is in '(.*)'")]
        public void Program_HI(string program)
        {
            try
            {
                Thread.Sleep(5000); // Time delay in HIs
                var hiControl = new HIControlPage();
                Assert.AreEqual(program, hiControl.GetCurrentHICard(),
                    "Program name should be : '" + program + "' but its '" + hiControl.GetCurrentHICard() + "'");
                Reporting.Log("pass", "Validated the HI program is " + hiControl.GetCurrentHICard());
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Error in HI program function. Error  : " + e);
                throw;
            }
        }

        /// <summary>
        ///     Validates that the volume on card matches volume in right HIs
        /// </summary>
        /// <param name="volume">volume on card</param>
        [Then(@"validate Right HI volume is '(.*)'")]
        public void ValidateVolume_RightHI(int volume)
        {
            try
            {
                var hiControl = new HIControlPage();
                Assert.AreEqual(volume, hiControl.Read_HI_Value("right"));
                Reporting.Log("pass", "Validated volume on Right HI is " + volume);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Error in ValidateVolume_HI. Error  : " + e);
                throw;
            }
        }

        /// <summary>
        ///     Validates that the volume on card matches volume in left HIs
        /// </summary>
        /// <param name="volume">volume on card</param>
        [Then(@"validate Left HI volume is '(.*)'")]
        public void ValidateVolume_LeftHI(int volume)
        {
            try
            {
                var hiControl = new HIControlPage();
                Assert.AreEqual(volume, hiControl.Read_HI_Value("left"));
                Reporting.Log("pass", "Validated volume on Left HI is " + volume);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Error in ValidateVolume_HI. Error  : " + e);
                throw;
            }
        }


        /// <summary>
        ///     Validates that the volume on card matches volume in HIs
        /// </summary>
        /// <param name="volume">volume on card</param>
        [Then(@"validate HI volume is '(.*)'")]
        public void ValidateVolume_HI(int volume)
        {
            try
            {
                var hiControl = new HIControlPage();
                Assert.AreEqual(volume, hiControl.Read_HI_Value("left"));
                Assert.AreEqual(volume, hiControl.Read_HI_Value("right"));
                Reporting.Log("pass", "Validated volume on HIs is " + volume);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Error in ValidateVolume_HI. Error  : " + e);
                throw;
            }
        }


        /// <summary>
        ///     Validates MelodyLastPlayedType in HIs
        /// </summary>
        [Then(@"validate HI melody is '(.*)'")]
        public void Validatemelody_HI(string melody)
        {
            try
            {
                var hiControl = new HIControlPage();
                Assert.AreEqual(melody, hiControl.HI_Melody_Check("left"));
                Assert.AreEqual(melody, hiControl.HI_Melody_Check("right"));
                Reporting.Log("pass", "Validated melody on HIs is " + melody);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Error in ValidateVolume_HI. Error  : " + e);
                throw;
            }
        }


        /// <summary>
        ///     ValidatesPNR value in HIs
        /// </summary>
        [Then(@"validate HI PNR value is '(.*)'")]
        public void ValidatePNR_HI(string value)
        {
            try
            {
                var hiControl = new HIControlPage();
                Assert.AreEqual(value, hiControl.HI_Read_Noise_Reduction("left"));
                Assert.AreEqual(value, hiControl.HI_Read_Noise_Reduction("right"));
                Reporting.Log("pass", "Validated PNR on HIs is " + value);
            }
            catch (Exception e)
            {
                Reporting.Log("Fail", "Error in ValidatePNR__HI. Error  : " + e);
                throw;
            }
        }

        #endregion
    }
}