namespace DaiQuery
{
    /// <summary>
    /// A constituent component of statements and queries, made of a keyword followed by a body.
    /// </summary>
    public abstract class Clause : LanguageElement, IClause
    {
        private readonly eClauseKeyword keyword;
        eClauseKeyword IClause.Keyword
        {
            get { return keyword; }
        }

        bool IClause.IsEmpty
        {
            get { return IsEmpty(); }
        }

        public Clause()
            : base()
        {
            keyword = InitKeyword();
        }

        /// <summary>
        /// Defines the specific keyword that characterizes a concrete instance of a <see cref="Clause"/>.
        /// </summary>
        /// <returns></returns>
        internal abstract eClauseKeyword InitKeyword();

        internal abstract bool IsEmpty();

        internal override abstract IRenderer GetRenderer();
    }
}
