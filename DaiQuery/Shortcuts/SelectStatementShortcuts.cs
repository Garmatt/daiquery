using System.ComponentModel;

namespace DaiQuery.Shortcuts
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class QueryShortcuts
    {
        public static Query Select(this Query Query, params Expression[] expressionsToSelect)
        {
            return Query.Select(expressionsToSelect);
        }
    }
}
