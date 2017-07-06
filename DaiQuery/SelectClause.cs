using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public sealed class SelectClause : Clause, ISelectClause
    {
        private readonly Dictionary<IExpression, string> aliasedFields;

        public SelectClause()
            : base()
        {
            aliasedFields = new Dictionary<IExpression, string>();
        }

        public void Add(Expression expression, string alias)
        {
            if (string.IsNullOrWhiteSpace(alias))
                throw new ArgumentException("The alias must be a non-null, non-empty string.", "alias");

            aliasedFields.Add(expression, alias);
        }

        internal override bool IsEmpty()
        {
            return aliasedFields == null || !aliasedFields.Any();
        }

        internal override eClauseKeyword InitKeyword()
        {
            return eClauseKeyword.SELECT;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetSelectClauseRenderer<SelectClause>(this);
        }

        IEnumerable<KeyValuePair<IExpression, string>> ISelectClause.AliasedFields
        {
            get { return aliasedFields; }
        }
    }
}
