/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 4/29/2013
 * Time: 10:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace nlogtest
{
    using System;
    using NLog;
    using NLog.Targets;
    using NLog.Config;
    //using NLog.Win32.Targets;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            
            // Step 1. Create configuration object 
            LoggingConfiguration config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            //ColoredConsoleTarget consoleTarget = new ColoredConsoleTarget();
            //config.AddTarget("console", consoleTarget);
            //
            FileTarget fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            // Step 3. Set target properties 
            //consoleTarget.Layout = "${date:format=HH\\:MM\\:ss}: ${message}";
            // set the file 
            //fileTarget.FileName = CxUtil.getDataDir() + "\\log.txt";
            fileTarget.FileName = "C:\\1" + "\\log.txt";
            fileTarget.Layout = "${date:format=HH\\:MM\\:ss}: ${message}";
            // don’t clutter the hard drive
            //fileTarget.deleteOldFileOnStartup = true;

            // Step 4. Define rules 
            //LoggingRule rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            //config.LoggingRules.Add(rule1);
            
            // Only log to file in non debug mode 
            //#if !DEBUG
                LoggingRule rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
                config.LoggingRules.Add(rule2);
            //#endif

            // Step 5. Activate the configuration 
            LogManager.Configuration = config;

            // Create logger
            Logger logger = LogManager.GetLogger("Example");
            // Example usage
            logger.Trace("trace log message");
            logger.Debug("debug log message");
            logger.Info("info log message");
            logger.Warn("warn log message");
            logger.Error("error log message");
            logger.Fatal("fatal log message");
            
            FileTarget myFileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
            myFileTarget.FileName = @"C:\1\2.txt";
            logger.Trace("trace log message");
            logger.Debug("debug log message");
            logger.Info("info log message");
            logger.Warn("warn log message");
            logger.Error("error log message");
            logger.Fatal("fatal log message");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}


