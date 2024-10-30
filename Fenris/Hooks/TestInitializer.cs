using Polaris.Base;
using System;

namespace Fenris.Hooks
{
    public class TestInitializer : Gleipner.Base.PageBase
    {
        public static void BeforeTestRun()
        {
            Console.WriteLine("Starting test run and initializing settings.");

            // Preload settings so they're ready for the pre-test related consumers of settings.
            Gleipner.ConfigElement.AppInitializer.InitializeSettings();
            AllureReporting.InitializeReport();
        }
    }
}