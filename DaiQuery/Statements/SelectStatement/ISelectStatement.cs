namespace DaiQuery
{
    internal interface ISelectStatement : IStatement
    {
        IFromClause FromClause { get; }
        IWhereClause WhereClause { get; }
        ISelectClause SelectClause { get; }
    }
}
