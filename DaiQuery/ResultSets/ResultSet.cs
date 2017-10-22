namespace DaiQuery
{
    public abstract class ResultSet : LanguageElement, IResultSet
    {
        public ResultSet()
            : base()
        { }

        public JoinSet InnerJoin(ResultSet otherSet, Predicate condition)
        {
            return new JoinSet(this, JoinType.InnerJoin, otherSet, condition);
        }

        internal override abstract IRenderer GetRenderer();

        protected abstract bool IsEmpty();

        bool IClauseBody.IsEmpty
        {
            get { return IsEmpty(); }
        }
    }
}
