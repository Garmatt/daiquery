namespace DaiQuery
{
    internal class WhereClauseRenderer<IWC> : ClauseRenderer<IWC>
        where IWC : IWhereClause
    {
        internal WhereClauseRenderer(IWC whereClause)
            : base(whereClause)
        { }

        protected override string RenderBodyPlain()
        {
            return ((IPredicate)Renderable.Predicate).RenderPlain();
        }

        protected override string RenderBodyPretty(int indentation)
        {
            return ((IPredicate)Renderable.Predicate).RenderPretty(indentation);
        }
    }
}
