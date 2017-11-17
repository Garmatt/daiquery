using System;
using System.Linq;

namespace DaiQuery
{
    internal class JoinSetRenderer<IJS> : Renderer<IJS>
        where IJS : IJoinSet
    {
        internal JoinSetRenderer(IJS joinSet)
            : base(joinSet)
        { }

        private string RenderJoinType(JoinType joinType)
        {
            switch (joinType)
            {
                case JoinType.InnerJoin:
                    return JoinStrings(Strings.Symbols.WhiteSpace, new string[] { Strings.Keywords.Inner, Strings.Keywords.Join }.Select(k => RenderKeyword(k)) );
                case JoinType.LeftOuterJoin:
                    return JoinStrings(Strings.Symbols.WhiteSpace, new string[] { Strings.Keywords.Left, Strings.Keywords.Outer, Strings.Keywords.Join }.Select(k => RenderKeyword(k)));
                case JoinType.RightOuterJoin:
                    return JoinStrings(Strings.Symbols.WhiteSpace, new string[] { Strings.Keywords.Right, Strings.Keywords.Outer, Strings.Keywords.Join }.Select(k => RenderKeyword(k)));
                case JoinType.FullOuterJoin:
                    return JoinStrings(Strings.Symbols.WhiteSpace, new string[] { Strings.Keywords.Full, Strings.Keywords.Outer, Strings.Keywords.Join }.Select(k => RenderKeyword(k)));
                case JoinType.CrossJoin:
                    return JoinStrings(Strings.Symbols.WhiteSpace, new string[] { Strings.Keywords.Cross, Strings.Keywords.Join }.Select(k => RenderKeyword(k)));
                default:
                    throw new NotSupportedException();
            }
        }

        private string RenderAsJoinMember(IResultSet resultSet)
        {
            resultSet.ConsiderAsJoinMember = true;
            string result = resultSet.RenderPlain();
            resultSet.ConsiderAsJoinMember = false;
            return result;
        }

        protected internal override RenderOptions GetRenderOptions(bool useIndentation)
        {
            RenderOptions baseOptions = base.GetRenderOptions(useIndentation);
            return Renderable.ConsiderAsJoinMember ? baseOptions | RenderOptions.EncloseInRoundBrackets : baseOptions;
        }

        public override string RenderPlain()
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, 
                RenderAsJoinMember(Renderable.LeftMember), RenderJoinType(Renderable.JoinType), RenderAsJoinMember(Renderable.RightMember),
                RenderKeyword(Strings.Keywords.On), ((IPredicate)Renderable.Condition).RenderPlain());
        }

        public override string RenderPretty(int indentation)
        {
            throw new NotImplementedException();
        }
    }
}
