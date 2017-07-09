using System.Collections.Generic;

namespace DaiQuery
{
    internal interface ICompoundPredicate : IPredicate
    {
        eLogicalConnective LogicalConnective { get; }
        IEnumerable<IPredicate> Predicates { get; }
    }
}
