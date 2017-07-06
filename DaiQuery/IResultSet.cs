using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal interface IResultSet : IRenderableEntity, IClauseBody
    {
        eJoinType JoinType { get; }
        IRenderableEntity LeftMember { get; }
        IRenderableEntity RightMember { get; }
        IPredicate Condition { get; }
    }
}
