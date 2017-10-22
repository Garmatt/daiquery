namespace DaiQuery
{
    /// <summary>
    /// A SQL language element that evaluates to scalar or tabular values.
    /// </summary>
    internal interface IExpression : IAliasableEntity
    {
        /// <summary>
        /// If true, the rendered expression should be preceded by an additive inverse sign.
        /// </summary>
        bool IsInversed { get; set; }

        /// <summary>
        /// If true, this expression is a member of a containing expression, and should be rendered between round brackets.
        /// </summary>
        bool ConsiderAsOperand { get; set; }

        /// <summary>
        /// A string that identifies this expression, typically in the context of a result set. Usually an alias or an identifier. Can be null.
        /// </summary>
        string Header { get; }

        IExpression Clone();
    }
}
