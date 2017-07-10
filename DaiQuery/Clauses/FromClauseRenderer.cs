namespace DaiQuery
{
    internal class FromClauseRenderer<IFC> : ClauseRenderer<IFC>
        where IFC : IFromClause
    {
        internal FromClauseRenderer(IFC fromClause)
            : base(fromClause)
        { }

        protected override string RenderBodyInline()
        {
            return ((ISet)Renderable.Source).RenderInline();
        }

        protected override string RenderBodyIndented(int indentation)
        {
            return ((ISet)Renderable.Source).RenderIndented(indentation);
        }
    }
}
