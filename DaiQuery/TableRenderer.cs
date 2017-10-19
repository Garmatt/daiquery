namespace DaiQuery
{
    internal class TableRenderer<IT> : IdentifiedEntityRenderer<IT>, IAliasableEntityRenderer<IT>
        where IT : ITable
    {
        internal TableRenderer(IT table)
            : base(table)
        { }

        public string RenderInlineWithAlias(string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderPlain(), RenderKeyword(Strings.Keywords.AS), alias);
        }

        public string RenderIndentedWithAlias(int indentation, string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderPretty(indentation), RenderKeyword(Strings.Keywords.AS), alias);
        }
    }
}
