/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/25/2013
 * Time: 4:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace DeviceCommands
{
    using System;
    using System.Runtime.InteropServices;
    
    /// <summary>
    /// Description of DeviceHelper.
    /// </summary>
    public class DeviceHelper
    {
//        public DeviceHelper()
//        {
//        }
        
        public void RefreshDevices()
        {
            
            
            NativeMethods.SP_DEVINFO_DATA data = new NativeMethods.SP_DEVINFO_DATA();
            data.cbSize = Marshal.SizeOf(data);
            bool result = NativeMethods.SetupDiEnumDeviceInfo(
        }
    }
}
