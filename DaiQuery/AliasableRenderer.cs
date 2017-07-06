using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal abstract class AliasableEntityRenderer<IA> : Renderer<IA>, IAliasableEntityRenderer<IA>
        where IA : IAliasableEntity
    {
        internal AliasableEntityRenderer(IA aliasable)
            : base(aliasable)
        { }

        public virtual string RenderInlineWithAlias(string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderInline(), RenderKeyword(Strings.Keywords.AS), alias); 
        }

        public virtual string RenderIndentedWithAlias(int indentation, string alias)
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderIndented(indentation), RenderKeyword(Strings.Keywords.AS), alias); 
        }

        public override abstract string RenderInline();

        public override abstract string RenderIndented(int indentation);
    }
}