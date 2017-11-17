namespace DaiQuery
{
    internal interface IResultSet : IClauseBody
    {
        bool ConsiderAsJoinMember { get; set; }
    }
}
