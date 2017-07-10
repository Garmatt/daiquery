namespace DaiQuery
{
    internal interface IWhereClause : IClause
    {
        //IPredicate predicate { get; }
        Predicate Predicate { get; set; }
    }
}
