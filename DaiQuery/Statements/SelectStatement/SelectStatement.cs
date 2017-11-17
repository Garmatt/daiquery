using System.Collections.Generic;
using System.Linq;

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

        public void Clear()
        {
            SelectClause.Clear();
            FromClause.Clear();
            WhereClause.Clear();
        }

        public SelectStatement Select(params string[] columnNames)
        {
            return Select(columnNames.Select(columnName => new Column(columnName)));
        }

        //public SelectStatement Select(params Expression[] expressionsToSelect)
        //{
        //    return Select((IEnumerable<Expression>)expressionsToSelect);
        //}

        public SelectStatement Select(IEnumerable<Expression> expressionsToSelect)
        {
            SelectClause newSelectClause = new SelectClause();
            newSelectClause.Add(expressionsToSelect);
            SelectClause = newSelectClause;
            return this;
        }

        public SelectStatement From(ResultSet source)
        {
            FromClause newFromClause = new FromClause();
            newFromClause.Source = source;
            FromClause = newFromClause;
            return this;
        }

        public SelectStatement From(string tableName)
        {
            return From(new Table(tableName));
        }

        public SelectStatement Where(Predicate condition)
        {
            WhereClause newWhereClause = new WhereClause();
            newWhereClause.Predicate = condition;
            WhereClause = newWhereClause;
            return this;
        }

        //public SelectStatement Where(string columnName, ComparisonOperator comparisonOperator, int constantNumber)
        //{
        //    return Where(new ComparisonPredicate(new Column(columnName), comparisonOperator, new ConstantNumber(constantNumber)));
        //}

        public SelectStatement Where(string columnName, bool equals, string constantString)
        {
            return Where(new ComparisonPredicate(new Column(columnName), equals ? ComparisonOperator.Equal : ComparisonOperator.NotEqual, new ConstantString(constantString, false)));
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
