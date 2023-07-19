using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChangeCalculatorTests
{
    [TestClass]
    public class ChangeCalculatorTests
    {
        [TestMethod]
        public void CalculateChange_Should_Return_Correct_Denominations()
        {
            // Arrange
            ChangeCalculator changeCalculator = new ChangeCalculator("US");
            double price = 10.50;
            List<double> payment = new List<double> { 20.00, 5.00, 1.00 };

            // Act
            Dictionary<double, int> change = changeCalculator.CalculateChange(price, payment);

            // Assert
            Dictionary<double, int> expectedChange = new Dictionary<double, int>
        {
            { 5.00, 1 },
            { 1.00, 2 },
            { 0.25, 2 },
            { 0.10, 2 },
            { 0.05, 1 }
        };

            CollectionAssert.AreEqual(expectedChange, change);
        }

        [TestMethod]
        public void CalculateChange_Should_Throw_Exception_On_Insufficient_Payment()
        {
            // Arrange
            ChangeCalculator changeCalculator = new ChangeCalculator("Mexico");
            double price = 100.00;
            List<double> payment = new List<double> { 50.00 };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => changeCalculator.CalculateChange(price, payment));
        }

        // Add more test methods as needed to cover various scenarios
    }

}
