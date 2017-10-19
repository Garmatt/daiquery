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
        private string RenderClauseKeyword(ClauseKeyword clauseKeyword)
        {
            string keywordAsString = null;
            switch (clauseKeyword)
            {
                case ClauseKeyword.From:
                    keywordAsString = Strings.Keywords.FROM;
                    break;
                case ClauseKeyword.Where:
                    keywordAsString = Strings.Keywords.WHERE;
                    break;
                case ClauseKeyword.Select:
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

        protected abstract string RenderBodyPlain();
        protected abstract string RenderBodyPretty(int indentation);

        public override string RenderPlain()
        {
            return JoinStrings(Strings.Symbols.WhiteSpace, RenderClauseKeyword(Renderable.Keyword), RenderBodyPlain());
        }

        public override string RenderPretty(int indentation)
        {
            return JoinStrings(Strings.Symbols.CarriageReturn, GetTabs(indentation) + RenderClauseKeyword(Renderable.Keyword), RenderBodyPretty(indentation + 1));
        }
    }
}
