using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Polaris.Base;

namespace Polaris.Hooks
{
    public class TestHook 
    {
        /// <summary>
        ///     Routed SpecFlow test hook [BeforeTestRun].
        /// </summary>
        ///
        
        public static void BeforeTestRun()
        {
            SettingsBase.LoadConfiguration();
        }
        

       
        
                                  

        /// <summary>
        ///     Routed SpecFlow test hook [BeforeFeature].
        /// </summary>
        public static void BeforeFeature()
        {
            // Terminate all iOS simulators before Test run

            if (SettingsBase.Platform is SettingsBase.PlatformType.iOS && SettingsBase.PhysicalDevice)
            {
                Console.WriteLine("Attempting to terminate all simulators for iOS...");

                var proc = new Process();

                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \"xcrun simctl shutdown all" + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                proc.WaitForExit();
                Thread.Sleep(3000);
            }
        }


        /// <summary>
        ///     Routed SpecFlow test hook [AfterFeature].
        /// </summary>
        public static void AfterFeature()
        {
        }


        /// <summary>
        ///     Routed SpecFlow test hook [BeforeScenario].
        /// </summary>
        public static void BeforeScenario()
        {
           
            var proc = new Process();

            if (Convert.ToString(Environment.OSVersion.Platform).Contains("Unix") && SettingsBase.Platform is SettingsBase.PlatformType.Android)
            {
                var adbpath = Path.Combine(SettingsBase.AndroidHomePath, "platform-tools/");


                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \"" + adbpath + "./adb logcat -c" + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;

                proc.Start();
                proc.WaitForExit();
            }

            if (Convert.ToString(Environment.OSVersion.Platform).Contains("Win") && SettingsBase.Platform is SettingsBase.PlatformType.Android)
            {
                var adbPath = Path.Combine(SettingsBase.AndroidHomePath, "platform-tools/adb");
                proc.StartInfo.FileName = adbPath;
                proc.StartInfo.Arguments = "logcat -c";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.CreateNoWindow = true;

                proc.Start();
            }
        }


        /// <summary>
        ///     Routed SpecFlow test hook [AfterScenario].
        /// </summary>
        public static void AfterScenario()
        {
        }


        /// <summary>
        ///     Routed SpecFlow test hook [BeforeStep].
        /// </summary>
        public static void BeforeStep()
        {
          
        }


        /// <summary>
        ///     Routed SpecFlow test hook [AfterStep].
        /// </summary>
        public static void AfterStep()
        {
        }
    }
}