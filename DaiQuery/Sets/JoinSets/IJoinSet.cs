namespace DaiQuery
{
    internal interface IJoinSet : ISet
    {
        JoinType JoinType { get; }
        Set LeftMember { get; }
        Set RightMember { get; }
        Predicate Condition { get; }
    }
}
