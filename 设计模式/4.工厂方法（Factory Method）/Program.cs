using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂方法
{
    class Program
    {
        static void Main(string[] args)
        {
            LogFactory factory = new EventFactory();

            Log log = factory.Create();

            log.Write();

            Console.ReadLine();
        }
    }
}
