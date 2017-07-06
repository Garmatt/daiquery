using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    /// <summary>
    /// A setting that dictates the letter case for the SQL reserved keywords in the generated code.
    /// </summary>
    internal enum eKeywordCase
    {
        /// <summary>
        /// The keywords will be rendered in UPPER CASE.
        /// </summary>
        UPPERCASE,
        /// <summary>
        /// The keywords will be rendered in lower case.
        /// </summary>
        LOWERCASE,
        /// <summary>
        /// The keywords will be rendered in Proper Case.
        /// </summary>
        PROPERCASE
    }
}
