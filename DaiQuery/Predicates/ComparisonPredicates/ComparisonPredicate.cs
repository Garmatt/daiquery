namespace DaiQuery
{
    public class ComparisonPredicate : Predicate, IComparisonPredicate
    {
        private readonly ComparisonOperator comparisonOperator;
        public Expression LeftMember; 
        public Expression RightMember; 

        public ComparisonPredicate(ComparisonOperator comparisonOperator)
            : base()
        {
            this.comparisonOperator = comparisonOperator;
        }

        public ComparisonPredicate(Expression leftMember, ComparisonOperator comparisonOperator, Expression rightMember)
            : this(comparisonOperator)
        {
            LeftMember = leftMember;
            RightMember = rightMember;
        }

        public ComparisonOperator Operator
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
            return new ComparisonPredicate(LeftMember.GetClone(), Operator, RightMember.GetClone());
        }
    }
}
