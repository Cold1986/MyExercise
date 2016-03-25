using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonLibrary;


namespace Redis
{
    class Program
    {
        
        static void Main(string[] args)
        {
            RedisHelper.CreateClient("127.0.0.1", 6379);
            RedisHelper.SetString("test", "test2", 1000);

            People Cold = new People();
            Cold.Name = "测试";
            Cold.age = 22;

            RedisHelper.Set<People>("testT", Cold, 1000);

            var tt=RedisHelper.Get<People>("testT");

            Console.WriteLine(RedisHelper.GetStringValue("test"));
            Console.ReadKey();
        }

        
    }

    class People
    {
        public string Name;
        public int age;
    }
}
