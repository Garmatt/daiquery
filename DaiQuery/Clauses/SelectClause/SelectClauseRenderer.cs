﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DaiQuery
{
    internal class SelectClauseRenderer<ISC> : ClauseRenderer<ISC>
        where ISC : ISelectClause
    {
        private int indentation;

        internal SelectClauseRenderer(ISC selectClause)
            : base(selectClause)
        {
            indentation = 0;
        }

        private IEnumerable<string> RenderExpressions(bool useIndentation)
        {
            HashSet<string> headers = new HashSet<string>();
            foreach (KeyValuePair<IExpression, string> kvp in Renderable.AliasedExpressions)
            {
                bool expressionHasAlias = !string.IsNullOrWhiteSpace(kvp.Value);
                string header = expressionHasAlias ? kvp.Value : kvp.Key.Header;
                if (!string.IsNullOrWhiteSpace(header) && !headers.Add(header))
                    throw new Exception(); //TODO: there is already a field with the same header

                yield return expressionHasAlias ? (
                    useIndentation ? kvp.Key.RenderPrettyWithAlias(indentation + 1, kvp.Value) : kvp.Key.RenderPlainWithAlias(kvp.Value)
                    ) : (
                    useIndentation ? kvp.Key.RenderPretty(indentation + 1) : kvp.Key.RenderPlain());
            }
        }

        protected override string RenderBodyPlain()
        {
            return JoinStrings(Strings.Symbols.Comma + Strings.Symbols.WhiteSpace, RenderExpressions(false));
        }

        protected override string RenderBodyPretty(int indentation)
        {
            this.indentation = indentation;
            string tabs = GetTabs(indentation);
            return JoinStrings(Strings.Symbols.Comma + Strings.Symbols.CarriageReturn, RenderExpressions(true).Select(renderedField => tabs + renderedField));
        }
    }
}
