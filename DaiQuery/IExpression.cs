using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal interface IExpression : IAliasableEntity
    {
        bool IsInversed { get; set; }
        bool ConsiderAsOperand { get; set; }
        string Header { get; }
        IExpression Clone();
    }
}
