/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 6/19/2013
 * Time: 4:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testArrayListCleanUp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            System.Collections.ArrayList arrList =
                new System.Collections.ArrayList();
            arrList.Add("host1");
            arrList.Add("host2");
            arrList.Add("host3");
            arrList.Add("host4");
            arrList.Add("host5");
            
            //Console.ReadKey();
            
            for (int i = 0; i < arrList.Count; i++) {
                if (2 == i || 4 == i) {
                    arrList[i] = "";
                }
            }
            
            
            foreach (var element in arrList) {
                Console.WriteLine(element);
            }
            
            arrList.Remove("");
            arrList.Remove("");
            arrList.Remove("");
            arrList.Remove("");

            foreach (var element in arrList) {
                Console.WriteLine(element);
            }
            
            Console.ReadKey();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}