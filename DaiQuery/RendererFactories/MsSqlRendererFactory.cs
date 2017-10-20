namespace DaiQuery
{
    /// <summary>
    /// Concrete class deriving from <see cref="RendererFactory"/>. Creates <see cref="IRenderableEntity"/> objects that generate MSSQL code.
    /// </summary>
    internal class MsSqlRendererFactory : RendererFactory
    {
        public MsSqlRendererFactory() 
            : base()
        { }
    }
}
