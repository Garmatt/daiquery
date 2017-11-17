namespace DaiQuery
{
    /// <summary>
    /// Represents a database table or view.
    /// </summary>
    internal interface ITable : IIdentifiedEntity, IAliasableEntity, IResultSet
    {
    }
}
