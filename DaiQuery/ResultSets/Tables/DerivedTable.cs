using System;

namespace DaiQuery
{
    public sealed class DerivedTable : ResultSet, IDerivedTable
    {
        public string Alias { get; set; }

        public Query Query { get; set; }

        protected override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        internal override IRenderer GetRenderer()
        {
            throw new NotImplementedException();
        }
    }
}
