using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    /// <summary>
    /// Abstract implementation of <see cref="IRenderer{IR}"/>.
    /// </summary>
    /// <typeparam name="IR">The type of the object to be rendered.</typeparam>
    internal abstract class Renderer<IR> : IRenderer<IR>
        where IR : IRenderableEntity
    {

        protected readonly IR renderable;

        protected Renderer(IR renderable) 
        {
            this.renderable = renderable;
        }

        protected string JoinStrings(string separator, params string[] strings)
        {
            if (strings != null)
                return JoinStrings(separator, strings.AsEnumerable<string>());

            return null;
        }

        protected string JoinStrings(string separator, IEnumerable<string> strings)
        {
            if (strings != null && strings.Any())
                return string.Join(separator, strings.Where(s => !string.IsNullOrWhiteSpace(s)));

            return null;
        }

        protected string RenderKeyword(string keyword)
        {
            eKeywordCase keywordCase = Settings.Manager.KeywordCase;
            switch (keywordCase)
            {
                case eKeywordCase.UPPERCASE:
                    return keyword.ToUpper();
                case eKeywordCase.LOWERCASE:
                    return keyword.ToLower();
                case eKeywordCase.PROPERCASE:
                    return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(keyword.ToLower());
                default:
                    throw new NotSupportedException();
            }
        }

        protected string GetTabs(int indentation)
        {
            return JoinStrings(string.Empty, Enumerable.Repeat<string>(Strings.Symbols.Tab, indentation));
        }

        private bool MustRenderIndentedByDefault
        {
            get { return Settings.Manager.DefaultRenderMode == eRenderMode.INDENTED; }
        }

        private bool MustIndent(eRenderOptions renderOptions)
        {
            return (eRenderOptions.USE_INDENTATION & renderOptions) != 0;
        }

        private bool MustEncloseInRoundBrackets(eRenderOptions renderOptions)
        {
            return (eRenderOptions.ENCLOSE_IN_ROUND_BRACKETS & renderOptions) != 0;
        }

        public abstract string RenderInline();
        public abstract string RenderIndented(int indentation);

        private string RenderWithoutBrackets(bool useIndentation)
        {
            int indentationSeed = 0;
            return useIndentation ? RenderIndented(indentationSeed) : RenderInline();
        }

        public string Render(eRenderOptions renderOptions)
        {
            string rendered = RenderWithoutBrackets(MustIndent(renderOptions));
            if (MustEncloseInRoundBrackets(renderOptions))
                rendered = JoinStrings(string.Empty, Strings.Symbols.OpenRoundBracket, rendered, Strings.Symbols.ClosedRoundBracket);

            return rendered;
        }

        protected internal virtual eRenderOptions GetRenderOptions(bool useIndentation)
        {
            return useIndentation ? eRenderOptions.USE_INDENTATION : eRenderOptions.NONE;
        }

        public string Render(bool useIndentation)
        {
            return Render(GetRenderOptions(useIndentation));
        }

        public string Render()
        {
            return Render(MustRenderIndentedByDefault);
        }

        public IR Renderable
        {
            get { return renderable; }
        }
    }
}
