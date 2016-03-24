using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略模式
{
    class Program
    {
        static void Main(string[] args)
        {
            CashContext csuper = new CashContext("满300返100");
            var res = csuper.GetResult(300);

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
