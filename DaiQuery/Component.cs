using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public abstract class RenderableEntity : IRenderableEntity
    {
        private readonly IRenderer renderer;

        internal IRendererFactory RendererFactory
        {
            get { return Settings.Manager.RendererFactory; }
        }

        internal IRenderer Renderer
        {
            get { return renderer; }
        }

        public RenderableEntity() 
        {
            renderer = GetRenderer();
        }

        internal abstract IRenderer GetRenderer();

        public string Render(bool useIndentation)
        {
            return renderer.Render(useIndentation);
        }

        public string Render()
        {
            return renderer.Render();
        }

        public override string ToString()
        {
            return Render();
        }

        public TagCollection TagCollection
        {
            get { throw new NotImplementedException(); }
        }

        string IRenderableEntity.RenderInline()
        {
            return renderer.RenderInline();
        }

        string IRenderableEntity.RenderIndented(int indentation)
        {
            return renderer.RenderIndented(indentation);
        }
    }
}
