using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal interface IArithmeticExpression : IExpression
    {
        IExpression FirstOperand { get; }
        IExpression SecondOperand { get; } 
        eArithmeticOperator Operator { get; }
    }
}
