using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation oper = null;
            oper = OperationFactory.createOperate("+");
            oper.NumberA = 1;
            oper.NumberB = 2;
            double result = oper.GetResult();

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
