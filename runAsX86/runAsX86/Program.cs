/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 3/5/2014
 * Time: 7:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
 
/***********************************************************************
 * CoolSoft RunAsX86
 ***********************************************************************
 * Based on original Gabriel Schenker idea:
 * http://lostechies.com/gabrielschenker/2009/10/21/force-net-application-to-run-in-32bit-process-on-64bit-os/
 *
 * changes:
 * - dialog for EXE file selection
 * - better error handling
 * - better command line parameters handling
 * - removed null reference exception
 ************************************************************/
 
// This class MUST be compiled as X86 exe
 
namespace RunAsX86
{
class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            // test if we have enough params
            if (args.Length == 0) {
                System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
                ofd.Title = "Choose a .NET executable to run in X86 mode";
                ofd.Filter = "Executable files (*.exe;*.dll)|*.exe;*.dll|All files|*.*";
                ofd.FilterIndex = 1;
                ofd.CheckFileExists = true;
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    Usage();
                    return 1;
                }
                else
                {
                    args = new string[] { ofd.FileName };
                }
            }
 
            // test if file exists
            if(! System.IO.File.Exists(args[0])) {
                Console.WriteLine("ERROR: exe file not found: " + args[0]);
                return 1;
            }
 
            // load the assembly
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var assemblyName = Path.Combine(directory, args[0]);
            var assembly = Assembly.LoadFile(assemblyName);
 
            // find the entry point of the assembly
            Type type = null;
            MethodInfo mi = null;
            foreach(Type t in assembly.GetTypes()) {
                if((mi = t.GetMethod("Main")) != null) {
                    type = t;
                    break;
                }
            }
 
            // is there a Main() method?
            if(type == null) {
                Console.WriteLine("ERROR: can't find valid entry point");
                return 1;
            }
 
            // extract arguments to be passed to the called entry point
            string[] newArgs = new string[args.Length-1];
            for (int i = 1; i < args.Length; i++) {
                newArgs[i-1] = args[i];
            }
 
            // call the entry point of the wrapped assembly and forward command line parameters
            object ret = mi.Invoke(type, new object[] { newArgs });
            return (ret == null) ? 0 : (int)ret;
        }
 
 
        /// <summary>
        /// Print usage infos
        /// </summary>
        static void Usage()
        {
            Console.WriteLine(@"
CoolSoft - RunAsX86 - v.1.0
---------------------------
Runs a .NET executable in X86 mode.
 
Usage: RunAsX86 filename.exe [param1] [param2] ...
 
filename.exe
filename of the .NET executable to run (specify the full path if needed).
 
param1, param2, ...
These parameters will be passed untouched to filename.exe
 
Press any key to continue.
");
            Console.ReadKey(true);
 
        }
    }
}