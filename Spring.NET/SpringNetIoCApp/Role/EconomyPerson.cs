using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetIoCApp
{
    public class EconomyPerson:Person
    {
        /// <summary>
        /// 经济社会使用锄头耕作
        /// </summary>
        public override void Work()
        {
            //不用知道什么工具，只需知道工厂能买到工具，而不自己制造工具，但仅由工厂制造锄头
            ITool tool = ToolFactory.CreateTool();
            tool.UseTool();
            Console.WriteLine("经济社会使用工具耕作");
        }
    }
}
