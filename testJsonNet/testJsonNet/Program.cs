/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/7/2014
 * Time: 10:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testJsonNet
{
    using System;
    using Newtonsoft.Json;
	using testInterfaces;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var testResult = new TestResult { Name = "test result ...", Id = "111", TestScenarioId = "222", TestSuiteId = "333" };
            Console.WriteLine(JsonConvert.SerializeObject(testResult));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}