using System;

namespace DaiQuery
{
    /// <summary>
    /// Specifies various rendering options, which can be combined using the bitwise OR operator.
    /// </summary>
    [Flags]
    internal enum RenderOptions
    {
        None = 0,
        EncloseInRoundBrackets = 1,
        UseIndentation = 2
    }
}
