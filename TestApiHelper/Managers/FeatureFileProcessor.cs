#region Using Directives

using LibGit2Sharp;
using System.Reflection;
using System.Text.RegularExpressions;
using TestApiHelper.Misc;

#endregion

namespace TestApiHelper.Managers
{
    public class FeatureFileProcessor
    {
        #region Fields

        private static readonly Regex TagRegex = new Regex(@"(@\w+(?::\w+)*)(?=\s*(@|$|\n))", RegexOptions.Compiled);
        private static readonly Regex ScenarioRegex = new Regex(@"^\s*(Scenario Outline:|Scenario:)\s*(.*?)(?:\s*-\s*)?(?=\s*\(|\s*$)(\((.*?)\))?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex StepRegex = new Regex(@"^\s*(Given|When|Then|And)\s+(.*?)(:\s*)?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        #endregion

        #region Private Methods

        public static string GetAssemblyDirectory()
        {
            var assemblyLocation = Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(assemblyLocation);
        }

        public static bool TestCaseEquals(Scenario mainTestCase, Scenario currentTestCase)
        {
            // Compare scenario titles
            if (mainTestCase.Title != currentTestCase.Title)
                return false;

            // Compare scenario titles
            if (mainTestCase.Description != currentTestCase.Description)
                return false;

            // Compare tags (assuming they are stored as lists of strings)
            if (!mainTestCase.Tags.SequenceEqual(currentTestCase.Tags))
                return false;

            // Compare steps (assuming they are stored as lists of strings)
            if (mainTestCase.Steps.Count != currentTestCase.Steps.Count)
                return false;

            for (int i = 0; i < mainTestCase.Steps.Count; i++)
            {
                if (mainTestCase.Steps[i] != currentTestCase.Steps[i])
                    return false;
            }

            // Compare examples (assuming they are stored as lists of dictionaries of strings)
            // Check if both are null or both are not null
            if (mainTestCase.Examples == null && currentTestCase.Examples == null)
                return true; // Both are null, considered equal for this property
            if (mainTestCase.Examples == null || currentTestCase.Examples == null)
                return false; // One is null and the other is not, not equal

            // If both are not null, compare the examples
            if (mainTestCase.Examples.Count != currentTestCase.Examples.Count)
                return false;

            for (int i = 0; i < mainTestCase.Examples.Count; i++)
            {
                var mainExample = mainTestCase.Examples[i];
                var currentExample = currentTestCase.Examples[i];

                // Check if both examples have the same set of keys
                if (!mainExample.Keys.SequenceEqual(currentExample.Keys))
                    return false;

                // Check if corresponding values for each key are equal
                foreach (var key in mainExample.Keys)
                {
                    if (mainExample[key] != currentExample[key])
                        return false;
                }
            }

            // If all elements are identical, return true
            return true;
        }

        private static List<string> FindFeatureFiles()
        {
            var currentDirectory = Path.Combine(GetAssemblyDirectory(), "..", "..", "..", "..");
            return Directory.GetFiles(currentDirectory, "*.feature", SearchOption.AllDirectories).ToList();
        }

        private static List<Scenario> ProcessFeatureFiles(List<string> featureFiles)
        {
            var testCases = new List<Scenario>();

            foreach (var file in featureFiles)
            {
                var lines = File.ReadAllLines(file);
                var testCasesInFile = ProcessFeatureFile(lines);
                testCases.AddRange(testCasesInFile);
            }

            return testCases;
        }

        public static IEnumerable<Scenario> ProcessFeatureFile(string[] lines)
        {
            var testCases = new List<Scenario>();
            var scenarioTags = new List<string>();
            bool inExamples = false;
            List<string> exampleHeaders = null;
            Scenario currentTestCase = null;
            string currentTestId = null;

            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                var line = lines[lineIndex];
                // Process tags and scenarios
                ProcessTags(line, ref scenarioTags, ref currentTestId);
                ProcessScenario(line, ref currentTestCase, scenarioTags, ref currentTestId, testCases);

                // Only process steps if we have a current test case
                if (currentTestCase != null)
                {
                    if (!ProcessStep(lines, ref lineIndex, currentTestCase))
                    {
                        // If the line is not a step, it could be a new scenario, tags, or something else
                        // We should check if we need to reset the currentTestCase or perform other actions
                        // based on the content of the line
                    }
                }

                // Process examples section if needed
                ProcessExamplesSection(line, ref inExamples, ref exampleHeaders, currentTestCase);
            }

            // Add the last test case to the list if it exists
            if (currentTestCase != null)
            {
                testCases.Add(currentTestCase);
            }

            return testCases;
        }

        private static void ProcessTags(string line, ref List<string> scenarioTags, ref string currentTestId)
        {
            string allureIdPrefix = "@label:allure_id:";
            var tagMatches = TagRegex.Matches(line);
            if (tagMatches.Count > 0)
            {
                foreach (Match match in tagMatches)
                {
                    var tag = match.Groups[1].Value.Trim();
                    scenarioTags.Add(tag);
                    if (tag.StartsWith(allureIdPrefix))
                    {
                        var idValue = tag.Substring(allureIdPrefix.Length);
                        if (!string.IsNullOrWhiteSpace(idValue))
                        {
                            currentTestId = idValue;
                        }
                        else
                        {
                            currentTestId = null; // Ensure currentTestId is null if the tag does not contain an ID
                        }
                    }
                }
            }
        }

        private static void ProcessScenario(string line, ref Scenario currentTestCase, List<string> scenarioTags, ref string currentTestId, List<Scenario> testCases)
        {
            var scenarioMatch = ScenarioRegex.Match(line);
            if (scenarioMatch.Success)
            {
                if (currentTestCase != null)
                {
                    testCases.Add(currentTestCase);
                }
                string title = scenarioMatch.Groups[2].Value.Trim();
                string description = scenarioMatch.Groups[4].Success ? scenarioMatch.Groups[4].Value.Trim() : string.Empty;

                currentTestCase = new Scenario
                {
                    Id = currentTestId, // Assign the currentTestId to the new scenario
                    Tags = new List<string>(scenarioTags),
                    Title = title,
                    Description = description,
                    Steps = new List<string>(),
                    Examples = new List<Dictionary<string, string>>()
                };
                // Reset scenarioTags and currentTestId for the next scenario
                scenarioTags.Clear();
                currentTestId = null;
            }
        }

        private static bool ProcessStep(string[] lines, ref int lineIndex, Scenario currentTestCase)
        {
            string line = lines[lineIndex].Trim();
            var stepMatch = StepRegex.Match(line);

            if (stepMatch.Success)
            {
                string stepPrefix = stepMatch.Groups[1].Value.Trim();
                string stepText = stepMatch.Groups[2].Value.Trim();
                string step = $"{stepPrefix} {stepText}";

                // Check if the step is followed by a table
                if (lineIndex + 1 < lines.Length && lines[lineIndex + 1].Trim().StartsWith("|"))
                {
                    step += ":"; // Append colon to indicate the start of a table
                    lineIndex++; // Move to the next line which is the start of the table
                    while (lineIndex < lines.Length && lines[lineIndex].Trim().StartsWith("|"))
                    {
                        step += $"\n{lines[lineIndex].Trim()}";
                        lineIndex++;
                    }
                    lineIndex--; // Decrement lineIndex to avoid skipping the next line after the table
                }

                // Add the step to the current test case if it's not null
                if (currentTestCase != null)
                {
                    currentTestCase.Steps.Add(step);
                }
                return true;
            }
            return false;
        }

        private static void ProcessExamplesSection(string line, ref bool inExamples, ref List<string> exampleHeaders, Scenario currentTestCase)
        {
            line = line.Trim();

            // Match Examples section
            if (line.StartsWith("Examples:"))
            {
                if (currentTestCase == null)
                {
                    // Handle the error or skip processing as needed
                    return;
                }

                inExamples = true;
                currentTestCase.Examples = new List<Dictionary<string, string>>();
                return;
            }

            // Match Examples headers
            if (inExamples && line.StartsWith("|") && exampleHeaders == null)
            {
                exampleHeaders = line.Trim('|').Split('|').Select(h => h.Trim()).ToList();
                return;
            }

            // Match Examples values
            if (inExamples && line.StartsWith("|") && exampleHeaders != null)
            {
                var values = line.Trim('|').Split('|').Select(v => v.Trim()).ToList();
                var example = new Dictionary<string, string>();
                for (int i = 0; i < exampleHeaders.Count; i++)
                {
                    example[exampleHeaders[i]] = values[i];
                }
                currentTestCase.Examples.Add(example);
                return;
            }

            // End of Examples section
            if (inExamples && !line.StartsWith("|"))
            {
                inExamples = false;
                exampleHeaders = null;
                return;
            }
        }

        private static void ValidateUniqueTestIds(IEnumerable<Scenario> testCases)
        {
            var validTestCasesWithId = testCases.Where(tc => !string.IsNullOrEmpty(tc.Id));

            var duplicateTestIds = validTestCasesWithId
                .GroupBy(tc => tc.Id)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicateTestIds.Any())
            {
                Console.Error.WriteLine($"Error: Duplicate @id tags have been found: {string.Join("", duplicateTestIds)}");
                Console.Error.WriteLine("Please check the test case identifiers and ensure they are unique.");
                Environment.Exit(1); // Exit the program with an error code
            }
        }

        private static void PrintTestCases(List<Scenario> testCases)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var testCase in testCases)
            {
                Console.WriteLine(new string('-', 60)); // Line separating scenarios
                Console.WriteLine($"ID: {testCase.Id}");
                Console.WriteLine($"Tags: {string.Join(", ", testCase.Tags)}");
                Console.WriteLine($"Scenario: {testCase.Title}");
                Console.WriteLine($"Steps:");
                foreach (var step in testCase.Steps)
                {
                    Console.WriteLine($"  - {step}"); // Additional indentation for steps
                }
                Console.WriteLine($"Examples:");
                if (testCase.Examples != null)
                {
                    foreach (var example in testCase.Examples)
                    {
                        Console.WriteLine($"  - {string.Join(", ", example.Select(kv => $"{kv.Key}: {kv.Value}"))}"); // Additional indentation for examples
                    }
                }
                Console.WriteLine(new string('-', 60)); // Line separating scenarios
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        #endregion

        #region Public Methods

        public static void AnalyzeProjectAndCollectAllTestCases()
        {
            var featureFiles = FindFeatureFiles();
            var testCases = ProcessFeatureFiles(featureFiles);
            ValidateUniqueTestIds(testCases);
            Console.WriteLine($"All scenarios found in the project: {testCases.Count}");
            PrintTestCases(testCases);
        }

        public static Scenario FindTestCaseByTag(int tag)
        {
            var featureFiles = FindFeatureFiles();
            var testCases = ProcessFeatureFiles(featureFiles);
            ValidateUniqueTestIds(testCases);
            var testCaseToProcess = testCases.FirstOrDefault(tc => tc.Tags.Contains($"@label:allure_id:{tag}"));
            return testCaseToProcess;
        }

        /// <summary>
        ///     Analyzes the changed scenarios in feature files and prints out the details.
        /// </summary>
        /// <returns>An enumerable of changed scenarios.</returns>
        public static IEnumerable<Scenario> AnalyzeChangedScenariosInFeatureFiles(bool aftermerge = false)
        {
            // Find all feature files in the project.
            var featureFiles = FindFeatureFiles();

            // Process the feature files to extract test cases.
            var testCases = ProcessFeatureFiles(featureFiles);

            // Validate that each test case has a unique ID.
            ValidateUniqueTestIds(testCases);

            // Get the list of test cases that need to be updated.
            var testsIDsNeedToBeUpdated = GetChangedTests(aftermerge);

            // Print the number of scenarios that have changed.
            Console.WriteLine($"The number of scenarios that have changed: {testsIDsNeedToBeUpdated.Count}/{testCases.Count}");
            Console.WriteLine();

            // Print the changed scenarios, if any.
            if (testsIDsNeedToBeUpdated.Count == 0)
            {
                Console.WriteLine("No scenarios have changed.");
            }
            else
            {
                PrintTestCases(testsIDsNeedToBeUpdated);
            }

            // Return the list of changed scenarios.
            return testsIDsNeedToBeUpdated;
        }

        /// <summary>
        /// Retrieves a list of test scenarios that have changed by comparing the current branch with the main branch or its previous state.
        /// This method identifies new, modified, and deleted feature files and processes them to determine
        /// the test scenarios that are affected by these changes. Depending on the 'afterMerge' parameter, it uses either
        /// the last common commit or the commit before the merge as a reference point to compare the changes.
        /// This ensures that the differences are accurately identified in the context of the current operation, whether it's before or after a merge.
        /// </summary>
        /// <param name="afterMerge">A boolean flag indicating whether the comparison should be made with the commit before the merge on the main branch.
        /// If set to true, the comparison is made against the state of the main branch just before the merge commit.
        /// If false or not provided, the comparison is made against the last common commit between the current and main branches.</param>
        /// <returns>A list of <see cref="Scenario"/> objects representing the changed test scenarios.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the repository cannot be found, the current branch cannot be found,
        /// the main branch cannot be found, the specified base commit for comparison cannot be found, or the base commit's tree cannot be found.</exception>
        public static List<Scenario> GetChangedTests(bool afterMerge = false)
        {
            // Initialize a list to hold the IDs of changed test scenarios.
            List<Scenario> changedTestIds = new List<Scenario>();

            // Initialize a list to hold the IDs of deleted test scenarios.
            List<Scenario> deletedTestIds = new List<Scenario>();

            // Determine the current directory of the assembly and navigate up to the project root.
            var currentDirectory = Path.Combine(GetAssemblyDirectory(), "..", "..", "..", "..");

            // Initialize a new repository object using the current directory.
            var repo = new Repository(currentDirectory);

            // Retrieve the current branch (HEAD) of the repository.
            var currentBranch = repo.Head ?? throw new InvalidOperationException("Current branch could not be found.");

            // Retrieve the main branch from the repository.
            var mainBranch = repo.Branches["origin/main"] ?? throw new InvalidOperationException("Main branch could not be found.");

            // Find the last common commit between the current branch and the main branch or the commit before the merge.
            Commit baseCommit;
            if (afterMerge)
            {
                // Get the commit before the last commit on the main branch (which is the merge commit)
                baseCommit = mainBranch.Commits.Skip(1).FirstOrDefault() ?? throw new InvalidOperationException("Unable to find the commit before the merge on the main branch.");
            }
            else
            {
                baseCommit = repo.ObjectDatabase.FindMergeBase(currentBranch.Tip, mainBranch.Tip)
                    ?? throw new InvalidOperationException("Unable to find a common ancestor between the current branch and the main branch.");
            }

            // Ensure the base commit has an associated tree.
            if (baseCommit.Tree == null)
            {
                throw new InvalidOperationException("The base commit's tree could not be found.");
            }

            // Compare the tree from the last common commit with the tree from the current branch.
            var patch = repo.Diff.Compare<Patch>(baseCommit.Tree, currentBranch.Tip.Tree);

            // Iterate over each change in the patch.
            foreach (var p in patch)
            {
                // Check if the file is a feature file
                if (p.Path.EndsWith(".feature"))
                {
                    // Process feature files
                    Blob oldBlob = baseCommit[p.Path]?.Target as Blob;
                    Blob newBlob = currentBranch.Tip[p.Path]?.Target as Blob;

                    // If oldBlob is null, the file is new in the current branch and does not exist in the main branch
                    if (oldBlob == null)
                    {
                        // The file is new, so all scenarios in it are considered changed
                        string[] newAddedFeatureFileLines = newBlob.GetContentText().Split('\n');
                        var newTestCases = ProcessFeatureFile(newAddedFeatureFileLines);
                        changedTestIds.AddRange(newTestCases);
                        continue; // Skip to the next file in the loop
                    }

                    // If newBlob is null, the file has been deleted in the current branch
                    if (newBlob == null)
                    {
                        // The file has been deleted, so we might want to handle this case differently
                        // For now, we'll just skip to the next file in the loop
                        continue;
                    }

                    string[] oldFeatureFileLines = oldBlob?.GetContentText().Split('\n');
                    string[] newFeatureFileLines = newBlob?.GetContentText().Split('\n');

                    // Process feature files
                    var mainTestCases = ProcessFeatureFile(oldFeatureFileLines);
                    var currentTestCases = ProcessFeatureFile(newFeatureFileLines);

                    // Compare test cases
                    foreach (var currentTestCase in currentTestCases)
                    {
                        var mainTestCase = mainTestCases.FirstOrDefault(tc => tc.Title == currentTestCase.Title);
                        if (mainTestCase == null) //Test doesn't exist in main branch
                        {
                            changedTestIds.Add(currentTestCase);
                        }
                        else if (!TestCaseEquals(mainTestCase, currentTestCase)) // Test exist in main branch, but has been changed
                        {
                            changedTestIds.Add(currentTestCase);
                        }
                    }

                    // What about test cases that exist in main branch, but not in the current branch?
                    foreach (var mainTestCase in mainTestCases)
                    {
                        var currentTestCase = currentTestCases.FirstOrDefault(tc => tc.Title == mainTestCase.Title);
                        if (currentTestCase == null) // Test doesn't exist in the current branch
                        {
                            // Log the deletion for further processing or notification.
                            if (mainTestCase.HasTag("@Example"))
                            {
                                Console.WriteLine($"Scenario with @Example tag deleted: Title: {mainTestCase.Title}, ID: {mainTestCase.Id ?? "N/A"}");
                            }
                            else
                            {
                                Console.WriteLine($"Scenario deleted: Title: {mainTestCase.Title}, ID: {mainTestCase.Id}");

                                // The test case has been deleted in the current branch and we can do something with it.
                                deletedTestIds.Add(mainTestCase);
                            }
                        }
                    }
                }
            }

            return changedTestIds;
        }

        #endregion
    }
}