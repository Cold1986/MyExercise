using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDi
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person Friend { get; set; }
    }
}
