namespace DaiQuery
{
    internal abstract class PredicateRenderer<IP> : Renderer<IP>
        where IP : IPredicate
    {
        internal PredicateRenderer(IP predicate)
            : base(predicate)
        { }

        public override abstract string RenderInline();

        public override abstract string RenderIndented(int indentation);
    }
}
