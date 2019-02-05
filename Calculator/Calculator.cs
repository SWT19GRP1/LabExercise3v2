using System;

namespace Calculator
{
    public class Calculator
    {
        public double Add(double a, double b)
        {
            double result = a + b;
            return Accumulator = result;
        }

        public double Subtract(double a, double b)
        {
            double result = a - b;
            return Accumulator = result;
        }

        public double Multiply(double a, double b)
        {
            double result = a * b;
            return Accumulator = result;
        }

        public double Power(double a, double b)
        {
            double result = Math.Pow(a, b);
            return Accumulator = result;
        }

        public double Add(double addend)
        {
            Accumulator += addend;
            return Accumulator;
        }

        public double Subtract(double subtractor)
        {
            Accumulator -= subtractor;
            return Accumulator;
        }

        public double Multiply(double multiplier)
        {
            Accumulator *= multiplier;
            return Accumulator;
        }

        public double Divide(double divisor)
        {
            Accumulator /= divisor;
            return Accumulator;
        }

        public double Power(double exponent)
        {
            Accumulator = Math.Pow(Accumulator, exponent);
            return Accumulator;
        }

        public void clear()
        {
            Accumulator = 0;
        }

        public double Accumulator { get; private set; } = 0;
    }
}
