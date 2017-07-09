using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public sealed class FromClause : Clause, IFromClause
    {
        private IClauseBody _source;
        IClauseBody IFromClause.source
        {
            get { return _source; }
        }

        public ISet Source
        {
            get { return (ISet)_source; }
            set { _source = (IClauseBody)value; }
        }

        public FromClause()
            : base()
        { }

        internal override bool IsEmpty()
        {
            return _source == null || _source.IsEmpty;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetFromClauseRenderer<FromClause>(this);
        }

        internal override eClauseKeyword InitKeyword()
        {
            return eClauseKeyword.FROM;
        }
    }
}
