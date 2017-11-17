namespace DaiQuery
{
    public class JoinSet : ResultSet, IJoinSet
    {
        public JoinType JoinType { get; set; }

        public ResultSet LeftMember { get; set; }

        public ResultSet RightMember { get; set; }

        public Predicate Condition { get; set; }
        
        internal JoinSet(ResultSet leftMember, JoinType joinType, ResultSet rightMember)
            : base()
        {
            JoinType = joinType;
            LeftMember = leftMember;
            RightMember = rightMember;
        }

        internal JoinSet(ResultSet leftMember, JoinType joinType, ResultSet rightMember, Predicate condition)
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
            return (LeftMember == null || ((IResultSet)LeftMember).IsEmpty) || (RightMember == null || ((IResultSet)RightMember).IsEmpty);
        }
    }
}
