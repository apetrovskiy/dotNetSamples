/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 7/3/2013
 * Time: 8:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */


namespace aun
{
    using System;
    using privMethods;
    using System.Reflection;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            MyClass myClass = new MyClass();
            myClass.PubMethod();
            
            Type myType = typeof(MyClass);
            MethodInfo privMethod = myType.GetMethod("PrivMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            privMethod.Invoke(myClass, null);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}