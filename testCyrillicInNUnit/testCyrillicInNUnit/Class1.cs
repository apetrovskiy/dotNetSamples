using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace testCyrillicInNUnit
{
    [TestFixture]
    public class testClass
    {

        [SetUp]
        public void Init()
        {
            Console.WriteLine("set up");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("tear down");
        }

        [Test]
        [TestCase("Погода")]
        public void TransferFunds(string weather)
        {
            Console.WriteLine("test 01");
        }

        [Test]
        [TestCase(@"Погода2")]
        public void TransferFunds2(string weather)
        {
            Console.WriteLine("test 02");
        }
    }
}