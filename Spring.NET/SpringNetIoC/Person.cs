using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetIoC
{
    public class Person:IPerson
    {
        public void Save()
        {
            Console.WriteLine("保存 Person");
        }
    }
}
