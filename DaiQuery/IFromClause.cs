﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    internal interface IFromClause : IClause
    {
        IClauseBody source { get; }
        ISet Source { get; set; }
    }
}
