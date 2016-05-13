/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 05/02/2016
 * Time: 10:30 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testUsername
{
    using System;
    using System.Linq;
    using System.Security.Principal;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Console.WriteLine(Environment.MachineName);
            Console.WriteLine(Environment.UserDomainName);
            Console.WriteLine(Environment.UserName);
            
            var currentIdentity = WindowsIdentity.GetCurrent();
            Console.WriteLine(currentIdentity.User);
            Console.WriteLine(currentIdentity.Name);
            currentIdentity.Groups.ToList().ForEach(group => Console.WriteLine(group.Value.ToString()));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}