/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/15/2013
 * Time: 11:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testCastleAop
{
    /// <summary>
    /// Description of MyStaticClass.
    /// </summary>
    public static class MyStaticClass
    {
        static MyStaticClass()
        {
        }
        
        public static void RunStaticMethod()
        {
            Console.WriteLine("static method!!!!!!!!");
        }
        
        public static bool StaticProperty { get; set; }
    }
}
