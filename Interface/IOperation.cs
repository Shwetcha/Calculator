using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interface
{
    public interface IOperation
    {
        string Symbol { get; }
        int Priority { get; }
        double PerformOperation(double leftOperand, double rightOperand);
    }
}
