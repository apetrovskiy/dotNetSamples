/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/20/2013
 * Time: 5:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace RDPlogoff
{
    using System;
    using System.Runtime.InteropServices;
    using DWORD = System.UInt32;
    
    /// <summary>
    /// Description of NativeMethods.
    /// </summary>
    public static class NativeMethods
    {
        static NativeMethods()
        {
        }
        
//        [DllImport("wtsapi32.dll", EntryPoint = "PostMessage", CharSet = CharSet.Auto)]
//        [return: MarshalAs(UnmanagedType.)]
//        internal static extern bool PostMessage1(IntPtr hWnd, uint Msg,
//                                                IntPtr wParam, IntPtr lParam);
        
//        HANDLE WTSOpenServer(
//          _In_  LPTSTR pServerName
//        );
        
        [DllImport("wtsapi32.dll", EntryPoint = "WTSOpenServer", CharSet = CharSet.Auto)]
        public static extern IntPtr WTSOpenServer(string pServerName);
        
//        SI_STATUS SI_Write (HANDLE Handle, LPVOID Buffer, DWORD NumBytesToWrite,
//        DWORD *NumBytesWritten, OVERLAPPED* o = NULL)
//        It means the .NET prototype should be this instead:
//        
//        [DllImport("SiUSBXp.dll")]
//        static extern int SI_Write(IntPtr Handle, byte[] Buffer,
//           uint NumBytesToWrite, out uint NumBytesWritten, IntPtr o);

//        BOOL WTSLogoffSession(
//          _In_  HANDLE hServer,
//          _In_  DWORD SessionId,
//          _In_  BOOL bWait
//        );
        
        [DllImport("wtsapi32.dll", EntryPoint = "WTSLogoffSession", CharSet = CharSet.Auto)]
        public static extern bool WTSLogoffSession(IntPtr hServer, DWORD SessionId, bool bWait);
        
//        BOOL WTSEnumerateProcesses(
//          _In_   HANDLE hServer,
//          _In_   DWORD Reserved,
//          _In_   DWORD Version,
//          _Out_  PWTS_PROCESS_INFO *ppProcessInfo,
//          _Out_  DWORD *pCount
//        );
//        
//        [DllImport("wtsapi32.dll", EntryPoint = "WTSEnumerateProcesses", CharSet = CharSet.Auto)]
//        public static extern bool WTSEnumerateProcesses(IntPtr hServer, DWORD Reserved, DWORD Version, 

//        BOOL WTSEnumerateSessions(
//          _In_   HANDLE hServer,
//          _In_   DWORD Reserved,
//          _In_   DWORD Version,
//          _Out_  PWTS_SESSION_INFO *ppSessionInfo,
//          _Out_  DWORD *pCount
//        );
        
        
//        [DllImport("kernel32.dll")]
//        private static extern uint WTSGetActiveConsoleSessionId();
//        
//        public static extern int WTSEnumerateSessions(
//                System.IntPtr hServer,
//                int Reserved,
//                int Version,
//                ref System.IntPtr ppSessionInfo,
//                ref int pCount);
//
//        public static extern void WTSEnumerateSessions(
//                        System.IntPtr hServer,
//                        ref System.IntPtr ppSessionInfo,
//                        ref int pCount)
//        {
//            WTSEnumerateSessions(hServer,0,1,ppSessionInfo,pCount);
//        }
    }
}
