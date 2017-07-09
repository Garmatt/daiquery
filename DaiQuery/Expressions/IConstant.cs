using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal interface IConstant<T> : IExpression
        //where T : struct
    {
        T Value { get; set; }
    }
}
