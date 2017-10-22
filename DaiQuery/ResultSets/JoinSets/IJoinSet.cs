namespace DaiQuery
{
    internal interface IJoinSet : IResultSet
    {
        JoinType JoinType { get; }
        ResultSet LeftMember { get; }
        ResultSet RightMember { get; }
        Predicate Condition { get; }
    }
}
