/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 10/22/2014
 * Time: 3:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testLoadResultAsJson
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Spring.Http.Converters.Json;
    using Spring.Rest.Client;
    using Tmx;
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            // var restTemplate = new RestTemplate(@"http://localhost:12340");
            var restTemplate = new RestTemplate(@"http://192.168.129.21:12340");
            restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            // var result = restTemplate.GetForMessage<TestSuite>(@"http://localhost:12340/api/results");
            // var result = restTemplate.GetForMessage<List<ITestSuite>>(@"http://localhost:12340/api/results");
            // var response = restTemplate.GetForMessage<XDocument>(@"http://localhost:12340/api/results");
            var response = restTemplate.GetForMessage<XDocument>(@"http://192.168.129.21:12340/api/results");
            
            TmxHelper.ImportTestResultsFromXdocument(response.Body);
            foreach (var suite in TestData.TestSuites) {
                Console.WriteLine(suite.Id + " " + suite.Name);
                foreach (var scenario in suite.TestScenarios) {
                    Console.WriteLine(scenario.Id + " " + scenario.Name);
                    foreach (var result in scenario.TestResults) {
                        Console.WriteLine(result.Id + " " + result.Name);
                    }
                }
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}