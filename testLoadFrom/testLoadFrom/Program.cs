/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/29/2013
 * Time: 12:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testLoadFrom
{
    using System;
    using System.Reflection;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            try {
//                Assembly.LoadFile(@"C:\Projects\PS\STUPS\binaries\selenium-dotnet\net35\Selenium.WebDriverBackedSelenium.dll");
//                Assembly.LoadFile(@"C:\Projects\PS\STUPS\binaries\selenium-dotnet\net35\WebDriver.Support.dll");
//                Assembly.LoadFile(@"C:\Projects\PS\STUPS\binaries\selenium-dotnet\net35\ThoughtWorks.Selenium.Core.dll");
                // Assembly assm = Assembly.LoadFile(@"C:\Projects\PS\STUPS\binaries\selenium-dotnet\net35\WebDriver.dll");
                Assembly.LoadFile(@"C:\Projects\PS\STUPS\binaries\NSubstitute-1.5.0.0\lib\NET35\NSubstitute.dll");
//                Assembly assm = Assembly.LoadFrom(@"C:\Projects\PS\STUPS\binaries\selenium-dotnet\net35\WebDriver.dll");
//                // var mock = Activator.CreateInstanceFrom(System.AppDomain.CurrentDomain, @"C:\Projects\PS\STUPS\binaries\Moq\NET35\Moq.dll", "Moq.Mock");
//                // var mock = Activator.CreateInstanceFrom(@"C:\Projects\PS\STUPS\binaries\Moq\NET35\Moq.dll", "Moq.Mock");
//                // var mock = Activator.CreateInstance(Type.GetType("Moq.Mock"), new objet[] { Type.GetType("Moq.Mock") });
//                // Type t = Type.GetType("OpenQA.Selenium.Firefox.FirefoxDriver");
//                Type t = Type.GetType("FirefoxDriver");
//                Type[] types = assm.GetTypes();
//                Console.WriteLine(assm.FullName);
//                foreach (Type typeItem in types) {
//                    Console.WriteLine(typeItem.Name);
//                    if ("FirefoxDriver" == typeItem.Name) {
//                        t = typeItem;
//                    }
//                }
                // Type t = Type.GetType("Mock<T>");
//                var mock = Activator.CreateInstance(Type.GetType("Mock"), new object[] { Type.GetType("Mock") });
//                object driver = Activator.CreateInstanceFrom(@"C:\Projects\PS\STUPS\binaries\selenium-dotnet\net35\WebDriver.dll", "WebElement");
                // object nsub = Activator.CreateInstanceFrom(@"C:\Projects\PS\STUPS\binaries\NSubstitute-1.5.0.0\lib\NET35\NSubstitute.dll", "ArrayContentsArgumentMatcher");
                object nsub = Activator.CreateInstance(@"NSubstitute", "ArrayContentsArgumentMatcher");
            }
            catch (Exception eTest) {
                Console.WriteLine(eTest.Message);
            }
            
//            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}