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
