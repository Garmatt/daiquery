namespace DaiQuery
{
    internal interface IComparisonPredicate : IPredicate
    {
        eComparisonOperator Operator { get; }
        IExpression LeftMember { get; }
        IExpression RightMember { get; }
    }
}
