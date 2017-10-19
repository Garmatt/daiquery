namespace DaiQuery
{
    internal class SelectStatementRenderer<ISS> : Renderer<ISS>
        where ISS : ISelectStatement
    {
        internal SelectStatementRenderer(ISS selectStatement)
            : base(selectStatement)
        { }

        private string RenderClausePlain(IClause clause)
        {
            return clause != null && !clause.IsEmpty ? clause.RenderPlain() : string.Empty;
        }

        private string RenderClausePretty(IClause clause, int indentation)
        {
            return clause != null && !clause.IsEmpty ? clause.RenderPretty(indentation) : string.Empty;
        }

        public override string RenderPlain()
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, 
                RenderClausePlain(Renderable.SelectClause),
                RenderClausePlain(Renderable.FromClause),
                RenderClausePlain(Renderable.WhereClause))
                + Strings.Symbols.Semicolon;
        }

        public override string RenderPretty(int indentation)
        {
            return JoinStrings(Strings.Symbols.CarriageReturn,
                RenderClausePretty(Renderable.SelectClause, indentation),
                RenderClausePretty(Renderable.FromClause, indentation),
                RenderClausePretty(Renderable.WhereClause, indentation))
                + Strings.Symbols.Semicolon;
        }
    }
}
