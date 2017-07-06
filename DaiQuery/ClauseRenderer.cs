using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal abstract class ClauseRenderer<IC> : Renderer<IC>
        where IC : IClause
    {
        private string RenderClauseKeyword(eClauseKeyword clauseKeyword)
        {
            string verboseKeyword = null;
            switch (clauseKeyword)
            {
                case eClauseKeyword.FROM:
                    verboseKeyword = Strings.Keywords.FROM;
                    break;
                case eClauseKeyword.WHERE:
                    verboseKeyword = Strings.Keywords.WHERE;
                    break;
                case eClauseKeyword.SELECT:
                    verboseKeyword = Strings.Keywords.SELECT;
                    break;
                default:
                    throw new NotImplementedException();
            }
            return RenderKeyword(verboseKeyword);
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
