/*
 * Created by SharpDevelop.
 * User: unknown
 * Date: 10/28/2014
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace impersonateIt
{
    using System;
    using System.Runtime.InteropServices;
    
    /// <summary>
    /// Description of ApplicationRunner.
    /// </summary>
    class ApplicationRunner
    {
        public static void CreateProcessWithCredentials(string strCommand, string strDomain, string strName, string strPassword)
        {
            var processInfo = new PROCESS_INFORMATION();
            var startInfo = new STARTUPINFO();
            bool res = false;
            UInt32 uiResultWait = NativeMethods.WAIT_FAILED;

            try 
            {
                startInfo.cb = Marshal.SizeOf(startInfo);

                res = NativeMethods.CreateProcessWithLogonW(
                    strName, 
                    strDomain, 
                    strPassword, 
                    (int)LogonFlags.LOGON_NETCREDENTIALS_ONLY,
                    null,
                    strCommand, 
                    0, 
                    IntPtr.Zero, 
                    null, 
                    ref startInfo, 
                    out processInfo
                );
                if (!res) { throw new Exception("CreateProcessWithLogonW failed with error " + Marshal.GetLastWin32Error()); }

                uiResultWait = NativeMethods.WaitForSingleObject(processInfo.hProcess, NativeMethods.INFINITE);
                if (uiResultWait == NativeMethods.WAIT_FAILED) { throw new Exception("WaitForSingleObject error #" + Marshal.GetLastWin32Error()); }

            } 
            finally
            {
                NativeMethods.CloseHandle(processInfo.hProcess);
                NativeMethods.CloseHandle(processInfo.hThread);
            }
        }

        public static void LogonAsSpecifiedUser(string command, string domain, string username, string password)
        {
            var processInfo = new PROCESS_INFORMATION();
            var startInfo = new STARTUPINFO();
            Boolean bResult = false;
            IntPtr hToken = IntPtr.Zero;
            UInt32 uiResultWait = NativeMethods.WAIT_FAILED;
            
            try 
            {
                bResult = NativeMethods.LogonUser(
                    username,
                    domain,
                    password,
                    LogonType.LOGON32_LOGON_INTERACTIVE,
                    LogonProvider.LOGON32_PROVIDER_DEFAULT,
                    out hToken
                );
                if (!bResult) { throw new Exception("Failed to log on as " + domain + @"\" + username + ": " + Marshal.GetLastWin32Error()); }

                startInfo.cb = Marshal.SizeOf(startInfo);
                startInfo.lpDesktop = "winsta0\\default";

                bResult = NativeMethods.CreateProcessAsUser(
                    hToken, 
                    null, 
                    command, 
                    IntPtr.Zero,
                    IntPtr.Zero,
                    false,
                    0,
                    IntPtr.Zero,
                    null,
                    ref startInfo,
                    out processInfo
                );
                if (!bResult) { throw new Exception("CreateProcessAsUser error #" + Marshal.GetLastWin32Error()); }

                uiResultWait = NativeMethods.WaitForSingleObject(processInfo.hProcess, NativeMethods.INFINITE);
                if (uiResultWait == NativeMethods.WAIT_FAILED) { throw new Exception("Failed to wait for running executable: " + Marshal.GetLastWin32Error()); }
            }
            finally 
            {
                NativeMethods.CloseHandle(hToken);
                NativeMethods.CloseHandle(processInfo.hProcess);
                NativeMethods.CloseHandle(processInfo.hThread);
            }
        }
    }
}
