namespace testCastleCoreWithAttributes
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Castle.Core.Internal;

    class Program
    {
        static void Main(string[] args)
        {
            var myTypeObj = ProxyFactory.Get<Type001>(new Type001());

            var properties = myTypeObj.GetType().GetProperties();
            properties.ToList().ForEach(prop =>
            {
                Console.WriteLine(prop.GetAttributes<MyAttrAttribute>().Count());
            });


            int i = 1;
        }
    }
}
