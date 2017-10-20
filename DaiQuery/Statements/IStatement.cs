using System.Collections.Generic;

namespace DaiQuery
{
    internal interface IStatement : IRenderableEntity
    {
        List<IClause> StatementStructure { get; }
    }
}
