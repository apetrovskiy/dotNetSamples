namespace testCastleCoreWithAttributes
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Castle.Core.Internal;

    class Program
    {
        static void Main(string[] args)
        {
            var myTypeObj = ProxyFactory.Get(new Type001{ BoolData = true, IntData = 3, StrData = "aaa" });

            var properties = myTypeObj.GetType().GetProperties();
            properties.ToList().ForEach(prop =>
            {
                Console.WriteLine(prop.Name + " = " + prop.GetValue(myTypeObj));
                Console.WriteLine(prop.GetAttributes<MyPropertyAttribute>().Count());
                Console.WriteLine(prop.GetCustomAttributes<MyPropertyAttribute>().Count());
            });

            myTypeObj.GetType().GetCustomAttributes().ToList().ForEach(attr => Console.WriteLine(attr.TypeId));
            Console.WriteLine(myTypeObj.GetType().GetAttributes<MyClassAttribute>().Count());

            int i = 1;
        }
    }
}
