namespace DaiQuery
{
    public class ResultSet : Set, IResultSet
    {
        private eJoinType joinType;
        private Set leftMember, rightMember;
        private Predicate condition;

        public Set LeftMember
        {
            get { return leftMember; }
            set { leftMember = value; }
        }
        public Set RightMember
        {
            get { return rightMember; }
            set { rightMember = value; }
        }
        public Predicate Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        //bool IClauseBody.IsEmpty
        //{
        //    get { return LeftMember == null || RightMember == null; }
        //}

        internal ResultSet(eJoinType joinType)
            : base()
        {
            this.joinType = joinType;
        }

        internal ResultSet(eJoinType joinType, Set leftMember, Set rightMember, Predicate condition)
            : this(joinType)
        {
            LeftMember = leftMember;
            RightMember = rightMember;
            Condition = condition;
        }

        eJoinType IResultSet.JoinType
        {
            get { return joinType; }
        }

        //IRenderableEntity IResultSet.LeftMember
        //{
        //    get { return leftMember; }
        //}

        //IRenderableEntity IResultSet.RightMember
        //{
        //    get { return rightMember; }
        //}

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetResultSetRenderer<ResultSet>(this);
        }

        protected override bool IsEmpty()
        {
            return (LeftMember == null || ((ISet)LeftMember).IsEmpty) || (RightMember == null || ((ISet)RightMember).IsEmpty);
        }
    }
}
