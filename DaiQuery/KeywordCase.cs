namespace DaiQuery
{
    /// <summary>
    /// A setting that dictates the letter case for the SQL reserved keywords in the generated code.
    /// </summary>
    internal enum KeywordCase
    {
        /// <summary>
        /// The keywords will be rendered in UPPER CASE.
        /// </summary>
        UpperCase,
        /// <summary>
        /// The keywords will be rendered in lower case.
        /// </summary>
        LowerCase,
        /// <summary>
        /// The keywords will be rendered in Proper Case.
        /// </summary>
        ProperCase
    }
}
