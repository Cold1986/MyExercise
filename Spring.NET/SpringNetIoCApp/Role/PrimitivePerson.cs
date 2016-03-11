using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetIoCApp
{
    public class PrimitivePerson : Person
    {
        /// <summary>
        /// 原始社会使用长矛打猎
        /// </summary>
        public override void Work()
        {
            //知道打猎使用的是长矛，并且制造长矛
            ITool tool = new Spear();
            tool.UseTool();
            Console.WriteLine("使用长矛打猎");
        }
    }
}
