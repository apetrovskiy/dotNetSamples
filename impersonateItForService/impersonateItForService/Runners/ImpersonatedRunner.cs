// This sample demonstrates the use of the WindowsIdentity class to impersonate a user. 
// IMPORTANT NOTES: 
// This sample requests the user to enter a password on the console screen. 
// Because the console window does not support methods allowing the password to be masked, 
// it will be visible to anyone viewing the screen. 
// On Windows Vista and later this sample must be run as an administrator.  
// https://msdn.microsoft.com/en-us/library/w070t6ka%28v=vs.110%29.aspx
// https://msdn.microsoft.com/en-us/library/chf6fbt4.aspx
// https://msdn.microsoft.com/en-us/library/system.security.principal.windowsimpersonationcontext.aspx

namespace impersonateItForService.Runners
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Security.Principal;
    using Helpers;
//using Abstract;

    //using NwxDataMining.Common;
    //using ObjectModel;

    public class ImpersonatedRunner // : ITestRunner
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public virtual void Run(string strCommand, string strDomain, string strName, string strPassword)
        {
            var data = new TestRunnerData
            {
                Command = strCommand,
                Domain = strDomain,
                Username = strName,
                Password = strPassword
            };
            Run(data);
        }

        // Test harness. 
        // If you incorporate this code into a DLL, be sure to demand FullTrust.
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public virtual void Run(TestRunnerData data)
        {
            try
            {
                SafeTokenHandle safeTokenHandle;
                // Get the user token for the specified user, domain, and password using the 
                // unmanaged LogonUser method. 
                // The local machine name can be used for the domain name to impersonate a user on this machine.
                const int LOGON32_PROVIDER_DEFAULT = 0;
                const int LOGON32_PROVIDER_WINNT35 = 1;
                const int LOGON32_PROVIDER_WINNT40 = 2;
                const int LOGON32_PROVIDER_WINNT50 = 3;
                //This parameter causes LogonUser to create a primary token. 
                const int LOGON32_LOGON_INTERACTIVE = 2;
                const int LOGON32_LOGON_SERVICE = 5;

                var windowsAccountType = WindowsAccountType.Normal;
                var logonType = LOGON32_LOGON_INTERACTIVE;
                var logonProvider = LOGON32_PROVIDER_DEFAULT;
                if (!string.IsNullOrEmpty(data.Domain) && "NT AUTHORITY" == data.Domain.ToUpper())
                {
                    windowsAccountType = WindowsAccountType.System;
                    logonType = LOGON32_LOGON_SERVICE;
                    // logonProvider = LOGON32_PROVIDER_WINNT50;
                }
                if (!string.IsNullOrEmpty(data.Password) && "null" == data.Password.ToLower())
                    data.Password = null;

                // Call LogonUser to obtain a handle to an access token. 
                var returnValue = LogonUser(
                    data.Username,
                    data.Domain,
                    data.Password,
                    logonType,
                    logonProvider,
                    out safeTokenHandle);

                if (!returnValue)
                {
                    var ret = Marshal.GetLastWin32Error();
                    // throw new Win32Exception(ret, CommonResources.Exception_FailedToRunLogonUser);
                    throw new Win32Exception(ret, "FailedToRunLogonUser");
                }

                using (safeTokenHandle)
                {
                    // Use the token handle returned by LogonUser. 
                    using (var newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle(), "aaaa", windowsAccountType))
                    {
                        using (var impersonatedUser = newId.Impersonate())
                        {
                            //if (data.TestSuites.Any())
                            //    data.SuiteSetUpRunner(data.TestSuites);

                            //data.TestCasesRunner(data.TestCases, data.SpecificSettings);

                            //if (data.TestSuites.Any())
                            //    data.SuiteTearDownRunner(data.TestSuites);

                            var testRunnerFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                            var process = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    WorkingDirectory = testRunnerFolderPath,
                                    FileName = testRunnerFolderPath + @"\" + "TestRunnerViaCmdline.exe",
                                    Arguments = data.Command.Replace(testRunnerFolderPath + @"\" + "TestRunnerViaCmdline.exe", string.Empty),
                                    UseShellExecute = true
                                }
                            };
                            Console.WriteLine(process.StartInfo.FileName);
                            Console.WriteLine(process.StartInfo.Arguments);
                            process.Start();

                            impersonatedUser.Undo();
                        }
                    }
                }
            }
            catch (Exception eImpersonatedRunException)
            {
                // TODO: return as it was
                // Assert.Fail(securityTestData.Description + " " + eImpersonatedRunException.Message);

                // TODO: log this state!

                throw new Exception(eImpersonatedRunException.Message);
            }
        }
    }
}