using Calculator.Implementation;
using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public static class TextCalculator
    {
        private static List<IOperation> operators;

        static TextCalculator()
        {
            operators = new List<IOperation>
        {
            new Addition("+", 1),
            new Subtraction("-", 1),
            new Multiplication("*", 2),
            new Division("/", 2)
        };
        }

        public static double Evaluate(string input)
        {
            try
            {
                string[] resSplitExpression = input.Split(' ');

                if (resSplitExpression.Length >= 3 || resSplitExpression.Length % 2 != 0)
                {
                    //Rearrange expression as per operand's sequence and operator priority
                    var rearrangedExpression = RearrangeExpression(resSplitExpression);

                    var stack = new Stack<double>();

                    foreach (var token in rearrangedExpression)
                    {
                        if (double.TryParse(token, out double operand))
                        {
                            stack.Push(operand);
                        }
                        else if (IsOperator(token))
                        {
                            if (stack.Count < 2)
                                throw new ArgumentException("Not enough operands for operator: " + token);

                            double rightOperand = stack.Pop();
                            double leftOperand = stack.Pop();
                            double result = CallPerformOperation(token, leftOperand, rightOperand);
                            stack.Push(result);
                        }
                        else
                        {
                            throw new ArgumentException("Invalid token: " + token);
                        }
                    }

                    if (stack.Count != 1)
                        throw new ArgumentException("Invalid expression format.");

                    return stack.Pop(); // return final result

                }
                else
                {
                    throw new ArgumentException("Invalid expression");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error evaluating the expression: " + ex.Message);
            }
        }

        private static bool IsOperator(string symbol)
        {
            return operators.Any(op => op.Symbol == symbol);
        }

        private static double CallPerformOperation(string symbol, double leftOperand, double rightOperand)
        {
            var op = operators.First(x => x.Symbol == symbol);
            return op.PerformOperation(leftOperand, rightOperand);
        }

        private static List<string> RearrangeExpression(string[] parts)
        {
            var output = new List<string>();
            var expressionStack = new Stack<string>();

            foreach (var part in parts)
            {
                if (double.TryParse(part, out _))
                {
                    output.Add(part);
                }
                else if (IsOperator(part))
                {
                    //if current operator has lower priority than last operator in stack 
                    while (expressionStack.Count > 0 && CheckOperatorPriority(part) <= CheckOperatorPriority(expressionStack.Peek()) && IsOperator(expressionStack.Peek()))
                    {
                        output.Add(expressionStack.Pop());
                    }
                    expressionStack.Push(part);
                }
            }

            while (expressionStack.Count > 0)
            {
                output.Add(expressionStack.Pop());
            }

            return output;
        }

        private static int CheckOperatorPriority(string symbol)
        {
            return operators.First(op => op.Symbol == symbol).Priority;
        }
    }
}
