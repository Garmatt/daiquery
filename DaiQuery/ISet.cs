namespace DaiQuery
{
    internal interface ISet : IClauseBody
    {
        ResultSet InnerJoin(Set set, Predicate condition);
    }
}
