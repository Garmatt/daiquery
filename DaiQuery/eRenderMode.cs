namespace DaiQuery
{
    /// <summary>
    /// Specifies the format for rendered SQL code. 
    /// </summary>
    internal enum eRenderMode
    {
        /// <summary>
        /// The code will be rendered in a single line.
        /// </summary>
        INLINE,
        /// <summary>
        /// The code will be rendered with carriage returns and tabs.
        /// </summary>
        INDENTED
    }
}
