using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal interface IComparisonPredicate : IPredicateInternal
    {
        eComparisonOperator Operator { get; }
        IExpression LeftMember { get; }
        IExpression RightMember { get; }
    }
}
