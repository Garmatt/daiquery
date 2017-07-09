namespace DaiQuery
{
    /// <summary>
    /// Represents a SQL server.
    /// </summary>
    public sealed class Server : LanguageElement, IIdentifiedEntity
    {
        public string Identifier { get; set; }

        public Server(string identifier)
        {
            Identifier = identifier;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetIdentifiedRenderer<Server>(this);
        }

        IIdentifiedEntity IIdentifiedEntity.Parent
        {
            get { return null; }
        }
    }
}
