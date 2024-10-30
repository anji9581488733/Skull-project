#region Using Directives

using TestApiHelper.Models.Common;

#endregion

namespace TestApiHelper.Models
{
    public class TestSuitesResponse
    {
        #region Properties

        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public Project? Project { get; set; }
        public Plan? Plan { get; set; }
        public int Revision { get; set; }
        public int TestCaseCount { get; set; }
        public string? SuiteType { get; set; }
        public string? TestCasesUrl { get; set; }
        public bool InheritDefaultConfigurations { get; set; }
        public List<DefaultConfiguration>? DefaultConfigurations { get; set; }
        public string? State { get; set; }
        public string? LastUpdatedDate { get; set; }

        #endregion
    }

    public class Plan
    {
        #region Properties

        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }

        #endregion
    }

    public class DefaultConfiguration
    {
        #region Properties

        public string? Id { get; set; }
        public string? Name { get; set; }

        #endregion
    }
}