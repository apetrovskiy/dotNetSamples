/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 2/18/2014
 * Time: 1:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testUsageOfLoadFrom
{
    using System;
    using System.Reflection;
    using Ninject;
    using Ninject.Parameters;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            Assembly externalAssembly = Assembly.LoadFrom(@"C:\Projects\probe\testUsageOFLoadFrom\lib\bin\Debug\lib.dll");
            
            Type neededType = null;
            foreach (Assembly assm in System.AppDomain.CurrentDomain.GetAssemblies()) {
                Console.WriteLine(assm.FullName);
                if ("lib" == assm.FullName.Substring(0, 3)) {
                    foreach (Type t in assm.GetTypes()) {
                        Console.WriteLine(t.Name);
                        neededType = t;
                    }
                }
            }
            
            string typeName = neededType.Name;
            var kernel = new StandardKernel(new ObjectModule());
            
            // Type mt = System.Type.GetType("MyClass");
            // Type t = System.Type.GetType("MyClass");
            // object myClassObject = kernel.Get(System.Type.GetType("MyClass"), new IParameter[] {});
            // object myClassObject = kernel.Get(System.Type.GetType("lib.lib.MyClass"), new IParameter[] {});
            // object myClassObject = kernel.Get<typeof(t)>(new IParameter[] {});
            
            // Console.WriteLine(myClassObject.GetType().Name);
            var myClassObject = kernel.Get(neededType);
            
            // Console.WriteLine(myClassObject.GetNumber().ToString());
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}