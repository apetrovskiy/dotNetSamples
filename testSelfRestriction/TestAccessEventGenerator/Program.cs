namespace TestAccessEventGenerator
{
    using System;
    using CommonTestAccessLibrary;

    class Program
    {
        static void Main(string[] args)
        {
            if (null == args || string.IsNullOrEmpty(args[0]))
                throw new Exception("USAGE: TestAccessEventGenerator path");
            var accessChecker = new AccessChecker(args[0]);
            accessChecker.RunTest();
        }
    }
}
