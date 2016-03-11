using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringNetIoCApp
{
    public class Computer : ITool
    {
        public void UseTool()
        {
            Console.WriteLine("使用电脑");
        }
    }
}
