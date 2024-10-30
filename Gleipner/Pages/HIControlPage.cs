using Gleipner.ConfigElement;
using HearingInstrumentControllerService;
using NUnit.Framework;
using Polaris.Base;
using ReSound.SET.Tools;
using System;
using System.Threading;
using PageBase = Gleipner.Base.PageBase;

namespace Gleipner.Pages
{
    public class HIControlPage : PageBase
    {
        private static readonly int SpeedLinkUsbNumber = 0;
        private static readonly int SpeedLinkPortNumber = 8733;

        public static void HI_InitializeHearingAids()
        {
            hics = new HicServiceClient(Settings.SpeedLinkIp, SpeedLinkPortNumber);
            hics.Open();

            Settings.EnableHIs = true;

            switch (Settings.HearingInstrumentPlatform)
            {
                case "Dooku1":
                    hics.InitializeHearingInstrumentControllers(SpeedLinkUsbNumber, Side.Both);
                    break;

                case "Dooku2":
                    hics.InitializeHearingInstrumentControllers(SpeedLinkUsbNumber, Side.Both);
                    break;

                case "Dooku3":
                    hics.InitializeHearingInstrumentControllers(SpeedLinkUsbNumber, Side.Both);
                    break;

                case "Palpatine6":
                    hics.InitializeHearingInstrumentControllers(SpeedLinkUsbNumber, Side.Both);
                    break;
                default:
                    throw new ArgumentException("HIPlatform setting unknown: " +
                                                SettingsBase.HearingInstrumentPlatform);
            }
        }


        public static void SetUpSpeedLink()
        {
            hics = new HicServiceClient(Settings.SpeedLinkIp, SpeedLinkPortNumber);
            hics.Open();
        }


        public static void ResetHearingAids()
        {
            hics.Reset(SpeedLinkUsbNumber);
        }


        public void BootLeftHearingAid()
        {
            hics.Boot(SpeedLinkUsbNumber, Side.Left, BootType.DspRunningNotInHostMode);
        }


        public void BootRightHearingAid()
        {
            hics.Boot(SpeedLinkUsbNumber, Side.Right, BootType.DspRunningNotInHostMode);
        }


        public void InitLeftHearingAid()
        {
            hics.InitializeHearingInstrumentControllers(SpeedLinkUsbNumber, Side.Left);
        }


        public void InitRightHearingAid()
        {
            hics.InitializeHearingInstrumentControllers(SpeedLinkUsbNumber, Side.Right);
        }


        public void HI_BootHearingAids()
        {
            Console.WriteLine("Attempting to boot hearing aids. HIC state: " + hics.State);


            hics.Boot(SpeedLinkUsbNumber, Side.Both, BootType.DspRunningNotInHostMode);
        }


        public string HI_Melody_Check(string HIside)
        {
            Thread.Sleep(3000);
            if (HIside == "right")
                return string.Concat((MelodyLastPlayedType)hics.GetMelodyLastPlayed(SpeedLinkUsbNumber, Side.Right));
            if (HIside == "left")
                return string.Concat((MelodyLastPlayedType)hics.GetMelodyLastPlayed(SpeedLinkUsbNumber, Side.Left));
            throw new ArgumentException("Hi side not recognized " + HIside);
        }

/*

        public int HI_Read_Bass(string HIside)
        {
            System.Threading.Thread.Sleep(2000);
            if (HIside == "right")
            {
                return ((int)hics.GetBassEqLevel(ReSound.SET.Tools.Side.Right));
            }
            if (HIside == "left")
            {
                return ((int)hics.GetBassEqLevel(ReSound.SET.Tools.Side.Left));
            }
            else return (0);
        }



        public int HI_Read_Middle(string HIside)
        {
            if (HIside == "right")
            {
                return ((int)hics.GetMidEqLevel(ReSound.SET.Tools.Side.Right));
            }
            if (HIside == "left")
            {
                return ((int)hics.GetMidEqLevel(ReSound.SET.Tools.Side.Left));
            }
            else return (0);
        }



        public int HI_Read_Treble(string HIside)
        {
            if (HIside == "right")
            {
                return ((int)hics.GetTrebleEqLevel(ReSound.SET.Tools.Side.Right));
            }
            if (HIside == "left")
            {
                return ((int)hics.GetTrebleEqLevel(ReSound.SET.Tools.Side.Left));
            }
            else return (0);
        }

*/

        public bool HI_Read_Speech_Focus(string Speech, string HIside)
        {
            bool check;
            if (HIside == "right")
            {
                if (string.Concat((BeamWidthLevel)hics.GetBeamWidthLevel(SpeedLinkUsbNumber, Side.Right)) == Speech)
                    check = true;
                else check = false;
                Assert.AreEqual(true, check, "Speech is not " + Speech);
                return check;
            }

            if (HIside == "left")
            {
                if (string.Concat((BeamWidthLevel)hics.GetBeamWidthLevel(SpeedLinkUsbNumber, Side.Left)) == Speech)
                    check = true;
                else check = false;
                Assert.AreEqual(true, check, "Speech is not " + Speech);
                return check;
            }

            return false;
        }


        public string HI_Read_Noise_Reduction(string HIside)
        {
            Thread.Sleep(3000);
            if (HIside == "right")
                return string.Concat((PNRMode)hics.GetPNRMode(SpeedLinkUsbNumber, Side.Right));
            if (HIside == "left")
                return string.Concat((PNRMode)hics.GetPNRMode(SpeedLinkUsbNumber, Side.Left));
            throw new ArgumentException("Hi side not recognized " + HIside);
        }


        public bool HI_Read_Wind_Noise(string Wind, string HIside)
        {
            bool check;

            if (HIside == "right")
            {
                if (string.Concat((WNR)hics.GetWNR(SpeedLinkUsbNumber, Side.Right)) == Wind)
                    check = true;
                else check = false;
                Assert.AreEqual(true, check, "Wind is not " + Wind);
                return check;
            }

            if (HIside == "left")
            {
                if (string.Concat((WNR)hics.GetWNR(SpeedLinkUsbNumber, Side.Left)) == Wind)
                    check = true;
                else check = false;
                Assert.AreEqual(true, check, "Wind is not " + Wind);
                return check;
            }

            return false;
        }


        /*
         * 15/11 2019 - Outcommented pending development in new HICs and formal verification.
         * May become useful after formal verification.
         *
        public bool HI_Read_Band_Split(string Speech, string HIside)
        {
            bool check;
            if (HIside == "right")
            {
                if (string.Concat((ReSound.SET.Tools.BandSplitLevel)hics.GetBandSplitLevel(ReSound.SET.Tools.Side.Right)) == Speech)
                {
                    check = true;
                }
                else check = false;
                Assert.AreEqual(true, check, "Speech is not " + Speech);
                return (check);
            }
            if (HIside == "left")
            {
                if (string.Concat((ReSound.SET.Tools.BandSplitLevel)hics.GetBandSplitLevel(ReSound.SET.Tools.Side.Left)) == Speech)
                {
                    check = true;
                }
                else check = false;
                Assert.AreEqual(true, check, "Speech is not " + Speech);
                return (check);
            }
            else return (false);
        }



        public bool HI_Read_TSG(string TSG, string HIside)
        {
            bool check;
            if (HIside == "right")
            {
                if (string.Concat((ReSound.SET.Tools.TSGAmplitudeModulationAtt)hics.GetTSGAmplitudeModulationAtt(ReSound.SET.Tools.Side.Right)) == TSG)
                {
                    check = true;
                }
                else check = false;
                Assert.AreEqual(true, check, "Left side TSG amplitude is " + TSG);
                return (check);
            }
            if (HIside == "left")
            {
                if (string.Concat((ReSound.SET.Tools.TSGAmplitudeModulationAtt)hics.GetTSGAmplitudeModulationAtt(ReSound.SET.Tools.Side.Left)) == TSG)
                {
                    check = true;
                }
                else check = false;
                Assert.AreEqual(true, check, "Left side TSG amplitude is " + TSG);
                return (check);
            }
            else return (false);
        }



        public bool HI_Read_TSG_Natural_Sound(string TSG, string HIside)
        {
            bool check;
            if (HIside == "right")
            {
                if (string.Concat((ReSound.SET.Tools.TSGNaturalSound)hics.GetTSGNaturalSound(ReSound.SET.Tools.Side.Right)) == TSG)
                {
                    check = true;
                }
                else check = false;
                Assert.AreEqual(true, check, "Left side TSG amplitude is " + TSG);
                return (check);
            }
            if (HIside == "left")
            {
                if (string.Concat((ReSound.SET.Tools.TSGNaturalSound)hics.GetTSGNaturalSound(ReSound.SET.Tools.Side.Left)) == TSG)
                {
                    check = true;
                }
                else check = false;
                Assert.AreEqual(true, check, "Left side TSG amplitude is " + TSG);
                return (check);
            }
            else return (false);
        }
        */


        public string GetCurrentHICard()
        {
            Thread.Sleep(3000);
            if (hics.GetProgramName(SpeedLinkUsbNumber, Side.Right) ==
                hics.GetProgramName(SpeedLinkUsbNumber, Side.Left))
                return hics.GetProgramName(SpeedLinkUsbNumber, Side.Right);
            return "Both HIs not on same program";
        }


        public int Read_HI_Value(string side)
        {
            Thread.Sleep(5000);

            if (side == "left")
                return (int)Volume_convert_from_hi((float)hics.GetCurrentMicrophoneGainScaled(SpeedLinkUsbNumber, Side.Left));
            //return (Left_Channel_HI);
            if (side == "right")
                return (int)Volume_convert_from_hi((float)hics.GetCurrentMicrophoneGainScaled(SpeedLinkUsbNumber, Side.Right));
            //return (Right_Channel_HI);
            return 0;
        }


        public int Read_Streamer_Value(string side)
        {
            var Left_Channel_HI =
                (int)Volume_convert_from_hi((float)hics.GetCurrentCodecGainScaled(SpeedLinkUsbNumber, Side.Left));
            var Right_Channel_HI =
                (int)Volume_convert_from_hi((float)hics.GetCurrentCodecGainScaled(SpeedLinkUsbNumber, Side.Right));

            if (side == "left")
                return Left_Channel_HI;
            if (side == "right")
                return Right_Channel_HI;
            return 0;
        }


        public float Volume_convert_from_hi(float value_from_hi)
        {
            var NY1 = value_from_hi / 254;
            var NY2 = (int)(1 + 12 * NY1);

            if ((int)value_from_hi <= 0)
                return 0;
            return NY2;
        }
    }
}