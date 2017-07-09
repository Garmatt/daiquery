namespace DaiQuery
{
    public class ComparisonPredicate : Predicate, IComparisonPredicate
    {
        private readonly eComparisonOperator comparisonOperator;
        public Expression LeftMember; 
        public Expression RightMember; 

        public ComparisonPredicate(eComparisonOperator comparisonOperator)
            : base()
        {
            this.comparisonOperator = comparisonOperator;
        }

        public ComparisonPredicate(eComparisonOperator comparisonOperator, Expression leftMember, Expression rightMember)
            : this(comparisonOperator)
        {
            LeftMember = leftMember;
            RightMember = rightMember;
        }

        public eComparisonOperator Operator
        {
            get { return comparisonOperator; }
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetComparisonPredicateRenderer<ComparisonPredicate>(this);
        }

        IExpression IComparisonPredicate.LeftMember
        {
            get { return LeftMember; }
        }

        IExpression IComparisonPredicate.RightMember
        {
            get { return RightMember; }
        }

        protected override bool IsEmpty()
        {
            return LeftMember == null || RightMember == null;
        }

        internal override Predicate GetClone()
        {
            return new ComparisonPredicate(Operator, LeftMember.GetClone(), RightMember.GetClone());
        }
    }
}
