using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal class FromClauseRenderer<IFC> : ClauseRenderer<IFC>
        where IFC : IFromClause
    {
        internal FromClauseRenderer(IFC fromClause)
            : base(fromClause)
        { }

        protected override string RenderBodyInline()
        {
            return Renderable.source.RenderInline();
        }

        protected override string RenderBodyIndented(int indentation)
        {
            return Renderable.source.RenderIndented(indentation);
        }
    }
}
