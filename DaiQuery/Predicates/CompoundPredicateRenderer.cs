using System;
using System.Linq;

namespace DaiQuery
{
    internal class CompoundPredicateRenderer<ICP> : PredicateRenderer<ICP>
        where ICP : ICompoundPredicate
    {
        internal CompoundPredicateRenderer(ICP compoundPredicate)
            : base(compoundPredicate)
        { }

        private string RenderLogicalConnective(LogicalConnective logicalConnective)
        {
            string result = null;
            switch (logicalConnective)
            {
                case LogicalConnective.And:
                    result = Strings.Keywords.And;
                    break;
                case LogicalConnective.Or:
                    result = Strings.Keywords.Or;
                    break;
                default:
                    throw new NotSupportedException();
            }
            return RenderKeyword(result);
        }

        public override string RenderPlain()
        {
            return JoinStrings(Strings.Symbols.WhiteSpace + RenderLogicalConnective(Renderable.LogicalConnective) + Strings.Symbols.WhiteSpace, Renderable.Predicates.Select(p => p.RenderPlain()));
        }

        public override string RenderPretty(int indentation)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace + RenderLogicalConnective(Renderable.LogicalConnective) + Strings.Symbols.CarriageReturn, Renderable.Predicates.Select(p => p.RenderPretty(indentation)));
        }
    }
}
