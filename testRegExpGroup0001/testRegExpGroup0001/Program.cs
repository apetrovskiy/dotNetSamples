/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 6/25/2016
 * Time: 10:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testRegExpGroup0001
{
    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        public static void Main(string[] args)
        {
            string a = "pieter was a small boy";
            var regex = new Regex(@"\b[A-Z]", RegexOptions.IgnoreCase);
            a = regex.Replace(a, m=>m.ToString().ToUpper());
            
            
            var testClass = new TestClass();
            testClass.Test();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}