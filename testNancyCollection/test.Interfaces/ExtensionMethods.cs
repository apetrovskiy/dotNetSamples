/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 15/04/2015
 * Time: 04:04 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace test.Interfaces
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Description of ExtensionMethods.
    /// </summary>
    public static class ExtensionMethods
    {
        public static void PrintOut(this IDataExchange dataExchangeObject)
        {
            Console.WriteLine(dataExchangeObject.IntData);
            Console.WriteLine(dataExchangeObject.StringData);
            dataExchangeObject.ArrayIntData.ToList().ForEach(Console.WriteLine);
            dataExchangeObject.ArrayObjectData.ToList().ForEach(Console.WriteLine);
            dataExchangeObject.ArrayStringData.ToList().ForEach(Console.WriteLine);
            dataExchangeObject.ListIntData.ForEach(Console.WriteLine);
            dataExchangeObject.ListObjectData.ForEach(Console.WriteLine);
            dataExchangeObject.ListStringData.ForEach(Console.WriteLine);
//                Console.WriteLine(dataExchangeObject.QueueIntData.Dequeue());
//                Console.WriteLine(dataExchangeObject.QueueIntData.Dequeue());
//                Console.WriteLine(dataExchangeObject.QueueIntData.Dequeue());
//                Console.WriteLine(dataExchangeObject.QueueObjectData.Dequeue());
//                Console.WriteLine(dataExchangeObject.QueueObjectData.Dequeue());
//                Console.WriteLine(dataExchangeObject.QueueObjectData.Dequeue());
//                Console.WriteLine(dataExchangeObject.QueueObjectData.Dequeue());
//                Console.WriteLine(dataExchangeObject.QueueStringData.Dequeue());
//                Console.WriteLine(dataExchangeObject.QueueStringData.Dequeue());
//                Console.WriteLine(dataExchangeObject.QueueStringData.Dequeue());
        }
    }
}
