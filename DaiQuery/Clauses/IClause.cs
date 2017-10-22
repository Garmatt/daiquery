namespace DaiQuery
{
    /// <summary>
    /// A constituent component of statements and queries, made of a keyword followed by a body.
    /// </summary>
    internal interface IClause : IRenderableEntity
    {
        ClauseKeyword Keyword { get; }

        /// <summary>
        /// True if the body of the clause is empty, false otherwise.
        /// </summary>
        bool IsEmpty { get; }

        void Clear();
    }
}
