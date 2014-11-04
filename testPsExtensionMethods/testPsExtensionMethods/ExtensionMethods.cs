/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/7/2013
 * Time: 12:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testPsExtensionMethods
{
    /// <summary>
    /// Description of ExtensionMethods.
    /// </summary>
    public static class ExtensionMethods
    {
        public static void Command1(this IUpper element)
        {
            Console.WriteLine("method Command 1");
        }
        
        public static void Command2(this Upper element)
        {
            Console.WriteLine("method Command 2");
        }
        
        public static void Command3(this ILower element)
        {
            Console.WriteLine("method Command 3");
        }
        
        public static void Command4(this Lower element)
        {
            Console.WriteLine("method Command 4");
        }
        
        public static void Command5(this IUpper element)
        {
            Console.WriteLine("method Command 5");
        }
        
        public static void Command6(this ILower element)
        {
            Console.WriteLine("method Command 6");
        }
    }
}
