using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyclops.Web
{
    public abstract class ViewModel<T> where T : class, new()
    {
        public abstract bool IsValid();

        public abstract T ToModel();
    }
}
