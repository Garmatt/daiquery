namespace DaiQuery
{
    /// <summary>
    /// Concrete class deriving from <see cref="RendererFactory"/>. Creates <see cref="IRenderableEntity"/> objects that generate standard SQL code.
    /// </summary>
    internal class StandardRendererFactory : RendererFactory
    {
        public StandardRendererFactory()
            : base()
        { }
    }
}
