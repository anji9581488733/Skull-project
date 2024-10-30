using Polaris.Base;

namespace Gleipner.ConfigElement
{
    /// <summary>
    ///     Settings used in app.config and frameworkelement.cs file
    /// </summary>
    public class Settings : SettingsBase
    {
        /// <summary>
        ///     Path to Android simulator when using adb
        /// </summary>
        public static string AndroidSimulatorPath { get; internal set; }


        /// <summary>
        ///     Run tests on simulator or physical device
        /// </summary>
        public static bool ExecuteOnSimulator { get; internal set; }

        /// <summary>
        ///     Wipe device app cache on loading/installing app.
        ///     Currently only for Android
        /// </summary>
        public static bool AppDataModeClear { get; internal set; }


        /// <summary>
        ///     Loads settings data for Gandalf from PATH variables, where applicable.
        /// </summary>
        public override void InitializeSettings()
        {
            InitializeBaseSettings();
        }
    }
}