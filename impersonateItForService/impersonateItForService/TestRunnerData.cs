namespace impersonateItForService
{
    public class TestRunnerData
    {
        public string Command { get; set; }

        public string Domain { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public Action<List<TestCase>, ISpecificSettings> TestCasesRunner { get; set; }
        //public List<TestCase> TestCases { get; set; }
        //public Action<List<TestSuite>> SuiteSetUpRunner { get; set; }
        //public Action<List<TestSuite>> SuiteTearDownRunner { get; set; }
        //public List<TestSuite> TestSuites { get; set; }
        public bool NeedImpersonationForSetUp { get; set; }
        public bool NeedImpersonationForTest { get; set; }
        public bool NeedImpersonationForTearDown { get; set; }
        //public ISpecificSettings SpecificSettings { get; set; }

        //public TestRunnerData()
        //{
        //    TestCases = new List<TestCase>();
        //    TestSuites = new List<TestSuite>();
        //}
    }
}