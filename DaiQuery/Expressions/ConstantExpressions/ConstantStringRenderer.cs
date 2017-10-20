namespace DaiQuery
{
    internal class ConstantStringRenderer<ICS> : ConstantRenderer<string, ICS>
        where ICS : IConstantString
    {
        internal ConstantStringRenderer(ICS constantString)
            : base(constantString)
        { }
        
        protected string EscapeSpecialCharacters(string input)
        {
            input = input.Replace(@"\", @"\\");
            input = input.Replace(@"%", @"\%");
            input = input.Replace(@"[", @"\[");
            input = input.Replace(@"]", @"\]");
            input = input.Replace(@"_", @"\_");
            input = input.Replace(@"'", @"''");
            return input;
        }

        protected override string RenderConstantValue(string value)
        {
            string result = Renderable.EscapeSpecialCharacters ? EscapeSpecialCharacters(value) : value;
            return JoinStrings(string.Empty, Strings.Symbols.SingleQuotationMark, result, Strings.Symbols.SingleQuotationMark);
        }
    }
}
