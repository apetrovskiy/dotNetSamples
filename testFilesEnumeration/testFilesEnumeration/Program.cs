/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/06/2015
 * Time: 06:39 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testFilesEnumeration
{
    using System;
    using System.IO;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            
            /*
            E:\20150611\LTS\ 
            */
            
            var filePaths = Directory.GetFiles(@"E:\20150611\LTS\");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}