namespace DaiQuery
{
    internal interface IPredicate : IClauseBody
    {
        bool IsNegated { get; set; }
        IPredicate Clone();
    }
}
