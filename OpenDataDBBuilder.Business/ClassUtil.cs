using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataDBBuilder.Business
{
    public class ClassUtil
    {
        public T initializeIfNull<T>(T obj)
        {
            if (obj == null)
                return (T)Activator.CreateInstance(typeof(T));
            else
                return obj;
        }
    }
}
