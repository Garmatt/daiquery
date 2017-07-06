using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal class CompoundPredicateRenderer<ICP> : PredicateRenderer<ICP>
        where ICP : ICompoundPredicate
    {
        protected const string KWD_AND = "AND";
        protected const string KWD_OR = "OR";

        internal CompoundPredicateRenderer(ICP compoundPredicate)
            : base(compoundPredicate)
        { }

        private string RenderLogicalConnective(eLogicalConnective logicalConnective)
        {
            string result = null;
            switch (logicalConnective)
            {
                case eLogicalConnective.AND:
                    result = KWD_AND;
                    break;
                case eLogicalConnective.OR:
                    result = KWD_OR;
                    break;
                default:
                    throw new NotSupportedException();
            }
            return RenderKeyword(result);
        }

        public override string RenderInline()
        {
            return JoinStrings(Strings.Symbols.WhiteSpace + RenderLogicalConnective(Renderable.LogicalConnective) + Strings.Symbols.WhiteSpace, Renderable.Predicates.Select(p => p.RenderInline()));
        }

        public override string RenderIndented(int indentation)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace + RenderLogicalConnective(Renderable.LogicalConnective) + Strings.Symbols.CarriageReturn, Renderable.Predicates.Select(p => p.RenderIndented(indentation)));
        }
    }
}
