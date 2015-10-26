/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 17/09/2015
 * Time: 06:00 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNullArguments
{
    using System;
    
    class Program
    {
        public static void Main(string[] args)
        {
            if (null == args || 1 > args.Length) {
                Console.WriteLine("Please specify parameters: service_url [path_to_export_file]");
                return;
            }
            
            Console.WriteLine(args.Length);
            Console.WriteLine(string.IsNullOrEmpty(args[0]));
            // Console.WriteLine(string.IsNullOrEmpty(args[1] ?? null));
            
            var pathToExportFile = @"C:\TestHome\Data" + @"\AllChanges.txt";
            if (2 <= args.Length && !string.IsNullOrEmpty(args[1]))
                pathToExportFile = args[1];
            Console.WriteLine(pathToExportFile);
            
            Console.Write("Done!");
            Console.Read();
        }
    }
}