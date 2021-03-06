﻿using System;
using System.Security.Cryptography.X509Certificates;
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

        // The TestCase feature allows reusing test code for different input and expected output
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
        [TestCase(5, 6, -1)]
        [TestCase(12.508, 11.35, 1.158)]
        [TestCase(10, -2, 12)]
        [TestCase(-1, -2, 1)]
        public void AccumulateSubtract_SubtractNumbers_ResultIsCorrect(double y, double x, double result)
        {
            _uut.Add(y);
            Assert.That(_uut.Subtract(x), Is.EqualTo(result).Within(0.0005));
        }

        [TestCase(5, 2, 7)]
        [TestCase(5, 6, 11)]
        [TestCase(12.508, 11.350, 23.858)]
        [TestCase(10, -2, 8)]
        [TestCase(-1, -2, -3)]
        public void AccumulateAdd_AddNumbers_ResultIsCorrect(double y, double x, double result)
        {
            _uut.Add(y);
            Assert.That(_uut.Add(x), Is.EqualTo(result).Within(0.0005));
        }

        [TestCase(5, 2, 10)]
        [TestCase(5, 6, 30)]
        [TestCase(12.508, 11.350, 141.9658)]
        [TestCase(10, -2, -20)]
        [TestCase(-1, -2, 2)]
        public void AccumulateMultiply_MultiplyNumbers_ResultIsCorrect(double y, double x, double result)
        {
            _uut.Add(y);
            Assert.That(_uut.Multiply(x), Is.EqualTo(result).Within(0.0005));
        }

        [Test]
        public void Clear_AccumulatorIsZero_isTrue()
        {
            _uut.clear();
            Assert.AreEqual(_uut.Accumulator, 0);
        }

        [TestCase (3, 3, 27)]
        [TestCase (5, 2, 25)]
        [TestCase (5, -1, 0.2)]
        public void AccumulatePower_RaisingAccumulatorToNumber_ResultIsCorrect(double x, double y, double result)
        {
            _uut.clear();
            _uut.Add(x);

            double CalcResult = _uut.Power(y);

            Assert.That(CalcResult, Is.EqualTo(result).Within(0.000005));
        }

        [TestCase(10, 5, 2)]
        [TestCase(5,2,2.5)]
        [TestCase(9.6,3,3.2)]
        [TestCase(-20,5,-4)]
        [TestCase(-8,-2,4)]
        [TestCase(50,-5,-10)]

    

        public void DivideNumbers_ResultIsCorrect(double dividend, double divisor, double result)
        {
            Assert.That(_uut.Divide(dividend,divisor), Is.EqualTo(result).Within(0.00005));
        }
        [Test]
        public void DivideNumber_ExceptionIsExpected()
        {
          
            Assert.That(()=>_uut.Divide(3,0), Throws.TypeOf<DivideByZeroException>());

     
        }

        [TestCase(9, 3, 3)]
        [TestCase(5, 2, 2.5)]
        [TestCase(9.6, 3, 3.2)]
        [TestCase(-20, 5, -4)]
        [TestCase(-8, -2, 4)]
        [TestCase(50, -5, -10)]


        public void AccumulateDivide_Dividing_ResultIsCorrect(double x, double y, double result)
        {
            _uut.Add(x);
            Assert.That(_uut.Divide(y), Is.EqualTo(result).Within(0.00005));
        }

        [Test]
        public void AccumulateDivide_ExceptionIsExpected()
        {

            _uut.Add(8);
            Assert.That(()=>_uut.Divide(0), Throws.TypeOf<DivideByZeroException>());
        }
    }
}
