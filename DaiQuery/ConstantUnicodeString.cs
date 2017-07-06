using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public class ConstantUnicodeString : ConstantString
    {
        public ConstantUnicodeString(string value, bool escapeSpecialCharacters)
            : base(value, escapeSpecialCharacters)
        { }

        internal override IRenderer GetRenderer()
        {
            return RendererFactory.GetConstantUnicodeStringRenderer<ConstantUnicodeString>(this);
        }
    }
}
