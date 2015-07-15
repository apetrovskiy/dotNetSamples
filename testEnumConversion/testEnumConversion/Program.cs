/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 15/07/2015
 * Time: 07:45 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testEnumConversion
{
    using System;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            // var a1 = (Values)"val1";
            Console.WriteLine(Values.val1);
            Console.WriteLine(Values.val1.ToString());
            System.Convert.ChangeType("val1", typeof(Values));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
    
    public enum Values
    {
        val1,
        val2,
        val
    }
}