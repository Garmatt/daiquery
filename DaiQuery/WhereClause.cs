using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public sealed class WhereClause : Clause, IWhereClause
    {
        private IPredicateInternal _predicate;
        IPredicateInternal IWhereClause.predicate
        {
            get { return _predicate; }
        }

        public IPredicate Predicate
        {
            get { return (IPredicate)_predicate; }
            set { _predicate = (IPredicateInternal)value; }
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
