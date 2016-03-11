using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;

namespace SpringNetDi
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();

            PersonDao dao = ctx.GetObject("personDao") as PersonDao;
            dao.Get();

            Console.ReadLine();
        }
    }
}
