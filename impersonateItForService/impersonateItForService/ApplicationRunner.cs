/*
 * Created by SharpDevelop.
 * User: unknown
 * Date: 10/28/2014
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace impersonateItForService
{
    using System;
    using System.Runtime.InteropServices;
    using NativeMethods;

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
            UInt32 uiResultWait = NativeMethods.NativeMethods.WAIT_FAILED;

            try 
            {
                startInfo.cb = Marshal.SizeOf(startInfo);

                res = NativeMethods.NativeMethods.CreateProcessWithLogonW(
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

                uiResultWait = NativeMethods.NativeMethods.WaitForSingleObject(processInfo.hProcess, NativeMethods.NativeMethods.INFINITE);
                if (uiResultWait == NativeMethods.NativeMethods.WAIT_FAILED) { throw new Exception("WaitForSingleObject error #" + Marshal.GetLastWin32Error()); }

            } 
            finally
            {
                NativeMethods.NativeMethods.CloseHandle(processInfo.hProcess);
                NativeMethods.NativeMethods.CloseHandle(processInfo.hThread);
            }
        }

        public static void LogonAsSpecifiedUser(string command, string domain, string username, string password)
        {
            var processInfo = new PROCESS_INFORMATION();
            var startInfo = new STARTUPINFO();
            Boolean bResult = false;
            IntPtr hToken = IntPtr.Zero;
            UInt32 uiResultWait = NativeMethods.NativeMethods.WAIT_FAILED;
            
            try 
            {
                bResult = NativeMethods.NativeMethods.LogonUser(
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

                bResult = NativeMethods.NativeMethods.CreateProcessAsUser(
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

                uiResultWait = NativeMethods.NativeMethods.WaitForSingleObject(processInfo.hProcess, NativeMethods.NativeMethods.INFINITE);
                if (uiResultWait == NativeMethods.NativeMethods.WAIT_FAILED) { throw new Exception("Failed to wait for running executable: " + Marshal.GetLastWin32Error()); }
            }
            finally 
            {
                NativeMethods.NativeMethods.CloseHandle(hToken);
                NativeMethods.NativeMethods.CloseHandle(processInfo.hProcess);
                NativeMethods.NativeMethods.CloseHandle(processInfo.hThread);
            }
        }
    }
}
