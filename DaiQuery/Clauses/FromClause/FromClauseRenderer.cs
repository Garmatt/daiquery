namespace DaiQuery
{
    internal class FromClauseRenderer<IFC> : ClauseRenderer<IFC>
        where IFC : IFromClause
    {
        internal FromClauseRenderer(IFC fromClause)
            : base(fromClause)
        { }

        protected override string RenderBodyPlain()
        {
            return ((IResultSet)Renderable.Source).RenderPlain();
        }

        protected override string RenderBodyPretty(int indentation)
        {
            return ((IResultSet)Renderable.Source).RenderPretty(indentation);
        }
    }
}
