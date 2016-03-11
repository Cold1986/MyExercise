using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;

namespace SpringNetIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            NormalMethod();  // 一般方法
            FactoryMethod();  // 工厂方法
            IoCMethod();  // IoC方法"

            Console.ReadLine();
        }

        private static void NormalMethod()
        {
            IPerson dao = new Person();
            dao.Save();
            Console.WriteLine("我是一般方法");
        }

        private static void FactoryMethod()
        {
            IPerson dao = DataAccess.CreatePersonDao();
            dao.Save();
            Console.WriteLine("我是工厂方法");
        }

        private static void IoCMethod()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            IPerson dao = ctx.GetObject("Person") as IPerson;
            if (dao != null)
            {
                dao.Save();
                Console.WriteLine("我是IoC方法");
            }
        }
    }
}
