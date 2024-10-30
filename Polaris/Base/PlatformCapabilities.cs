using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using static Polaris.Base.SettingsBase;

namespace Polaris.Base
{
    public class PlatformCapabilities
    {
        // 
        /// <summary>
        ///     Holds the configuration options for the Appium driver. This includes platform-specific options
        ///     such as device name, platform version, app package, and any other desired capabilities that
        ///     are required to initialize and configure the Appium driver for running tests on mobile devices.
        ///     This field is set once with the desired capabilities and used when creating a new instance of the Appium driver.
        /// </summary>
        private static AppiumOptions? driverOptions;

        /// <summary>
        ///     Gets the settings activity name for the current platform.
        /// </summary>
        /// <value>
        ///     The fully qualified name of the settings activity for iOS or Android platforms.
        /// </value>
        /// <exception cref="System.NotImplementedException">
        ///     Thrown if the platform is not supported or has not been set.
        /// </exception>
        /// <remarks>
        ///     This property uses the current value of the 'Platform' field or property to determine which settings activity name to return.
        ///     For iOS, it returns the name of the Apple settings application.
        ///     For Android, it returns the name of the Android settings application.
        ///     If the platform is neither iOS nor Android, the property throws a NotImplementedException, indicating that the platform is not supported.
        /// </remarks>
        public static string SettingsActivity => Platform switch
        {
            PlatformType.iOS => "com.apple.Preferences",
            PlatformType.Android => "com.android.settings",
            _ => throw new NotImplementedException()
        };

        /// <summary>
        ///     Holds the path to the application package selected by the <see cref="SelectApp"/> method.
        /// </summary>
        /// <remarks>
        ///     This field is statically initialized with the return value of the <see cref="SelectApp"/> method.
        ///     It is intended to be used throughout the application to reference the path of the selected app package.
        ///     Ensure that the <see cref="SelectApp"/> method is called before accessing this field to avoid null reference exceptions.
        /// </remarks>
        public static string AppPathPackage = SelectApp();

        public static string AppType { get; set; } = AppPathPackage.Contains("TestMultiplePlugins")
            ? "TestMultiplePlugins"
            : "TestSinglePlugin";

        /// <summary>
        ///     Initializes the Appium driver options with native iOS capabilities.
        /// </summary>
        /// <param name="goToSettings">If set to true, the driver will navigate to the iOS settings upon initialization.</param>
        /// <param name="language">The language to set for the iOS device (default is "en").</param>
        /// <returns>
        ///     An instance of <see cref="AppiumOptions"/> configured with the desired capabilities for iOS.
        /// </returns>
        /// <remarks>
        ///     This method configures various capabilities for the Appium driver specific to iOS, such as platform name,
        ///     automation name, platform version, device name, and other necessary capabilities. If <paramref name="goToSettings"/>
        ///     is true, it sets the app capability to the iOS settings. Otherwise, it sets the full reset capability.
        ///     The method assumes that static fields for platform, automationName, platformVersion, etc., are already set.
        /// </remarks>
        public static AppiumOptions InitNativeIOSCapabilities(bool goToSettings, string language = "en")
        {
            driverOptions = new AppiumOptions();
            
            lock (driverOptions)
            {
                driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, Platform);
                driverOptions.AddAdditionalCapability("appium:automationName", automationName);
                driverOptions.AddAdditionalCapability("appium:platformVersion", platformVersion);
                driverOptions.AddAdditionalCapability("appium:deviceName", DeviceName);
                driverOptions.AddAdditionalCapability("appium:udid", udid);
                driverOptions.AddAdditionalCapability("appium:xcodeOrgId", xcodeOrgId);
                driverOptions.AddAdditionalCapability("appium:xcodeSigningId", xcodeSigningId);
                driverOptions.AddAdditionalCapability("appium:updateWDABundleId", updatedWDABundleId);
                driverOptions.AddAdditionalCapability("appium:wdaLaunchTimeout", WdaLaunchTimeout);
                driverOptions.AddAdditionalCapability("appium:wdaStartupRetryInterval", wdaStartupRetryInterval);
                driverOptions.AddAdditionalCapability("appium:newCommandTimeout", newCommandTimeout);
                driverOptions.AddAdditionalCapability("appium:includeSafariInWebviews", includeSafariInWebviews);
                driverOptions.AddAdditionalCapability("appium:noReset", noReset);
                driverOptions.AddAdditionalCapability("appium:derivedDataPath", derivedDataPath);
                driverOptions.AddAdditionalCapability("appium:useNewWDA", UseNewWDA);
                driverOptions.AddAdditionalCapability("appium:printPageSourceOnFindFailure", ScreenshotOnPass);
                driverOptions.AddAdditionalCapability("appium:retriesOnError", RetriesOnError);
                driverOptions.AddAdditionalCapability("appium:wdaConnectionTimeout", wdaConnectionTimeout);
                driverOptions.AddAdditionalCapability("appium:locationServicesAuthorized", locationServicesAuthorized);
                driverOptions.AddAdditionalCapability("appium:bundleID", AppBundleId);
                driverOptions.AddAdditionalCapability("appium:language", language);
                
                if (goToSettings)
                {
                    driverOptions.AddAdditionalCapability("appium:app", SettingsActivity);
                }
                else
                {
                    driverOptions.AddAdditionalCapability("appium:fullReset", FullReset);
                }
            }

            return driverOptions;
        }

        /// <summary>
        ///     Initializes the Appium driver options with native Android capabilities.
        /// </summary>
        /// <param name="goToSettings">If set to true, the driver will navigate to the Android settings upon initialization.</param>
        /// <param name="language">The language to set for the Android device (default is "en").</param>
        /// <param name="region">The region to set for the Android device (default is "US").</param>
        /// <returns>
        ///     An instance of <see cref="AppiumOptions"/> configured with the desired capabilities for Android.
        /// </returns>
        /// <remarks>
        ///     This method configures various capabilities for the Appium driver specific to Android, such as platform name,
        ///     automation name, timeouts, and language settings. If <paramref name="goToSettings"/> is true, it sets the
        ///     app package and activity to the Android settings. Otherwise, it sets the full reset capability.
        ///     The method assumes that static fields for platform, automationName, adbExecTimeout, etc., are already set.
        /// </remarks>
        public static AppiumOptions InitNativeAndroidCapabilities(bool goToSettings, string language = "en", string region = "US")
        {
            driverOptions = new AppiumOptions();

            lock (driverOptions)
            {
                driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, Platform);
                driverOptions.AddAdditionalCapability("appium:automationName", automationName);
                driverOptions.AddAdditionalCapability("appium:adbExecTimeout", adbExecTimeout);
                driverOptions.AddAdditionalCapability("appium:uiautomator2ServerInstallTimeout",uiautomator2ServerInstallTimeout);
                driverOptions.AddAdditionalCapability("appium:printPageSourceOnFindFailure", ScreenshotOnPass);
                driverOptions.AddAdditionalCapability("appium:retriesOnError", RetriesOnError);
                driverOptions.AddAdditionalCapability("appium:derivedDataPath", derivedDataPath);
                driverOptions.AddAdditionalCapability("appium:language", language);
                driverOptions.AddAdditionalCapability("appium:locale", region);
                

                if (goToSettings)
                {
                    driverOptions.AddAdditionalCapability("appium:appPackage", SettingsActivity);
                    driverOptions.AddAdditionalCapability("appium:appActivity", ".Settings");
                }
                else
                {
                    driverOptions.AddAdditionalCapability("appium:fullReset", FullReset);
                }
            }

            return driverOptions;
        }

        /// <summary>
        ///     Selects the application file to be used based on the provided AppPackage name or by finding the most recent app file.
        /// </summary>
        /// <returns>
        ///     The full path of the selected application file.
        /// </returns>
        /// <exception cref="System.Exception">
        ///     Thrown when AppPackage is null or empty, and no '.apk' or '.ipa' files are found in the executing assembly's directory.
        /// </exception>
        /// <remarks>
        ///     This method determines the application file path in one of two ways:
        ///     If the AppPackage field is not set (null or empty), it calls the FindApp method to locate the most recently created '.apk' or '.ipa' file in the executing assembly's directory.
        ///     If the AppPackage field is set, it constructs the full path by combining the AppPath field with the AppPackage field.
        ///     The AppPackage field is expected to contain the name of the application file, while the AppPath field should specify the directory where the application file is located.
        /// </remarks>
        private static string SelectApp()
        {
            if (string.IsNullOrEmpty(AppPackage))
            {
                return FindApp();
            }
            else
            {
                return Path.Combine(AppPath, AppPackage);
            }
        }
        
        /// <summary>
        ///     Searches the executing assembly's directory for the most recently created '.apk' or '.ipa' file.
        /// </summary>
        /// <returns>
        ///     The full path of the most recently created application file.
        /// </returns>
        /// <exception cref="System.Exception">
        ///     Thrown when no '.apk' or '.ipa' files are found in the executing assembly's directory.
        /// </exception>
        /// <remarks>
        ///     This method enumerates all files in the directory of the executing assembly and filters them to include only '.apk' (Android app) or '.ipa' (iOS app) files.
        ///     It then orders the filtered files by creation time in descending order, so the most recently created file is considered to be the desired application file.
        ///     If at least one application file is found, the method logs the path of the most recent one and returns it.
        ///     If no application files are found, the method throws an exception indicating the failure to find an application file.
        /// </remarks>
        private static string FindApp()
        {
            // Get the directory path
            var directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    
            // Log the directory path
            Console.WriteLine($"Searching for app files in directory: {directoryPath}");

            var appFiles = Directory.GetFiles(directoryPath)
                .Where(file => Regex.IsMatch(file, @".*\.(apk|ipa)")).ToList();

            if (appFiles.Any())
            {
                var sortedFiles = appFiles
                    .Select(file => new FileInfo(file))
                    .OrderByDescending(file => file.CreationTime)
                    .Select(file => file.FullName)
                    .ToList();

                var foundApp = sortedFiles.First();
                Console.WriteLine($"App has been found: {foundApp}");

                return foundApp;
            }
            else
            {
                throw new Exception($"Cannot find App file in output directory: {directoryPath}");
            }
        }

    }
}