/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 11/15/2013
 * Time: 2:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNSub2
{
    using System;
    using NSubstitute;
    using NUnit.Framework;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            //ICalculator calculator = Substitute.For<ICalculator>();
            //Console.WriteLine(calculator.GetType().Name);
            //Console.WriteLine(calculator.Received().GetType().Name);
            
            //ICalculator calc = new Calculator();
            //Console.WriteLine(calc.Add(1, 2).ToString());
            
            //calculator.//.Add(1, 2); //.Returns(3);
            //Assert.That(calculator.Add(1, 2), Is.EqualTo(3));
            //Console.WriteLine(calculator.Add(1, 2).ToString());
            
            ILogger logger = null;
            try {
                //logger = Substitute.For<ILogger>();
                logger = Substitute.For<FakeLogger>();
            }
            catch (Exception eeee) {
                Console.WriteLine(eeee.Message);
            }
            logger.LogError("aaaa");
            try {
                logger.Received().LogError("aaaa");
                Assert.That(logger.LogError2("cccc"), Is.EqualTo("cccc+"));
            }
            catch (Exception eeee2) {
                Console.WriteLine(eeee2.Message);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}