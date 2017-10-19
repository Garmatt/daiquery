namespace DaiQuery
{
    internal abstract class PredicateRenderer<IP> : Renderer<IP>
        where IP : IPredicate
    {
        internal PredicateRenderer(IP predicate)
            : base(predicate)
        { }

        public override abstract string RenderPlain();

        public override abstract string RenderPretty(int indentation);
    }
}
