using System;

namespace DaiQuery
{
    internal class ResultSetRenderer<IRS> : Renderer<IRS>
        where IRS : IResultSet
    {
        internal ResultSetRenderer(IRS resultSet)
            : base(resultSet)
        { }

        public override string RenderPlain()
        {
            throw new NotImplementedException();
        }

        public override string RenderPretty(int indentation)
        {
            throw new NotImplementedException();
        }
    }
}
