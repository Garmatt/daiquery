using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    /// <summary>
    /// Generates SQL code in accordance with a variety of parameters.
    /// </summary>
    internal interface IRenderer
    {
        string Render(eRenderOptions renderOptions);
        string Render(bool useIndentation);
        string Render();
        string RenderInline();
        string RenderIndented(int indentation);
    }

    /// <summary>
    /// Renders a logical representation of a SQL statement, namely an <see cref="IRenderableEntity"/>, into SQL code. 
    /// </summary>
    /// <typeparam name="IR"></typeparam>
    internal interface IRenderer<IR> : IRenderer
        where IR : IRenderableEntity
    {
        IR Renderable { get; }
    }
}
