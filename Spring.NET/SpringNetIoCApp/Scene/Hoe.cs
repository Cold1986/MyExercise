using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetIoCApp
{
    public class Hoe:ITool
    {
        public void UseTool()
        {
            Console.WriteLine("使用锄头");
        }
    }
}
