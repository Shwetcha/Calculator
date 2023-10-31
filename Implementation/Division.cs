using System;

namespace Calculator.Implementation
{
    internal class Division : Interface.IOperation
    {
        public string Symbol { get; }
        public int Priority { get; }

        public Division(string symbol, int precedence)
        {
            Symbol = symbol;
            Priority = precedence;
        }

        public double PerformOperation(double leftOperand, double rightOperand)
        {
            if (rightOperand == 0)
                throw new ArithmeticException("Cannot divide by zero");
            return leftOperand / rightOperand;
        }
    }
}
