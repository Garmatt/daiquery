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
            return ((IPredicate)Renderable.Predicate).RenderInline();
        }

        protected override string RenderBodyIndented(int indentation)
        {
            return ((IPredicate)Renderable.Predicate).RenderIndented(indentation);
        }
    }
}
