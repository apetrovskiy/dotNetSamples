/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 10/28/2014
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testImpersonation02
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Test with CreateProcessWithLogonW...");
                // Win32.LaunchCommand1("\\\\server\\tests\\Batch.cmd", "domain", "user", "password");
                Win32.LaunchCommand1("c:\\windows\\system32\\cmd.exe", "perflab", "administrator", "Lock12Lock");
                // Win32.LaunchCommand1("c:\\windows\\system32\\cmd.exe", "spanew", "administrator", "Lock12Lock");
                Console.WriteLine("Test with CreateProcessAsUser...");
                // Win32.LaunchCommand2("\\\\server\\tests\\Batch.cmd", "domain", "user", "password");
                Win32.LaunchCommand2("c:\\windows\\system32\\cmd.exe", "perflab", "administrator", "Lock12Lock");
                // Win32.LaunchCommand2("c:\\windows\\system32\\cmd.exe", "spanew", "administrator", "Lock12Lock");
            }
            catch (Exception ex)
            {
                Console.WriteLine("LaunchCommand error: " + ex.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}