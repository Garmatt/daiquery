using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DaiQuery
{
    /// <summary>
    /// Renders an <see cref="IRenderableEntity"/> object into SQL code.
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
            switch (Settings.Manager.KeywordCase)
            {
                case KeywordCase.UpperCase:
                    return keyword.ToUpper();
                case KeywordCase.LowerCase:
                    return keyword.ToLower();
                case KeywordCase.ProperCase:
                    return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(keyword.ToLower());
                default:
                    throw new NotImplementedException("This letter case has not been implemented yet.");
            }
        }

        /// <summary>
        /// Returns the concatenation of n times the tab symbol, where n = <paramref name="indentation"/>.
        /// </summary>
        /// <param name="indentation"></param>
        /// <returns></returns>
        protected string GetTabs(int indentation)
        {
            return JoinStrings(string.Empty, Enumerable.Repeat<string>(Strings.Symbols.Tab, indentation));
        }

        private bool MustRenderIndentedByDefault
        {
            get { return Settings.Manager.DefaultRenderMode == RenderMode.Pretty; }
        }

        private bool MustIndent(RenderOptions renderOptions)
        {
            return (RenderOptions.UseIndentation & renderOptions) != 0;
        }

        private bool MustEncloseInRoundBrackets(RenderOptions renderOptions)
        {
            return (RenderOptions.EncloseInRoundBrackets & renderOptions) != 0;
        }

        public abstract string RenderPlain();
        public abstract string RenderPretty(int indentation);

        private string RenderWithoutBrackets(bool useIndentation)
        {
            int indentationSeed = 0;
            return useIndentation ? RenderPretty(indentationSeed) : RenderPlain();
        }

        public string Render(RenderOptions renderOptions)
        {
            string rendered = RenderWithoutBrackets(MustIndent(renderOptions));
            if (MustEncloseInRoundBrackets(renderOptions))
                rendered = JoinStrings(string.Empty, Strings.Symbols.OpenRoundBracket, rendered, Strings.Symbols.ClosedRoundBracket);

            return rendered;
        }

        /// <summary>
        /// Generates and returns the most appropriate set of rendering options for the <see cref="Renderable"/> object, taking into account the value of <paramref name="useIndentation"/> and possibly the state of the <see cref="Renderer"/> itself.
        /// </summary>
        /// <param name="useIndentation"></param>
        /// <returns></returns>
        protected internal virtual RenderOptions GetRenderOptions(bool useIndentation)
        {
            return useIndentation ? RenderOptions.UseIndentation : RenderOptions.None;
        }

        public string Render(bool useIndentation)
        {
            return Render(GetRenderOptions(useIndentation));
        }

        public string Render()
        {
            return Render(MustRenderIndentedByDefault);
        }

        /// <summary>
        /// The <see cref="IRenderableEntity"/> object associated with this <see cref="Renderer"/>.
        /// </summary>
        public IR Renderable
        {
            get { return renderable; }
        }
    }
}
