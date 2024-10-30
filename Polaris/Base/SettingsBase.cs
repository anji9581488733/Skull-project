using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Polaris.Base
{
    /// <summary>
    ///     Base settings required for all projects and test targets.
    /// </summary>
    public abstract class SettingsBase
    {
        public enum LogType
        {
            All,
            Calabash,
            Debug,
            Info,
            Off
        }

        /// <summary>
        /// 
        /// </summary>
        public enum PlatformType
        {
            Android,
            iOS,
        }

        public static bool EnableHIs;


        /// <summary>
        ///     Output log filter. All, Debug, Info or Off.
        ///     A log request of level p in a logger with level q is enabled if p >=q.
        ///     All < Debug < Info < Off.
        /// </summary>
        public static LogType LogLevel { get; set; }

        /// <summary>
        ///     Default timeout in seconds for all time dependent Xamarin.UITest calls.
        /// </summary>
        public static TimeSpan Timeout { get; set; }

        /// <summary>
        ///     Take a screenshot on each successfully executed step.
        /// </summary>
        public static bool ScreenshotOnPass { get; set; }

        /// <summary>
        ///     Android/iOS platform
        /// </summary>
        public static PlatformType Platform { get; set; }

        /// <summary>
        ///     Amount of times a test will attempt to run after first failure.
        /// </summary>
        public static int RetriesOnError { get; set; }

        /// <summary>
        ///     Path to position of app package file
        /// </summary>
        public static string? AppPath { get; set; }

        /// <summary>
        ///     Package file name of app that should be used for current test
        /// </summary>
        public static string? AppPackage { get; set; }


        /// <summary>
        ///     Unique device identifier for mobile devices
        /// </summary>
        public static string DeviceId { get; set; }

        /// <summary>
        ///     Default timeout in seconds for all time dependent Appium.UITest calls.
        /// </summary>
        public static int newCommandTimeout { get; set; }


        /// <summary>
        ///     Adding the wdaConnectionTimeout for launching the App
        /// </summary>
        public static int wdaConnectionTimeout { get; set; }

        /// <summary>
        ///     Default timeout in seconds for all time dependent Appium.UITest calls.
        /// </summary>
        public static int adbExecTimeout { get; set; }

        /// <summary>
        ///     Default timeout in seconds for all time dependent Appium.UITest calls for Android.
        /// </summary>
        public static int uiautomator2ServerInstallTimeout { get; set; }

        /// <summary>
        ///     Default timeout in seconds for all wdaStartupRetry calls.
        /// </summary>
        public static int wdaStartupRetryInterval { get; set; }

        /// <summary>
        ///     Name of Hearing Instruments.
        /// </summary>
        public static string HIName { get; set; }

        /// <summary>
        ///     Unique device identifier for physical/simulators devices
        /// </summary>
        public static bool PhysicalDevice { get; set; }

        /// <summary>
        ///     AutomationName for ios/Android devices
        /// </summary>
        public static string automationName { get; set; }

        /// <summary>
        ///     Name of the platformVerion for ios devices
        /// </summary>
        public static string platformVersion { get; set; }

        /// <summary>
        ///     Name of the udid of the ios device
        /// </summary>
        public static string udid { get; set; }

        /// <summary>
        ///     Name of the xcodeOrgId for the real device
        /// </summary>
        public static string xcodeOrgId { get; set; }


        /// <summary>
        ///     Name of the xcodeSigningId for the real device
        /// </summary>
        public static string xcodeSigningId { get; set; }

        /// <summary>
        ///     Name of the updatedWDABundleId for the real device.
        /// </summary>
        public static string updatedWDABundleId { get; set; } = "com.nap.WebDriverAgentRunner";
        
        /// <summary>
        ///     Name of the WdaLaunchTimeout for the real device.
        /// </summary>
        public static int WdaLaunchTimeout { get; set; } = 120000;

        /// <summary>
        ///     Name of the derivedDataPath for the WebDriverAgent
        /// </summary>
        public static string derivedDataPath { get; set; }


        /// <summary>
        ///     Name of the includeSafariInWebviews
        /// </summary>
        public static string includeSafariInWebviews { get; set; }

        /// <summary>
        ///     Name of the useNewWDA for the WebDriverAgent.
        /// </summary>
        public static bool UseNewWDA { get; set; } = false;

        /// <summary>
        ///     Name of the locationServiceAuthorized for the WebDriverAgent
        /// </summary>
        public static bool locationServicesAuthorized { get; set; }

        /// <summary>
        ///     Directory path for Xamarin.UITest debug log.
        /// </summary>
        public static string XamarinLogDir { get; set; }

        /// <summary>
        ///     Unique device identifier for iOS devices
        /// </summary>
        public static string AppBundleId { get; set; }

        /// <summary>
        ///     Full reset appium property.
        /// </summary>
        public static bool FullReset { get; set; } = false;

        /// <summary>
        ///     Path to %ANDROID_HOME%. Enables executing thread to define standard Android vantage point for emulator, adb and
        ///     other Android SDK tools.
        ///     Will replace AndroidSimulatorPath in the future.
        /// </summary>
        public static string AndroidHomePath { get; set; }
        
        /// <summary>
        ///     Path to %ANDROID_BUILDTOOLSPATH%. Enables executing thread to define standard Android vantage point for emulator, adb and
        ///     other Android SDK tools.
        ///     Will replace AndroidSimulatorPath in the future.
        /// </summary>
        public static string Android_BuildToolsPath { get; set; }

        /// <summary>
        ///     Name of the physical/simulated device testing is executed on
        /// </summary>
        public static string? DeviceName { get; set; }

        /// <summary>
        ///     Value of noReset as true/false
        /// </summary>
        public static string noReset { get; set; }

        /// <summary>
        ///     IP adress to SpeedLink currently in use
        /// </summary>
        public static string SpeedLinkIp { get; set; }

        /// <summary>
        ///     Hearing instrument platform specifier for HICS
        /// </summary>
        public static string HearingInstrumentPlatform { get; set; }

        // AppName reflects the folder current Language test images gets organized by.
        // If Language test is executed by Jenkins, the Jenkins job would also know what app is used
        // and should set this dynamically.

        /// <summary>
        ///     Informal name for app curently under test
        /// </summary>
        public static string AppName { get; set; }

        /// <summary>
        ///     Appium path for running the appium server for Windows
        /// </summary>
        public static string AppiumPath { get; set; }

        /// <summary>
        ///     Appium path for running the server for IOS
        /// </summary>
        public static string AppiumNodePath { get; set; }

        /// <summary>
        ///     Node path for running the server for IOS
        /// </summary>
        public static string NodePath { get; set; }

        /// <summary>
        ///     Appium Logs are saved in the path specified here.
        /// </summary>
        public static string LogPath { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppiumLogs", "AppiumLogs.txt");

        /// <summary>
        ///     Path to shared NAS drive usable for data storage. Language tests use this as delivery directory
        /// </summary>
        public static string SharedDrive { get; set; }


        /// <summary>
        ///     Build number of the ipa/app/apk file as described in build.number parameter in Artifactory
        /// </summary>
        public static string AppBuildNumber { get; set; }

        /// <summary>
        ///     App version number of the ipa/app/apk file as described in build.number parameter in Artifactory
        /// </summary>
        public static string AppVersionNumber { get; set; }

        /// <summary>
        ///     Serve allure report localy after test execution.
        /// </summary>
        public static bool ServeLocalAllureReport { get; set; } = false;

        /// <summary>
        ///     Loads all settings from both core functionality and project dependent features.
        ///     Requires specific implementation in each POM project.
        ///     POM projects must call InitializeBaseSettings() to complete initialization of common settings.
        /// </summary>
        public abstract void InitializeSettings();

        public static void LoadConfiguration()
        {
            if (File.Exists(AppSettings.ConfigPath))
            {
                Console.WriteLine("Found local settings file at " + AppSettings.ConfigPath);
                AppSettings.LoadEnvVars(AppSettings.ConfigPath);
            }
            else
            {
                // Example of config is available here: .\\devops-ui-test-framework\\SKULD\\config
                throw new FileNotFoundException($"Cannot find file: " + AppSettings.ConfigName);
            }
        }

        /// <summary>
        ///     get device ID from Device Name for iOS/Android.
        /// </summary>
        public static string GetDeviceID()
        {
            var DeviceId = string.Empty;
            if (LogLevel <= LogType.Debug)
                Console.WriteLine("Attempting to get device ID from " + DeviceName);

            var proc = new Process();
            if (Platform is PlatformType.iOS)
            {
                var rerun = 0;
                do
                {
                    proc = new Process();
                    rerun = 0;
                    proc.StartInfo.FileName = "/bin/bash";
                    proc.StartInfo.Arguments = "-c " + "\"xcrun xctrace list devices" + "\"";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;

                    proc.Start();
                    var output = new List<string>();
                    do
                    {
                        output.Add(proc.StandardOutput.ReadLine());
                    } while (!proc.StandardOutput.EndOfStream);

                    foreach (var lines in output)
                        if (PhysicalDevice && lines.Contains(DeviceName) && !lines.Contains("Simulator"))
                        {
                            DeviceId = lines.Split(" ".ToCharArray()).Last().TrimStart('(').TrimEnd(')');
                            return DeviceId;
                        }
                        else if (PhysicalDevice == false && lines.Contains(DeviceName) && lines.Contains("Simulator"))
                        {
                            DeviceId = lines.Split(" ".ToCharArray()).Last().TrimStart('(').TrimEnd(')');
                            return DeviceId;
                        }

                    rerun++;
                    Console.WriteLine(rerun);
                } while (DeviceId == "" && rerun < 10);
            }
            else if (Platform is PlatformType.Android)
            {
                if (!PhysicalDevice) 
                    return "emulator-5554";

                var adbPath = Path.Combine(AndroidHomePath, "platform-tools/adb");
                proc.StartInfo.FileName = adbPath;
                proc.StartInfo.Arguments = "devices";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.CreateNoWindow = true;

                proc.Start();
                var output = new List<string>();
                
                do
                {
                    output.Add(proc.StandardOutput.ReadLine());
                } while (!proc.StandardOutput.EndOfStream);

                foreach (string line in output)
                {
                    Match match = Regex.Match(line, @"^(?<DeviceID>.*?)\s+device$");
                    if (match.Success)
                    {
                        DeviceId = match.Groups["DeviceID"].Value;
                        break;
                    }
                }
            }

            proc.WaitForExit();
            return DeviceId;
        }

        /// <summary>
        ///     Framework-wide settings
        /// </summary>
        public void InitializeBaseSettings()
        {
            Console.WriteLine("Initializing settings with environment variables.");


            // LogLevel
            var envLogLevel = Environment.GetEnvironmentVariable("LogLevel");
            Console.WriteLine("Using 'LogLevel' environment variable value: " + envLogLevel);

            LogLevel = (LogType)Enum.Parse(typeof(LogType), envLogLevel);

            // Verbose logging of all env vars on the machine at the time of execution
            if (LogLevel <= LogType.Debug)
            {
                Console.WriteLine("This machine has the following environment variables:");
                foreach (DictionaryEntry e in Environment.GetEnvironmentVariables())
                    Console.WriteLine(e.Key + ":" + e.Value);
            }


            // Platform
            var envPlatform = Environment.GetEnvironmentVariable("platformName");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'platformName' environment variable value: " + envPlatform);

            Platform = (PlatformType)Enum.Parse(typeof(PlatformType), envPlatform);

            // AppPath
            var envAppPath = Environment.GetEnvironmentVariable("AppPath");

            if (string.IsNullOrEmpty(envAppPath))
            {
                Console.WriteLine("The \"AppPath\" environment has not been set. The framework will try to find the latest application from the output folder");
            }
            else
            {
                Console.WriteLine($"Using 'AppPath' environment variable value: {envAppPath}");
                AppPath = Path.GetFullPath(envAppPath);
            }

            // AppPackage
            var envAppPackage = Environment.GetEnvironmentVariable("AppPackage");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'AppPackage' environment variable value: " + envAppPackage);

            AppPackage = envAppPackage;

            // xcodeOrgId
            var envxcodeOrgId = Environment.GetEnvironmentVariable("xcodeOrgId");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'AppPackage' environment variable value: " + envxcodeOrgId);

            xcodeOrgId = envxcodeOrgId;


            // AppiumPath
            var envAppiumPath = Environment.GetEnvironmentVariable("AppiumPath");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'AppiumPath' environment variable value: " + envAppiumPath);

            AppiumPath = envAppiumPath;

            // AppiumNodePath
            var envAppiumNodePath = Environment.GetEnvironmentVariable("AppiumNodePath");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'AppiumNodePath' environment variable value: " + envAppiumNodePath);

            AppiumNodePath = envAppiumNodePath;

            // NodePath
            var envNodePath = Environment.GetEnvironmentVariable("NodePath");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'NodePath' environment variable value: " + envNodePath);

            NodePath = envNodePath;

            // LogPath
            var envLogPath = Environment.GetEnvironmentVariable("LogPath");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'LogPath' environment variable value: " + envLogPath);

            if (!string.IsNullOrEmpty(envLogPath))
            {
                LogPath = envLogPath;
            }

            // xcodeSigningId
            var envxcodeSigningId = Environment.GetEnvironmentVariable("xcodeSigningId");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'xcodeSigningId' environment variable value: " + envxcodeSigningId);

            xcodeSigningId = envxcodeSigningId;

            // updatedWDABundleId
            var envupdatedWDABundleId = Environment.GetEnvironmentVariable("updatedWDABundleId");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'updatedWDABundleId' environment variable value: " + envupdatedWDABundleId);

            if (!string.IsNullOrEmpty(envupdatedWDABundleId))
            {
                updatedWDABundleId = envupdatedWDABundleId;
            }
            
            // wdaLaunchTimeout
            var wdaLaunchTimeout = Environment.GetEnvironmentVariable("wdaLaunchTimeout");
            
            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'wdaLaunchTimeout' environment variable value: " + wdaLaunchTimeout);

            if (!string.IsNullOrWhiteSpace(wdaLaunchTimeout))
                WdaLaunchTimeout = int.Parse(wdaLaunchTimeout);
            
            // useNewWDA
            var useNewWDA = Environment.GetEnvironmentVariable("useNewWDA");
            
            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'useNewWDA' environment variable value: " + useNewWDA);

            if (!string.IsNullOrWhiteSpace(useNewWDA))
                UseNewWDA = bool.Parse(useNewWDA);

            // derivedDataPath
            var envderivedDataPath = Environment.GetEnvironmentVariable("derivedDataPath");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'derivedDataPath' environment variable value: " + envderivedDataPath);

            derivedDataPath = envderivedDataPath;

            // automationName
            var envautomationName = Environment.GetEnvironmentVariable("automationName");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'automationName' environment variable value: " + envautomationName);

            automationName = envautomationName;

            // includeSafariInWebviews
            var envincludeSafariInWebviews = Environment.GetEnvironmentVariable("includeSafariInWebviews");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'includeSafariInWebviews' environment variable value: " +
                                  envincludeSafariInWebviews);

            if (!string.IsNullOrWhiteSpace(envincludeSafariInWebviews))
                PhysicalDevice = bool.Parse(envincludeSafariInWebviews);

            // noReset
            var envnoReset = Environment.GetEnvironmentVariable("noReset");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'noReset' environment variable value: " + envnoReset);

            if (!string.IsNullOrWhiteSpace(envnoReset))
                PhysicalDevice = bool.Parse(envnoReset);

            // locationServicesAuthorized
            var envlocationServicesAuthorized = Environment.GetEnvironmentVariable("locationServicesAuthorized");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'locationServicesAuthorized' environment variable value: " +
                                  envlocationServicesAuthorized);

            if (!string.IsNullOrWhiteSpace(envlocationServicesAuthorized))
                PhysicalDevice = bool.Parse(envlocationServicesAuthorized);

            // platformVersion  
            var envplatformVersion = Environment.GetEnvironmentVariable("platformVersion");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'platformVersion' environment variable value: " + envplatformVersion);

            platformVersion = envplatformVersion;

            // ScreenshotOnPass
            var envScreenshotOnPass = Environment.GetEnvironmentVariable("ScreenshotOnPass");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'ScreenshotOnPass' environment variable value: " + envScreenshotOnPass);

            ScreenshotOnPass = bool.Parse(envScreenshotOnPass);


            // RetriesOnError
            var envRetriesOnError = Environment.GetEnvironmentVariable("RetriesOnError");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'RetriesOnError' environment variable value: " + envRetriesOnError);

            RetriesOnError = int.Parse(envRetriesOnError);


            // iOS App Bundle Id
            var envAppBundleId = Environment.GetEnvironmentVariable("AppBundleId");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'AppBundleId' environment variable value: " + envAppBundleId);

            AppBundleId = envAppBundleId;

            // Full Reset - this will reinstall app.
            var envFullReset = Environment.GetEnvironmentVariable("FullReset");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'FullReset' environment variable value: " + envFullReset);

            if (!string.IsNullOrWhiteSpace(envFullReset))
                FullReset = bool.Parse(envFullReset);

            // Physical device or simulator ( true / false )
            var envPhysicalDevice = Environment.GetEnvironmentVariable("PhysicalDevice");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'PhysicalDevice' environment variable value: " + envPhysicalDevice);

            if (!string.IsNullOrWhiteSpace(envPhysicalDevice))
                PhysicalDevice = bool.Parse(envPhysicalDevice);

            // Timeout. 
            var envTimeOut = Environment.GetEnvironmentVariable("Timeout");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'Timeout' environment variable value: " + envTimeOut);

            if (!string.IsNullOrWhiteSpace(envTimeOut))
                Timeout = TimeSpan.FromSeconds(int.Parse(envTimeOut));

            // wdaStartupRetryInterval. 
            var envwdaStartupRetryInterval = Environment.GetEnvironmentVariable("wdaStartupRetryInterval");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'wdaStartupRetryInterval' environment variable value: " +
                                  envwdaStartupRetryInterval);

            if (!string.IsNullOrWhiteSpace(envwdaStartupRetryInterval))
                wdaStartupRetryInterval = int.Parse(envwdaStartupRetryInterval);

            // adbExecTimeout. 
            var envadbExecTimeout = Environment.GetEnvironmentVariable("adbExecTimeout");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'adbExecTimeout' environment variable value: " + envadbExecTimeout);

            if (!string.IsNullOrWhiteSpace(envadbExecTimeout))
                adbExecTimeout = int.Parse(envadbExecTimeout);

            // uiautomator2ServerInstallTimeout. 
            var envuiautomator2ServerInstallTimeout =
                Environment.GetEnvironmentVariable("uiautomator2ServerInstallTimeout");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'uiautomator2ServerInstallTimeout' environment variable value: " +
                                  envuiautomator2ServerInstallTimeout);

            if (!string.IsNullOrWhiteSpace(envuiautomator2ServerInstallTimeout))
                uiautomator2ServerInstallTimeout = int.Parse(envuiautomator2ServerInstallTimeout);

            // newCommandTimeout. 
            var envnewCommandTimeout = Environment.GetEnvironmentVariable("newCommandTimeout");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'envnewCommandTimeout' environment variable value: " + envnewCommandTimeout);

            if (!string.IsNullOrWhiteSpace(envnewCommandTimeout))
                newCommandTimeout = int.Parse(envnewCommandTimeout);


            // wdaConnectionTimeout. 
            var envwdaConnectionTimeout = Environment.GetEnvironmentVariable("wdaConnectionTimeout");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'envwdaConnectionTimeout' environment variable value: " +
                                  envwdaConnectionTimeout);

            if (!string.IsNullOrWhiteSpace(envwdaConnectionTimeout))
                wdaConnectionTimeout = int.Parse(envwdaConnectionTimeout);

            // Xamarin log directory
            var envXamarinLogDir = Environment.GetEnvironmentVariable("XamarinLogDir");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'XamarinLogDir' environment variable value: " + envXamarinLogDir);

            XamarinLogDir = envXamarinLogDir;

            // Xamarin log directory
            var envHIName = Environment.GetEnvironmentVariable("HIName");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'HIName' environment variable value: " + envHIName);

            HIName = envHIName;

            // Android home path. Formatted like this to stay in line with Google standard env name.
            var envAndroidHomePath = Environment.GetEnvironmentVariable("ANDROID_HOME");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'ANDROID_HOME' environment variable value: " + envAndroidHomePath);

            AndroidHomePath = envAndroidHomePath;
            
            // Android home path. Formatted like this to stay in line with Google standard env name.
            var envAndroidBuildToolsPath = Environment.GetEnvironmentVariable("ANDROID_BUILDTOOLSPATH");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'ANDROID_BuildToolsPath' environment variable value: " + envAndroidBuildToolsPath);

            Android_BuildToolsPath = envAndroidBuildToolsPath;
            
            /// Get Device Name
            ReturnDeviceName();
            
            // App name
            var envAppName = Environment.GetEnvironmentVariable("AppName");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'AppName' environment variable value: " + envAppName);

            AppName = envAppName;

            // ServeLocalAllureReport
            var envServeLocalAllureReport = Environment.GetEnvironmentVariable("ServeLocalAllureReport");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'ServeLocalAllureReport' environment variable value: " + envServeLocalAllureReport);

            if (!string.IsNullOrEmpty(envServeLocalAllureReport))
                ServeLocalAllureReport = bool.Parse(envServeLocalAllureReport);

            // SpeedLink IP
            var envSpeedLinkIP = Environment.GetEnvironmentVariable("SpeedLinkIP");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'SpeedLinkIp' environment variable value: " + envSpeedLinkIP);

            SpeedLinkIp = envSpeedLinkIP;


            // Hearing instrument platform
            var envHearingInstrumentPlatform = Environment.GetEnvironmentVariable("HearingInstrumentPlatform");

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'HearingInstrumentPlatform' environment variable value: " +
                                  envHearingInstrumentPlatform);

            HearingInstrumentPlatform = envHearingInstrumentPlatform;


            // App build number
            var envAppBuildNumber = Environment.GetEnvironmentVariable("AppBuildNumber");
            //  int buildNumber;

            if (LogLevel <= LogType.Info)
                Console.WriteLine($"Using 'AppBuildNumber' environment variable value: {envAppBuildNumber}");

            //   int.TryParse(envAppBuildNumber, out buildNumber);
            //  AppBuildNumber = buildNumber;
            AppBuildNumber = envAppBuildNumber;


            // App version number
            var envAppVersionNumber = Environment.GetEnvironmentVariable("AppVersionNumber");

            if (LogLevel <= LogType.Info)
                Console.WriteLine($"Using 'AppVersionNumber' environment variable value: {envAppVersionNumber}");

            //   int.TryParse(envAppBuildNumber, out buildNumber);
            //  AppBuildNumber = buildNumber;
            AppVersionNumber = envAppVersionNumber;


            // Path to NAS or similar shared drive service accesible to the nodes
            var envSharedDrive = Environment.GetEnvironmentVariable("SharedDrive");

            if (LogLevel <= LogType.Info)
                Console.WriteLine($"Using 'SharedDrive' environment variable value: {envSharedDrive}");

            SharedDrive = envSharedDrive;

            DeviceId = GetDeviceID();

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Fetched available 'DeviceId' as :" + DeviceId +
                                  " from Device Name environmental variable value: " + DeviceName);

            // udid
            var envudid = DeviceId;

            if (LogLevel <= LogType.Info)
                Console.WriteLine("Using 'AppPackage' environment variable value: " + envudid);

            udid = envudid;
        }

        // Method for returning the device name
        private void ReturnDeviceName()
        {
            // Get the value of the "DeviceName" environment variable
            var envDeviceName = Environment.GetEnvironmentVariable("DeviceName");

            // Display information about using the "DeviceName" environment variable value if the log level is sufficient
            if (LogLevel <= LogType.Info)
            {
                Console.WriteLine("Using 'DeviceName' environment variable value: " + envDeviceName);
            }

            // Check the platform and device type, then assign the value to "DeviceName" considering the environment variable value
            if (!AppSettings.IsWindows)
            {
                if (Platform is PlatformType.iOS)
                {
                    DeviceName = GetDeviceName(envDeviceName, "ideviceinfo | awk -F': ' '/DeviceName/ {print $2}'", PhysicalDevice);
                }
                else if (Platform is PlatformType.Android)
                {
                    DeviceName = GetDeviceName(envDeviceName, "adb shell getprop ro.product.vendor.model");
                }
            }
            else
            {
                DeviceName = GetDeviceName(envDeviceName, "adb shell getprop ro.product.vendor.model");
            }
        }

        // Method for getting the device name considering the environment variable value
        private string GetDeviceName(string envDeviceName, string command, bool isPhysicalDevice = true)
        {
            // If the environment variable value is null, execute the appropriate command and return the result
            return envDeviceName ?? AppBase.ExecuteCommandAndReturnOutput(isPhysicalDevice ? command : "xcrun simctl list | grep Booted | awk -F ' ' '{print $1, $2}'").Trim();
        }
    }
}