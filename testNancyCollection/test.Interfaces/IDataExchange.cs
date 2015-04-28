/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 14/04/2015
 * Time: 08:17 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace test.Interfaces
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of IDataExchange.
    /// </summary>
    public interface IDataExchange
    {
        string StringData { get; set; }
        int IntData { get; set; }
        List<string> ListStringData { get; set; }
        List<int> ListIntData { get; set; }
        List<object> ListObjectData { get; set; }
        string[] ArrayStringData { get; set; }
        int[] ArrayIntData { get; set; }
        object[] ArrayObjectData { get; set; }
        // Queue<string> QueueStringData { get; set; }
        // Queue<int> QueueIntData { get; set; }
        // Queue<object> QueueObjectData { get; set; }
    }
}
