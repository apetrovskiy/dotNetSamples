namespace testTimeSchedLibs
{
    using System;
    using Quartz;
    public class Meat :IJob
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }

        public JobBuilder GetJobBuilder()
        {
            throw new NotImplementedException();
        }

        public JobKey Key { get; private set; }
        public string Description { get; private set; }
        public Type JobType { get; private set; }
        public JobDataMap JobDataMap { get; private set; }
        public bool Durable { get; private set; }
        public bool PersistJobDataAfterExecution { get; private set; }
        public bool ConcurrentExecutionDisallowed { get; private set; }
        public bool RequestsRecovery { get; private set; }
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("trigger fired");
        }
    }
}