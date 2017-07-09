using System;

namespace DaiQuery
{
    /// <summary>
    /// Represents one of the elements that make up the SQL language.
    /// </summary>
    public abstract class LanguageElement : IRenderableEntity, ITaggableEntity
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

        public LanguageElement() 
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

        public TagCollection Tags
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
