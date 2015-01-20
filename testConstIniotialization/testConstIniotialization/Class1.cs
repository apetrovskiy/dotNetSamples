/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 1/20/2015
 * Time: 10:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testConstIniotialization
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public class Class1
    {
        internal readonly string Data01;
        public readonly string Data02;
        
        public Class1()
        {
        }
        
        public string Data03 { get; set; }
        public string Data04 { get; internal set; }
        
    }
}
