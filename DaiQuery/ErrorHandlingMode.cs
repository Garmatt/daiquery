namespace DaiQuery
{
    /// <summary>
    /// A setting that dictates how the application should respond to the request of rendering a chunk of bad formatted SQL code, i.e. code that the database engine will refuse to process.
    /// </summary>
    internal enum ErrorHandlingMode
    {
        /// <summary>
        /// The SQL code will be generated with comments that explain where and why its execution would fail.
        /// </summary>
        PrintWarning,
        /// <summary>
        /// The application will throw an exception.
        /// </summary>
        ThrowException
    }
}
