using System;

namespace DaiQuery
{
    internal class ComparisonPredicateRenderer<ICP> : PredicateRenderer<ICP>
        where ICP : IComparisonPredicate
    {
        protected const string OP_EQUAL = "=";
        protected const string OP_NOT_EQUAL = "<>";
        protected const string OP_GREATER = ">";
        protected const string OP_LESS = "<";
        protected const string OP_GREATER_EQUAL = ">=";
        protected const string OP_LESS_EQUAL = "=";

        internal ComparisonPredicateRenderer(ICP comparisonPredicate)
            : base(comparisonPredicate)
        { }

        protected string RenderOperator(ComparisonOperator comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.Equal:
                    return OP_EQUAL;
                case ComparisonOperator.NotEqual:
                    return OP_NOT_EQUAL;
                case ComparisonOperator.Greater:
                    return OP_GREATER;
                case ComparisonOperator.Less:
                    return OP_LESS;
                case ComparisonOperator.GreaterOrEqual:
                    return OP_GREATER_EQUAL;
                case ComparisonOperator.LessOrEqual:
                    return OP_LESS_EQUAL;
                default:
                    throw new NotSupportedException();
            }
        }

        public override string RenderPlain()
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, 
                Renderable.LeftMember.RenderPlain(), 
                RenderOperator(Renderable.Operator), 
                Renderable.RightMember.RenderPlain());
        }

        public override string RenderPretty(int indentation)
        {
            return JoinStrings(string.Empty, GetTabs(indentation), RenderPlain());
        }
    }
}
