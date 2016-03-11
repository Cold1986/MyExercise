using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateObjects
{
    public class instanceObjectsFactoryTest
    {
        public PersonDao CreateInstanceMethod()
        {
            return new PersonDao();
        }
    }
}
