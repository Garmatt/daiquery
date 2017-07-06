using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal class ConstantUnicodeStringRenderer<ICS> : ConstantStringRenderer<ICS>
        where ICS : IConstantString
    {
        private const string UNICODE_PREFIX = "N";

        internal ConstantUnicodeStringRenderer(ICS constantString)
            : base(constantString)
        { }

        protected override string RenderConstantValue(string value)
        {
            return JoinStrings(string.Empty, UNICODE_PREFIX, base.RenderConstantValue(value));
        }
    }
}
