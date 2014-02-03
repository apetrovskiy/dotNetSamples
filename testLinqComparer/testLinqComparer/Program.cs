/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/3/2014
 * Time: 9:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testLinqComparer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var list1 =
                new List<testClass>();
            list1.Add(new testClass("aaaa", "bbbb"));
            list1.Add(new testClass("cccc", "dddd"));
            list1.Add(new testClass("eeee", "ffff"));
            list1.Add(new testClass("gggg", "hhhh"));
            
            var list2 =
                new List<testClass>();
            list2.Add(new testClass("aaaa", "bbbb"));
            list2.Add(new testClass("cccc", "cccc"));
            list2.Add(new testClass("ffff", "ffff"));
            list2.Add(new testClass("gggg", "hhhh"));
            
            // var common =
                //list1.Where(tc => list2.Any(tc2 => tc.Prop1 == tc2.Prop1 && tc.Prop2 == tc2.Prop2));
                // list1.SelectMany(list1, tc => list2.Any(tc2 => tc.Prop1 == tc2.Prop1 && tc.Prop2 == tc2.Prop2));
            
            var query =
                from element1 in list1
                from element2 in list2
                where element1.Prop1 == element2.Prop1 && element1.Prop2 == element2.Prop2
                select element1;

            
            // foreach (var element in common) {
            foreach (var element0 in query) {
                Console.WriteLine("element: {0}, {1}", element0.Prop1, element0.Prop2);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}