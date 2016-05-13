/*
 * Created by SharpDevelop.
 * User: unknown
 * Date: 10/28/2014
 * Time: 9:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace impersonateItForService.Runners.Helpers
{
    using System;

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
    
    [Flags]
    public enum LogonType
    {
        LOGON32_LOGON_INTERACTIVE = 2,
        LOGON32_LOGON_NETWORK = 3,
        LOGON32_LOGON_BATCH = 4,
        LOGON32_LOGON_SERVICE = 5,
        LOGON32_LOGON_UNLOCK = 7,
        LOGON32_LOGON_NETWORK_CLEARTEXT = 8,
        LOGON32_LOGON_NEW_CREDENTIALS = 9
    }
    
    [Flags]
    public enum LogonProvider
    {
        LOGON32_PROVIDER_DEFAULT = 0,
        LOGON32_PROVIDER_WINNT35,
        LOGON32_PROVIDER_WINNT40,
        LOGON32_PROVIDER_WINNT50
    }
}
