using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public sealed class Database : RenderableEntity, IIdentified
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
        
        IIdentified IIdentified.Parent
        {
            get { return Server; }
        }
    }
}
