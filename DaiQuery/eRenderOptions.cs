using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    [Flags]
    internal enum eRenderOptions
    {
        NONE = 0,
        ENCLOSE_IN_ROUND_BRACKETS = 1,
        USE_INDENTATION = 2
    }
}
