using System;

namespace Calculator
{
    public class Calculator
    {
        public double Add(double a, double b)
        {
            _accumulator = a + b;
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            _accumulator = a - b;
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            _accumulator = a * b;
            return a * b;
        }

        public double Power(double a, double b)
        {
            _accumulator = Math.Pow(a, b);
            return Math.Pow(a, b);
        }

        public double Add(double addend)
        {
            _accumulator += addend;
            return _accumulator;
        }

        public double Subtract(double subtractor)
        {
            _accumulator -= subtractor;
            return _accumulator;
        }

        public double Multiply(double multiplier)
        {
            _accumulator *= multiplier;
            return _accumulator;
        }

        public double Divide(double divisor)
        {
            _accumulator /= divisor;
            return _accumulator;
        }

        private int _accumulator;

    }
}
