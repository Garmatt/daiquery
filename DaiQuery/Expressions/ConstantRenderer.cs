namespace DaiQuery
{
    internal abstract class ConstantRenderer<T, IC> : ExpressionRenderer<IC>
        where IC : IConstant<T>
    {
        internal ConstantRenderer(IC constant)
            : base(constant)
        { }

        protected abstract string RenderConstantValue(T value);

        protected internal override string RenderFlatRegardlessOfInversed()
        {
            return RenderConstantValue(Renderable.Value);
        }
    }
}
