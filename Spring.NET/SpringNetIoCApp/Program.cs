using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;

namespace SpringNetIoCApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimitivePerson PPerson = new PrimitivePerson();
            PPerson.Work();

            EconomyPerson EPerson = new EconomyPerson();
            EPerson.Work();

            IApplicationContext ctx = ContextRegistry.GetContext();
            Person person = (Person)ctx.GetObject("modernPerson");
            person.Work();

            Console.ReadLine();
        }
    }
}
