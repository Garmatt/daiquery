using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal class WhereClauseRenderer<IWC> : ClauseRenderer<IWC>
        where IWC : IWhereClause
    {
        internal WhereClauseRenderer(IWC whereClause)
            : base(whereClause)
        { }

        protected override string RenderBodyInline()
        {
            return Renderable.predicate.RenderInline();
        }

        protected override string RenderBodyIndented(int indentation)
        {
            return Renderable.predicate.RenderIndented(indentation);
        }
    }
}
