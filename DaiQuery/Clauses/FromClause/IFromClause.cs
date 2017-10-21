namespace DaiQuery
{
    internal interface IFromClause : IClause
    {
        //IClauseBody source { get; }
        Set Source { get; set; }
    }
}
