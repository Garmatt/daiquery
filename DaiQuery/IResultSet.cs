
namespace DaiQuery
{
    internal interface IResultSet : IRenderableEntity, IClauseBody
    {
        eJoinType JoinType { get; }
        IRenderableEntity LeftMember { get; }
        IRenderableEntity RightMember { get; }
        Predicate Condition { get; }
    }
}
