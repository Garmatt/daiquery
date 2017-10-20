namespace DaiQuery
{
    public class JoinSet : Set, IJoinSet
    {
        private JoinType joinType;
        JoinType IJoinSet.JoinType
        {
            get { return joinType; }
        }

        public Set LeftMember
        {
            get;
            set;
        }
        public Set RightMember
        {
            get;
            set;
        }
        public Predicate Condition
        {
            get;
            set;
        }
        
        internal JoinSet(JoinType joinType)
            : base()
        {
            this.joinType = joinType;
        }

        internal JoinSet(JoinType joinType, Set leftMember, Set rightMember, Predicate condition)
            : this(joinType)
        {
            LeftMember = leftMember;
            RightMember = rightMember;
            Condition = condition;
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetJoinSetRenderer<JoinSet>(this);
        }

        protected override bool IsEmpty()
        {
            return (LeftMember == null || ((ISet)LeftMember).IsEmpty) || (RightMember == null || ((ISet)RightMember).IsEmpty);
        }
    }
}
