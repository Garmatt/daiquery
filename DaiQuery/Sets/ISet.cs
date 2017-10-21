namespace DaiQuery
{
    internal interface ISet : IClauseBody
    {
        JoinSet InnerJoin(Set set, Predicate condition);
    }
}
