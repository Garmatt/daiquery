using System.Collections.Generic;
using System.Linq;

namespace DaiQuery
{
    public sealed class Query : LanguageElement, IQuery
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

        public Query()
            : base()
        {
            SelectClause = new SelectClause();
            FromClause = new FromClause();
            WhereClause = new WhereClause();
        }

        public void Clear()
        {
            SelectClause.Clear();
            FromClause.Clear();
            WhereClause.Clear();
        }

        public Query Select(params string[] columnNames)
        {
            return Select(columnNames.Select(columnName => new Column(columnName)));
        }

        //public Query Select(params Expression[] expressionsToSelect)
        //{
        //    return Select((IEnumerable<Expression>)expressionsToSelect);
        //}

        public Query Select(IEnumerable<Expression> expressionsToSelect)
        {
            SelectClause newSelectClause = new SelectClause();
            newSelectClause.Add(expressionsToSelect);
            SelectClause = newSelectClause;
            return this;
        }

        public Query From(ResultSet source)
        {
            FromClause newFromClause = new FromClause();
            newFromClause.Source = source;
            FromClause = newFromClause;
            return this;
        }

        public Query From(string tableName)
        {
            return From(new Table(tableName));
        }

        public Query Where(Predicate condition)
        {
            WhereClause newWhereClause = new WhereClause();
            newWhereClause.Predicate = condition;
            WhereClause = newWhereClause;
            return this;
        }

        //public Query Where(string columnName, ComparisonOperator comparisonOperator, int constantNumber)
        //{
        //    return Where(new ComparisonPredicate(new Column(columnName), comparisonOperator, new ConstantNumber(constantNumber)));
        //}

        public Query Where(string columnName, bool equals, string constantString)
        {
            return Where(new ComparisonPredicate(new Column(columnName), equals ? ComparisonOperator.Equal : ComparisonOperator.NotEqual, new ConstantString(constantString, false)));
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetStatementRenderer<Query>(this);
        }

        IWhereClause IQuery.WhereClause
        {
            get { return WhereClause; }
        }

        ISelectClause IQuery.SelectClause
        {
            get { return SelectClause; }
        }

        IFromClause IQuery.FromClause
        {
            get { return FromClause; }
        }

        List<IClause> IStatement.StatementStructure
        {
            get { return new List<IClause> { SelectClause, FromClause, WhereClause }; }
        }
    }
}
