using System;

namespace DaiQuery
{
    internal class ComparisonPredicateRenderer<ICP> : PredicateRenderer<ICP>
        where ICP : IComparisonPredicate
    {
        internal ComparisonPredicateRenderer(ICP comparisonPredicate)
            : base(comparisonPredicate)
        { }

        protected string RenderOperator(ComparisonOperator comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.Equal:
                    return Strings.Operators.Equal;
                case ComparisonOperator.NotEqual:
                    return Strings.Operators.NotEqual;
                case ComparisonOperator.Greater:
                    return Strings.Operators.Greater;
                case ComparisonOperator.Less:
                    return Strings.Operators.Less;
                case ComparisonOperator.GreaterOrEqual:
                    return Strings.Operators.GreaterEqual;
                case ComparisonOperator.LessOrEqual:
                    return Strings.Operators.LessEqual;
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
