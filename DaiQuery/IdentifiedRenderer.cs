using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal class IdentifiedRenderer<II> : Renderer<II>
        where II : IIdentified
    {
        internal IdentifiedRenderer(II identified)
            : base(identified)
        { }

        public override string RenderInline()
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

        public override string RenderIndented(int indentation)
        {
            return GetTabs(indentation) + RenderInline();
        }
    }
}
