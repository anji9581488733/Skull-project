using System;
using System.Configuration;
using System.IO;
using Fenris.Hooks;
using Fenris.Steps.Base;
using Polaris.Base;
using Reqnroll;
using SettingsBase = Polaris.Base.SettingsBase;


namespace Fenris.Steps
{
    [Binding]
    public sealed class Playground : StepsBase
    {
        [Given(@"shared drive is readable")]
        public void GivenSharedDriveIsReadable()
        {
            if (!Directory.Exists(SettingsBase.SharedDrive))
            {
                throw new Exception($"Shared drive not accessible at: {SettingsBase.SharedDrive}");
            }

            Console.WriteLine($"Shared drive '{SettingsBase.SharedDrive}' is accessible");
        }


        [When(@"I create a file named ""(.*)"" on the shared drive")]
        public void WhenICreateAFileNamedOnTheSharedDrive(string FileName)
        {
            File.Create(Path.Combine(SettingsBase.SharedDrive, FileName));
        }


        [Then(@"validate ""(.*)"" exists on the shared drive")]
        public void ThenValidateExistsOnTheSharedDrive(string FileName)
        {
            var filePath = Path.Combine(SettingsBase.SharedDrive, FileName);

            if (!File.Exists(filePath))
            {
                throw new Exception($"File not found at {filePath}");
            }

            Console.WriteLine($"File found on shared drive at {filePath}");
        }


        [Given(@"I set AppPackage to '(.*)'")]
        public void GivenISetAppPackageTo(string AppPackage)
        {
            SettingsBase.AppPackage = AppPackage;
            if (!File.Exists(Path.Combine(SettingsBase.AppPath, SettingsBase.AppPackage)))
            {
                throw new Exception(Path.Combine(SettingsBase.AppPath, SettingsBase.AppPackage) + " not found...");
            }

            Console.WriteLine($"AppPackage set to {AppPackage}");
        }


        [Given(@"I set AppName to '(.*)'")]
        public void GivenISetAppNameTo(string AppName)
        {
            SettingsBase.AppName = AppName;
        }


        /// <summary>
        ///     Used for creating a pending step in the report in test og Gleipner.
        /// </summary>
        [When(@"I am pending a step")]
        public void WhenPendingStepOne()
        {
            ScenarioContext.Current.Pending();
        }
    }
}