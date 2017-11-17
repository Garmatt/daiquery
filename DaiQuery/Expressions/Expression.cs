namespace DaiQuery
{
    /// <summary>
    /// A SQL language element that evaluates to scalar or tabular values.
    /// </summary>
    public abstract class Expression : LanguageElement, IExpression
    {
        internal new IAliasableEntityRenderer Renderer
        {
            get { return (IAliasableEntityRenderer)base.Renderer; }
        }

        bool IExpression.IsInversed { get; set; }

        bool IExpression.ConsiderAsOperand { get; set; }

        string IExpression.Header
        {
            get { return GetHeader(); }
        }

        protected abstract string GetHeader();

        public Expression()
            : base()
        { }

        internal abstract Expression GetClone();

        public static Expression operator -(Expression expression)
        {
            Expression minusExpression = expression.GetClone();
            ((IExpression)minusExpression).IsInversed = !((IExpression)expression).IsInversed;
            return minusExpression;
        }

        public static ArithmeticExpression operator +(Expression x, Expression y)
        {
            return new ArithmeticExpression(ArithmeticOperator.Plus, x, y);
        }

        public static ArithmeticExpression operator -(Expression x, Expression y)
        {
            return new ArithmeticExpression(ArithmeticOperator.Minus, x, y);
        }

        public static ArithmeticExpression operator *(Expression x, Expression y)
        {
            return new ArithmeticExpression(ArithmeticOperator.Times, x, y);
        }

        public static ArithmeticExpression operator /(Expression x, Expression y)
        {
            return new ArithmeticExpression(ArithmeticOperator.Divide, x, y);
        }

        internal override abstract IRenderer GetRenderer();

        IExpression IExpression.Clone()
        {
            return GetClone();
        }

        string IAliasableEntity.RenderPlainWithAlias(string alias)
        {
            return Renderer.RenderPlainWithAlias(alias);
        }

        string IAliasableEntity.RenderPrettyWithAlias(int indentation, string alias)
        {
            return Renderer.RenderPrettyWithAlias(indentation, alias);
        }
    }
}
