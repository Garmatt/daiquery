namespace DaiQuery
{
    /// <summary>
    /// Renders an <see cref="IExpression"/> object into SQL code.
    /// </summary>
    /// <typeparam name="IE"></typeparam>
    internal abstract class ExpressionRenderer<IE> : AliasableEntityRenderer<IE>
        where IE : IExpression
    {
        internal ExpressionRenderer(IE expression)
            : base(expression)
        { }

        protected internal abstract string RenderFlatRegardlessOfInversed();

        public override string RenderPlain()
        {
            string result = RenderFlatRegardlessOfInversed();
            if (!string.IsNullOrWhiteSpace(result) && Renderable.IsInversed)
                result = JoinStrings(string.Empty, Strings.Math.MINUS, Strings.Symbols.OpenRoundBracket, result, Strings.Symbols.ClosedRoundBracket);

            return result;
        }

        public override string RenderPretty(int indentation)
        {
            return JoinStrings(string.Empty, GetTabs(indentation), RenderPlain());
        }
    }
}
