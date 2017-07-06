using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal abstract class PredicateRenderer<IP> : Renderer<IP>
        where IP : IPredicateInternal
    {
        internal PredicateRenderer(IP predicate)
            : base(predicate)
        { }

        public override abstract string RenderInline();

        public override abstract string RenderIndented(int indentation);
    }
}
