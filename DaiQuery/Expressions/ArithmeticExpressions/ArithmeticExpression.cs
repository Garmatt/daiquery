﻿namespace DaiQuery
{
    /// <summary>
    /// An expression that results from combining two sub-expression with a binary arithmetic operator.
    /// </summary>
    public sealed class ArithmeticExpression : Expression, IArithmeticExpression
    {
        private readonly ArithmeticOperator arithmeticOperator;
        public Expression FirstOperand; 
        public Expression SecondOperand; 

        public ArithmeticExpression(ArithmeticOperator arithmeticOperator)
            : base()
        {
            this.arithmeticOperator = arithmeticOperator;
        }

        public ArithmeticExpression(ArithmeticOperator arithmeticOperator, Expression firstOperand, Expression secondOperand)
            : this(arithmeticOperator)
        {
            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
        }

        protected override string GetHeader()
        {
            return null;
        }

        internal override Expression GetClone()
        {
            return new ArithmeticExpression(this.arithmeticOperator, this.FirstOperand.GetClone(), this.SecondOperand.GetClone());
        }

        public ArithmeticOperator Operator
        {
            get { return arithmeticOperator; }
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetArithmeticExpressionRenderer<ArithmeticExpression>(this);
        }

        IExpression IArithmeticExpression.FirstOperand
        {
            get { return FirstOperand; }
        }

        IExpression IArithmeticExpression.SecondOperand
        {
            get { return SecondOperand; }
        }
    }
}
