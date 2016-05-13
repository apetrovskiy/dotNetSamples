namespace TestAccessGenerator
{
    using System;
    using CommonTestAccessLibrary;

    class Program
    {
        static void Main(string[] args)
        {
            if (null == args || string.IsNullOrEmpty(args[0]))
                throw new Exception("USAGE: TestAccessGenerator path [account]");
            var accessChecker = new AccessChecker(args[0]);
            if (1 < args.Length && !string.IsNullOrEmpty(args[1]))
                accessChecker.AccountName = args[1];
            accessChecker.RunGeneration();
        }
    }
}
