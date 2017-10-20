namespace DaiQuery
{
    public sealed class WhereClause : Clause, IWhereClause
    {
        private Predicate _predicate;
        //IPredicate IWhereClause.predicate
        //{
        //    get { return _predicate; }
        //}

        public Predicate Predicate
        {
            get { return _predicate; }
            set { _predicate = value; }
        }

        public WhereClause()
            : base()
        { }

        internal override bool IsEmpty()
        {
            return _predicate == null || ((IPredicate)_predicate).IsEmpty;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetWhereClauseRenderer<WhereClause>(this);
        }

        internal override ClauseKeyword InitKeyword()
        {
            return ClauseKeyword.Where;
        }
    }
}
