namespace TestApiHelper.Misc
{
    public class Scenario
    {
        #region Properties

        public List<string> Tags { get; set; } = new List<string>();
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Id { get; set; }
        public string? AreaPath { get; set; }
        public string? Summary { get; set; }
        public List<string> Comments { get; set; } = new List<string>();
        public string? State { get; set; }
        public string? Reason { get; set; }
        public List<Dictionary<string, string>> Examples { get; set; } = new List<Dictionary<string, string>>();
        public List<string> Steps { get; set; } = new List<string>();
        public Dictionary<string, List<string>> Values { get; set; } = new Dictionary<string, List<string>>();
        public List<string> Issues { get; set; } = new List<string>();
        public bool IsGood => Issues.Count == 0;

        #endregion

        #region Public Methods

        public bool HasTag(string tag)
        {
            // Assume that the tag is case-insensitive
            return Tags.Contains(tag);
        }

        #endregion
    }
}