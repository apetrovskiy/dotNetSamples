/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/02/2015
 * Time: 05:14 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Description of MyClass.
    /// </summary>
    [Serializable]
    public class Something : ISomething
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}