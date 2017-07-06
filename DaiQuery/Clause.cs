using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public abstract class Clause : RenderableEntity, IClause
    {
        private readonly eClauseKeyword keyword;
        eClauseKeyword IClause.Keyword
        {
            get { return keyword; }
        }

        bool IClause.IsEmpty
        {
            get { return IsEmpty(); }
        }

        public Clause()
            : base()
        {
            this.keyword = InitKeyword();
        }

        internal abstract eClauseKeyword InitKeyword();

        internal abstract bool IsEmpty();

        internal override abstract IRenderer GetRenderer();
    }
}
