using System.ComponentModel;

namespace DaiQuery.Shortcuts
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class SelectStatementShortcuts
    {
        public static SelectStatement Select(this SelectStatement selectStatement, params Expression[] expressionsToSelect)
        {
            return selectStatement.Select(expressionsToSelect);
        }
    }
}
