using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal class TableRenderer<IT> : IdentifiedRenderer<IT>, IAliasableEntityRenderer<IT>
        where IT : ITable
    {
        internal TableRenderer(IT table)
            : base(table)
        { }

        public string RenderInlineWithAlias(string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderInline(), RenderKeyword(Strings.Keywords.AS), alias);
        }

        public string RenderIndentedWithAlias(int indentation, string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderIndented(indentation), RenderKeyword(Strings.Keywords.AS), alias);
        }
    }
}
