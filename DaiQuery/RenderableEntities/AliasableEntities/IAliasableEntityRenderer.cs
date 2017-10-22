namespace DaiQuery
{
    /// <summary>
    /// Extends <see cref="IRenderer"/> providing methods for appending an alias to the rendered entity.
    /// </summary>
    internal interface IAliasableEntityRenderer : IRenderer
    {
        string RenderPlainWithAlias(string alias);
        string RenderPrettyWithAlias(int indentation, string alias);
    }

    /// <summary>
    /// Renders into SQL code a logical representation of a SQL statement that can have an alias, namely an <see cref="IAliasableEntity"/>. 
    /// </summary>
    /// <typeparam name="IA">The type of the entity to be rendered.</typeparam>
    internal interface IAliasableEntityRenderer<IA> : IRenderer<IA>, IAliasableEntityRenderer
        where IA: IAliasableEntity
    { }
}
