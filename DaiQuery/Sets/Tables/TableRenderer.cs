namespace DaiQuery
{
    internal class TableRenderer<IT> : IdentifiedEntityRenderer<IT>, IAliasableEntityRenderer<IT>
        where IT : ITable
    {
        internal TableRenderer(IT table)
            : base(table)
        { }

        public string RenderPlainWithAlias(string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderPlain(), RenderKeyword(Strings.Keywords.As), alias);
        }

        public string RenderPrettyWithAlias(int indentation, string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderPretty(indentation), RenderKeyword(Strings.Keywords.As), alias);
        }
    }
}
