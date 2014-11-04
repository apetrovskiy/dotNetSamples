/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/2/2013
 * Time: 2:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testListConversion
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            System.Collections.Generic.List<int> list1 = new System.Collections.Generic.List<int>();
            System.Collections.Generic.List<object> list2 = new System.Collections.Generic.List<object>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            //list2 = list1 as System.Collections.Generic.List<object>;
            var list3 = from items in list1
                select i;
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}