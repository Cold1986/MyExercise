using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    public class OperationDiv : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if (NumberB == 0)
                throw new Exception("除数不能为0。");
            result = NumberA / NumberB;
            return result;
        }

        public string privateDivMethod()
        {
            return "这个是OperationDiv特有方法";
        }
    }
}
