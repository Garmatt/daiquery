using System;
using System.Text;

namespace DaiQuery
{
    /// <summary>
    /// Renders an <see cref="IColumn"/> object into SQL code.
    /// </summary>
    /// <typeparam name="IC"></typeparam>
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
                sb.Append(Renderable.Parent.RenderPlain()).Append(Strings.Symbols.Period);

            sb.Append(Strings.Symbols.OpenDelimiter).Append(identifier).Append(Strings.Symbols.ClosedDelimiter);
            return sb.ToString();
        }
    }
}
