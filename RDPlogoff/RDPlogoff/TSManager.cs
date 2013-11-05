/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 6/4/2013
 * Time: 3:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace RDPlogoff
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;

    class TSManager
    {
        [DllImport("wtsapi32.dll", SetLastError=true)]
        static extern IntPtr WTSOpenServer([MarshalAs(UnmanagedType.LPStr)] String pServerName);
    
        [DllImport("wtsapi32.dll")]
        static extern void WTSCloseServer(IntPtr hServer);
    
        [DllImport("wtsapi32.dll", SetLastError=true)]
        static extern Int32 WTSEnumerateSessions(
            IntPtr hServer, 
            [MarshalAs(UnmanagedType.U4)] Int32 Reserved,
            [MarshalAs(UnmanagedType.U4)] Int32 Version, 
            ref IntPtr ppSessionInfo,
            [MarshalAs(UnmanagedType.U4)] ref Int32 pCount);
    
        [DllImport("wtsapi32.dll")]
        static extern void WTSFreeMemory(IntPtr pMemory);
    
        [StructLayout(LayoutKind.Sequential)]
        private struct WTS_SESSION_INFO
        {
            public Int32 SessionID;
    
            [MarshalAs(UnmanagedType.LPStr)]
            public String pWinStationName;
    
            public WTS_CONNECTSTATE_CLASS State;
        }
    
        public enum WTS_CONNECTSTATE_CLASS
        {
            WTSActive,
            WTSConnected,
            WTSConnectQuery,
            WTSShadow,
            WTSDisconnected,
            WTSIdle,
            WTSListen,
            WTSReset,
            WTSDown,
            WTSInit
        } 
    
        public static IntPtr OpenServer(String Name)
        {
            IntPtr server = WTSOpenServer(Name);
            return server;
        }
        public static void CloseServer(IntPtr ServerHandle)
        {
            WTSCloseServer(ServerHandle);
        }
        public static List<String> ListSessions(String ServerName)
        {
            IntPtr server = IntPtr.Zero;
            List<String> ret = new List<string>();
            server = OpenServer(ServerName);
    
            try
            {
            IntPtr ppSessionInfo = IntPtr.Zero;
    
            Int32 count = 0;
            Int32 retval = WTSEnumerateSessions(server, 0, 1, ref ppSessionInfo, ref count);
            Int32 dataSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
    
            Int64 current = (int)ppSessionInfo;
    
            if (retval != 0)
            {
                for (int i = 0; i < count; i++)
                {
                WTS_SESSION_INFO si = (WTS_SESSION_INFO)Marshal.PtrToStructure((System.IntPtr)current, typeof(WTS_SESSION_INFO));
                current += dataSize;
    
                ret.Add(si.SessionID + " " + si.State + " " + si.pWinStationName);
                }
    
                WTSFreeMemory(ppSessionInfo);
            }
            }
            finally
            {
            CloseServer(server);
            }
    
            return ret;
        }
    }
}
