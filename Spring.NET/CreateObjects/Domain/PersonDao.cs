using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateObjects
{
    public class PersonDao
    {
        public class person
        {
            public override string ToString()
            {
                return "我是嵌套类Person";
            } 
        }

        public override string ToString()
        {
            return "我是PersonDao";
        }
    }
}
