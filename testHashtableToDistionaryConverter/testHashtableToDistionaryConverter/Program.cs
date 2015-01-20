/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 1/12/2015
 * Time: 6:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testHashtableToDistionaryConverter
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var hashtable = new Hashtable();
//            {
//                "aaa" = "aaaa",
//                "bbb" = "bbbb",
//                "ccc" = "cccc"
//            };
            hashtable.Add("aaa", "aaaa");
            hashtable.Add("bbb", "bbbb");
            hashtable.Add("ccc", "cccc");
            // var dict = hashtable
            // Dictionary<string, string> dict = hashtable.ase
            var dict = hashtable.Cast<DictionaryEntry>().ToDictionary(val => val.Key, val => val.Value);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}