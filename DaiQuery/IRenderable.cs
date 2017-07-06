using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    /// <summary>
    /// Any entity that can be rendered as SQL code.
    /// </summary>
    internal interface IRenderableEntity
    {
        string Render(bool useIndentation);
        string Render();
        string RenderInline();
        string RenderIndented(int indentation);
    }
}
