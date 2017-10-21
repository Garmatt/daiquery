namespace DaiQuery
{
    public sealed class FromClause : Clause, IFromClause
    {
        public Set Source
        {
            get;
            set;
        }

        public FromClause()
            : base()
        { }

        internal override bool IsEmpty()
        {
            return Source == null || ((ISet)Source).IsEmpty;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetFromClauseRenderer<FromClause>(this);
        }

        internal override ClauseKeyword InitKeyword()
        {
            return ClauseKeyword.From;
        }
    }
}
