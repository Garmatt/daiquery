namespace DaiQuery
{
    /// <summary>
    /// Generates SQL code.
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
    /// Renders an <see cref="IRenderableEntity"/> object into SQL code. 
    /// </summary>
    /// <typeparam name="IR"></typeparam>
    internal interface IRenderer<IR> : IRenderer
        where IR : IRenderableEntity
    {
        /// <summary>
        /// The <see cref="IRenderableEntity"/> object associated with this <see cref="IRenderer"/>.
        /// </summary>
        IR Renderable { get; }
    }
}
