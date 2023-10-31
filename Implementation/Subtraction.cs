namespace Calculator.Implementation
{
    internal class Subtraction : Interface.IOperation
    {
        public string Symbol { get; }
        public int Priority { get; }

        public Subtraction(string symbol, int precedence)
        {
            Symbol = symbol;
            Priority = precedence;
        }

        public double PerformOperation(double leftOperand, double rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }
}
