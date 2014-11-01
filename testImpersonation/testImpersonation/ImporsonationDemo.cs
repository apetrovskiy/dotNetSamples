/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 10/24/2014
 * Time: 7:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testImpersonation
{
    /// <summary>
    /// Description of ImporsonationDemo.
    /// </summary>
// This sample demonstrates the use of the WindowsIdentity class to impersonate a user. 
// IMPORTANT NOTES: 
// This sample requests the user to enter a password on the console screen. 
// Because the console window does not support methods allowing the password to be masked, 
// it will be visible to anyone viewing the screen. 
// On Windows Vista and later this sample must be run as an administrator.  


    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Mono.Options;

     [Flags]
     enum CreationFlags 
    {
        CREATE_SUSPENDED       = 0x00000004,
        CREATE_NEW_CONSOLE     = 0x00000010,
        CREATE_NEW_PROCESS_GROUP   = 0x00000200,
        CREATE_UNICODE_ENVIRONMENT = 0x00000400,
        CREATE_SEPARATE_WOW_VDM    = 0x00000800,
        CREATE_DEFAULT_ERROR_MODE  = 0x04000000,
    }

    [Flags]
    enum LogonFlags 
    {
        LOGON_WITH_PROFILE     = 0x00000001,
        LOGON_NETCREDENTIALS_ONLY  = 0x00000002    
    }

//Chris Hand cj_hand@hotmail.com
//2005.03.13

    class ImpersonationDemo
    {
        public const UInt32 Infinite = 0xffffffff;
        public const Int32      Startf_UseStdHandles = 0x00000100;
        public const Int32      StdOutputHandle = -11;
        public const Int32      StdErrorHandle = -12;

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public struct StartupInfo
        {
            public int    cb;
            public String reserved;
            public String desktop;
            public String title;
            public int    x;
            public int    y;
            public int    xSize;
            public int    ySize;
            public int    xCountChars;
            public int    yCountChars;
            public int    fillAttribute;
            public int    flags;
            public UInt16 showWindow;
            public UInt16 reserved2;
            public byte   reserved3;
            public IntPtr stdInput;
            public IntPtr stdOutput;
            public IntPtr stdError;
        } 

        internal struct ProcessInformation
        {
            public IntPtr process;
            public IntPtr thread;
            public int    processId;
            public int    threadId;
        }


        [DllImport("advapi32.dll", SetLastError=true, CharSet=CharSet.Unicode)]
        // public static extern bool CreateProcessWithLogonW(
        public static extern int CreateProcessWithLogonW(
            String userName,
            String domain,
            String password,
            LogonFlags logonFlags, // UInt32 logonFlags,
            String applicationName,
            String commandLine,
            CreationFlags creationFlags, // UInt32 creationFlags,
            IntPtr environmentBlock, // UInt32 environment,
            String currentDirectory,
            ref   StartupInfo startupInfo,
            out  ProcessInformation processInformation);

        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern bool GetExitCodeProcess(IntPtr process, ref UInt32 exitCode);

        [DllImport("Kernel32.dll", SetLastError=true)]
        public static extern UInt32 WaitForSingleObject(IntPtr handle, UInt32 milliseconds);

        [DllImport("Kernel32.dll", SetLastError=true)]
        public static extern IntPtr GetStdHandle(IntPtr handle);

        [DllImport("Kernel32.dll", SetLastError=true)]
        public static extern bool CloseHandle(IntPtr handle);
        
        [DllImport("kernel32.dll")]
        static extern uint GetLastError();
        
//        [DllImport("advapi32.dll", SetLastError=true)]
//        static extern TODO UserID(TODO);

        [STAThread]
        static void Main(string[] args)
        {
			bool show_help = false;
	        var names = new List<string> ();
	        
            String command = string.Empty;
            String user    = string.Empty;
            String domain  = string.Empty;
            String password = string.Empty;
            String currentDirectory = System.IO.Directory.GetCurrentDirectory();
            
            var inputOptions = new OptionSet ()
                .Add("d|domain", "domain", option => domain = option)
                .Add("u|username", "username", option => user = option)
                .Add("p|password", "password", option => password = option)
                .Add("c|command", "command", option => command = option)
                .Add("h|help", "help", option => show_help = true);
	        
            List<string> parameters = null;
            try {
                parameters = inputOptions.Parse(args);
            } catch (OptionException e) {
                Console.WriteLine("Try impersonateIt --help for more information.");
            }
            
            if (show_help) {
                ShowHelp (inputOptions);
                return;
            }
            
            var startupInfo = new StartupInfo();
            startupInfo.cb = Marshal.SizeOf(typeof(StartupInfo));
            startupInfo.reserved = null;
            startupInfo.flags &= Startf_UseStdHandles;
            startupInfo.stdOutput = (IntPtr)StdOutputHandle;
            startupInfo.stdError = (IntPtr)StdErrorHandle;
            startupInfo.showWindow = 1;
            startupInfo.title = "IMPERSONATED";

            UInt32 exitCode = 123456;
            var processInfo = new ProcessInformation();
            
            try
            {
                int res = CreateProcessWithLogonW(
                    user,
                    domain,
                    password,
                    0, // LogonFlags.LOGON_NETCREDENTIALS_ONLY, // (UInt32) LogonFlags.LOGON_NETCREDENTIALS_ONLY, // (UInt32) 2,
                    null, // command,
                    command, // null, //command,
                    // (UInt32)(CreationFlags.CREATE_NEW_CONSOLE | CreationFlags.CREATE_NEW_PROCESS_GROUP | CreationFlags.CREATE_SEPARATE_WOW_VDM), //(UInt32) 0,
                    // (UInt32) CreationFlags.CREATE_UNICODE_ENVIRONMENT, // 0, //CreationFlags.CREATE_NEW_PROCESS_GROUP, //.CREATE_SEPARATE_WOW_VDM,
                    0, // (UInt32) CreationFlags.CREATE_NEW_PROCESS_GROUP,
                    IntPtr.Zero, // (UInt32) 0,
                    null, // currentDirectory,
                    ref startupInfo,
                    out processInfo);
                
                Console.WriteLine("result = " + res);
                if (0 == res)
                    Console.WriteLine(Marshal.GetLastWin32Error());
            } 
            catch (Exception e)
            {
                Console.WriteLine("FAILURE!");
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }
            
            Console.WriteLine("Running ...");
//            Console.WriteLine(Environment.UserDomainName);
//            Console.WriteLine(Environment.UserName);
//            Console.WriteLine(Environment.CommandLine);
//            Console.WriteLine(Environment.CurrentDirectory);
//            Console.WriteLine(Environment.ExitCode);
            Console.WriteLine(processInfo.processId);
            Console.WriteLine(processInfo.threadId);
            WaitForSingleObject(processInfo.process, Infinite);
            GetExitCodeProcess(processInfo.process, ref exitCode);

            Console.WriteLine("Exit code: {0}", exitCode);
            Console.ReadKey();

            CloseHandle(processInfo.process);
            CloseHandle(processInfo.thread);
        }
        
        static void ShowHelp (OptionSet inputOptions)
        {
            Console.WriteLine ("Usage: impersonateIt [OPTIONS]+ message");
            Console.WriteLine ("Greet a list of individuals with an optional message.");
            Console.WriteLine ("If no message is specified, a generic greeting is used.");
            Console.WriteLine ();
            Console.WriteLine ("Options:");
            inputOptions.WriteOptionDescriptions (Console.Out);
        }
    }
}
