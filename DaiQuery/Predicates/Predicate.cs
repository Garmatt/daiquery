namespace DaiQuery
{
    public abstract class Predicate : LanguageElement, IPredicate
    {
        private bool isNegated;

        public Predicate()
            : base()
        {
            isNegated = false;
        }

        protected abstract bool IsEmpty();

        internal abstract Predicate GetClone();

        public static CompoundPredicate operator &(Predicate a, Predicate b)
        {
            CompoundPredicate result = new CompoundPredicate(eLogicalConnective.AND);
            result.AppendPredicates(a, b);
            return result;
        }

        public static CompoundPredicate operator |(Predicate a, Predicate b)
        {
            CompoundPredicate result = new CompoundPredicate(eLogicalConnective.OR);
            result.AppendPredicates(a, b);
            return result;
        }

        public static Predicate operator !(Predicate p)
        {
            Predicate result = p.GetClone();
            result.isNegated = !p.isNegated;
            return result;
        }

        bool IPredicate.IsNegated
        {
            get
            {
                return isNegated;
            }
            set
            {
                isNegated = false;
            }
        }

        bool IClauseBody.IsEmpty
        {
            get { return IsEmpty(); }
        }

        IPredicate IPredicate.Clone()
        {
            return GetClone();
        }

        internal override abstract IRenderer GetRenderer();
    }
}
