namespace DaiQuery
{
    public sealed class WhereClause : Clause, IWhereClause
    {
        private IPredicate _predicate;
        IPredicate IWhereClause.predicate
        {
            get { return _predicate; }
        }

        public IPredicate Predicate
        {
            get { return (IPredicate)_predicate; }
            set { _predicate = (IPredicate)value; }
        }

        public WhereClause()
            : base()
        { }

        internal override bool IsEmpty()
        {
            return _predicate == null || _predicate.IsEmpty;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetWhereClauseRenderer<WhereClause>(this);
        }

        internal override eClauseKeyword InitKeyword()
        {
            return eClauseKeyword.WHERE;
        }
    }
}
