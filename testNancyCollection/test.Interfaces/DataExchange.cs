/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 14/04/2015
 * Time: 08:20 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace test.Interfaces
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of DataExchange.
    /// </summary>
    public class DataExchange : IDataExchange
    {
        public string StringData { get; set; }
        public int IntData { get; set; }
        public List<string> ListStringData { get; set; }
        public List<int> ListIntData { get; set; }
        public List<object> ListObjectData { get; set; }
        public string[] ArrayStringData { get; set; }
        public int[] ArrayIntData { get; set; }
        public object[] ArrayObjectData { get; set; }
    }
}
