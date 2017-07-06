using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal class ColumnRenderer<IC> : ExpressionRenderer<IC>
        where IC : IColumn
    {
        internal ColumnRenderer(IC column)
            : base(column)
        { }

        protected internal override string RenderFlatRegardlessOfInversed()
        {
            string identifier = Renderable.Identifier;
            if (string.IsNullOrWhiteSpace(identifier))
                throw new Exception();

            StringBuilder sb = new StringBuilder();
            if (Renderable.Parent != null)
                sb.Append(Renderable.Parent.RenderInline()).Append(Strings.Symbols.Period);

            sb.Append(Strings.Symbols.OpenDelimiter).Append(identifier).Append(Strings.Symbols.ClosedDelimiter);
            return sb.ToString();
        }
    }
}
