/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 10/24/2014
 * Time: 6:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

//namespace testImpersonation
//{
//    using System;
//    
//  [DllImport("advapi32.dll", SetLastError=true, CharSet=CharSet.Unicode)]
//  public static extern bool CreateProcessWithLogonW(
//     String             userName,
//     String             domain,
//     String             password,
//     LogonFlags         logonFlags,
//     String             applicationName,
//     String             commandLine,
//     CreationFlags          creationFlags,
//     UInt32             environment,
//     String             currentDirectory,
//     ref  StartupInfo       startupInfo,
//     out ProcessInformation     processInformation);
//  
//    class Program
//    {
//        public static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//            
//            // TODO: Implement Functionality Here
//            
//            var demo = new ImpersonationDemo();
//            demo.
//            
//            Console.Write("Press any key to continue . . . ");
//            Console.ReadKey(true);
//        }
//    }
//}