using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal interface ISelectStatement : IRenderableEntity
    {
        IFromClause FromClause { get; }
        IWhereClause WhereClause { get; }
        ISelectClause SelectClause { get; }
    }
}
