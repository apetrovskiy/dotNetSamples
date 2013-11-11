/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/8/2013
 * Time: 2:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management.Automation;

namespace testWildcard
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            WildcardOptions options =
                WildcardOptions.IgnoreCase |
                WildcardOptions.Compiled;
            
            string name1 = "";
            string name2 = null;
            string name3 = "aaa";
            string name4 = "*aa*";
            Console.WriteLine(string.IsNullOrEmpty(name1) ? "*" : name1);
            Console.WriteLine(string.IsNullOrEmpty(name2) ? "*" : name2);
            Console.WriteLine(string.IsNullOrEmpty(name3) ? "*" : name3);
            Console.WriteLine(string.IsNullOrEmpty(name4) ? "*" : name4);
            
            WildcardPattern wildcardName1 = 
                new WildcardPattern(name1, options);
            //WildcardPattern wildcardName2 = 
            //    new WildcardPattern(name2, options);
            WildcardPattern wildcardName3 = 
                new WildcardPattern(name3, options);
            WildcardPattern wildcardName4 = 
                new WildcardPattern(name4, options);
            
            Console.WriteLine(wildcardName1.IsMatch("aa"));
            //Console.WriteLine(wildcardName2);
            Console.WriteLine(wildcardName3.IsMatch("aa"));
            Console.WriteLine(wildcardName4.IsMatch("aa"));
            
            WildcardPattern wildcardName5 = 
                new WildcardPattern(string.IsNullOrEmpty(name1) ? "*" : name1, options);
            WildcardPattern wildcardName6 = 
                new WildcardPattern(string.IsNullOrEmpty(name2) ? "*" : name2, options);
            WildcardPattern wildcardName7 = 
                new WildcardPattern(string.IsNullOrEmpty(name3) ? "*" : name3, options);
            WildcardPattern wildcardName8 = 
                new WildcardPattern(string.IsNullOrEmpty(name4) ? "*" : name4, options);
            
            Console.WriteLine(wildcardName5.IsMatch("aa"));
            Console.WriteLine(wildcardName6.IsMatch("aa"));
            Console.WriteLine(wildcardName7.IsMatch("aa"));
            Console.WriteLine(wildcardName8.IsMatch("aa"));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}