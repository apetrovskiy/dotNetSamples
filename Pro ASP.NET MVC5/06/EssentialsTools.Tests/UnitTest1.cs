namespace EssentialsTools.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;

    [TestClass]
    public class UnitTest1
    {
        IDiscountHelper GetTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            // Arrange
            var target = GetTestObject();
            decimal total = 200;

            // Act
            var discountedTotal = target.ApplyDiscount(total);

            // Assert
            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            // Arrange
            var target = GetTestObject();

            // Act
            var tenDollarDiscount = target.ApplyDiscount(10);
            var hundredDollarDiscount = target.ApplyDiscount(100);
            var fiftyDollarDiscount = target.ApplyDiscount(50);

            // Assert
            Assert.AreEqual(5, tenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(95, hundredDollarDiscount, "$100 discount is wrong");
            Assert.AreEqual(45, fiftyDollarDiscount, "$50 discount is worng");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            // Arrange
            var target = GetTestObject();

            // Act
            var discount5 = target.ApplyDiscount(5);
            var discount0 = target.ApplyDiscount(0);

            // Assert
            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            // Arrange
            var target = GetTestObject();

            // Act
            target.ApplyDiscount(-1);
        }
    }
}
