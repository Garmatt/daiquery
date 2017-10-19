namespace DaiQuery
{
    internal interface IConstantString : IConstant<string>
    {
        bool EscapeSpecialCharacters { get; }
    }
}
