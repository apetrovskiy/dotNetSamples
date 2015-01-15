/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 1/15/2015
 * Time: 5:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace testFileExists
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            Console.WriteLine(File.Exists(@"E:\1111111111111111\Workflow.xml"));
            Console.WriteLine(File.Exists(@"E:\1111111111111111\Workflow.*"));
            Console.WriteLine(File.Exists(@"E:\1111111111111111\Workflow*"));
            // File.
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}