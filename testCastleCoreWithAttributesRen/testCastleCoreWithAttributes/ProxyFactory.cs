namespace testCastleCoreWithAttributes
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Castle.DynamicProxy;
    using Castle.DynamicProxy.Generators;
    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

    public class ProxyFactory
    {
        private static ProxyGenerator Generator = new ProxyGenerator();

        public static T Get<T>(T objectToBeProxified)
        {
            // Get the attribute constructor.
            Type[] classCtorTypes = Type.EmptyTypes;
            var classAttrCtor = typeof(MyClassAttribute).GetConstructor(types: classCtorTypes);
            Debug.Assert(condition: classAttrCtor != null, message: "Could not get constructor for attribute.");

            // Create an attribute builder.
            object[] classAttrArguments = new object[] { };
            // var builder = new System.Reflection.Emit.CustomAttributeBuilder(con: ctor, constructorArgs: attributeArguments);

            // Create the proxy generation options.
            // This is how we tell Castle.DynamicProxy how to create the attribute.
            var proxyOptions = new ProxyGenerationOptions();
            // proxyOptions.AdditionalAttributes.Add(builder);
            proxyOptions.AdditionalAttributes.Add(new CustomAttributeInfo(classAttrCtor, classAttrArguments));

            objectToBeProxified.GetType().GetProperties().ToList().ForEach(prop =>
            {
                Type[] propCtorTypes = new [] { typeof(string), typeof(string) };
                var propAttrCtor = typeof(MyPropertyAttribute).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, CallingConventions.HasThis, propCtorTypes, null);

                Console.WriteLine(prop.Name);
                Debug.Assert(condition: propAttrCtor != null, message: string.Format("Could not get constructor for attribute. Property name = {0}", prop.Name));
                object[] propAttributeArguments = { "AA", prop.Name };
                // proxyOptions.AdditionalAttributes.Add(new CustomAttributeInfo(propAttrCtor21, propAttributeArguments, new[] { prop }, new [] { prop.GetValue(objectToBeProxified) }));
                // proxyOptions.AdditionalAttributes.Add(new CustomAttributeInfo(propAttrCtor21, propAttributeArguments));
                proxyOptions.AdditionalAttributes.Add(new CustomAttributeInfo(propAttrCtor, propAttributeArguments,
                    new[]
                    {
                        typeof(MyPropertyAttribute).GetProperty("RowPosition"),
                        typeof(MyPropertyAttribute).GetProperty("ColumnHeading")
                    },
                    new object[] { propAttributeArguments[0], propAttributeArguments[1] }));
            });

            // Create the proxy generator.
            var proxyGenerator = new ProxyGenerator();

            // Create the class proxy.
            var classArguments = new object[] { };
            return (T)proxyGenerator.CreateClassProxyWithTarget(classToProxy: typeof(T), options: proxyOptions, constructorArguments: classArguments, additionalInterfacesToProxy: new Type[] { typeof(IInterface01) }, target: objectToBeProxified, interceptors: null);
        }
    }
}