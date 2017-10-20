namespace DaiQuery
{
    internal interface ISelectStatement : IRenderableEntity
    {
        IFromClause FromClause { get; }
        IWhereClause WhereClause { get; }
        ISelectClause SelectClause { get; }
    }
}
