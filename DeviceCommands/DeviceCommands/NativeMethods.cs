/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/25/2013
 * Time: 4:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace DeviceCommands
{
    using System;
    
    
    /// <summary>
    /// Description of NativeMethods.
    /// </summary>
    public class NativeMethods
    {
//        public NativeMethods()
//        {
//        }
        
        [DllImport("setupapi.dll", SetLastError=true)]
        public static extern bool SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet, uint MemberIndex, ref SP_DEVINFO_DATA DeviceInfoData);
        
        [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetupDiGetClassDevs(
            ref Guid ClassGuid,
            [MarshalAs(UnmanagedType.LPTStr)] string Enumerator,
            IntPtr hwndParent,
            uint Flags
           );
    
        [StructLayout(LayoutKind.Sequential)]
        public struct SP_DEVINFO_DATA
        {
            public uint cbSize;
            public Guid ClassGuid;
            public uint DevInst;
            public IntPtr Reserved;
        }
    }
}
