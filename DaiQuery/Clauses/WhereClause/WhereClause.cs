using System;

namespace DaiQuery
{
    public sealed class WhereClause : Clause, IWhereClause
    {
        public Predicate Predicate
        {
            get;
            set;
        }

        public WhereClause()
            : base()
        { }

        internal override bool IsEmpty()
        {
            return Predicate == null || ((IPredicate)Predicate).IsEmpty;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetWhereClauseRenderer<WhereClause>(this);
        }

        internal override ClauseKeyword InitKeyword()
        {
            return ClauseKeyword.Where;
        }

        public override void Clear()
        {
            Predicate = null;
        }
    }
}
