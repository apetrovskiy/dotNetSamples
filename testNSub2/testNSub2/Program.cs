using NUnit.Framework.Constraints;
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
                Console.WriteLine("test aaaa");
                logger.Received().LogError("aaaa");
                
                Console.WriteLine("test cccc");
                Assert.That(logger.LogError2("cccc"), Is.EqualTo("cccc+"));
                
                Console.WriteLine("test dddd");
                Assert.AreEqual("dddd+", logger.LogError2("dddd"));
                
                Console.WriteLine("test eeee");
                logger.Received().LogError2("eeee");
                logger.DidNotReceive().LogError2("ffff");
                
                logger.LogError2("ffff");
            }
            catch (Exception eeee2) {
                Console.WriteLine(eeee2.Message);
            }
            
            ICommand command = null;
            SomethingThatNeedsACommand something = null;
            CommandRepeater repeater = null;
            
            try {
                //[Test]
                //public void Should_execute_command() {
                    //Arrange
                    //var 
                    command = Substitute.For<ICommand>();
                    //var 
                    something = new SomethingThatNeedsACommand(command);
                    //Act
                    something.DoSomething();
                    //Assert
                    command.Received().Execute();
                    // there are call(s) in fact command.DidNotReceive().Execute();
                //}
            }
            catch (Exception example01) {
                Console.WriteLine(example01.Message);
            }
            try {
                //var 
                command = Substitute.For<ICommand>();
                //var 
                something = new SomethingThatNeedsACommand(command);
                //Act
                something.DontDoAnything();
                //Assert
                command.DidNotReceive().Execute();
                // no calls in fact command.Received().Execute();
            }
            catch (Exception example02) {
                Console.WriteLine(example02.Message);
            }
            
            try {
            //[Test]
            //public void Should_execute_command_the_number_of_times_specified() {
              //var 
              command = Substitute.For<ICommand>();
              //var 
              repeater = new CommandRepeater(command, 3); // only 3 would work
              //Act
              repeater.Execute();
              //Assert
              command.Received(3).Execute(); // << This will fail if 2 or 4 calls were received
            //}
            }
            catch (Exception example03) {
                Console.WriteLine(example03.Message);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}