namespace DaiQuery
{
    /// <summary>
    /// Represents a SQL database.
    /// </summary>
    public sealed class Database : LanguageElement, IIdentifiedEntity
    {
        public string Identifier { get; set; }
        public Server Server;

        public Database(string identifier)
            : base()
        {
            Identifier = identifier;
        }

        public Database(string identifier, Server server)
            : this(identifier)
        {
            Server = server;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetIdentifiedRenderer<Database>(this);
        }
        
        IIdentifiedEntity IIdentifiedEntity.Parent
        {
            get { return Server; }
        }
    }
}
