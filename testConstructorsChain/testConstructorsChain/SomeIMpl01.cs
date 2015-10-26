/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 13/08/2015
 * Time: 09:16 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testConstructorsChain
{
    using System;
    
    /// <summary>
    /// Description of SomeIMpl01.
    /// </summary>
    public class SomeImpl01 : ISome
    {
        public SomeImpl01()
        {
            Console.WriteLine("Constructor in the parent class");
        }
        
        public string Prop01 { get; set; }
        public bool Prop02 { get; set; }
        public int Prop03 { get; set; }
    }
}
