/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 10/14/2014
 * Time: 2:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;
using testDotLiquid;
using testDotLiquid.Helpers;

namespace runner2
{
    class Program
    {
        public static void Main(string[] args)
        {
            // var modulesLoader = new ModulesLoader((new TmxServerRootPathProvider()).GetRootPath());
//            var modulesLoader = new ModulesLoader(Environment.CurrentDirectory);
//            modulesLoader.Load();
            
//		    var dataLoader = new DataLoader();
//		    dataLoader.LoadData();
            
Assembly.LoadFrom(@"C:\Projects\probe\testDotLiquid\testDotLiquid2\bin\Debug\Nancy.ViewEngines.DotLiquid.dll");
Console.WriteLine("0000000000000000");  
            
            ServerControl.Start();
            
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                Console.WriteLine(assembly.FullName);
            }
            
            Console.WriteLine ("Press any key to stop server...");
            Console.ReadKey(true);
        }
    }
}