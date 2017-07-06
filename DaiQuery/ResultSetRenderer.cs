using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal class ResultSetRenderer<IRS> : Renderer<IRS>
        where IRS : IResultSet
    {
        internal ResultSetRenderer(IRS resultSet)
            : base(resultSet)
        { }

        public override string RenderInline()
        {
            throw new NotImplementedException();
        }

        public override string RenderIndented(int indentation)
        {
            throw new NotImplementedException();
        }
    }
}
