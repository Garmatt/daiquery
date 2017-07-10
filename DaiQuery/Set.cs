namespace DaiQuery
{
    public abstract class Set : LanguageElement, ISet
    {
        public Set()
            : base()
        { }

        public ResultSet InnerJoin(Set set, Predicate condition)
        {
            return new ResultSet(eJoinType.INNER_JOIN, this, set, condition);
        }

        //public IResultSet InnerJoin(ISet set, string alias, IPredicate condition)
        //{
        //    return new ResultSet(eJoinType.INNER_JOIN, this, null, set, alias, condition);
        //}

        internal override abstract IRenderer GetRenderer();

        ResultSet ISet.InnerJoin(Set set, Predicate condition)
        {
            throw new System.NotImplementedException();
        }

        protected abstract bool IsEmpty();

        bool IClauseBody.IsEmpty
        {
            get { return IsEmpty(); }
        }
    }
}
