/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 09/04/2016
 * Time: 09:37 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testApp
{
    using System;
    using System.Linq;
    
    class Program
    {
        public static void Main(string[] args)
        {
            if (null != args && args.Any())
                args.ToList().ForEach(Console.WriteLine);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}