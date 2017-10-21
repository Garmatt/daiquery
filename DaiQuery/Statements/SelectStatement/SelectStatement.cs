using System.Collections.Generic;

namespace DaiQuery
{
    public sealed class SelectStatement : LanguageElement, ISelectStatement
    {
        public SelectClause SelectClause
        {
            get;
            set;
        }
        
        public FromClause FromClause
        {
            get;
            set;
        }
        
        public WhereClause WhereClause
        {
            get;
            set;
        }

        public SelectStatement()
            : base()
        {
            SelectClause = new SelectClause();
            FromClause = new FromClause();
            WhereClause = new WhereClause();
        }

        public SelectStatement Select(params Expression[] expressionsToSelect)
        {
            return Select((IEnumerable<Expression>)expressionsToSelect);
        }

        public SelectStatement Select(IEnumerable<Expression> expressionsToSelect)
        {
            SelectClause newSelectClause = new SelectClause();
            newSelectClause.Add(expressionsToSelect);
            SelectClause = newSelectClause;
            return this;
        }

        public SelectStatement From(Set source)
        {
            FromClause newFromClause = new FromClause();
            newFromClause.Source = source;
            FromClause = newFromClause;
            return this;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetStatementRenderer<SelectStatement>(this);
        }

        IWhereClause ISelectStatement.WhereClause
        {
            get { return WhereClause; }
        }

        ISelectClause ISelectStatement.SelectClause
        {
            get { return SelectClause; }
        }

        IFromClause ISelectStatement.FromClause
        {
            get { return FromClause; }
        }

        List<IClause> IStatement.StatementStructure
        {
            get { return new List<IClause> { SelectClause, FromClause, WhereClause }; }
        }
    }
}
