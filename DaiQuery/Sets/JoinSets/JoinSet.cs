namespace DaiQuery
{
    public class JoinSet : Set, IJoinSet
    {
        public JoinType JoinType
        {
            get;
            set;
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
        
        internal JoinSet(Set leftMember, JoinType joinType, Set rightMember)
            : base()
        {
            JoinType = joinType;
            LeftMember = leftMember;
            RightMember = rightMember;
        }

        internal JoinSet(Set leftMember, JoinType joinType, Set rightMember, Predicate condition)
            : this(leftMember, joinType, rightMember)
        {
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
