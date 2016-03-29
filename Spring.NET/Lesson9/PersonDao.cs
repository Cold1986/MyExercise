using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    public class PersonDao
    {
        private int intProp;

        public PersonDao(int intProp)
        {
            this.intProp = intProp;
        }

        public Person Entity { get; set; }

        public override string ToString()
        {
            return "构造函数参数intProp为：" + this.intProp;
        }
    }
}
