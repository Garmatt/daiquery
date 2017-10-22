using System;
using System.Text;

namespace DaiQuery
{
    internal class IdentifiedEntityRenderer<II> : Renderer<II>
        where II : IIdentifiedEntity
    {
        internal IdentifiedEntityRenderer(II identified)
            : base(identified)
        { }

        public override string RenderPlain()
        {
            string identifier = Renderable.Identifier;
            if (string.IsNullOrWhiteSpace(identifier))
                throw new Exception(); //to do

            StringBuilder sb = new StringBuilder();
            if (Renderable.Parent != null)
                sb.Append(Renderable.Parent.RenderPlain()).Append(Strings.Symbols.Period);

            sb.Append(Strings.Symbols.OpenDelimiter).Append(identifier).Append(Strings.Symbols.ClosedDelimiter);
            return sb.ToString();
        }

        public override string RenderPretty(int indentation)
        {
            return GetTabs(indentation) + RenderPlain();
        }
    }
}
