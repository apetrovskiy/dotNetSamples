using System.Security.AccessControl;
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
            
            bool commonObjects = false;
            
            var e1 = new testClass("aaaa", "bbbb");
            var e2 = new testClass("cccc", "dddd");
            var e3 = new testClass("eeee", "ffff");
            var e4 = new testClass("gggg", "hhhh");
            var e5 = new testClass("cccc", "cccc");
            var e6 = new testClass("ffff", "ffff");
            
            var list1 =
                new List<testClass>();
            if (commonObjects) {
                list1.Add(e1);
                list1.Add(e2);
                list1.Add(e3);
                list1.Add(e4);
            } else {
                list1.Add(new testClass("aaaa", "bbbb"));
                list1.Add(new testClass("cccc", "dddd"));
                list1.Add(new testClass("eeee", "ffff"));
                list1.Add(new testClass("gggg", "hhhh"));
            }
            
            var list2 =
                new List<testClass>();
            if (commonObjects) {
                list2.Add(e1);
                list2.Add(e5);
                list2.Add(e6);
                list2.Add(e4);
            } else {
                list2.Add(new testClass("aaaa", "bbbb"));
                list2.Add(new testClass("cccc", "cccc"));
                list2.Add(new testClass("ffff", "ffff"));
                list2.Add(new testClass("gggg", "hhhh"));
            }
            
            var query =
                from element1 in list1
                from element2 in list2
                where element1.Prop1 == element2.Prop1 && element1.Prop2 == element2.Prop2
                select element1;
            
            var common =
                list1.Intersect(list2);
            
            var diff =
                list1.Except(list2);
            
            Console.WriteLine("=========================== common part ============================");
            
            foreach (var element in common) {
                Console.WriteLine("element {0}, {1}", element.Prop1, element.Prop2);
            }
            
            Console.WriteLine("=========================== difference ============================");
            
            foreach (var element in diff) {
                Console.WriteLine("element {0}, {1}", element.Prop1, element.Prop2);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}