namespace DaiQuery
{
    /// <summary>
    /// What follows the keyword in a SQL clause.
    /// </summary>
    internal interface IClauseBody : IRenderableEntity
    {
        bool IsEmpty { get; }
    }
}
