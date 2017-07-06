using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal interface IAliasableEntity : IRenderableEntity
    {
        string RenderInlineWithAlias(string alias);
        string RenderIndentedWithAlias(int indentation, string alias);
    }
}
