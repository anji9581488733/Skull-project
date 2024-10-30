#region Using Directives

using System.Reflection;
using TestApiHelper.Managers;

#endregion

namespace TestApiHelperUnitTests.Managers.FeatureFileProcessorTests
{
    [TestFixture]
    public class AssemblyDirectoryTests
    {
        [Test]
        public void GetAssemblyDirectory_ReturnsValidDirectoryPath()
        {
            // Act
            string directoryPath = FeatureFileProcessor.GetAssemblyDirectory();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(directoryPath), "The directory path should not be null or empty.");
            Assert.IsTrue(Directory.Exists(directoryPath), "The directory path should point to an existing directory.");
            Assert.AreEqual(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), directoryPath, "The directory path should be the same as the executing assembly's directory.");
        }
    }
}