using System;
using System.Collections.Generic;
using System.Linq;

namespace DaiQuery
{
    public sealed class SelectClause : Clause, ISelectClause
    {
        private readonly Dictionary<IExpression, string> aliasedExpressions;

        public SelectClause()
            : base()
        {
            aliasedExpressions = new Dictionary<IExpression, string>();
        }

        public SelectClause Add(Expression expressionToSelect, string expressionAlias)
        {
            if (string.IsNullOrWhiteSpace(expressionAlias))
                throw new ArgumentException("The alias must be a non-null, non-empty string.", "alias");

            aliasedExpressions.Add(expressionToSelect, expressionAlias);
            return this;
        }

        public SelectClause Add(params Expression[] expressionsToSelect)
        {
            return Add((IEnumerable<Expression>)expressionsToSelect);
        }

        public SelectClause Add(IEnumerable<Expression> expressionsToSelect)
        {
            foreach (Expression expressionToSelect in expressionsToSelect)
                Add(expressionToSelect, (string)null);

            return this;
        }

        public SelectClause Clear()
        {
            aliasedExpressions.Clear();
            return this;
        }

        internal override bool IsEmpty()
        {
            return aliasedExpressions == null || !aliasedExpressions.Any();
        }

        internal override eClauseKeyword InitKeyword()
        {
            return eClauseKeyword.SELECT;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetSelectClauseRenderer<SelectClause>(this);
        }

        IEnumerable<KeyValuePair<IExpression, string>> ISelectClause.AliasedExpressions
        {
            get { return aliasedExpressions; }
        }
    }
}
