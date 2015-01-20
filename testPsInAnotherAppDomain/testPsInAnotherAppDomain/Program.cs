/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/10/2014
 * Time: 4:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testPsInAnotherAppDomain
{
    using System;
    using PSRunner;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            
            
            Runner.InitializeRunspace(@"");
            Runner.RunPSCode(@"get-childitem c:\1", true);
            Runner.CloseRunspace();
            
            
            System.AppDomain NewAppDomain = System.AppDomain.CreateDomain("NewApplicationDomain");
            
            // Load the assembly and call the default entry point:
            // NewAppDomain.ExecuteAssembly(@"C:\Projects\PS\STUPS\PS\PSRunner\bin\Release35\PSRunner.dll");
            
            // Create an instance of RemoteObject:
            var handle = NewAppDomain.CreateInstanceFrom(@"C:\Projects\PS\STUPS\PS\PSRunner\bin\Release35\PSRunner.dll ", "PSRunner.Runner");
            
            var obj = handle.Unwrap();
            
            
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}