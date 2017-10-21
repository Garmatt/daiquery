namespace DaiQuery
{
    public class ConstantUnicodeString : ConstantString
    {
        public ConstantUnicodeString(string value, bool escapeSpecialCharacters)
            : base(value, escapeSpecialCharacters)
        { }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetConstantUnicodeStringRenderer<ConstantUnicodeString>(this);
        }
    }
}
