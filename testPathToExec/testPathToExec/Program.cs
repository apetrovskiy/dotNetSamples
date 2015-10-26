/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 24/08/2015
 * Time: 02:56 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testPathToExec
{
    using System;
    using System.Reflection;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().Location);
            Console.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}