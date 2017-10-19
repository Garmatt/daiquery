namespace DaiQuery
{
    internal interface IComparisonPredicate : IPredicate
    {
        ComparisonOperator Operator { get; }
        IExpression LeftMember { get; }
        IExpression RightMember { get; }
    }
}
