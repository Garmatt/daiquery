namespace DaiQuery
{
    /// <summary>
    /// A SQL language element that evaluates to scalar or tabular values.
    /// </summary>
    public abstract class Expression : LanguageElement, IExpression
    {
        private bool isInversed;
        private bool considerAsOperand;

        internal new IAliasableEntityRenderer Renderer
        {
            get { return (IAliasableEntityRenderer)base.Renderer; }
        }

        bool IExpression.IsInversed
        {
            get
            {
                return isInversed;
            }
            set
            {
                isInversed = value;
            }
        }

        bool IExpression.ConsiderAsOperand
        {
            get
            {
                return considerAsOperand;
            }
            set
            {
                considerAsOperand = value;
            }
        }

        string IExpression.Header
        {
            get { return GetHeader(); }
        }

        protected abstract string GetHeader();

        public Expression()
            : base()
        {
            isInversed = false;
            considerAsOperand = false;
        }

        internal abstract Expression GetClone();

        public static Expression operator -(Expression expression)
        {
            Expression minusExpression = expression.GetClone();
            ((IExpression)minusExpression).IsInversed = !((IExpression)expression).IsInversed;
            return minusExpression;
        }

        public static ArithmeticExpression operator +(Expression x, Expression y)
        {
            return new ArithmeticExpression(eArithmeticOperator.PLUS, x, y);
        }

        public static ArithmeticExpression operator -(Expression x, Expression y)
        {
            return new ArithmeticExpression(eArithmeticOperator.MINUS, x, y);
        }

        public static ArithmeticExpression operator *(Expression x, Expression y)
        {
            return new ArithmeticExpression(eArithmeticOperator.TIMES, x, y);
        }

        public static ArithmeticExpression operator /(Expression x, Expression y)
        {
            return new ArithmeticExpression(eArithmeticOperator.DIVIDE, x, y);
        }

        internal override abstract IRenderer GetRenderer();

        IExpression IExpression.Clone()
        {
            return GetClone();
        }

        string IAliasableEntity.RenderPlainWithAlias(string alias)
        {
            return Renderer.RenderInlineWithAlias(alias);
        }

        string IAliasableEntity.RenderPrettyWithAlias(int indentation, string alias)
        {
            return Renderer.RenderIndentedWithAlias(indentation, alias);
        }
    }
}
