/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/14/2013
 * Time: 12:55 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testCastleAop
{
    using System;
    using Castle.DynamicProxy;
    // using Snap.Interfaces;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            //helper
            
            var proxyGenerator = new ProxyGenerator();
            var bizTarget = new BizClass();
            BizClass biz = (BizClass)proxyGenerator
                .CreateClassProxyWithTarget(
                    typeof(BizClass),
                    bizTarget,
                    new MyFirstAspect());
//                .CreateClassProxy<BizClass>(
//                    new MyFirstAspect());
            // TODO: Implement Functionality Here
            // var biz = new BizClass();
            biz.Do();
            
            Console.WriteLine(biz.GetType().Name);
            
            BizClass.StaticProperty = true;
            Console.WriteLine(BizClass.StaticProperty);
            
            BizClass.OutLine("test line");
            
            Console.WriteLine("internal static property = {0}", BizClass.StaticProperty);
            BizClass.StaticProperty = false;
            Console.WriteLine("internal static property = {0}", BizClass.StaticProperty);
            
            biz.MyMethod();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}