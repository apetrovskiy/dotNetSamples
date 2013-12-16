/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/14/2013
 * Time: 12:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testCastleAop
{
    using System;
    
    /// <summary>
    /// Description of BizClass.
    /// </summary>
    public class BizClass
    {
        public virtual void Do()
        {
            Console.WriteLine("Do");
        }
        
        public static bool StaticProperty { get; set; }
        public static void OutLine(string line)
        {
            Console.WriteLine(line);
        }
        
        // internal static MyStaticClass myVar;
        
        public bool MyBool
        {
            get { return MyStaticClass.StaticProperty; }
            set { MyStaticClass.StaticProperty = value; }
        }
        
        public void MyMethod()
        {
            MyStaticClass.RunStaticMethod();
        }
    }
}
