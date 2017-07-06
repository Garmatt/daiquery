using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal interface IClause : IRenderableEntity
    {
        eClauseKeyword Keyword { get; }
        bool IsEmpty { get; }
    }
}
