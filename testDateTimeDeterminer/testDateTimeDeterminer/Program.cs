/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 31/03/2015
 * Time: 03:44 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testDateTimeDeterminer
{
    using System;
       
    class Program
    {
        public static void Main(string[] args)
        {
            var checker = new Checker();
            checker.Run();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
      }
}