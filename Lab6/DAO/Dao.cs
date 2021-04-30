using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    interface Dao<T>
    {
        void Insert(T param);
        void Delete(String oldParameter);
        void Update(T param, String oldParameter);
       
    }
}
