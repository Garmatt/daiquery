namespace DaiQuery
{
    internal interface IWhereClause : IClause
    {
        Predicate Predicate { get; set; }
    }
}
