using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public sealed class SelectStatement : RenderableEntity, ISelectStatement
    {
        private SelectClause selectClause;
        public SelectClause SelectClause
        {
            get 
            {
                return selectClause; 
            }
            set
            {
                selectClause = value;
            }
        }

        private FromClause fromClause;
        public FromClause FromClause
        {
            get
            {
                return fromClause;
            }
            set
            {
                fromClause = value;
            }
        }

        private WhereClause whereClause;
        public WhereClause WhereClause
        {
            get
            {
                return whereClause;
            }
            set
            {
                whereClause = value;
            }
        }

        public SelectStatement()
            : base()
        {
            Initialize();
        }

        private void Initialize()
        {
            selectClause = new SelectClause();
            fromClause = new FromClause();
            whereClause = new WhereClause();
        }

        internal override IRenderer GetRenderer()
        {
            return new SelectStatementRenderer<SelectStatement>(this);
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
    }
}
