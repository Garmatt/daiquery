using System.Collections.Generic;

namespace DaiQuery
{
    internal interface ICompoundPredicate : IPredicate
    {
        LogicalConnective LogicalConnective { get; }
        IEnumerable<IPredicate> Predicates { get; }
    }
}
