using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal abstract class ExpressionRenderer<IE> : AliasableEntityRenderer<IE>
        where IE : IExpression
    {
        protected const string MTH_INVERT = "-";

        internal ExpressionRenderer(IE expression)
            : base(expression)
        { }

        protected internal abstract string RenderFlatRegardlessOfInversed();

        public override string RenderInline()
        {
            string result = RenderFlatRegardlessOfInversed();
            if (!string.IsNullOrWhiteSpace(result) && Renderable.IsInversed)
                result = JoinStrings(string.Empty, MTH_INVERT, Strings.Symbols.OpenRoundBracket, result, Strings.Symbols.ClosedRoundBracket);

            return result;
        }

        public override string RenderIndented(int indentation)
        {
            return JoinStrings(string.Empty, GetTabs(indentation), RenderInline());
        }
    }
}
