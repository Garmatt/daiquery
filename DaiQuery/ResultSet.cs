namespace DaiQuery
{
    public class ResultSet : Set, IResultSet
    {
        private eJoinType joinType;
        private IRenderableEntity leftMember, rightMember;
        private Predicate condition;

        public ISet LeftMember
        {
            get { return (ISet)leftMember; }
            set { leftMember = (IRenderableEntity)value; }
        }
        public ISet RightMember
        {
            get { return (ISet)rightMember; }
            set { rightMember = (IRenderableEntity)value; }
        }
        public Predicate Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        bool IClauseBody.IsEmpty
        {
            get { return LeftMember == null || RightMember == null; }
        }

        internal ResultSet(eJoinType joinType)
            : base()
        {
            this.joinType = joinType;
        }

        internal ResultSet(eJoinType joinType, ISet leftMember, ISet rightMember, Predicate condition)
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

        IRenderableEntity IResultSet.LeftMember
        {
            get { return leftMember; }
        }

        IRenderableEntity IResultSet.RightMember
        {
            get { return rightMember; }
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetResultSetRenderer<ResultSet>(this);
        }
    }
}
