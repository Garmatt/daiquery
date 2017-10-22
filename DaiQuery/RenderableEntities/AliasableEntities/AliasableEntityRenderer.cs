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

        public virtual string RenderPlainWithAlias(string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderPlain(), RenderKeyword(Strings.Keywords.As), alias); 
        }

        public virtual string RenderPrettyWithAlias(int indentation, string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderPretty(indentation), RenderKeyword(Strings.Keywords.As), alias); 
        }

        public override abstract string RenderPlain();

        public override abstract string RenderPretty(int indentation);
    }
}