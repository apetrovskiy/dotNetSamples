namespace impersonateItForService.Runners
{
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    //using Abstract;
    //using ObjectModel;

    public class SimpleRunner // : ITestRunner
    {
        public virtual void Run(TestRunnerData data)
        {
            // fake
            // TODO: write the real code
            var testRunnerFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = testRunnerFolderPath,
                    FileName = testRunnerFolderPath + @"\TestRunner.exe",
                    UseShellExecute = true
                }
            };
            process.Start();
        }
    }
}