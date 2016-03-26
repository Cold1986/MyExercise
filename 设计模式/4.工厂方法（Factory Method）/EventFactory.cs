using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂方法
{
    public class EventFactory:LogFactory
    {
        public override Log Create()
        {
            return new EventLog();
        }
    }
}
