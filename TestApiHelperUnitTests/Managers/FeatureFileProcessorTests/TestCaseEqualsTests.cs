#region Using Directives

using TestApiHelper.Managers;
using TestApiHelper.Misc;

#endregion

namespace TestApiHelperUnitTests.Managers.FeatureFileProcessorTests
{
    [TestFixture]
    public class TestCaseEqualsTests
    {
        [Test]
        public void TestCaseEquals_IdenticalScenarios_ReturnsTrue()
        {
            // Arrange
            var scenario1 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "And I press 'Close Button' on Assembly List Plugin Page"
            }
            };
            var scenario2 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "And I press 'Close Button' on Assembly List Plugin Page"
            }
            };

            // Act
            bool areEqual = FeatureFileProcessor.TestCaseEquals(scenario1, scenario2);

            // Assert
            Assert.IsTrue(areEqual, "Scenarios should be equal when they have identical properties.");
        }

        [Test]
        public void TestCaseEquals_IdenticalScenariosWithExamples_ReturnsTrue()
        {
            // Arrange
            var scenario1 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "And I press 'Close Button' on Assembly List Plugin Page"
            },
                Examples = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "en", "US" },
                    { "pl", "PL" },
                    { "de", "DE" },
                }
            }
            };
            var scenario2 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "And I press 'Close Button' on Assembly List Plugin Page"
            },
                Examples = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "en", "US" },
                    { "pl", "PL" },
                    { "de", "DE" },
                }
            }
            };

            // Act
            bool areEqual = FeatureFileProcessor.TestCaseEquals(scenario1, scenario2);

            // Assert
            Assert.IsTrue(areEqual, "Scenarios should be equal when they have identical properties.");
        }

        [Test]
        public void TestCaseEquals_ScenariosWithDifferentCountOfExamples_ReturnsFalse()
        {
            // Arrange
            var scenario1 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "And I press 'Close Button' on Assembly List Plugin Page"
            },
                Examples = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "en", "US" },
                    { "pl", "PL" },
                    { "de", "DE" },
                }
            }
            };
            var scenario2 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "And I press 'Close Button' on Assembly List Plugin Page"
            },
                Examples = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "en", "US" },
                    { "pl", "PL" },
                }
            }
            };

            // Act
            bool areEqual = FeatureFileProcessor.TestCaseEquals(scenario1, scenario2);

            // Assert
            Assert.IsFalse(areEqual, "Scenarios should be not equal when they have different examples count.");
        }

        [Test]
        public void TestCaseEquals_ScenariosWithDifferentExamplesContent_ReturnsFalse()
        {
            // Arrange
            var scenario1 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "And I press 'Close Button' on Assembly List Plugin Page"
            },
                Examples = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "en", "US" },
                    { "pl", "PL" },
                    { "de", "DE" },
                }
            }
            };
            var scenario2 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "And I press 'Close Button' on Assembly List Plugin Page"
            },
                Examples = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "en", "US" },
                    { "pl", "PL" },
                    { "xx", "XX" },
                }
            }
            };

            // Act
            bool areEqual = FeatureFileProcessor.TestCaseEquals(scenario1, scenario2);

            // Assert
            Assert.IsFalse(areEqual, "Scenarios should be not equal when they have different examples.");
        }

        [Test]
        public void TestCaseEquals_ScenariosWithDifferentCountOfSteps_ReturnsFalse()
        {
            // Arrange
            var scenario1 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "And I press 'Close Button' on Assembly List Plugin Page"
            },
                Examples = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "en", "US" },
                    { "pl", "PL" },
                    { "de", "DE" },
                }
            }
            };
            var scenario2 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
            },
                Examples = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "en", "US" },
                    { "pl", "PL" },
                    { "de", "DE" },
                }
            }
            };

            // Act
            bool areEqual = FeatureFileProcessor.TestCaseEquals(scenario1, scenario2);

            // Assert
            Assert.IsFalse(areEqual, "Scenarios should be not equal when they have different step count.");
        }

        [Test]
        public void TestCaseEquals_ScenariosWithDifferentStepsContent_ReturnsFalse()
        {
            // Arrange
            var scenario1 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "And I press 'Close Button' on Assembly List Plugin Page"
            },
                Examples = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "en", "US" },
                    { "pl", "PL" },
                    { "de", "DE" },
                }
            }
            };
            var scenario2 = new Scenario
            {
                Title = "Verify Plugin",
                Tags = new List<string> { "@label:allure_id:123456", "@Smoke" },
                Steps = new List<string>
            {
                "Given I launch the plugin app",
                "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "ABC"
            },
                Examples = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "en", "US" },
                    { "pl", "PL" },
                    { "de", "DE" },
                }
            }
            };

            // Act
            bool areEqual = FeatureFileProcessor.TestCaseEquals(scenario1, scenario2);

            // Assert
            Assert.IsFalse(areEqual, "Scenarios should be not equal when they have different steps.");
        }

        
    }
}