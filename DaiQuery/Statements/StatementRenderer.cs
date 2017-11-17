using System;
using System.Linq;

namespace DaiQuery
{
    internal class StatementRenderer<IS> : Renderer<IS>
        where IS : IStatement
    {
        internal StatementRenderer(IS statement)
            : base(statement)
        { }

        private string RenderClausePlain(IClause clause)
        {
            return clause != null && !clause.IsEmpty ? clause.RenderPlain() : string.Empty;
        }

        private string RenderClausePretty(IClause clause, int indentation)
        {
            return clause != null && !clause.IsEmpty ? clause.RenderPretty(indentation) : string.Empty;
        }

        private string RenderStatement(string separator, Func<IClause, string> renderClause)
        {
            string renderedStatement = JoinStrings(separator, Renderable.StatementStructure.Select(renderClause));
            if (!string.IsNullOrWhiteSpace(renderedStatement))
                renderedStatement = renderedStatement + Strings.Symbols.Semicolon;

            return renderedStatement;
        }

        public override string RenderPlain()
        {
            return RenderStatement(Strings.Symbols.WhiteSpace, RenderClausePlain);
        }

        public override string RenderPretty(int indentation)
        {
            return RenderStatement(Strings.Symbols.CarriageReturn, clause => RenderClausePretty(clause, indentation));
        }
    }
}
