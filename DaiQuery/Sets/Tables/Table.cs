namespace DaiQuery
{
    /// <summary>
    /// Represents a database table or view.
    /// </summary>
    public sealed class Table : ResultSet, ITable
    {
        public string Identifier { get; set; }
        public Schema Schema;

        internal new IAliasableEntityRenderer Renderer
        {
            get { return (IAliasableEntityRenderer)base.Renderer; }
        }

        public Table(string identifier)
            : base()
        {
            Identifier = identifier;
        }

        public Table(string identifier, Schema schema)
            : this(identifier)
        {
            Schema = schema;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetTableRenderer<Table>(this);
        }

        IIdentifiedEntity IIdentifiedEntity.Parent
        {
            get { return Schema; }
        }

        string IAliasableEntity.RenderPlainWithAlias(string alias)
        {
            return Renderer.RenderInlineWithAlias(alias);
        }

        string IAliasableEntity.RenderPrettyWithAlias(int indentation, string alias)
        {
            return Renderer.RenderIndentedWithAlias(indentation, alias);
        }

        bool IClauseBody.IsEmpty
        {
            get { return false; }
        }

        protected override bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(Identifier);
        }
    }
}
