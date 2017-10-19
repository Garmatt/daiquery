namespace DaiQuery
{
    public sealed class FromClause : Clause, IFromClause
    {
        //private Set _source;
        //IClauseBody IFromClause.source
        //{
        //    get { return _source; }
        //}

        public Set Source
        {
            get; //{ return _source; }
            set; //{ _source = value; }
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

        internal override eClauseKeyword InitKeyword()
        {
            return eClauseKeyword.FROM;
        }
    }
}
