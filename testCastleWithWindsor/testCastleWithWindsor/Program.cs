/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 4/8/2014
 * Time: 6:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testCastleWithWindsor
{
    using System;
    using Castle.Windsor;
	using Castle.Windsor.Proxy;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var container = new WindsorContainer();
            container.Kernel.ProxyFactory = new DefaultProxyFactory(disableSignedModule:true);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}