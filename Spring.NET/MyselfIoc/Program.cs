using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyselfIoc
{
    class Program
    {
        static void Main(string[] args)
        {
            AppRegistry();
            Console.ReadLine();
        }

        static void AppRegistry()
        {
            MyXmlFactory ctx = new MyXmlFactory(@"E:\project\MyExercise\Spring.NET\MyselfIoc\Objects.xml");
            Console.WriteLine(ctx.GetObject("Person").ToString());
        }
    }
}
