using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IArrayKey<T>
    {
        int CompareTo(T[] arr1, T[] arr2);
    }
}
