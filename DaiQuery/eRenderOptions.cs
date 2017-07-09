using System;

namespace DaiQuery
{
    /// <summary>
    /// Specifies various rendering options, which can be combined using the bitwise OR operator.
    /// </summary>
    [Flags]
    internal enum eRenderOptions
    {
        NONE = 0,
        ENCLOSE_IN_ROUND_BRACKETS = 1,
        USE_INDENTATION = 2
    }
}
