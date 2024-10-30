namespace TestApiHelper.Models
{
    public class TestPlan
    {
        public string TestPlanId { get; set; }
        public string Name { get; set; }
        public List<Test> Tests { get; set; }
    }

    public class Test
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Selector { get; set; }
        public List<string> Tags { get; set; }
    }
}