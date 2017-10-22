using System;

namespace DaiQuery
{
    public sealed class FromClause : Clause, IFromClause
    {
        public ResultSet Source
        {
            get;
            set;
        }

        public FromClause()
            : base()
        { }

        internal override bool IsEmpty()
        {
            return Source == null || ((IResultSet)Source).IsEmpty;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetFromClauseRenderer<FromClause>(this);
        }

        internal override ClauseKeyword InitKeyword()
        {
            return ClauseKeyword.From;
        }

        public override void Clear()
        {
            Source = null;
        }
    }
}
