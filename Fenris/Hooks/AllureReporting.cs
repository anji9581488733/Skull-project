using Allure.Net.Commons;
using OpenQA.Selenium;
using Polaris;
using Polaris.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fenris.Hooks;

public class AllureReporting
{
    #region Public Methods

    public static void InitializeReport()
    {
        if (SettingsBase.ServeLocalAllureReport)
            CloseAllureServeProcesses();

        // Clean up the allure-results directory
        AllureLifecycle.Instance.CleanupResultDirectory();

        // Generate the environment.properties file in the allure-results directory
        GenerateAllureEnvironment(AppSettings.AllureResultsDirectory);
    }

    /// <summary>
    /// Copy the latest history directory to the allure-results directory.
    /// </summary>
    public static void RestoreHistory()
    {
        if (Directory.Exists(AppSettings.AllureHistoryPath))
        {
            // Take all the directories from the history folder
            var historyDirectories = Directory.GetDirectories(AppSettings.AllureHistoryPath);

            // Check if there are any directories in the history folder
            if (historyDirectories.Length > 0)
            {
                // Sort the directories by the last write time and take the latest one
                var latestHistoryDirectory = historyDirectories
                    .Select(directory => new DirectoryInfo(directory))
                    .OrderByDescending(directoryInfo => directoryInfo.LastWriteTime)
                    .First()
                    .FullName;

                // Define the path to the 'history' subfolder in the latest history directory
                var historySubfolderSourcePath = Path.Combine(latestHistoryDirectory, "history");

                // Define the path to the 'history' subfolder in the latest history directory
                var historySubfolderDestinationPath = Path.Combine(AppSettings.AllureResultsDirectory.FullName, "history");

                // Copy the contents of the latest history directory to the allure-results directory
                CopyDirectoryContents(historySubfolderSourcePath, historySubfolderDestinationPath);
            }
        }
        else
        {
            Directory.CreateDirectory(AppSettings.AllureResultsDirectory.FullName);
        }
    }

    /// <summary>
    /// 1. Copy the contents of the allure-result directory to the allure-results directory.
    /// 2. Copy the contents of the allure-results directory to the history directory.
    /// </summary>
    public static void SaveHistory()
    {
        if (Directory.Exists(AppSettings.GeneratedAllureResultDirectory.FullName))
        {
            CopyDirectoryContents(AppSettings.GeneratedAllureResultDirectory.FullName, AppSettings.AllureResultsDirectory.FullName);
            CopyDirectoryContents(AppSettings.AllureResultsDirectory.FullName, AppSettings.TimestampedAppiumHistoryDirectoryPath);
        }
    }

    /// <summary>
    /// Method to close all the allure serve processes.
    /// </summary>
    public static void CloseAllureServeProcesses()
    {
        Process[] processes = Process.GetProcessesByName("java");

        foreach (Process process in processes)
        {
            try
            {
                process.Kill();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during closing process: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Generate the allure report from the allure-results directory.
    /// </summary>
    public static void GenerateHistory()
    {
        AppBase.ExecuteCommand($"allure generate {AppSettings.AllureResultsDirectory} --clean -o {AppSettings.GeneratedAllureResultDirectory.FullName}");
    }

    /// <summary>
    /// Method to copy the contents of a directory to another directory.
    /// </summary>
    /// <param name="sourceDirectoryPath"></param>
    /// <param name="destinationDirectoryPath"></param>
    public static void CopyDirectoryContents(string sourceDirectoryPath, string destinationDirectoryPath)
    {
        // Create the destination directory if it does not exist
        if (!Directory.Exists(destinationDirectoryPath))
        {
            Directory.CreateDirectory(destinationDirectoryPath);
        }

        // Copy each directory and its contents to destination
        foreach (string dirPath in Directory.GetDirectories(sourceDirectoryPath, "*", SearchOption.AllDirectories))
        {
            // Create the destination directory based on the relative path
            Directory.CreateDirectory(Path.Combine(destinationDirectoryPath, Path.GetRelativePath(sourceDirectoryPath, dirPath)));
        }

        // Copy each file to destination
        foreach (string filePath in Directory.GetFiles(sourceDirectoryPath, "*.*", SearchOption.AllDirectories))
        {
            // Create the new file path based on the relative path
            string newFilePath = Path.Combine(destinationDirectoryPath, Path.GetRelativePath(sourceDirectoryPath, filePath));
            File.Copy(filePath, newFilePath, true);
        }
    }

    public static void TakeAndSaveScreenshot(string language = "en", string region = "US")
    {
        AllureApi.AddAttachment("Screenshot", "image/png", SaveScreenshot(language, region));
    }
    
    public static string TakesAndSaveScreenshot(string suffix = "")
    {
        return SaveScreenshot(suffix);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Save the screenshot to the allure-results directory.
    /// </summary>
    /// <param name="language"></param>
    /// <param name="region"></param>
    /// <returns></returns>
    private static string SaveScreenshot(string language = "en", string region = "US")
    {
        try
        {
            var screenshot = ((ITakesScreenshot)Polaris.Base.PageBase.driver).GetScreenshot();
            var screenshotPath = Path.Combine(AppSettings.AllureResultsDirectory.FullName, "Screenshots");
            Directory.CreateDirectory(screenshotPath);
            var fileName = $"{language}_{region}_screenshot_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.png";
            var filePath = Path.Combine(screenshotPath, fileName);
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);

            return filePath;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save screenshot: " + ex.ToString());
            return null;
        }
    }
    
    private static string SaveScreenshot(string suffix = "")
    {
        try
        {
            string deviceName = SettingsBase.DeviceName;
            string appPackage = SettingsBase.AppPackage;
            string pluginName = Path.GetFileNameWithoutExtension(appPackage); // Get the plugin name from the AppPackage

            var screenshot = ((ITakesScreenshot)Polaris.Base.PageBase.driver).GetScreenshot();
            var screenshotPath = Path.Combine(AppSettings.AllureResultsDirectory.FullName, "Screenshots", deviceName, pluginName);
            Directory.CreateDirectory(screenshotPath);
            var fileName = $"screenshot_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}{(string.IsNullOrEmpty(suffix) ? "" : $"_{suffix}")}.png";
            var filePath = Path.Combine(screenshotPath, fileName);
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);

            return filePath;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save screenshot: " + ex.ToString());
            return null;
        }
    }

    /// <summary>
    /// Generate the environment.properties file in the allure-results directory.
    /// </summary>
    /// <param name="directory"></param>
    /// <exception cref="ArgumentException"></exception>
    private static void GenerateAllureEnvironment(DirectoryInfo directory)
    {
        var environmentVariables = Environment.GetEnvironmentVariables();
        string filePath = "environment.properties";
        var newFilePath = Path.Combine(directory.FullName, filePath);

        List<string> importantEnv = new()
        {
            "platformName",
            nameof(SettingsBase.PhysicalDevice),
            nameof(SettingsBase.automationName),
            nameof(SettingsBase.AppPackage),
            nameof(SettingsBase.HearingInstrumentPlatform),
            "BuildVersion"
        };

        try
        {
            // Check that the ANDROID_HOME environment variable is set
            string androidHome = Environment.GetEnvironmentVariable("ANDROID_HOME");
            if (string.IsNullOrEmpty(androidHome))
            {
                throw new Exception(
                    "The ANDROID_HOME environment variable is not set. Make sure the Android SDK is installed.");
            }

            // Construct full path to aapt.exe file
            string buildToolsFolder = Path.Combine(androidHome, "build-tools");

            // Check the available build-tools versions and choose the latest one
            string? latestBuildToolsVersion = GetLatestBuildToolsVersion(buildToolsFolder);
            if (string.IsNullOrEmpty(latestBuildToolsVersion))
            {
                throw new Exception(
                    "Build-tools versions not found installed. Make sure the Android SDK is installed.");
            }

            string aaptFileName;
            string grepCommand;


            if (AppSettings.IsWindows)
            {
                aaptFileName = "aapt.exe";
                grepCommand = "findstr versionCode";
            }
            else
            {
                aaptFileName = "aapt";
                grepCommand = "grep versionCode";
            }

            string aaptPath = Path.Combine(buildToolsFolder, latestBuildToolsVersion, aaptFileName);
            string testedAppPath = PlatformCapabilities.AppPathPackage;
            Console.WriteLine(aaptPath.Equals(null)); // prints True if aaptPath is null
            Console.WriteLine(testedAppPath.Equals(null)); // prints True if testedAppPath is null
            Console.WriteLine(grepCommand.Equals(null)); // prints True if grepCommand is null
            // Run the aapt command and get the output
            try
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = aaptPath,
                    Arguments = string.Format(@"dump badging {0} | {1}", testedAppPath, grepCommand),
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };
                Console.WriteLine(processStartInfo.Equals(null));
                if (processStartInfo != null)
                {
                    var process = new Process
                    {
                        StartInfo = processStartInfo,
                        EnableRaisingEvents = true
                    };

                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    // Parse the output to extract the versionCode
                    var match = Regex.Match(output, "versionCode='(\\d+)'");
                    if (match.Success)
                    {
                        string versionCode = match.Groups[1].Value;

                        // Add the versionCode to the environment variables
                        environmentVariables["BuildVersion"] = versionCode;
                    }
                }

                SaveEnvironmentDataToFile(newFilePath, importantEnv, environmentVariables);

                Console.WriteLine($"New file {newFilePath} has been created.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        catch (Exception ex)
        {
            throw new ArgumentException($"Failed to create a file. Exception: {ex.Message}");
        }
    }

    /// <summary>
    /// Get the latest build-tools version from the build-tools folder.
    /// </summary>
    /// <param name="buildToolsFolder"></param>
    /// <returns></returns>
    private static string GetLatestBuildToolsVersion(string buildToolsFolder)
    {
        // Check the available build-tools versions and choose the latest one
        if (Directory.Exists(buildToolsFolder))
        {
            var subdirectories = Directory.GetDirectories(buildToolsFolder);
            if (subdirectories.Length > 0)
            {
                // Sort the versions in descending order and select the first one
                Array.Sort(subdirectories, (a, b) => string.Compare(b, a, StringComparison.OrdinalIgnoreCase));
                return Path.GetFileName(subdirectories[0]);
            }
        }

        return null;
    }

    /// <summary>
    /// Save the environment data to a file.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="importantEnv"></param>
    /// <param name="data"></param>
    private static void SaveEnvironmentDataToFile(string filePath, List<string> importantEnv, IDictionary data)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            switch (true)
            {
                case bool when AppSettings.IsWindows:
                    sw.WriteLine($"HostOS=Windows");
                    break;
                case bool when !AppSettings.IsWindows:
                    sw.WriteLine($"HostOS=Mac");
                    break;
            }
            sw.WriteLine($"UDID={SettingsBase.DeviceId}");
            sw.WriteLine($"DeviceName={SettingsBase.DeviceName}");

            foreach (DictionaryEntry entry in data)
            {
                string key = entry.Key.ToString() ?? string.Empty;
                string value = entry.Value?.ToString() ?? string.Empty;

                if (importantEnv.Contains(key))
                    sw.WriteLine($"{key}={value.Replace("\\", "\\\\")}");
            }

        }
    }

    #endregion

}