namespace DaiQuery
{
    internal class SelectStatementRenderer<ISS> : Renderer<ISS>
        where ISS : ISelectStatement
    {
        internal SelectStatementRenderer(ISS selectStatement)
            : base(selectStatement)
        { }

        private string RenderClauseFlat(IClause clause)
        {
            return clause != null && !clause.IsEmpty ? clause.RenderInline() : string.Empty;
        }

        private string RenderClauseIndented(IClause clause, int indentation)
        {
            return clause != null && !clause.IsEmpty ? clause.RenderIndented(indentation) : string.Empty;
        }

        public override string RenderInline()
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, 
                RenderClauseFlat(Renderable.SelectClause),
                RenderClauseFlat(Renderable.FromClause),
                RenderClauseFlat(Renderable.WhereClause))
                + Strings.Symbols.Semicolon;
        }

        public override string RenderIndented(int indentation)
        {
            return JoinStrings(Strings.Symbols.CarriageReturn,
                RenderClauseIndented(Renderable.SelectClause, indentation),
                RenderClauseIndented(Renderable.FromClause, indentation),
                RenderClauseIndented(Renderable.WhereClause, indentation))
                + Strings.Symbols.Semicolon;
        }
    }
}
