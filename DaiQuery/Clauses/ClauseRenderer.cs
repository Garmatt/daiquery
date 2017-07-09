using System;

namespace DaiQuery
{
    /// <summary>
    /// Renders an <see cref="IClause"/> object into SQL code.
    /// </summary>
    /// <typeparam name="IC"></typeparam>
    internal abstract class ClauseRenderer<IC> : Renderer<IC>
        where IC : IClause
    {
        private string RenderClauseKeyword(eClauseKeyword clauseKeyword)
        {
            string keywordAsString = null;
            switch (clauseKeyword)
            {
                case eClauseKeyword.FROM:
                    keywordAsString = Strings.Keywords.FROM;
                    break;
                case eClauseKeyword.WHERE:
                    keywordAsString = Strings.Keywords.WHERE;
                    break;
                case eClauseKeyword.SELECT:
                    keywordAsString = Strings.Keywords.SELECT;
                    break;
                default:
                    throw new NotImplementedException();
            }
            return RenderKeyword(keywordAsString);
        }

        internal ClauseRenderer(IC clause)
            : base(clause)
        { }

        protected abstract string RenderBodyInline();
        protected abstract string RenderBodyIndented(int indentation);

        public override string RenderInline()
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderClauseKeyword(Renderable.Keyword), RenderBodyInline());
        }

        public override string RenderIndented(int indentation)
        {
            return JoinStrings(Strings.Symbols.CarriageReturn, GetTabs(indentation) + RenderClauseKeyword(Renderable.Keyword), RenderBodyIndented(indentation + 1));
        }
    }
}
