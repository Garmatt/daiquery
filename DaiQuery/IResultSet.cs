namespace DaiQuery
{
    internal interface IResultSet : ISet
    {
        JoinType JoinType { get; }
        Set LeftMember { get; }
        Set RightMember { get; }
        Predicate Condition { get; }
    }
}
