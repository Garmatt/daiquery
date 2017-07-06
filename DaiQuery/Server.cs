using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public sealed class Server : RenderableEntity, IIdentified
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

        IIdentified IIdentified.Parent
        {
            get { return null; }
        }
    }
}
