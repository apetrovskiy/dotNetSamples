/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/18/2013
 * Time: 1:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace howToPowerShell
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Diagnostics;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Process ps = new Process();
            ps.StartInfo.Arguments = @" -noninteractive -executionpolicy bypass -command ""& { D:\probe_script\1.ps1 aaaaa $true 7; }""";
            ps.StartInfo.FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.LoadUserProfile = false;
            ps.StartInfo.UseShellExecute = false;
            ps.EnableRaisingEvents = true;
            ps.Start();
            ps.WaitForExit(1200000);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}