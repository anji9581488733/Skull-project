using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Gleipner.Base;
using static Polaris.Base.SettingsBase;

namespace Gleipner.Pages
{
    public class SimulatorPage : PageBase
    {
        // Message store for standard output and standard error.
        // Populated by private events for each data output.
        // Only used for ADB/Android.
        public List<string> adbError = new List<string>();
        public List<string> adbOutput = new List<string>();


        /// <summary>
        ///     Standard output event handler, saving messages in message store.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Adb_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Trim garbage output lines with no content.
            if (!string.IsNullOrWhiteSpace(e.Data))
            {
                // Update console on new input
                if (e.Data != adbOutput.LastOrDefault() && LogLevel <= LogType.Debug)
                    Console.WriteLine("Received from adb standard out: " + e.Data);
                adbOutput.Add(e.Data);
            }
        }


        /// <summary>
        ///     Private standard error event handler, saving messages in message store.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Adb_ErrorDataRecieved(object sender, DataReceivedEventArgs e)
        {
            // Trim garbage error lines with no content.
            if (!string.IsNullOrWhiteSpace(e.Data))
            {
                // Update console on new input
                if (e.Data != adbError.LastOrDefault() && LogLevel <= LogType.Debug)
                    Console.WriteLine("Received from adb standard error: " + e.Data);
                adbError.Add(e.Data);
            }
        }


        /// <summary>
        ///     Enabling running any adb command with supplied argument string.
        /// </summary>
        /// <param name="adbArgs">ADB argument string</param>
        public void RunAdb(string adbArgs)
        {
            var adbPath = Path.Combine(AndroidHomePath, "platform-tools/adb");

            var adb = new Process();
            adb.StartInfo.FileName = adbPath;
            adb.StartInfo.Arguments = adbArgs;
            adb.StartInfo.UseShellExecute = false;
            adb.StartInfo.RedirectStandardError = true;
            adb.StartInfo.RedirectStandardOutput = true;
            adb.StartInfo.CreateNoWindow = true;

            // Attach event to listen to redirected output
            adb.OutputDataReceived += Adb_OutputDataReceived;
            adb.ErrorDataReceived += Adb_ErrorDataRecieved;
            adb.EnableRaisingEvents = true;


            // Execute adb command and begin listen to success/error results.
            adb.Start();

            adb.BeginOutputReadLine();
            adb.BeginErrorReadLine();

            // Wait for all async events to return and let adb complete.
            adb.WaitForExit();
        }


        /// <summary>
        ///     Start an emulator specified by Setting.DeviceName and wait till it has completed booting.
        /// </summary>
        public void StartEmulator()
        {
            var emulatorPath = Path.Combine(AndroidHomePath, "emulator/emulator");

            // Start emulator fresh each time. 
            // -wipe-data for clearing apps/settings
            // -no-snapshot for minimizing emulator launch exceptions from stored bad states.
            var emulatorArgs = "@" + DeviceName + " -wipe-data -no-snapshot";

            var emulatorStart = new ProcessStartInfo(emulatorPath, emulatorArgs)
            {
                UseShellExecute = true
            };


            if (LogLevel <= LogType.Debug)
                Console.WriteLine($"Starting Android emulator using {emulatorStart.Arguments}");

            var emulator = new Process { StartInfo = emulatorStart };
            emulator.Start();


            // Verify device is ready before continuing
            if (LogLevel <= LogType.Debug)
                Console.Write("Waiting for initial emulator boot status");

            // Starting an emulator from scratch causes an interim state of "no devices found".
            // Halt boot state detection till initial boot state is detectable.
            RunAdb("-s emulator-5554 wait-for-device");

            if (EmulatorBooted())
            {
                if (LogLevel <= LogType.Info)
                    Console.WriteLine("Booted Android emulator with device :" + DeviceName);
                return;
            }

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Emulator didn't reach booted state before timeout");
            throw new Exception("Emulator not ready. Wait time expired.");
        }


        /// <summary>
        ///     Polls for Android emulator boot state, detecting if UI is fully loaded and emulator ready to recieve apps.
        ///     Times out if 10 minutes has passed
        /// </summary>
        /// <returns>True if emulator is fully booted, false otherwise</returns>
        public bool EmulatorBooted()
        {
            // Boot detection monitoring full UI loaded, so Xamarin.UITest dont start install while device is booting.
            //
            // Full UI is not loaded till emulator network changes to LTE or WIFI.
            // Filter "adb shell dumpsys connectivity" for the line containing LTE/WIFI state of network agent.
            // Connectivity flow states go from no network -> LTE -> WIFI -> UI ready.
            // Sometimes the emulator never reaches WIFI, so LTE state is used instead.
            // Commands are directed to emulators only using adb -e so we dont accidentially check for physical devices.


            // Attempt to reach booted state in 10 minutes
            var maxDuration = new Stopwatch();
            var timeOut = new TimeSpan(0, 10, 0);

            maxDuration.Start();

            adbError.Clear();
            adbOutput.Clear();
            // On slower machines much time is spent on network being ready, so wait with network info till boot animation is done.
            do
            {
                // Get fresh service.bootanim.exit state
                RunAdb("-e shell getprop service.bootanim.exit");

                // Exit early if no emulators was found
                if (adbError.Any(x => x.Contains("no emulators found")))
                {
                    if (LogLevel <= LogType.Debug)
                        Console.WriteLine("No running emulators found.");
                    return false;
                }

                // Skip throttle if boot animation done
                if (adbOutput.LastOrDefault() == "1")
                {
                    if (LogLevel <= LogType.Debug)
                        Console.WriteLine("Emulator boot animation done.");
                    break;
                }


                // throttle the adb spam hawking cpu/io while the emulator boots
                Thread.Sleep(500);
            } while (adbOutput.LastOrDefault() != "1" && maxDuration.Elapsed < timeOut);

            // Monitor network state to determine if UI has booted
            while (maxDuration.Elapsed < timeOut)
            {
                // Get fresh network state
                adbOutput.Clear();
                RunAdb("-e shell \"dumpsys connectivity | sed -e '/[0-9] NetworkAgentInfo.*CONNECTED/p' -n\"");

                // Scan for LTE or WIFI state of network card, showing UI has booted
                if (adbOutput.Any(x => x.Contains("LTE")) ||
                    adbOutput.Any(x => x.Contains("WIFI")))
                {
                    if (LogLevel <= LogType.Debug)
                        Console.WriteLine($"Found LTE/WIFI state in {adbOutput.LastOrDefault()}");

                    // UI booted on device
                    return true;
                }

                // throttle the adb spam hawking cpu/io while the emulator boots
                Thread.Sleep(500);
            }

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Timed out waiting for emulator to reach fully booted state.");

            // Timed out waiting for UI to boot
            return false;
        }


        /// <summary>
        ///     Change system language of Android emulator.
        /// </summary>
        /// <param name="language">ISO language code in xx-XX format</param>
        public void ChangeEmulatorLanguage(string language)
        {
            if (Platform is PlatformType.Android)
            {
                // Change language/locale on emulator.
                if (LogLevel <= LogType.Debug)
                    Console.WriteLine($"Change language on {DeviceName} to {language}");

                RunAdb($"-e shell su 0 setprop persist.sys.locale {language}");


                // Reboot the emulator to update language
                if (LogLevel <= LogType.Debug)
                    Console.WriteLine($"Rebooting {DeviceName} to update language");

                RunAdb("-e shell su 0 setprop ctl.restart zygote");


                // Verify device is ready before continuing
                if (LogLevel <= LogType.Debug)
                    Console.WriteLine("Verifying device has rebooted");

                if (EmulatorBooted())
                {
                    if (LogLevel <= LogType.Info)
                        Console.WriteLine($"Completed {language} language change and boot sequence.");

                    return;
                }

                if (LogLevel <= LogType.Info)
                    Console.WriteLine("Timed out waiting for emulator to reach booted state after language change.");
                throw new Exception("Emulator language change incomplete. Wait time expired during reboot.");
            }

            throw new NotImplementedException($"Changing emulator language on {Platform} is not supported.");
        }


        /// <summary>
        ///     Terminates all running Android emulators.
        /// </summary>
        public void KillAllEmulators()
        {
            // Reset message store and populate it with a list of devices currently connected
            adbOutput.Clear();
            RunAdb("devices -l");

            // Store devices in static list that wont chance with more adb commands
            var devices = new List<string>(adbOutput);


            // We need to monitor if the emulator truely is dead, as adb will exit while emulator is shutting down,
            // causing all sorts of havoc with subsequent actions.
            foreach (var line in devices)
            {
                // If we hit the devices header line, or find a non-emulator device, break and continue with next line.
                if (line.Contains("List of devices") || !line.Contains("product:sdk_"))
                    continue;

                // Split serial number from remaining output using any whitespace char as delimiter
                var serial = line.Split()[0];

                if (LogLevel <= LogType.Debug)
                    Console.WriteLine($"Found emulator serial {serial}");

                do
                {
                    // Terminate emulator
                    RunAdb("-s " + serial + " emu kill");

                    // Throttle since adb exits instantly before completing kill
                    Thread.Sleep(1000);

                    if (LogLevel <= LogType.Debug)
                        Console.WriteLine($"Sent kill command to emulator {serial}");

                    // Check if the emulator serial number is gone from devices list
                    adbOutput.Clear();
                    RunAdb("devices -l");

                    // Continue to attempt to kill this emulator till it no longer shows on the device list.
                } while (adbOutput.Any(x => x.Contains(serial)));
            }


            if (LogLevel <= LogType.Info)
                Console.WriteLine("Terminated all running emulators");
        }
    }
}