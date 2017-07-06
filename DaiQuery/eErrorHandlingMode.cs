using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    /// <summary>
    /// A setting that dictates how the application should respond to the request of rendering a chunk of bad formatted SQL code, i.e. code that the database engine will refuse to process.
    /// </summary>
    internal enum eErrorHandlingMode
    {
        /// <summary>
        /// The SQL code will be generated with comments that explain where and why its execution would fail.
        /// </summary>
        PRINT_COMMENT,
        /// <summary>
        /// The application will throw an exception.
        /// </summary>
        THROW_EXCEPTION
    }
}
