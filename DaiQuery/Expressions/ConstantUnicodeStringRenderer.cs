namespace DaiQuery
{
    internal class ConstantUnicodeStringRenderer<ICS> : ConstantStringRenderer<ICS>
        where ICS : IConstantString
    {
        internal ConstantUnicodeStringRenderer(ICS constantString)
            : base(constantString)
        { }

        protected override string RenderConstantValue(string value)
        {
            return JoinStrings(string.Empty, Strings.Symbols.UnicodePrefix, base.RenderConstantValue(value));
        }
    }
}
