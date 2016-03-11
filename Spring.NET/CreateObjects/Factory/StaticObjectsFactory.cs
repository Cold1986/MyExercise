using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateObjects
{
    public class StaticObjectsFactory
    {
        public static PersonDao CreateInstanceTest()
        {
            return new PersonDao();
        }

        public static PersonDao.person CreateInstance()
        {
            return new PersonDao.person();
        }
    }
}
