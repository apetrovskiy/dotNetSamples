/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 9/20/2013
 * Time: 9:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.Test.ObjectComparison;
//using System.Collections.Generic;

namespace testapitest
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            
            string s1 = "abcd;efgh;ijkl";
            string s2 = "abcd;efgh;ijkl";
            string s3 = "abcd;efgh";
            string s4 = "efgh;ijkl";
            
            //ObjectGraphFactory factory = new PublicPropertyObjectGraphFactory();
            //Microsoft.Test.ObjectComparison.com
            //ojbectcomparer
            //ObjectComparer comparer = new ObjectComparer(factory);
            //comparer.
            ObjectGraphFactory factory = new PublicPropertyObjectGraphFactory();
            ObjectGraphFactoryMap map = new ObjectGraphFactoryMap(true);
            GraphNode s1Graph = factory.CreateObjectGraph(s1, map);
            GraphNode s2Graph = factory.CreateObjectGraph(s2, map);
            ObjectGraphComparer comparer = new ObjectGraphComparer();
            Console.WriteLine(
                "Objects s1 and s2 {0}", 
                comparer.Compare(s1Graph, s2Graph) ? "match!" : "do NOT match!");
            
            s2Graph = factory.CreateObjectGraph(s3, map);
            comparer = new ObjectGraphComparer();
            Console.WriteLine(
                "Objects s1 and s3 {0}", 
                comparer.Compare(s1Graph, s2Graph) ? "match!" : "do NOT match!");
            
            s2Graph = factory.CreateObjectGraph(s4, map);
            comparer = new ObjectGraphComparer();
            Console.WriteLine(
                "Objects s1 and s4 {0}", 
                comparer.Compare(s1Graph, s2Graph) ? "match!" : "do NOT match!");

            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}