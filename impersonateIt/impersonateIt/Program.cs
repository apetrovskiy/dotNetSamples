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
    using Mono.Options;
    
    class Program
    {
        public static void Main(string[] args)
        {
            bool show_help = false;
            String command = string.Empty;
            String username    = string.Empty;
            String domain  = string.Empty;
            String password = string.Empty;
            
            var inputOptions = new OptionSet () {
                { "d=|domain=", "domain", option => domain = option },
                { "u=|username=", "username", option => username = option },
                { "p=|password=", "password", option => password = option },
                { "c=|command=", "command", option => command = option },
                { "h|help", "help", option => show_help = true }
            };
            inputOptions.Parse(args);
            
            show_help |= string.IsNullOrEmpty(command) || string.IsNullOrEmpty(domain) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password);
            
            if (show_help) {
                ShowHelp (inputOptions);
                return;
            }
            
            try
            {
                Console.WriteLine(@"running '{0}' as {1}\{2}" , command, domain, username);
                ApplicationRunner.CreateProcessWithCredentials(command, domain, username, password);
                ApplicationRunner.LogonAsSpecifiedUser(command, domain, username, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error detected: " + ex.Message);
            }
        }
        
        static void ShowHelp (OptionSet inputOptions)
        {
            Console.WriteLine ("Usage: impersonateIt -d domain -u username -p password -c path_to_program");
            Console.WriteLine ();
            Console.WriteLine ("Options:");
            inputOptions.WriteOptionDescriptions (Console.Out);
        }
    }
}