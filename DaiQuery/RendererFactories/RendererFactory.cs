namespace DaiQuery
{
    /// <summary>
    /// Implementation of the abstract factory pattern for <see cref="IRenderer"/> objects.
    /// </summary>
    internal abstract class RendererFactory : IRendererFactory
    {
        public RendererFactory() { }

        public virtual IRenderer GetArithmeticExpressionRenderer<IAE>(IAE arithmeticExpression)
            where IAE : IArithmeticExpression
        {
            return new ArithmeticExpressionRenderer<IAE>(arithmeticExpression);
        }

        public virtual IRenderer GetCompoundPredicateRenderer<ICP>(ICP compoundPredicate)
            where ICP : ICompoundPredicate
        {
            return new CompoundPredicateRenderer<ICP>(compoundPredicate);
        }

        public virtual IRenderer GetWhereClauseRenderer<IWC>(IWC whereClause)
            where IWC : IWhereClause
        {
            return new WhereClauseRenderer<IWC>(whereClause);
        }

        public virtual IRenderer GetConstantStringRenderer<ICS>(ICS constantString)
            where ICS : IConstantString
        {
            return new ConstantStringRenderer<ICS>(constantString);
        }

        public virtual IRenderer GetConstantUnicodeStringRenderer<ICS>(ICS constantString)
            where ICS : IConstantString
        {
            return new ConstantUnicodeStringRenderer<ICS>(constantString);
        }

        public virtual IRenderer GetIdentifiedRenderer<II>(II identified)
            where II : IIdentifiedEntity
        {
            return new IdentifiedEntityRenderer<II>(identified);
        }

        public virtual IRenderer GetSelectStatement<ISS>(ISS selectStatement) 
            where ISS : ISelectStatement
        {
            return new SelectStatementRenderer<ISS>(selectStatement);
        }

        public virtual IRenderer GetSelectClauseRenderer<ISC>(ISC selectClause) 
            where ISC : ISelectClause
        {
            return new SelectClauseRenderer<ISC>(selectClause);
        }

        public virtual IRenderer GetFromClauseRenderer<IFC>(IFC fromClause) 
            where IFC : IFromClause
        {
            return new FromClauseRenderer<IFC>(fromClause);
        }

        public virtual IRenderer GetTableRenderer<IT>(IT table) 
            where IT : ITable
        {
            return new TableRenderer<IT>(table);
        }

        public virtual IRenderer GetColumnRenderer<IC>(IC column) 
            where IC : IColumn
        {
            return new ColumnRenderer<IC>(column);
        }

        public virtual IRenderer GetComparisonPredicateRenderer<ICP>(ICP comparisonPredicate)
            where ICP : IComparisonPredicate
        {
            return new ComparisonPredicateRenderer<ICP>(comparisonPredicate);
        }

        public virtual IRenderer GetJoinSetRenderer<IJS>(IJS joinSet)
            where IJS : IJoinSet
        {
            return new JoinSetRenderer<IJS>(joinSet);
        }
    }
}
