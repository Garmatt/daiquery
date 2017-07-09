namespace DaiQuery
{
    /// <summary>
    /// Represents a column of a database table or view.
    /// </summary>
    public class Column : Expression, IColumn
    {
        public string Identifier { get; set; }
        internal ITable Table;

        internal new IAliasableEntityRenderer Renderer
        {
            get { return (IAliasableEntityRenderer)base.Renderer; }
        }

        public Column(string identifier)
            : base()
        {
            Identifier = identifier;
        }

        public Column(string identifier, Table table)
            : this(identifier)
        {
            Table = table;
        }

        IIdentifiedEntity IIdentifiedEntity.Parent
        {
            get { return Table; }
        }

        protected override string GetHeader()
        {
            return Identifier;
        }

        internal override Expression GetClone()
        {
            Column clone = new Column(Identifier);
            clone.Table = Table;
            return clone;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetColumnRenderer<Column>(this);
        }
    }
}
