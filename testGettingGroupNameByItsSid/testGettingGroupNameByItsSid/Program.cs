/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 01/07/2015
 * Time: 07:08 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testGettingGroupNameByItsSid
{
    using System;
    using System.Security.Principal;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var guestsGroup = new SecurityIdentifier(WellKnownSidType.BuiltinGuestsSid, null).Translate(typeof(NTAccount)).Value;
            Console.WriteLine(guestsGroup);
            
            var usersGroup = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null).Translate(typeof(NTAccount)).Value;
            Console.WriteLine(usersGroup);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}