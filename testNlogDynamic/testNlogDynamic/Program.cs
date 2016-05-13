namespace testNlogDynamic
{
    using System;
    using NLog;
    using NLog.Config;
    using NLog.Targets;

    class Program
    {
        static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget();
            config.AddTarget("logfile", fileTarget);
            fileTarget.FileName = @"C:\1\TheNewestLog1234.txt";
            LogManager.Configuration = config;

            var rule = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule);

            var logger = LogManager.GetLogger("logfile");
            logger.Info("test");

            Console.Read();
        }
    }
}
