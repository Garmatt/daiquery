namespace DaiQuery
{
    /// <summary>
    /// An <see cref="IRenderableEntity"/> that is characterized by a SQL identifier, i.e. a string that is natively associated to it as a database object.
    /// </summary>
    internal interface IIdentifiedEntity : IRenderableEntity
    {
        string Identifier { get; set; }
        IIdentifiedEntity Parent { get; }
    }
}
