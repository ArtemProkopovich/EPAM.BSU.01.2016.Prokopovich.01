using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IArrayKey<in T1, out T2> where T2 : IComparable<T2>
    {
        T2 GetKey(T1[] array);
    }
}
