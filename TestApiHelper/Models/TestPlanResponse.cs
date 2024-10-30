#region Using Directives

using TestApiHelper.Models.Common;

#endregion

namespace TestApiHelper.Models
{
    public class TestPlanResponse
    {
        #region Properties

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public Project? Project { get; set; }
        public Area? Area { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Iteration { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Identity? UpdatedBy { get; set; }
        public Identity? Owner { get; set; }
        public int Revision { get; set; }
        public string? State { get; set; }
        public RootSuite? RootSuite { get; set; }
        public string? ClientUrl { get; set; }
        public TestOutcomeSettings? TestOutcomeSettings { get; set; }

        #endregion
    }

    public class Area
    {
        #region Properties

        public string? Id { get; set; }
        public string? Name { get; set; }

        #endregion
    }

    public class Identity
    {
        #region Properties

        public string? DisplayName { get; set; }
        public string? Url { get; set; }
        public Links? Links { get; set; }
        public Guid Id { get; set; }
        public string? UniqueName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Descriptor { get; set; }

        #endregion
    }

    public class RootSuite
    {
        #region Properties

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }

        #endregion
    }

    public class TestOutcomeSettings
    {
        #region Properties

        public bool SyncOutcomeAcrossSuites { get; set; }

        #endregion
    }
}