/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 6/25/2014
 * Time: 4:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Collections.Generic;
using NBehave.Narrator.Framework;
using NBehave.Spec.NUnit;

// namespace NBehave.Examples.Calculator_table.Steps
namespace testLib
{
    [ActionSteps]
    public class AddNumbers
    {
        private Calculator _calculator;

        [BeforeScenario]
        public void SetUp_scenario()
        {
            _calculator = new Calculator();
        }

        [Given(@"I have entered $number into the calculator")]
        public void Enter_number(int number)
        {
            _calculator.Enter(number);
        }

        [When(@"I add the numbers")]
        public void Add()
        {
            _calculator.Add();
        }

        [Then(@"the sum should be $result")]
        public void Result(int result)
        {
            _calculator.Value().ShouldEqual(result);
        }
    }
    
//    public class Calculator
//    {
//        public void Enter(int number) {}
//        public void Add() {}
//        public int Value() { return 3; }
//    }
    
	public class Calculator
    {
        private readonly Queue<int> _buffer = new Queue<int>();

        public void Enter(int number)
        {
            _buffer.Enqueue(number);
        }

        public void Add()
        {
            _buffer.Enqueue(_buffer.Dequeue() + _buffer.Dequeue());
        }

        public int Value()
        {
            return _buffer.Peek();
        }
    }
}
