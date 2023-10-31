namespace Calculator.Implementation
{
    internal class Multiplication : Interface.IOperation
    {
        public string Symbol { get; }
        public int Priority { get; }

        public Multiplication(string symbol, int precedence)
        {
            Symbol = symbol;
            Priority = precedence;
        }

        public double PerformOperation(double leftOperand, double rightOperand)
        {
            return leftOperand * rightOperand; 
        }
    }
}
