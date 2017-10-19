namespace DaiQuery
{
    internal interface IConstant<T> : IExpression
        //where T : struct
    {
        T Value { get; set; }
    }
}
