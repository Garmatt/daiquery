using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal interface IIdentified : IRenderableEntity
    {
        string Identifier { get; set; }
        IIdentified Parent { get; }
    }
}
