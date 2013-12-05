/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/3/2013
 * Time: 5:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace testHtToDictConversion
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            Hashtable ht = new Hashtable {
                {"aaa", 111},
                {"bbb", 222}
            };
            
            Dictionary<string, int> dict = new Dictionary<string, int>();
           
            foreach (int key in ht.Keys.Cast<string>().All<string>(k => {dict.Add(k, Convert.ToInt32(ht[k])); return true; })) {
                
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}