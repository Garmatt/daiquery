namespace DaiQuery
{
    public abstract class Set : LanguageElement, ISet
    {
        public Set()
            : base()
        { }

        public JoinSet InnerJoin(Set set, Predicate condition)
        {
            return new JoinSet(this, JoinType.InnerJoin, set, condition);
        }

        internal override abstract IRenderer GetRenderer();

        protected abstract bool IsEmpty();

        bool IClauseBody.IsEmpty
        {
            get { return IsEmpty(); }
        }
    }
}
