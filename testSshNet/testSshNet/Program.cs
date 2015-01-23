/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 1/22/2015
 * Time: 6:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testSshNet
{
    using System;
    using System.Collections.Generic;
    using Renci.SshNet;
    
    class Program
    {
        public static void Main(string[] args)
        {
//            const string vmId = @"(?m)(?n)(?<=^)\d+(?=\s\s+)";
//            const string vmName = @"(?m)(?n)(?<=^[\d]+\s+)[^\s].*[^\s](?=\s+\[)";
//            const string vmFile = @"(?m)(?n)(?<=.*\s+)\[[^\]]+\].*\.vmx(?=\s\s+\w)";
//            const string vmGuestOs = @"";
//            const string vmVersion = @"";
//            const string vmAnnotation = @"";
            
            var connInfo = new ConnectionInfo(
                               "172.28.1.11",
                               "root",
                               new AuthenticationMethod[] {
                    new PasswordAuthenticationMethod("root", @"=1qwerty"),
                    new PrivateKeyAuthenticationMethod(
                        "root",
                        new [] { new PrivateKeyFile(@"e:\putty\my_esxi.key", "=1qwerty") }),
                });
            
            var vms = new List<IEsxiVirtualMachine>();
            
            using (var client = new SshClient(connInfo)) {
                client.Connect();
                
                // this works
                // Console.WriteLine(client.RunCommand("ls -l").Result);
                
                using (var cmd = client.CreateCommand("vim-cmd vmsvc/getallvms")) {
                    var result = cmd.Execute();
                    Console.WriteLine("row count = {0}", result.Split('\r').Length);
                    Console.WriteLine(cmd.CommandText);
                    Console.WriteLine("Return value = {0}", cmd.ExitStatus);
                    Console.WriteLine(result);
                    
                    var plainDataConverter = new PlainDataConverter();
                    vms = plainDataConverter.GetMachines(result);
                }
                
               client.Disconnect();
            }
            
            foreach (var vm in vms) {
                Console.WriteLine("id = {0}, name = {1}, path = {2}", vm.Id, vm.Name, vm.Path);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}