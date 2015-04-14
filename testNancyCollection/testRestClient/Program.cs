/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 14/04/2015
 * Time: 08:09 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testRestClient
{
    using System;
    using System.Collections.Generic;
    using Spring.Http.Converters.Json;
    using Spring.Rest.Client;
    using test.Interfaces;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var restTemplate = new RestTemplate(Constants.BaseUrl);
            restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            var outputData = new DataExchange {
                // ArrayIntData = new int[] { 1, 2, 3 },
                // ArrayObjectData = new object[] { new 
                // ArrayStringData = new string[] { "aaa", "bbb", "ccc" },
                IntData = 4,
                // ListIntData = new List<int> { 5, 6, 7 },
                // ListObjectData
                // ListStringData = new List<string> { "ddd", "eee", "fff" },
                StringData = "ggg"
            };
            
            try {
                restTemplate.PostForMessage<DataExchange>(Constants.OutputDataUrl, outputData);
            }
            catch (Exception eOoutputDataException) {
                Console.WriteLine(eOoutputDataException.Message);
            }
            
            try {
                var inputData = restTemplate.GetForMessage<DataExchange>(Constants.InputDataUrl);
            }
            catch (Exception eInputDataException) {
                Console.WriteLine(eInputDataException.Message);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}