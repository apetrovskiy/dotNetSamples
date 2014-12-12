/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/12/2014
 * Time: 7:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using testCollComparer;
namespace testCollComparer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public interface ISomeInterface
    {
        string P1 { get; set; }
        string P2 { get; set; }
        List<string> P3 { get; set; }
        List<object> P4 { get; set; }
        string ToString();
    }
    
    public class SomeClassA : ISomeInterface
    {
        public SomeClassA()
        {
            P3 = new List<string>();
            P4 = new List<object>();
        }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public List<string> P3 { get; set; }
        public List<object> P4 { get; set; }
        public override string ToString()
        {
            return P1 + P2 + P3.SelectMany(item => item) + P4.SelectMany(item => item.ToString());
        }
    }
    
    public class AnotherClassB : ISomeInterface
    {
        public AnotherClassB()
        {
            P3 = new List<string>();
            P4 = new List<object>();
        }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public List<string> P3 { get; set; }
        public List<object> P4 { get; set; }
        public override string ToString()
        {
            return P1 + P2 + P3.SelectMany(item => item) + P4.SelectMany(item => item.ToString());
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            var list01 = new List<SomeClassA> {
                new SomeClassA { P1 = "a", P2 = "b" },
                new SomeClassA { P1 = "c", P2 = "d" },
                new SomeClassA { P1 = "e", P2 = "f" },
                new SomeClassA { P1 = "g", P2 = "h" },
                new SomeClassA { P1 = "g", P2 = "h" },
                new SomeClassA { P1 = "k", P2 = "l" },
                new SomeClassA { P3 = new List<string> { "a", "b", "c" } },
                new SomeClassA { P3 = new List<string> { "a", "b", "c" } },
                new SomeClassA { P4 = new List<object> { new { a = "b" }, new { c = "d" }}}
            }.Select(item => item.ToString()).ToList();
            
            var list02 = new List<AnotherClassB> {
                new AnotherClassB { P1 = "a", P2 = "b" },
                new AnotherClassB { P1 = "c", P2 = "e" },
                new AnotherClassB { P1 = "e", P2 = "f" },
                new AnotherClassB { P1 = "g", P2 = "h" },
                new AnotherClassB { P1 = "i", P2 = "j" },
                new AnotherClassB { P1 = "k", P2 = "l" },
                new AnotherClassB { P3 = new List<string> { "a", "b", "c" } },
                new AnotherClassB { P3 = new List<string> { "a", "b", "d" } },
                new AnotherClassB { P4 = new List<object> { new { a = "b" }, new { c = "d" }}}
            }.Select(item => item.ToString()).ToList();
            
            Console.WriteLine("\r\n=============== only in the first list ===============");
            list01.Except(list02).ToList().ForEach(Console.WriteLine);
            
            Console.WriteLine("\r\n=============== only in the second list ===============");
            list02.Except(list01).ToList().ForEach(Console.WriteLine);
            
            Console.WriteLine("\r\n=============== are lists equal? ===============");
            Console.WriteLine(list01.SequenceEqual(list02));
            
            Console.WriteLine("\r\n=============== are there duplicates in the first list? ===============");
            var duplesInList01 = !list01.SequenceEqual(list01.Distinct().ToList());
            Console.WriteLine(duplesInList01);
            if (duplesInList01) {
                Console.WriteLine("=============== duplicates in the first list ===============");
                list01.GroupBy(item => item).SelectMany(grp => grp.Skip(1)).ToList().ForEach(Console.WriteLine);
            }
            
            Console.WriteLine("\r\n=============== are there duplicates in the second list? ===============");
            var duplesInList02 = !list02.SequenceEqual(list02.Distinct().ToList());
            Console.WriteLine(duplesInList02);
            if (duplesInList02) {
                Console.WriteLine("=============== duplicates in the second list ===============");
                list02.GroupBy(item => item).SelectMany(grp => grp.Skip(1)).ToList().ForEach(Console.WriteLine);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}