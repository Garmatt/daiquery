namespace DaiQuery
{
    /// <summary>
    /// An <see cref="IRenderableEntity"/> that can be assigned an alias.
    /// </summary>
    internal interface IAliasableEntity : IRenderableEntity
    {
        string RenderPlainWithAlias(string alias);
        string RenderPrettyWithAlias(int indentation, string alias);
    }
}
