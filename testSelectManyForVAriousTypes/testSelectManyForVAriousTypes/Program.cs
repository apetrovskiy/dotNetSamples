/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 02/09/2015
 * Time: 03:16 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testSelectManyForVAriousTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var testObjects = new[] { new TestType(), new TestType(), new TestType() };
            var count = 10;
            var suffixBase = "3333";
            var suffixes = new List<string>();
            for (var i = 1; i <= count; i++)
                suffixes.Add(suffixBase + i);
            var preparedTestObjects = testObjects
                //.SelectMany<TestType, TestType>(testObj => suffixes.ForEach(suffix => testObj.Suffix = suffix));
                .Select<TestType, TestType>(testObj  => {
                            foreach (var suffix in suffixes) {
                                testObj.Suffix = suffix;
                                var testObj1 = testObj;
                            }
                        });
            foreach (var testObj in preparedTestObjects) {
                Console.WriteLine(testObj.Suffix);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}