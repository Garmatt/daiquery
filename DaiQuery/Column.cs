using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public class Column : Expression, IColumn
    {
        public string Identifier { get; set; }
        internal ITable Table;

        internal new IAliasableRenderer Renderer
        {
            get { return (IAliasableRenderer)base.Renderer; }
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

        IIdentified IIdentified.Parent
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
