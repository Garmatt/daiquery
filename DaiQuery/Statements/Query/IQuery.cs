namespace DaiQuery
{
    internal interface IQuery : IStatement
    {
        IFromClause FromClause { get; }
        IWhereClause WhereClause { get; }
        ISelectClause SelectClause { get; }
        void Clear();
    }
}
