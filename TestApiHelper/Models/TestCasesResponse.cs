#region Using Directives

using TestApiHelper.Models.Common;

#endregion

namespace TestApiHelper.Models
{
    public class TestCasesResponse
    {
        #region Properties

        public List<TestCaseDetail>? Value { get; set; }
        public int Count { get; set; }

        #endregion
    }

    public class TestCaseDetail
    {
        #region Properties

        public TestCase? TestCase { get; set; }
        public List<PointAssignment>? PointAssignments { get; set; }

        #endregion
    }

    public class TestCase
    {
        #region Properties

        public string? Id { get; set; }
        public string? Url { get; set; }
        public string? WebUrl { get; set; }

        #endregion
    }

    public class PointAssignment
    {
        #region Properties

        public Configuration? Configuration { get; set; }
        public Tester? Tester { get; set; }

        #endregion
    }

    public class Configuration
    {
        #region Properties

        public string? Id { get; set; }
        public string? Name { get; set; }

        #endregion
    }

    public class Tester
    {
        #region Properties

        public string? DisplayName { get; set; }
        public string? Url { get; set; }
        public Links? Links { get; set; }
        public string Id { get; set; }
        public string? UniqueName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Descriptor { get; set; }

        #endregion
    }
}