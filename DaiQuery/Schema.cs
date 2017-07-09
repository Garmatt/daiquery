using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    /// <summary>
    /// Represents a database schema.
    /// </summary>
    public sealed class Schema : LanguageElement, IIdentifiedEntity
    {
        public string Identifier { get; set; }
        public Database Database;

        public Schema(string identifier)
            : base()
        {
            Identifier = identifier;
        }

        public Schema(string identifier, Database database)
            : this(identifier)
        {
            Database = database;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetIdentifiedRenderer<Schema>(this);
        }

        IIdentifiedEntity IIdentifiedEntity.Parent
        {
            get { return Database; }
        }
    }
}
