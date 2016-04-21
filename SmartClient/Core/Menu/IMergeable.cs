using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Menu
{
    public interface IMergeable<T>
    {
        T Merge(T other);
    }
}
