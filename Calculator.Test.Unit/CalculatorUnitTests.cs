using System;
using Calculator;
using NUnit.Framework;


namespace Calculator.Test.Unit
{
    [TestFixture]
    [Author("Troels Jensen")]
    public class CalculatorUnitTests
    {
        private Calculator _uut;

        // Using the SetUp feature, saves coding (part of) the Arrange step
        [SetUp]
        public void Setup()
        {
            _uut = new Calculator();
        }

        // A single test case, with fixed input and expected output
        [Test]
        public void Add_Add2And3_ResultIs5()
        {
            // Act
            var result = _uut.Add(2, 3);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        // The TestCase feature allows reusing test code for diffent input and expected output
        [TestCase(3, 2, 5)]
        [TestCase(-3, -2, -5)]
        [TestCase(-3, 2, -1)]
        [TestCase(3, -2, 1)]
        [TestCase(3, 0, 3)]
        public void Add_AddPosAndNegNumbers_ResultIsCorrect(int a, int b, int result)
        {
            // Combining the Act and Assert steps is also possible
            Assert.That(_uut.Add(a, b), Is.EqualTo(result));
        }


        [TestCase(3, 2, 1)]
        [TestCase(-3, -2, -1)]
        [TestCase(-3, 2, -5)]
        public void Subtract_SubtractPosAndNegNumbers_ResultIsCorrect(int a, int b, int result)
        {
            Assert.That(_uut.Subtract(a, b), Is.EqualTo(result));
        }


        [TestCase(3, 2, 6)]
        [TestCase(-3, -2, 6)]
        [TestCase(-3, 2, -6)]
        [TestCase(3, -2, -6)]
        [TestCase(0, -2, 0)]
        [TestCase(-2, 0, 0)]
        [TestCase(0, 0, 0)]
        public void Multiply_MultiplyNunmbers_ResultIsCorrect(int a, int b, int result)
        {
            Assert.That(_uut.Multiply(a, b), Is.EqualTo(result));
        }


        [TestCase(2, 3, 8)]
        [TestCase(2, -3, 0.125)]
        [TestCase(-2, -3, -0.125)]
        [TestCase(1, 10, 1)]
        [TestCase(1, -10, 1)]
        [TestCase(10, 0, 1)]
        [TestCase(4, 0.5, 2.0)]
		[TestCase(9, 0.5, 3.0)]
        public void Power_RaiseNumbers_ResultIsCorrect(double x, double exp, double result)
        {
            Assert.That(_uut.Power(x, exp), Is.EqualTo(result));
        }

        // For floating point results, exact equal comparison can be tricky
        // Use EqualTo modifier Within
        [Test]
        public void Power_SquareRootHalf_ResultIsWithinPrecision()
        {
            // Raising a number to 1/2 is the same as taking the square root
            double result = _uut.Power(0.5, 0.5);

            Assert.That(result, Is.EqualTo(0.707107).Within(0.0000005));
        }

        [TestCase (5,2,3)]
        public void AccumulateSubtract_SubtractNumbers_ResultIsCorrect(double y, double x, double result)
        {
            _uut.Add(y);
            Assert.That(_uut.Subtract(x), Is.EqualTo(result).Within(0.0005));
        }
    }
}
