namespace DaiQuery
{
    internal interface IResultSet : ISet
    {
        eJoinType JoinType { get; }
        Set LeftMember { get; }
        Set RightMember { get; }
        Predicate Condition { get; }
    }
}
