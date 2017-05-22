namespace testCastleCoreWithAttributes
{
    using System;
    using System.Diagnostics;
    using Castle.DynamicProxy;
    using Castle.DynamicProxy.Generators;

    public class ProxyFactory
    {
        private static ProxyGenerator Generator = new ProxyGenerator();

        public static T Get<T>(T objectToBeProxified)
        {
            // return Generator.CreateClassProxy<T>()

            // Get the attribute constructor.
            Type[] ctorTypes = Type.EmptyTypes;
            var ctor = typeof(MyAttrAttribute).GetConstructor(types: ctorTypes);
            Debug.Assert(condition: ctor != null, message: "Could not get constructor for attribute.");

            // Create an attribute builder.
            object[] attributeArguments = new object[] { };
            var builder = new System.Reflection.Emit.CustomAttributeBuilder(con: ctor, constructorArgs: attributeArguments);

            // Create the proxy generation options.
            // This is how we tell Castle.DynamicProxy how to create the attribute.
            var proxyOptions = new Castle.DynamicProxy.ProxyGenerationOptions();
            // proxyOptions.AdditionalAttributes.Add(builder);
            proxyOptions.AdditionalAttributes.Add(new CustomAttributeInfo(ctor, attributeArguments));

            // Create the proxy generator.
            var proxyGenerator = new Castle.DynamicProxy.ProxyGenerator();

            // Create the class proxy.
            var classArguments = new object[] { };
            return (T)proxyGenerator.CreateClassProxy(classToProxy: typeof(T), options: proxyOptions, constructorArguments: classArguments);
        }
    }
}