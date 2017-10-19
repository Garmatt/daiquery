using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected string RenderOperator(eComparisonOperator comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case eComparisonOperator.EQUAL:
                    return OP_EQUAL;
                case eComparisonOperator.NOT_EQUAL:
                    return OP_NOT_EQUAL;
                case eComparisonOperator.GREATER:
                    return OP_GREATER;
                case eComparisonOperator.LESS:
                    return OP_LESS;
                case eComparisonOperator.GREATER_OR_EQUAL:
                    return OP_GREATER_EQUAL;
                case eComparisonOperator.LESS_OR_EQUAL:
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
