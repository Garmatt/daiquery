using System;

namespace DaiQuery
{
    /// <summary>
    /// Renders an <see cref="IArithmeticExpression"/> object into SQL code.
    /// </summary>
    /// <typeparam name="IAE"></typeparam>
    internal class ArithmeticExpressionRenderer<IAE> : ExpressionRenderer<IAE>
        where IAE : IArithmeticExpression
    {
        internal ArithmeticExpressionRenderer(IAE arithmeticExpression)
            : base(arithmeticExpression)
        { }
        
        protected string RenderOperator(ArithmeticOperator arithmeticOperator)
        {
            switch (arithmeticOperator)
            {
                case ArithmeticOperator.Minus:
                    return Strings.Math.Minus;
                case ArithmeticOperator.Plus:
                    return Strings.Math.Plus;
                case ArithmeticOperator.Times:
                    return Strings.Math.Times;
                case ArithmeticOperator.Divide:
                    return Strings.Math.Divide;
                default:
                    throw new NotSupportedException();
            }
        }

        private string RenderAsOperand(IExpression expression)
        {
            expression.ConsiderAsOperand = true;
            string result = expression.RenderPlain();
            expression.ConsiderAsOperand = false;
            return result;
        }

        protected internal override RenderOptions GetRenderOptions(bool useIndentation)
        {
            RenderOptions baseOptions = base.GetRenderOptions(useIndentation);
            return Renderable.ConsiderAsOperand ? baseOptions | RenderOptions.EncloseInRoundBrackets : baseOptions;
        }

        protected internal override string RenderFlatRegardlessOfInversed()
        {
            return JoinStrings(Strings.Symbols.WhiteSpace + RenderOperator(Renderable.Operator) + Strings.Symbols.WhiteSpace, RenderAsOperand(Renderable.FirstOperand), RenderAsOperand(Renderable.SecondOperand));
        }
    }
}
