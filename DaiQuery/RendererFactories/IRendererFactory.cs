namespace DaiQuery
{
    /// <summary>
    /// Exposes a collection of factory methods that each return a dedicated <see cref="IRenderer"/> object for an <see cref="IRenderableEntity"/> object.
    /// </summary>
    internal interface IRendererFactory
    {
        IRenderer GetArithmeticExpressionRenderer<IAE>(IAE arithmeticExpression)
            where IAE : IArithmeticExpression;

        IRenderer GetCompoundPredicateRenderer<ICP>(ICP compoundPredicate)
            where ICP : ICompoundPredicate;

        IRenderer GetWhereClauseRenderer<IWC>(IWC whereClause)
            where IWC : IWhereClause;

        IRenderer GetConstantStringRenderer<ICS>(ICS constantString)
            where ICS : IConstantString;

        IRenderer GetConstantUnicodeStringRenderer<ICS>(ICS constantString)
            where ICS : IConstantString;

        IRenderer GetIdentifiedRenderer<II>(II identified)
            where II : IIdentifiedEntity;

        IRenderer GetStatementRenderer<IS>(IS statement)
            where IS : IStatement;

        IRenderer GetSelectClauseRenderer<ISC>(ISC selectClause)
            where ISC : ISelectClause;

        IRenderer GetFromClauseRenderer<IFC>(IFC fromClause)
            where IFC : IFromClause;

        IRenderer GetTableRenderer<IT>(IT table)
            where IT : ITable;

        IRenderer GetColumnRenderer<IC>(IC column)
            where IC : IColumn;

        IRenderer GetComparisonPredicateRenderer<ICP>(ICP comparisonPredicate)
            where ICP : IComparisonPredicate;

        IRenderer GetJoinSetRenderer<IJS>(IJS joinSet)
            where IJS : IJoinSet;
    }
}
