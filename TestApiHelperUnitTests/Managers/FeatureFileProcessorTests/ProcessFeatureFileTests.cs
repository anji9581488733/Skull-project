#region Using Directives

using TestApiHelper.Managers;
using TestApiHelper.Misc;

#endregion

namespace TestApiHelperUnitTests.Managers.FeatureFileProcessorTests
{
    [TestFixture]
    public class ProcessFeatureFile
    {
        [Test]
        public void ProcessFeatureFile_TagInOneLine_ReturnsCorrectScenarios()
        {
            // Arrange
            var lines = new[] 
            {
            "Feature: Some feature",
            "",
            "",
            "  @label:allure_id:123456",
            "  Scenario: Some scenario",
            "    Given some precondition",
            "    When some action is taken",
            "    Then some result is expected"
            };
            var expectedScenarios = new List<Scenario>
        {
            new Scenario
            {
                Id = "123456",
                Tags = new List<string> { "@label:allure_id:123456" },
                Title = "Some scenario",
                Steps = new List<string>
                {
                    "Given some precondition",
                    "When some action is taken",
                    "Then some result is expected"
                },
                Examples = new List<Dictionary<string, string>>()
            }
        };

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines);

            // Assert
            Assert.AreEqual(expectedScenarios.Count, actualScenarios.Count(), "The number of scenarios should match.");
            for (int i = 0; i < expectedScenarios.Count; i++)
            {
                Assert.AreEqual(expectedScenarios[i].Id, actualScenarios.ElementAt(i).Id, "Scenario IDs should match.");
                Assert.AreEqual(expectedScenarios[i].Title, actualScenarios.ElementAt(i).Title, "Scenario titles should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Tags, actualScenarios.ElementAt(i).Tags, "Scenario tags should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Steps, actualScenarios.ElementAt(i).Steps, "Scenario steps should match.");
            }
        }

        [Test]
        public void ProcessFeatureFile_TagsInMultipleLines_ReturnsCorrectScenarios()
        {
            // Arrange
            var lines = new[] 
            {
            "Feature: Some feature",
            "",
            "",
            "  @blabla",
            "  @label:allure_id:123456",
            "  Scenario: Some scenario",
            "    Given some precondition",
            "    When some action is taken",
            "    Then some result is expected"
            };
            var expectedScenarios = new List<Scenario>
        {
            new Scenario
            {
                Id = "123456",
                Tags = new List<string> { "@blabla", "@label:allure_id:123456" },
                Title = "Some scenario",
                Steps = new List<string>
                {
                    "Given some precondition",
                    "When some action is taken",
                    "Then some result is expected"
                },
                Examples = new List<Dictionary<string, string>>()
            }
        };

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines);

            // Assert
            Assert.AreEqual(expectedScenarios.Count, actualScenarios.Count(), "The number of scenarios should match.");
            for (int i = 0; i < expectedScenarios.Count; i++)
            {
                Assert.AreEqual(expectedScenarios[i].Id, actualScenarios.ElementAt(i).Id, "Scenario IDs should match.");
                Assert.AreEqual(expectedScenarios[i].Title, actualScenarios.ElementAt(i).Title, "Scenario titles should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Tags, actualScenarios.ElementAt(i).Tags, "Scenario tags should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Steps, actualScenarios.ElementAt(i).Steps, "Scenario steps should match.");
            }
        }

        [Test]
        public void ProcessFeatureFile_TagsInMultipleLinesIDAbove_ReturnsCorrectScenarios()
        {
            // Arrange
            var lines = new[] 
            {
            "Feature: Some feature",
            "",
            "",
            "  @blabla",
            "  @label:allure_id:123456",
            "  @blabla",
            "  Scenario: Some scenario",
            "    Given some precondition",
            "    When some action is taken",
            "    Then some result is expected"
            };
            var expectedScenarios = new List<Scenario>
            {
            new Scenario
            {
                Id = "123456",
                Tags = new List<string> { "@blabla", "@label:allure_id:123456", "@blabla" },
                Title = "Some scenario",
                Steps = new List<string>
                {
                    "Given some precondition",
                    "When some action is taken",
                    "Then some result is expected"
                },
                Examples = new List<Dictionary<string, string>>()
            }
        };

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines);

            // Assert
            Assert.AreEqual(expectedScenarios.Count, actualScenarios.Count(), "The number of scenarios should match.");
            for (int i = 0; i < expectedScenarios.Count; i++)
            {
                Assert.AreEqual(expectedScenarios[i].Id, actualScenarios.ElementAt(i).Id, "Scenario IDs should match.");
                Assert.AreEqual(expectedScenarios[i].Title, actualScenarios.ElementAt(i).Title, "Scenario titles should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Tags, actualScenarios.ElementAt(i).Tags, "Scenario tags should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Steps, actualScenarios.ElementAt(i).Steps, "Scenario steps should match.");
            }
        }

        [Test]
        public void ProcessFeatureFile_MultipleScenarios_ReturnsCorrectScenarios()
        {
            // Arrange
            var lines = new[] 
            {
            "Feature: Some feature",
            "",
            "",
            "  @tag1",
            "  @label:allure_id:123456",
            "  @tag2",
            "  Scenario: Some scenario",
            "    Given some precondition",
            "    When some action is taken",
            "    Then some result is expected",
            "",
            "",
            "  @tag3",
            "  @label:allure_id:234567 @tag4",
            "  @tag5",
            "  Scenario: Some scenario",
            "  Given some precondition",
            "    When some action is taken",
            "    Then some result is expected",
            };
            var expectedScenarios = new List<Scenario>
            {
            new Scenario
            {
                Id = "123456",
                Tags = new List<string> { "@tag1", "@label:allure_id:123456", "@tag2" },
                Title = "Some scenario",
                Steps = new List<string>
                {
                    "Given some precondition",
                    "When some action is taken",
                    "Then some result is expected"
                },
                Examples = new List<Dictionary<string, string>>()
            },
            new Scenario
            {
                Id = "234567",
                Tags = new List<string> { "@tag3", "@label:allure_id:234567", "@tag4", "@tag5" },
                Title = "Some scenario",
                Steps = new List<string>
                {
                    "Given some precondition",
                    "When some action is taken",
                    "Then some result is expected"
                },
                Examples = new List<Dictionary<string, string>>()
            }
        };

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines);

            //// Assert
            Assert.AreEqual(expectedScenarios.Count, actualScenarios.Count(), "The number of scenarios should match.");
            for (int i = 0; i < expectedScenarios.Count; i++)
            {
                Assert.AreEqual(expectedScenarios[i].Id, actualScenarios.ElementAt(i).Id, "Scenario IDs should match.");
                Assert.AreEqual(expectedScenarios[i].Title, actualScenarios.ElementAt(i).Title, "Scenario titles should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Tags, actualScenarios.ElementAt(i).Tags, "Scenario tags should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Steps, actualScenarios.ElementAt(i).Steps, "Scenario steps should match.");
            }
        }

        [Test]
        public void ProcessFeatureFile_MultipleScenariosNotFormatted_ReturnsCorrectScenarios()
        {
            // Arrange
            var lines = new[] 
            {
            "Feature: Some feature",
            "",
            "",
            "                           @blabla",
            "     @label:allure_id:123456",
            "    @blabla",
            "                Scenario: Some scenario",
            " Given some precondition",
            "                  When some action is taken",
            "   Then some result is expected",
            "",
            "",
            "                   @blabla",
            "            @label:allure_id:234567",
            "    @blabla",
            "Scenario: Some scenario",
            "              Given some precondition",
            "    When some action is taken",
            "            Then some result is expected",
            };
            var expectedScenarios = new List<Scenario>
            {
            new Scenario
            {
                Id = "123456",
                Tags = new List<string> { "@blabla", "@label:allure_id:123456", "@blabla" },
                Title = "Some scenario",
                Steps = new List<string>
                {
                    "Given some precondition",
                    "When some action is taken",
                    "Then some result is expected"
                },
                Examples = new List<Dictionary<string, string>>()
            },
            new Scenario
            {
                Id = "234567",
                Tags = new List<string> { "@blabla", "@label:allure_id:234567", "@blabla" },
                Title = "Some scenario",
                Steps = new List<string>
                {
                    "Given some precondition",
                    "When some action is taken",
                    "Then some result is expected"
                },
                Examples = new List<Dictionary<string, string>>()
            }
        };

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines);

            //// Assert
            Assert.AreEqual(expectedScenarios.Count, actualScenarios.Count(), "The number of scenarios should match.");
            for (int i = 0; i < expectedScenarios.Count; i++)
            {
                Assert.AreEqual(expectedScenarios[i].Id, actualScenarios.ElementAt(i).Id, "Scenario IDs should match.");
                Assert.AreEqual(expectedScenarios[i].Title, actualScenarios.ElementAt(i).Title, "Scenario titles should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Tags, actualScenarios.ElementAt(i).Tags, "Scenario tags should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Steps, actualScenarios.ElementAt(i).Steps, "Scenario steps should match.");
            }
        }

        [Test]
        public void ProcessFeatureFile_WithExamplesSection_ReturnsScenariosWithExamples()
        {
            // Arrange
            var lines = new[]
            {
                "@Language",
                "Scenario Outline: Verify Consent Plugin in different languages",
                "    Given I launch the plugin app in '<language>' and '<region>'",
                "    When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "    Then Validate 'Closed' text is displayed on the Display Message plugin page",
                "",
                "Examples:",
                "| language | region |",
                "| en       | US     |",
                "| pl       | PL     |",
                "| da       | DK     |"
            };

            var expectedExamples = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "language", "en" }, { "region", "US" } },
                new Dictionary<string, string> { { "language", "pl" }, { "region", "PL" } },
                new Dictionary<string, string> { { "language", "da" }, { "region", "DK" } }
            };

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines).ToList();

            // Assert
            Assert.AreEqual(1, actualScenarios.Count, "There should be one scenario processed.");
            var scenario = actualScenarios.First();
            Assert.AreEqual("Verify Consent Plugin in different languages", scenario.Title, "The scenario title should match.");
            Assert.AreEqual(expectedExamples.Count, scenario.Examples.Count, "The number of examples should match.");
            for (int i = 0; i < expectedExamples.Count; i++)
            {
                CollectionAssert.AreEqual(expectedExamples[i], scenario.Examples[i], $"The example at index {i} should match.");
            }
        }

        [Test]
        public void ProcessFeatureFile_MultipleScenariosWithExamplesSection_ReturnsScenariosWithExamples()
        {
            // Arrange
            var lines = new[]
            {
                "@Language",
                "Scenario Outline: Verify Consent Plugin in different languages",
                "    Given I launch the plugin app in '<language>' and '<region>'",
                "    When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                "    Then Validate 'Closed' text is displayed on the Display Message plugin page",
                "",
                "Examples:",
                "| language | region |",
                "| en       | US     |",
                "| pl       | PL     |",
                "| da       | DK     |",
                "",
                "",
                "  @blabla",
                "  @label:allure_id:123456",
                "  @blabla",
                "  Scenario: Some scenario",
                "    Given some precondition",
                "    When some action is taken",
                "    Then some result is expected",
                "",
                "",
                "  @blabla",
                "  @label:allure_id:234567",
                "  @blabla",
                "  Scenario: Some scenario",
                "  Given some precondition",
                "    When some action is taken",
                "    Then some result is expected",
            };

            var expectedScenarios = new List<Scenario>
            {

                new Scenario
                {
                    Id = null,
                    Tags = new List<string> { "@Language" },
                    Title = "Verify Consent Plugin in different languages",
                    Steps = new List<string>
                    {
                        "Given I launch the plugin app in '<language>' and '<region>'",
                        "When I press 'Copy Assembly List' on Assemble List Plugin Page and copy contents to the report",
                        "Then Validate 'Closed' text is displayed on the Display Message plugin page"
                    },
                    Examples = new List<Dictionary<string, string>>
                    {
                        new Dictionary<string, string> { { "language", "en" }, { "region", "US" } },
                        new Dictionary<string, string> { { "language", "pl" }, { "region", "PL" } },
                        new Dictionary<string, string> { { "language", "da" }, { "region", "DK" } }
                    }
                },
                new Scenario
                {
                    Id = "123456",
                    Tags = new List<string> { "@blabla", "@label:allure_id:123456", "@blabla" },
                    Title = "Some scenario",
                    Steps = new List<string>
                    {
                        "Given some precondition",
                        "When some action is taken",
                        "Then some result is expected"
                    },
                    Examples = new List<Dictionary<string, string>>()
                },
                new Scenario
                {
                    Id = "234567",
                    Tags = new List<string> { "@blabla", "@label:allure_id:234567", "@blabla" },
                    Title = "Some scenario",
                    Steps = new List<string>
                    {
                        "Given some precondition",
                        "When some action is taken",
                        "Then some result is expected"
                    },
                    Examples = new List<Dictionary<string, string>>()
                }
            };

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines).ToList();

            // Assert
            Assert.AreEqual(expectedScenarios.Count, actualScenarios.Count, "The number of scenarios should match.");
            for (int i = 0; i < expectedScenarios.Count; i++)
            {
                Assert.AreEqual(expectedScenarios[i].Id, actualScenarios.ElementAt(i).Id, "Scenario IDs should match.");
                Assert.AreEqual(expectedScenarios[i].Title, actualScenarios.ElementAt(i).Title, "Scenario titles should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Tags, actualScenarios.ElementAt(i).Tags, "Scenario tags should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Steps, actualScenarios.ElementAt(i).Steps, "Scenario steps should match.");
                for (int j = 0; j < expectedScenarios[i].Examples.Count; j++)
                {
                    CollectionAssert.AreEqual(expectedScenarios[i].Examples[j], actualScenarios.ElementAt(i).Examples[j], $"The example at index {j} should match.");
                }
            }
        }

        [Test]
        public void ProcessFeatureFile_WithDescriptionInParentheses_ReturnsCorrectDescription()
        {
            // Arrange
            var lines = new[] {
            "Feature: Some feature",
            "",
            "  @label:allure_id:123456",
            "  Scenario: Some scenario (Description of the scenario)",
            "    Given some precondition",
            "    When some action is taken",
            "    Then some result is expected"
            };
            var expectedDescription = "Description of the scenario";

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines).ToList();

            // Assert
            Assert.AreEqual(1, actualScenarios.Count, "There should be one scenario processed.");
            var scenario = actualScenarios.First();
            Assert.AreEqual(expectedDescription, scenario.Description, "The scenario description should match.");
        }

        [Test]
        public void ProcessFeatureFile_WithoutDescription_ReturnsEmptyDescription()
        {
            // Arrange
            var lines = new[] 
            {
            "Feature: Some feature",
            "",
            "  @label:allure_id:123456",
            "  Scenario: Some scenario",
            "    Given some precondition",
            "    When some action is taken",
            "    Then some result is expected"
            };
            var expectedDescription = string.Empty;

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines).ToList();

            // Assert
            Assert.AreEqual(1, actualScenarios.Count, "There should be one scenario processed.");
            var scenario = actualScenarios.First();
            Assert.AreEqual(expectedDescription, scenario.Description, "The scenario description should be empty.");
        }

        [Test]
        public void ProcessFeatureFile_WithIncorrectlyFormattedDescription_IgnoresMalformedDescription()
        {
            // Arrange
            var lines = new[] 
            {
            "Feature: Some feature",
            "",
            "  @label:allure_id:123456",
            "  Scenario: Some scenario (Description with missing closing parenthesis",
            "    Given some precondition",
            "    When some action is taken",
            "    Then some result is expected"
            };
            var expectedDescription = string.Empty; // Assuming that the parser requires both parentheses

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines).ToList();

            // Assert
            Assert.AreEqual(1, actualScenarios.Count, "There should be one scenario processed.");
            var scenario = actualScenarios.First();
            Assert.AreEqual(expectedDescription, scenario.Description, "The scenario description should be ignored due to incorrect formatting.");
        }

        [Test]
        public void ProcessFeatureFile_WithNestedParentheses_ReturnsOuterDescription()
        {
            // Arrange
            var lines = new[] 
            {
            "Feature: Some feature",
            "",
            "  @label:allure_id:123456",
            "  Scenario: Some scenario (Description with (nested) parentheses)",
            "    Given some precondition",
            "    When some action is taken",
            "    Then some result is expected"
            };
            var expectedDescription = "Description with (nested) parentheses"; // Assuming that the parser can handle nested parentheses

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines).ToList();

            // Assert
            Assert.AreEqual(1, actualScenarios.Count, "There should be one scenario processed.");
            var scenario = actualScenarios.First();
            Assert.AreEqual(expectedDescription, scenario.Description, "The scenario description should include nested parentheses.");
        }

        [Test]
        public void ProcessFeatureFile_WithTitleAndDescriptionSeparatedByDash_ReturnsCorrectTitleAndDescription()
        {
            // Arrange
            var lines = new[] 
            {
            "Feature: Some feature",
            "",
            "  @label:allure_id:123456",
            "  Scenario: Some scenario - (Description with dash)",
            "    Given some precondition",
            "    When some action is taken",
            "    Then some result is expected"
            };
            var expectedTitle = "Some scenario";
            var expectedDescription = "Description with dash";

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines).ToList();

            // Assert
            Assert.AreEqual(1, actualScenarios.Count, "There should be one scenario processed.");
            var scenario = actualScenarios.First();
            Assert.AreEqual(expectedTitle, scenario.Title, "The scenario title should match.");
            Assert.AreEqual(expectedDescription, scenario.Description, "The scenario description should match.");
        }

        [Test]
        public void ProcessFeatureFile_WhenScenarioHasNoId_CurrentTestIdShouldBeNull()
        {
            // Arrange
            var lines = new[]
            {
            "Feature: Some feature",
            "",
            "@normal @Test @label:allure_id:1655572 @tms:1655572 @story:Test @parentSuite:Test @owner:QA",
            "Scenario: Some scenario - (Description as example)",
            "    Given some precondition",
            "",
            "@normal @Test @label:allure_id: @tms: @story:Test @parentSuite:Test @owner:QA",
            "Scenario: Some scenario2 - (Description as example)",
            "    Given some precondition",
            };

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines).ToList();

            // Assert
            Assert.AreEqual(2, actualScenarios.Count, "There should be two scenarios processed.");
            Assert.IsNotNull(actualScenarios[0].Id, "The first scenario should have an ID.");
            Assert.AreEqual("1655572", actualScenarios[0].Id, "The ID of the first scenario should match the expected value.");
            Assert.IsNull(actualScenarios[1].Id, "The second scenario should not have an ID.");
        }

        [Test]
        public void ProcessFeatureFile_TagsWithAndWithoutSpace_ReturnsCorrectScenarios()
        {
            // Arrange
            var lines = new[]
            {
            "Feature: Some feature",
            "",
            "  @tag1 @tag2 ",
            "  @label:allure_id:123456 @tag3",
            "  Scenario: Some scenario",
            "    Given some precondition",
            "    When some action is taken",
            "    Then some result is expected",
            "",
            "  @tag4",
            "  @label:allure_id:234567 @tag5",
            "  Scenario: Another scenario",
            "    Given another precondition",
            "    When another action is taken",
            "    Then another result is expected"
            };
            var expectedScenarios = new List<Scenario>
            {
            new Scenario
            {
                Id = "123456",
                Tags = new List<string> { "@tag1", "@tag2", "@label:allure_id:123456", "@tag3" },
                Title = "Some scenario",
                Steps = new List<string>
                {
                    "Given some precondition",
                    "When some action is taken",
                    "Then some result is expected"
                },
                Examples = new List<Dictionary<string, string>>()
            },
            new Scenario
            {
                Id = "234567",
                Tags = new List<string> { "@tag4", "@label:allure_id:234567", "@tag5" },
                Title = "Another scenario",
                Steps = new List<string>
                {
                    "Given another precondition",
                    "When another action is taken",
                    "Then another result is expected"
                },
                Examples = new List<Dictionary<string, string>>()
            }
            };

            // Act
            var actualScenarios = FeatureFileProcessor.ProcessFeatureFile(lines);

            // Assert
            Assert.AreEqual(expectedScenarios.Count, actualScenarios.Count(), "The number of scenarios should match.");
            for (int i = 0; i < expectedScenarios.Count; i++)
            {
                Assert.AreEqual(expectedScenarios[i].Id, actualScenarios.ElementAt(i).Id, "Scenario IDs should match.");
                Assert.AreEqual(expectedScenarios[i].Title, actualScenarios.ElementAt(i).Title, "Scenario titles should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Tags, actualScenarios.ElementAt(i).Tags, "Scenario tags should match.");
                CollectionAssert.AreEqual(expectedScenarios[i].Steps, actualScenarios.ElementAt(i).Steps, "Scenario steps should match.");
            }
        }
    }
}
