using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaiQuery
{
    public interface ISet : ITaggable
    {
        ResultSet InnerJoin(ISet set, IPredicate condition);
    }
}
