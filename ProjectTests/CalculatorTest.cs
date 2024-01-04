using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectLibrary;

namespace ProjectTests
{
    public class CalculatorTest
    {
        [Test]
        [TestCase(4, 3, 7)]
        [TestCase(21, 5.25, 26.25)]
        [TestCase(double.MaxValue, 5, double.MaxValue)]
        public void Add_Test(double x, double y, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Add(x, y);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(4, 3, 1)]
        [TestCase(21, -5, 26)]
        [TestCase(-21, -5, -16)]
        [TestCase(5, 0 , 0)]
        public void Substract_Test(double x, double y, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Subtract(x, y);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(4, 3, 12)]
        [TestCase(2.5, 4, 10)]
        [TestCase(-3, 5, -15)]
        [TestCase(-10, -4, 40)]
        [TestCase(2.5, 0, 2.5)]
        [TestCase(double.MaxValue, 5, double.MaxValue)]
        public void Multiply_Test(double x, double y, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Multiply(x, y);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(8, 4, 2)]
        [TestCase(2.5, 5, 0.5)]
        [TestCase(-5, 1, -5)]
        [TestCase(-100, -4, -25)]
        [TestCase(5, 0, 0)]
        public void Divide_Test(double x, double y, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Divide(x, y);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

      
    }
}
