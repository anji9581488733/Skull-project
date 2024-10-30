using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using static Polaris.Base.SettingsBase;

namespace Polaris.Base
{
    public abstract class AppInitializer
    {
        /// <summary>
        ///     Represents the type of platform for a mobile application.
        /// </summary>
        public enum PlatformType
        {
            /// <summary>
            ///     The iOS platform for Apple devices.
            /// </summary>
            iOS,

            /// <summary>
            ///     The Android platform for devices running the Android operating system.
            /// </summary>
            Android
        }

        /// <summary>
        ///     A dictionary mapping friendly application names to their respective platform-specific application IDs.
        /// </summary>
        private static readonly Dictionary<string, string> applicationIDMappings = new()
        {
            { "TestSinglePlugin", "com.ReSound.TestSinglePlugin" },
            { "UIGallery", "com.ReSound.UIGallery" },
            { "TestMultiplePlugins", "com.ReSound.TestMultiplePlugins" },
            { "JabraHearingTestPOC" , "com.ReSound.JabraHearingTestPOC"},
            { "Preferences" , "com.apple.Preferences"},
            { "settings" , "com.android.settings"}
        };

        /// <summary>
        ///     Holds a reference to the local Appium server service.
        /// </summary>
        /// <remarks>
        ///     This field is used to manage the local instance of the Appium server.
        ///     It can be null if the service has not been started or if it is not being used.
        ///     Proper initialization and disposal of this service are crucial to ensure
        ///     that the Appium server does not continue to run after the tests are completed.
        /// </remarks>
        private static AppiumLocalService? _appiumLocalService;

        /// <summary>
        ///     Gets or sets the Appium driver used for interacting with the mobile application.
        /// </summary>
        /// <value>
        ///     The instance of <see cref="AppiumDriver{IWebElement}"/> that allows for automation of mobile application actions.
        ///     This can be null if the driver has not been initialized.
        /// </value>
        /// <remarks>
        ///     This property should be set with an initialized instance of the Appium driver before attempting to interact with the mobile application.
        ///     It is important to ensure that the driver is properly disposed of after the tests are completed to free up resources.
        /// </remarks>
        public static AppiumDriver<IWebElement>? AppiumDriver { get; set; }

        /// <summary>
        ///     Initializes project and common settings, as well as initializing Xamarin app configuration (ConfigureApp object).
        ///     Project specific implementation of InitializeSettings required.
        /// </summary>
        public static void InitializeSettings()
        {
            // C# is unable to have static abstract methods, so throw an exception notifying of wrong usage instead.
            throw new NotImplementedException(
                "Polaris.InitializeSettings requires project specific implementation, and can not be used in its default form.");
        }

        /// <summary>
        ///     Initializes and starts the Appium driver for the specified mobile platform.
        /// </summary>
        /// <param name="platformType">The type of mobile platform to initialize the driver for (iOS or Android).</param>
        /// <param name="goToSettings">A boolean value indicating whether to navigate to the device settings after initialization.</param>
        /// <param name="language">The language to set for the driver session (default is "en").</param>
        /// <param name="region">The region to set for the driver session (default is "US").</param>
        /// <returns>
        ///     An instance of <see cref="AppiumDriver{IWebElement}"/> if the driver is successfully started, otherwise null.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when an unsupported platform type is provided.</exception>
        /// <exception cref="ApplicationException">Thrown when there is an error starting the Appium driver.</exception>
        /// <remarks>
        ///     This method initializes the Appium driver with platform-specific capabilities and starts a session.
        ///     If <paramref name="goToSettings"/> is true, the method will navigate to the device settings.
        ///     Otherwise, it will attempt to reinstall the application specified by <see cref="PlatformCapabilities.AppPathPackage"/>.
        ///     The method sets an implicit wait of 1 second for the driver session.
        /// </remarks>
        public static AppiumDriver<IWebElement>? StartApp(PlatformType platformType, bool goToSettings=false, string language = "en", string region = "US")
        {
            AppiumOptions driverOptions;
            var builder = StartAppiumLocalServiceWithPath();
            const int webDriverAgentPort = 8100;

            try
            {
                switch (platformType)
                {
                    case PlatformType.iOS:
                        if (AppBase.IsPortInUse(webDriverAgentPort))
                            AppBase.ReleasePort(webDriverAgentPort);
                        driverOptions = PlatformCapabilities.InitNativeIOSCapabilities(goToSettings, language);
                        AppiumDriver = new IOSDriver<IWebElement>(builder, driverOptions, TimeSpan.FromSeconds(180));
                        break;
                    case PlatformType.Android:
                        driverOptions = PlatformCapabilities.InitNativeAndroidCapabilities(goToSettings, language, region);
                        AppiumDriver = new AndroidDriver<IWebElement>(builder, driverOptions, TimeSpan.FromSeconds(180));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(platformType), platformType, "Unsupported platform type.");
                }
                SetImplicitWait(AppiumDriver, TimeSpan.FromSeconds(3));

                if (!goToSettings)
                {
                    if (AppiumDriver is AndroidDriver<IWebElement> androidDriver)
                        androidDriver.PressKeyCode(AndroidKeyCode.Home);

                    ReinstallApp(AppiumDriver, PlatformCapabilities.AppPathPackage);
                    OpenApp(PlatformCapabilities.AppPathPackage);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting Appium driver: {ex.Message}");
                // Throws a new exception with the original one as internal
                throw new ApplicationException("Failed to start the Appium driver.", ex); 
            }

            return AppiumDriver;
        }
        /// <summary>
        ///     Uninstalls and then reinstalls the application on the mobile device using the Appium driver.
        /// </summary>
        /// <param name="driver">The Appium driver instance used to control the mobile device.</param>
        /// <param name="appPathPackage">The application identifier or path used to locate the application to be reinstalled.</param>
        /// <remarks>
        ///     This method will first attempt to map the application identifier from the provided <paramref name="appPathPackage"/>.
        ///     If the application is already installed on the device, it will be uninstalled.
        ///     After uninstallation, or if the app was not present, the method will proceed to install the application.
        ///     It is assumed that the <paramref name="appPathPackage"/> provided is a valid path to the application package or a valid application ID.
        /// </remarks>
        private static void ReinstallApp(AppiumDriver<IWebElement> driver, string appPathPackage)
        {
            string? mappedAppId = ReturnMappedAppID(appPathPackage);

            if (driver.IsAppInstalled(mappedAppId))
                driver.RemoveApp(mappedAppId);

            driver.InstallApp(appPathPackage);
        }

        /// <summary>
        ///     Sets the implicit wait timeout for the Appium driver.
        /// </summary>
        /// <param name="driver">The Appium driver instance used to control the mobile device.</param>
        /// <param name="timeout">The maximum timespan to wait for an element to become available before throwing an exception.</param>
        public static void SetImplicitWait(AppiumDriver<IWebElement> driver, TimeSpan timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = timeout;
        }

        /// <summary>
        ///     Activates or launches the specified application on the connected device.
        /// </summary>
        /// <param name="appId">The friendly name of the application to be opened.</param>
        /// <remarks>
        ///     This method uses the <see cref="ReturnMappedAppID"/> method to resolve the platform-specific application ID
        ///     before attempting to activate or launch the application. It waits up to 180 seconds for the application to launch.
        /// </remarks>
        public static void OpenApp(string appId)
        {
            AppiumDriver.ActivateApp(ReturnMappedAppID(appId), TimeSpan.FromSeconds(180));
        }

        /// <summary>
        ///     Retrieves the platform-specific application ID based on a given friendly name.
        /// </summary>
        /// <param name="input">
        ///     The friendly name of the application.
        /// </param>
        /// <returns>
        ///     The mapped application ID if found; otherwise, null.
        /// </returns>
        public static string? ReturnMappedAppID(string input)    
        {
            var result = applicationIDMappings
                .FirstOrDefault(mapping => input.Contains(mapping.Key));
            
            return result.Value ?? null;
        }
        
        public static void TerminateApp(string appId)
        {
            var appID = ReturnMappedAppID(appId);
            var args = new Dictionary<string, object>
            {
                { "bundleId", appID }
            };
            AppiumDriver.ExecuteScript("mobile: terminateApp", args);
        }
        
        public static void terminateApp(string appId)
        {
            AppiumDriver.TerminateApp(ReturnMappedAppID(appId), TimeSpan.FromSeconds(180));
        }

        /// <summary>
        ///     Retrieves an available port on the local machine.
        /// </summary>
        /// <remarks>
        ///     This method attempts to bind a TcpListener to an automatically assigned port
        ///     and then retrieves the port number. If successful, it returns the available port.
        ///     In case of exceptions, it logs the error message to the console and returns the default Appium port.
        /// </remarks>
        /// <returns>
        ///     An integer representing an available port number or the default Appium port (4723) if an error occurs.
        /// </returns>
        public static int GetAvailablePort()
        {
            var port = 4723;
            try
            {
                var listener = new TcpListener(IPAddress.Loopback, 0);
                listener.Start();
                port = ((IPEndPoint)listener.LocalEndpoint).Port;
                listener.Stop();
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"SocketException: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IOException: {ex.Message}");
            }

            return port;
        }

        /// <summary>
        ///     Initializes and starts the Appium local service with a specified base path.
        /// </summary>
        /// <remarks>
        ///     This method configures and starts an Appium local service instance with custom arguments.
        ///     It sets the base path for the Appium server and adjusts the configuration based on the operating system.
        ///     For Windows, it sets the Appium JavaScript path and Node.js executable path.
        ///     For macOS, it additionally sets the derived data path and log file path.
        ///     The service is started on an available port retrieved from the <see cref="GetAvailablePort"/> method.
        ///     If the service fails to start, it logs the exception to the console.
        /// </remarks>
        /// <returns>An instance of <see cref="AppiumLocalService"/> representing the started Appium server.</returns>
        private static AppiumLocalService? StartAppiumLocalServiceWithPath()
        {
            KeyValuePair<string, string> relaxedsecurity = new KeyValuePair<string, string>("--base-path", "/wd/hub");

            var args = new OptionCollector();
            args.AddArguments(relaxedsecurity);

            if (AppSettings.IsWindows)
            {
                _appiumLocalService = new AppiumServiceBuilder()
                    .WithAppiumJS(new FileInfo(AppiumPath))
                    .UsingDriverExecutable(new FileInfo(@"C:\Program Files\nodejs\node.exe"))
                    .WithIPAddress("127.0.0.1")
                    .UsingPort(GetAvailablePort())
                    .WithArguments(args)
                    .WithLogFile(new FileInfo(LogPath))
                    .Build();
            }
            else
            {
                KeyValuePair<string, string> derivedPath = new KeyValuePair<string, string>("--default-capabilities", $"\"{{\\\"derivedDataPath\\\": \\\"{derivedDataPath}\\\"}}\"");
                args.AddArguments(derivedPath);

                _appiumLocalService = new AppiumServiceBuilder()
                    .WithAppiumJS(new FileInfo(AppiumNodePath))
                    .UsingDriverExecutable(new FileInfo(NodePath))
                    .WithIPAddress("127.0.0.1")
                    .UsingPort(GetAvailablePort())
                    .WithArguments(args)
                    .WithLogFile(new FileInfo(LogPath))
                    .Build();
            }

            try
            {
                if (!_appiumLocalService.IsRunning)
                {
                    _appiumLocalService.Start();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, rethrow it, etc.)
                Console.WriteLine($"Error starting Appium server: {ex.Message}");
            }

            return _appiumLocalService;
        }
    }
}