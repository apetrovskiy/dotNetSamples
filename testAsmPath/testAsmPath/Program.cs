/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 10/1/2014
 * Time: 12:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testAsmPath
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies()) {
                Console.WriteLine(asm.CodeBase);
                Console.WriteLine(asm.EscapedCodeBase);
                Console.WriteLine(asm.FullName);
                Console.WriteLine(asm.Location);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}