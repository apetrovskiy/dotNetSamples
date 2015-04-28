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
    using System.Linq;
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
                ArrayIntData = new int[] { 1, 2, 3 },
                ArrayObjectData = new object[] { new DateTime(1990, 1, 1), 100, "1000", new Random() },
                ArrayStringData = new string[] { "aaa", "bbb", "ccc" },
                IntData = 4,
                ListIntData = new List<int> { 5, 6, 7 },
                ListObjectData = new List<object> { new DateTime(1995, 2, 2), 200, "2000", new Random(3) },
                ListStringData = new List<string> { "ddd", "eee", "fff" },
                StringData = "ggg",
                // QueueIntData = new Queue<int>(),
                // QueueObjectData = new Queue<object>(),
                // QueueStringData = new Queue<string>()
            };
//            outputData.QueueIntData.Enqueue(8);
//            outputData.QueueIntData.Enqueue(9);
//            outputData.QueueIntData.Enqueue(10);
//            outputData.QueueObjectData.Enqueue(new DateTime(2000, 3, 3));
//            outputData.QueueObjectData.Enqueue(300);
//            outputData.QueueObjectData.Enqueue("3000");
//            outputData.QueueObjectData.Enqueue(new Random(5));
//            outputData.QueueStringData.Enqueue("ggg");
//            outputData.QueueStringData.Enqueue("hhh");
//            outputData.QueueStringData.Enqueue("iii");
            
            try {
                var postingResponse = restTemplate.PostForMessage<DataExchange>(Constants.OutputDataUrl, outputData);
                Console.WriteLine(postingResponse.StatusCode);
            }
            catch (Exception eOoutputDataException) {
                Console.WriteLine(eOoutputDataException.Message);
            }
            
            try {
                var gettingResponse = restTemplate.GetForMessage<DataExchange>(Constants.InputDataUrl);
                Console.WriteLine(gettingResponse.StatusCode);
                gettingResponse.Body.PrintOut();
//                Console.WriteLine(gettingResponse.Body.IntData);
//                Console.WriteLine(gettingResponse.Body.StringData);
//                gettingResponse.Body.ArrayIntData.ToList().ForEach(Console.WriteLine);
//                gettingResponse.Body.ArrayObjectData.ToList().ForEach(Console.WriteLine);
//                gettingResponse.Body.ArrayStringData.ToList().ForEach(Console.WriteLine);
//                gettingResponse.Body.ListIntData.ForEach(Console.WriteLine);
//                gettingResponse.Body.ListObjectData.ForEach(Console.WriteLine);
//                gettingResponse.Body.ListStringData.ForEach(Console.WriteLine);
////                Console.WriteLine(gettingResponse.Body.QueueIntData.Dequeue());
////                Console.WriteLine(gettingResponse.Body.QueueIntData.Dequeue());
////                Console.WriteLine(gettingResponse.Body.QueueIntData.Dequeue());
////                Console.WriteLine(gettingResponse.Body.QueueObjectData.Dequeue());
////                Console.WriteLine(gettingResponse.Body.QueueObjectData.Dequeue());
////                Console.WriteLine(gettingResponse.Body.QueueObjectData.Dequeue());
////                Console.WriteLine(gettingResponse.Body.QueueObjectData.Dequeue());
////                Console.WriteLine(gettingResponse.Body.QueueStringData.Dequeue());
////                Console.WriteLine(gettingResponse.Body.QueueStringData.Dequeue());
////                Console.WriteLine(gettingResponse.Body.QueueStringData.Dequeue());
            }
            catch (Exception eInputDataException) {
                Console.WriteLine(eInputDataException.Message);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}