namespace DaiQuery
{
    /// <summary>
    /// An <see cref="IRenderableEntity"/> that can be assigned an alias.
    /// </summary>
    internal interface IAliasableEntity : IRenderableEntity
    {
        string RenderInlineWithAlias(string alias);
        string RenderIndentedWithAlias(int indentation, string alias);
    }
}
