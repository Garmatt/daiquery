namespace DaiQuery
{
    internal interface IAliasedEntity : IRenderableEntity
    {
        string Alias { get; set; }
    }
}
