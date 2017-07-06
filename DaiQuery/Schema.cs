using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public sealed class Schema : RenderableEntity, IIdentified
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

        IIdentified IIdentified.Parent
        {
            get { return Database; }
        }
    }
}
