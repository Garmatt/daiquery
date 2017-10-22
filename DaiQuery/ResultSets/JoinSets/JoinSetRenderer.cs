using System;

namespace DaiQuery
{
    internal class JoinSetRenderer<IJS> : Renderer<IJS>
        where IJS : IJoinSet
    {
        internal JoinSetRenderer(IJS joinSet)
            : base(joinSet)
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
