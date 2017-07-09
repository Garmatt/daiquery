namespace DaiQuery
{
    /// <summary>
    /// Renders into SQL code a logical representation of a SQL statement that can have an alias, namely an <see cref="IAliasableEntity"/>. 
    /// </summary>
    /// <typeparam name="IA">The type of the entity to be rendered.</typeparam>
    internal abstract class AliasableEntityRenderer<IA> : Renderer<IA>, IAliasableEntityRenderer<IA>
        where IA : IAliasableEntity
    {
        internal AliasableEntityRenderer(IA aliasable)
            : base(aliasable)
        { }

        public virtual string RenderInlineWithAlias(string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderInline(), RenderKeyword(Strings.Keywords.AS), alias); 
        }

        public virtual string RenderIndentedWithAlias(int indentation, string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderIndented(indentation), RenderKeyword(Strings.Keywords.AS), alias); 
        }

        public override abstract string RenderInline();

        public override abstract string RenderIndented(int indentation);
    }
}