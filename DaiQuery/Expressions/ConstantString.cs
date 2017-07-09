using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public class ConstantString : Constant<string>, IConstantString
    {
        private bool escapeSpecialCharacters;

        public ConstantString(string value, bool escapeSpecialCharacters)
            : base(value)
        {
            this.escapeSpecialCharacters = escapeSpecialCharacters;
        }

        internal override Expression GetClone()
        {
            return new ConstantString(Value, ((IConstantString)this).EscapeSpecialCharacters);
        }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetConstantStringRenderer<ConstantString>(this);
        }

        bool IConstantString.EscapeSpecialCharacters
        {
            get { return escapeSpecialCharacters; }
        }
    }
}
