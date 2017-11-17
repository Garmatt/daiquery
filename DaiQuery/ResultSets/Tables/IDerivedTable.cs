namespace DaiQuery
{
    internal interface IDerivedTable : IAliasedEntity, IResultSet
    {
        Query Query { get; set; }
    }
}
