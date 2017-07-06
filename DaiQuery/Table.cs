using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public sealed class Table : Set, ITable
    {
        public string Identifier { get; set; }
        public Schema Schema;

        internal new IAliasableRenderer Renderer
        {
            get { return (IAliasableRenderer)base.Renderer; }
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

        IIdentified IIdentified.Parent
        {
            get { return Schema; }
        }

        string IAliasableEntity.RenderInlineWithAlias(string alias)
        {
            return Renderer.RenderInlineWithAlias(alias);
        }

        string IAliasableEntity.RenderIndentedWithAlias(int indentation, string alias)
        {
            return Renderer.RenderIndentedWithAlias(indentation, alias);
        }

        bool IClauseBody.IsEmpty
        {
            get { return false; }
        }
    }
}
