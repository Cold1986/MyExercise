using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂方法
{
    public class EventLog : Log
    {
        public override void Write()
        {
            Console.WriteLine("EventLog Write Success!");
        }
    }
}
