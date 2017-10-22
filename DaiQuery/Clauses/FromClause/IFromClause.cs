namespace DaiQuery
{
    internal interface IFromClause : IClause
    {
        ResultSet Source { get; set; }
    }
}
