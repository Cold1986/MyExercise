using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDi2
{
    public class Person
    {
        public IList<Person> BestFriends { get; set; }

        public IList HappyYears { get; set; }

        public IList<int> Years { get; set; }

        public IDictionary HappyDic { get; set; }

        public IDictionary<string, object> HappyTimes { get; set; }
    }
}
