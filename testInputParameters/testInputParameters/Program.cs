/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 09/04/2016
 * Time: 09:37 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testInputParameters
{
    using System;
    using System.Diagnostics;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var cmdline = string.Empty;
            for (int i = 0; i < 50; i++) {
                cmdline += string.Format(" {0}", "param_sagertbvwe;tvkwe;rtmwa;letj;eortjupeortjert" + i);
            }
            
            var process  = new Process();
            process.StartInfo.Arguments = cmdline;
            // process.StartInfo.FileName = @"..\..\testApp\bin\Debug\testApp.exe";
            process.StartInfo.FileName = @"C:\Projects\probe\testInputParameters\testApp\bin\Debug\testApp.exe";
            process.Start();
            
//            Console.Write("Press any key to continue . . . ");
//            Console.ReadKey(true);
        }
    }
}