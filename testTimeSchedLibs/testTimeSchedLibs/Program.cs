namespace testTimeSchedLibs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Quartz;
    using Quartz.Impl;

    class Program
    {
        static void Main(string[] args)
        {
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler();
            scheduler.Start();

            var job = JobBuilder.Create<Meat>()
                .WithIdentity("myJob", "group1")
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(40)
                    .RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);

            Console.Read();
        }
    }
}
