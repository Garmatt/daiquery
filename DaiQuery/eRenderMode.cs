using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    /// <summary>
    /// A setting that dictates how the SQL code will be rendered. 
    /// </summary>
    internal enum eRenderMode
    {
        /// <summary>
        /// The code will be rendered in a single line.
        /// </summary>
        INLINE,
        /// <summary>
        /// The code will be rendered with carriage returns and tabs for the sake of readability.
        /// </summary>
        INDENTED
    }
}
