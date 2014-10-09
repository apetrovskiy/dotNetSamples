/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 9/30/2014
 * Time: 1:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace fileChecker
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            const string pathToFolder01 = @"E:\1111111111111111";
            const string pathToFolder02 = @"E:\1111111111111111\";
            const string pathToFile01 = @"E:\1111111111111111\Workflow.xml";
            
            Console.WriteLine(Directory.Exists(pathToFolder01));
            Console.WriteLine(Directory.Exists(pathToFolder02));
            Console.WriteLine(Directory.Exists(pathToFile01));
            
            Console.WriteLine(File.Exists(pathToFolder01));
            Console.WriteLine(File.Exists(pathToFolder02));
            Console.WriteLine(File.Exists(pathToFile01));
                
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}