/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 07/08/2015
 * Time: 09:56 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testOrToArray
{
    using System;
    using System.Linq;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var valueToCompare = 3;
            var value01 = 1;
            var value03 = 3;
            var value05 = 5;
            var value07 = 7;
            
            Console.WriteLine("expected: True");
            Console.WriteLine(value01 == valueToCompare || value03 == valueToCompare || value05 == valueToCompare);
            Console.WriteLine((new[] { value01, value03, value05 }).Contains(valueToCompare));
            
            Console.WriteLine("expected: False");
            Console.WriteLine(value01 == valueToCompare || value05 == valueToCompare || value07 == valueToCompare);
            Console.WriteLine((new[] { value01, value05, value07 }).Contains(valueToCompare));
            
            bool result = false;
            int maxCounter = 10000000;
            
            Console.WriteLine("=============================================");
            Console.WriteLine("expected: True {0} times", maxCounter);
            var startTime = DateTime.Now;
            for (int i =0; i < maxCounter; i++) {
                result = value01 == valueToCompare || value03 == valueToCompare || value05 == valueToCompare;
            }
            var resultTime = DateTime.Now - startTime;
            Console.WriteLine(resultTime);
            
            Console.WriteLine("=============================================");
            Console.WriteLine("expected: True {0} times", maxCounter);
            startTime = DateTime.Now;
            for (int i =0; i < maxCounter; i++) {
                result = (new[] { value01, value03, value05 }).Contains(valueToCompare);
            }
            resultTime = DateTime.Now - startTime;
            Console.WriteLine(resultTime);
            
            Console.WriteLine("=============================================");
            Console.WriteLine("expected: False {0} times", maxCounter);
            startTime = DateTime.Now;
            for (int i =0; i < maxCounter; i++) {
                result = value01 == valueToCompare || value05 == valueToCompare || value07 == valueToCompare;
            }
            resultTime = DateTime.Now - startTime;
            Console.WriteLine(resultTime);
            
            Console.WriteLine("=============================================");
            Console.WriteLine("expected: False {0} times", maxCounter);
            startTime = DateTime.Now;
            for (int i =0; i < maxCounter; i++) {
                result = (new[] { value01, value05, value07 }).Contains(valueToCompare);
            }
            resultTime = DateTime.Now - startTime;
            Console.WriteLine(resultTime);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}