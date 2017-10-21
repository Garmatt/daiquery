using System.Collections.Generic;

namespace DaiQuery
{
    internal interface ISelectClause : IClause
    {
        IEnumerable<KeyValuePair<IExpression, string>> AliasedExpressions { get; }
    }
}
