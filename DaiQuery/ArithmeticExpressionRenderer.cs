using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal class ArithmeticExpressionRenderer<IAE> : ExpressionRenderer<IAE>
        where IAE : IArithmeticExpression
    {
        internal ArithmeticExpressionRenderer(IAE arithmeticExpression)
            : base(arithmeticExpression)
        { }
        
        protected string RenderOperator(eArithmeticOperator arithmeticOperator)
        {
            switch (arithmeticOperator)
            {
                case eArithmeticOperator.MINUS:
                    return Strings.Math.MINUS;
                case eArithmeticOperator.PLUS:
                    return Strings.Math.PLUS;
                case eArithmeticOperator.TIMES:
                    return Strings.Math.TIMES;
                case eArithmeticOperator.DIVIDE:
                    return Strings.Math.DIVIDE;
                default:
                    throw new NotSupportedException();
            }
        }

        private string RenderAsOperand(IExpression expression)
        {
            expression.ConsiderAsOperand = true;
            string result = expression.RenderInline();
            expression.ConsiderAsOperand = false;
            return result;
        }

        protected internal override eRenderOptions GetRenderOptions(bool useIndentation)
        {
            eRenderOptions baseOptions = base.GetRenderOptions(useIndentation);
            return Renderable.ConsiderAsOperand ? baseOptions | eRenderOptions.ENCLOSE_IN_ROUND_BRACKETS : baseOptions;
        }

        protected internal override string RenderFlatRegardlessOfInversed()
        {
            return JoinStrings(Strings.Symbols.WhiteSpace + RenderOperator(Renderable.Operator) + Strings.Symbols.WhiteSpace, RenderAsOperand(Renderable.FirstOperand), RenderAsOperand(Renderable.SecondOperand));
        }
    }
}
