namespace DaiQuery
{
    internal interface IResultSet : IClauseBody
    {
        JoinSet InnerJoin(ResultSet otherSet, Predicate condition);
    }
}
