namespace DaiQuery
{
    /// <summary>
    /// An expression that results from combining two sub-expression with a binary arithmetic operator.
    /// </summary>
    internal interface IArithmeticExpression : IExpression
    {
        IExpression FirstOperand { get; }
        IExpression SecondOperand { get; } 
        ArithmeticOperator Operator { get; }
    }
}
