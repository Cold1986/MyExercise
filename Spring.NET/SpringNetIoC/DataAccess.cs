using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetIoC
{
    public class DataAccess
    {
        public static IPerson CreatePersonDao()
        {
            return new Person();
        }
    }
}
