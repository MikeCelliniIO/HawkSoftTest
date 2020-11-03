using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HawkSoftTest
{
    public class EnumerableResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
